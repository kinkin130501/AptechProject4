using FourN.Data.EnumModel;
using FourN.Data.ViewModel;
using FourN.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Partner.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partner.Controllers
{
    public class CandidateExaminationController : Controller
    {
        private readonly IUserExaminationService _userExaminationService;
        private readonly IExaminationService _examinationService;
        private readonly IUserService _userService;
        private readonly IQuestionService _questionService;

        public CandidateExaminationController(IUserExaminationService userExaminationService, IExaminationService examinationService, IUserService userService, IQuestionService questionService)
        {
            _examinationService = examinationService;
            _userExaminationService = userExaminationService;
            _userService = userService;
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            var displayModel = new UserExaminationDisplayModel();

            displayModel.UserExaminations = new List<UserExaminationViewModel>();
            return View(displayModel);
        }
        public IActionResult IndexPartial()
        {
            var list = new List<UserExaminationViewModel>();
            var html = this.RenderView<IEnumerable<UserExaminationViewModel>>("_IndexPartial", list, true);
            return Json(new { html = html });
        }
        public IActionResult SearchUserExaminations(SearchUserExaminationViewModel model)
        {
            var list = _userExaminationService.SearchCandidateExaminations(model);
            var html = this.RenderView<IEnumerable<UserExaminationViewModel>>("_IndexPartial", list, true);
            return Json(new { html = html });
        }
        public IActionResult Details(int userExamId)
        {
            var userExam = _userExaminationService.GetUserExaminationById(userExamId);
            var examId = userExam.ExamId;
            var exam = _examinationService.GetExaminationById(examId);
            ViewBag.UserExaminationId = userExamId;
            ViewBag.CurrentScore = userExam.Score;
            ViewBag.StatusValue = userExam.StatusEnumValue;
            if (exam.ExamType == (int)ExamTypes.TracNghiem)
            {
                ViewBag.UserExamRightAnswerList = userExam.UserExaminationAnswers.Where(ex => ex.IsRightAnswer == true && ex.IsEssayAnswer == false);
                ViewBag.UserExamUnRightAnswerList = userExam.UserExaminationAnswers.Where(ex => ex.IsRightAnswer == false && ex.IsEssayAnswer == false);
                var html = this.RenderView<ExaminationViewModel>("_Details", exam, true);
                return Json(new { html = html });
            }

            return StatusCode(500, "Error in Controller");

        }
        public IActionResult MockExam(int userExamId)
        {
            //UserExaminationCrudModel crudModel = new UserExaminationCrudModel()
            //{
            //    ExamId = examId,
            //    StatusEnumValue = (int)StatusEnum.DangThi,
            //    CreatedAt = DateTime.Now,
            //    TimeConsumed = 0,
            //    ResultEnumValue = (int)ResultEnum.KhongVuot,
            //    UserExaminationGuid = Guid.NewGuid(),
            //    Score = 0,
            //    UserId = 1,
            //};

            //ViewBag.UserExamGuid = crudModel.UserExaminationGuid;
            //var result = _userExaminationService.CreateUserExamination(crudModel);
            var userExam = _userExaminationService.GetUserExaminationById(userExamId);
           
            if (userExam != null)
            {
                ViewBag.UserExamGuid = userExam.UserExaminationGuid;
                var exam = _examinationService.GetExaminationById(userExam.ExamId);
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
                foreach (var correctAnswer in correctAnswers)
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

            foreach (var item in listUnrightIdAnswer)
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
