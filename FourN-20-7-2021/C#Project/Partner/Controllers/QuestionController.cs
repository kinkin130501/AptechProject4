using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourN.Services.IService;
using FourN.Data.ViewModel;
using Partner.Helper;

namespace Partner.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetCurrentAuthentication() == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            var displayModel = new QuestionDisplayViewModel();
            var currentUser = HttpContext.Session.GetCurrentAuthentication();
            displayModel.Questions = _questionService.GetAllActiveQuestions().Where(x=>x.ParentQuestionId != 0).ToList();
            return View(displayModel);
        }

        public IActionResult IndexPartial()
        {
            var list = _questionService.GetAllQuestions().Where(m => m.Content != null && m.ParentQuestionId == null);
            var html = this.RenderView<IEnumerable<QuestionViewModel>>("_IndexPartial", list, true);
            return Json(new { html = html });
        }
        public IActionResult Create(int? parentId, string questionOf)
        {
            var model = _questionService.GetQuestionCrudModel(null);

            var html1 = this.RenderView<QuestionCrudModel>("_Create", model, true);
            return Json(new { html = html1 });
        }

        

        [HttpPost]
        public IActionResult Create(QuestionCrudModel model)
        {
            var currentUser = HttpContext.Session.GetCurrentAuthentication();
            model.ContentProviderId = 1;
            model.CreatedBy = 1;
            model.IsGroupQuestion = false;
            List<AnswerCrudModel> cartAnswer = SessionExtension.GetObjectFromJson<List<AnswerCrudModel>>(HttpContext.Session, "cartAnswer");
            if (cartAnswer == null)
            {
                return Json(new { isSuccess = false, message = "Please enter answer." });
            }
            var result = _questionService.CreateQuestion(model, cartAnswer);
            if (result.Result.IsSuccess)
            {
                HttpContext.Session.Remove("cartAnswer");
                return Ok();
            }
            else
            {
                return StatusCode(500, "server error");
            }
        }

        public IActionResult Edit(int id)
        {
            var question = _questionService.GetQuestionCrudModel(id);
            var questionViewModel = _questionService.GetQuestionById(id);
            List<AnswerViewModel> list = new List<AnswerViewModel>();

            if(questionViewModel.Answers != null)
            {
                foreach(var i in questionViewModel.Answers)
                {
                    var view = new AnswerViewModel
                    {
                        IsMultipleAnswer = i.IsMultipleAnswer,
                        AnswerId = i.AnswerId,
                        Content = i.Content,
                        IsCorrect = i.IsCorrect,
                        QuestionId = i.QuestionId,
                        CreatedAt = i.CreatedAt,
                        IsActive = i.IsActive,
                        
                    };
                    list.Add(view);
                }
            }
            SessionExtension.SetObjectAsJson(HttpContext.Session, "cartEditAnswer", list);
            var html = this.RenderView<QuestionCrudModel>("_Edit", question, true);
            return Json(new { html = html });
        }

        public IActionResult Details(int id)
        {
            var question = _questionService.GetQuestionById(id);
            
            var html = this.RenderView<QuestionViewModel>("_Details", question, true);
            return Json(new { html = html });
        }

        [HttpPost]
        public IActionResult Edit(QuestionCrudModel question)
        {
            //var currentUserId = HttpContext.Session.GetCurrentAuthentication().UserId;
            question.ModifiedBy = 1;

            List<AnswerCrudModel> cartEditAnswer = SessionExtension.GetObjectFromJson<List<AnswerCrudModel>>(HttpContext.Session, "cartEditAnswer");
            var rs = _questionService.UpdateQuestion(question, cartEditAnswer);
            if (rs.Result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "server error");
            }
            
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            var rs = _questionService.DeleteQuestionById(id).Result;
            if (rs.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "server error");
            }
        }

        public IActionResult QuestionListDetails(int id)
        {
            var list = _questionService.GetAllQuestionByParentId(id);
            var groupViewModel = new QuestionGroupViewModel();
            var questionGroup = _questionService.GetQuestionById(id);
            groupViewModel.QuestionViewModels = list;
            groupViewModel.Content = questionGroup.Content;
            groupViewModel.QuestionType = questionGroup.QuestionType;
            var html = this.RenderView<QuestionGroupViewModel>("_QuestionListDetails", groupViewModel, true);
            return Json(new { html = html });
        }

        public IActionResult SearchQuestions(SearchQuestionViewModel model)
        {
            var list = _questionService.SearchQuestions(model);
            var html = this.RenderView<IEnumerable<QuestionViewModel>>("_IndexPartial", list, true);
            return Json(new { html = html });
        }
    }
}
