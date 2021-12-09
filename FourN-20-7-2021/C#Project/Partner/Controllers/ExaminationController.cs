using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using FourN.Data;
using FourN.Data.Models;
using FourN.Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using Partner.Helper;
using Partner.Models;
using System.Threading.Tasks;
using FourN.Services.IService;
using FourN.Data.EnumModel;
using ResultEnum = FourN.Data.EnumModel.ResultEnum;

namespace Partner.Controllers
{
    public class ExaminationController : Controller
    {
        private readonly IExaminationService _examinationService;
        private readonly IQuestionService _questionService;
        private readonly IUserExaminationService _userExaminationService;
        private readonly IUserService _userService;

        public ExaminationController(IExaminationService examinationService, IQuestionService questionService, IUserExaminationService userExaminationService, /*ICourseService courseService,*/ IUserService userService)
        {
            _examinationService = examinationService;
            _questionService = questionService;
            _userExaminationService = userExaminationService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetCurrentAuthentication() == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            var list = _examinationService.GetAllExaminationsByCompany(1);
            return View(list);
        }

        public IActionResult IndexPartial()
        {

            var list = _examinationService.GetAllExaminations();
            var html = this.RenderView<IEnumerable<ExaminationViewModel>>("_IndexPartial", list, true);
            return Json(new { html = html });
        }
        public IActionResult Create(int? parentId, string examinationOf)
        {
            var model = _examinationService.GetExaminationCrudModel(null);
            if (examinationOf == null || parentId == null)
            {
                var html = this.RenderView<ExaminationCrudModel>("_Create", model, true);
                return Json(new { html = html });
            }

            var html1 = this.RenderView<ExaminationCrudModel>("_Create", model, true);
            return Json(new { html = html1 });
        }

        [HttpPost]
        public IActionResult Create(ExaminationCrudModel model)
        {

            var currentUser = HttpContext.Session.GetCurrentAuthentication();
            model.ContentProviderId = 1;

            var questionList = SessionExtension.GetObjectFromJson<List<QuestionViewModel>>(HttpContext.Session, "cartQuestion");
            var questionIdList = questionList.Select(m => m.QuestionId).ToList();
            var x = _examinationService.CreateExamination(model, questionIdList);
            if (x.Result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult QuestionRandomView(int? totalQuestion, int? examEnumType)
        {
            var ran = new Random();
            var newList = new List<QuestionViewModel>();

            IEnumerable<QuestionViewModel> list = new List<QuestionViewModel>();

            list = _questionService.GetAllActiveQuestions().Where(m => m.QuestionType.Equals((int)examEnumType)).OrderBy(x => ran.Next());

            newList = list.ToList();   

            HttpContext.Session.SetObjectAsJson("cartQuestion", newList.Take((int)totalQuestion));
            var html = this.RenderView<IEnumerable<QuestionViewModel>>("__QuestionRandomView", newList.Take((int)totalQuestion), true);
            return Json(new { html = html });
        }

        public void ClearCartQuestionSession()
        {
            HttpContext.Session.Remove("cartQuestion");
        }

        public IActionResult Details(int id)
        {
            var exam = _examinationService.GetExaminationById(id);

            var html = this.RenderView<ExaminationViewModel>("_Details", exam, true);
            return Json(new { html = html });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var rs = _examinationService.DeleteExamById(id);
            if (rs.Result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "server error");
            }
        }

        public IActionResult MockExam(int examId)
        {
            var currentUser = HttpContext.Session.GetCurrentAuthentication();
            
            UserExaminationCrudModel crudModel = new UserExaminationCrudModel() {
                ExamId = examId,
                StatusEnumValue = (int)StatusEnum.DangThi,
                CreatedAt = DateTime.Now,
                TimeConsumed = 0,
                ResultEnumValue = (int)ResultEnum.KhongVuot,
                UserExaminationGuid = Guid.NewGuid(),
                Score = 0,
                UserId = 1
        };

            ViewBag.UserExamGuid = crudModel.UserExaminationGuid;
            var result = _userExaminationService.CreateUserExamination(crudModel);
            if (result.Result.IsSuccess)
            {
                var exam = _examinationService.GetExaminationById(examId);
                var html = this.RenderView<ExaminationViewModel>("_MockExam", exam, true);
                return Json(new { html = html });
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public async Task<double> SubmitExam(string[] answerArr, int txtExamId, string txtUserExamGuid, int txtTimeConsume)
        {
            double totalScore = 0;
            var updateModel = _userExaminationService.GetUserExaminationCrudModel(txtUserExamGuid);
            var examModel = _examinationService.GetExaminationById(txtExamId);
            List<UserExaminationAnswerCrudModel> listUserExaminationAnswerCrudModel = new List<UserExaminationAnswerCrudModel>();

            if (answerArr[0] == null) //khong lam bai
            {
                await UpdateUserExamination(txtUserExamGuid, txtExamId, txtTimeConsume, totalScore);
                return totalScore;
            }

            var stringAnswerId = answerArr[0].Split(",");
            stringAnswerId.Distinct();
            int size = stringAnswerId.Length;
            //tạo mảng tạm kiểu int
            int[] intAnswerId = new int[size];

            //vòng lặp để chuyển từ array string to int
            for (int i = 0; i < size; i++)
            {
                intAnswerId[i] = int.Parse(stringAnswerId[i]);
            }

            List<int> listUnrightIdAnswer = intAnswerId.ToList();
            if (intAnswerId.Length != 0)
            {
                var correctAnswers = _examinationService.GetExaminationById(txtExamId).ExaminationQuestionsActives.Select(a => a.AnswerActive.Where(r => r.IsCorrect == true)).ToList();
                foreach(var correctAnswer in correctAnswers)
                {
                    foreach (var answer in correctAnswer)
                    {
                        foreach (var anId in intAnswerId)
                        {
                            var question = _questionService.GetQuestionActiveById(answer.ExaminationQuestionsActiveId);

                            if (anId == answer.AnswerId)
                            {
                                //create list of right answer to save
                                UserExaminationAnswerCrudModel tempModel = new UserExaminationAnswerCrudModel()
                                {
                                    AnswerContent = anId.ToString(),
                                    IsRightAnswer = true,
                                    /*QuestionId = question.QuestionId,*/
                                    UserExaminationId = updateModel.UserExaminationId,
                                    IsEssayAnswer = false,
                                    Score = (double)question.Score,
                                    ExaminationQuestionsActiveId = question.ExaminationQuestionsActiveId
                                };
                                //end
                                listUserExaminationAnswerCrudModel.Add(tempModel);
                                //update unright answer
                                listUnrightIdAnswer.Remove(anId);

                                totalScore += (double)question.Score;
                                break;
                            } 
                        }
                    }
                }
            }

            foreach(var item in listUnrightIdAnswer)
            {
                //create list of unright answer to save
                UserExaminationAnswerCrudModel tempModel = new UserExaminationAnswerCrudModel()
                {
                    AnswerContent = item.ToString(),
                    IsRightAnswer = false,
                    /*QuestionId = 0,*/
                    UserExaminationId = updateModel.UserExaminationId,
                    IsEssayAnswer = false,
                    Score = 0,
                    ExaminationQuestionsActiveId = 0
                };
                //end

                listUserExaminationAnswerCrudModel.Add(tempModel);
            }

            //create list of answer that user check
            await _userExaminationService.CreateUserExaminationAnswers(listUserExaminationAnswerCrudModel);
            
            //update kết quả bài thi sau khi nộp bài, sau nên tách thành hàm riêng*
            if(examModel.ExamType == (int)ExamTypes.TracNghiem)
            {
                updateModel.StatusEnumValue = (int)StatusEnum.DaChamDiem;
                updateModel.TimeConsumed = txtTimeConsume;
                updateModel.Score = totalScore;
                if(totalScore >= examModel.PassScore)
                {
                    updateModel.ResultEnumValue = (int)ResultEnum.Vuot;
                }
                else
                {
                    updateModel.ResultEnumValue = (int)ResultEnum.KhongVuot;
                }
            }


            var result = await UpdateUserExamination(txtUserExamGuid, txtExamId, txtTimeConsume, totalScore);
            if (result.IsSuccess)
            {
                return totalScore;
            }
            else
            {
                return -1;
            }
        }


        //function to update UserExamination since clicking submmit button
        public async Task<ResultViewModel> UpdateUserExamination(string txtUserExamGuid, int txtExamId, int txtTimeConsume, double totalScore)
        {
            var updateModel = _userExaminationService.GetUserExaminationCrudModel(txtUserExamGuid);
            var examModel = _examinationService.GetExaminationById(txtExamId);
            updateModel.UserMarkStringList = examModel.UserMarkStringList;
            if (examModel.ExamType == (int)ExamTypes.TracNghiem)
            {
                updateModel.StatusEnumValue = (int)StatusEnum.DaChamDiem;
                updateModel.TimeConsumed = txtTimeConsume;
                updateModel.Score = totalScore;
                if (totalScore >= examModel.PassScore)
                {
                    updateModel.ResultEnumValue = (int)ResultEnum.Vuot;
                }
                else
                {
                    updateModel.ResultEnumValue = (int)ResultEnum.KhongVuot;
                }
            }
            
            return await _userExaminationService.UpdateUserExamination(updateModel);
        }

    }
}
