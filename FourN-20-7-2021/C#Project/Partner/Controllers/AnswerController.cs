using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Partner.Helper;
using FourN.Data.ViewModel;
using FourN.Services.IService;

namespace Partner.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;

        public AnswerController(IAnswerService answerService, IQuestionService questionService)
        {
            _answerService = answerService;
            _questionService = questionService;
        }

        public IActionResult ShowAnswersInSession()
        {
            List<AnswerViewModel> cartAnswer = SessionExtension.GetObjectFromJson<List<AnswerViewModel>>(HttpContext.Session, "cartAnswer");
            List<AnswerViewModel> cartEditAnswer = SessionExtension.GetObjectFromJson<List<AnswerViewModel>>(HttpContext.Session, "cartEditAnswer");
            if(cartEditAnswer != null)
            {
                var html1 = this.RenderView<IEnumerable<AnswerViewModel>>("_IndexCanEdit", (IEnumerable<AnswerViewModel>)cartEditAnswer, true);
                return Json(new { html = html1 });
            }
            var html = this.RenderView<IEnumerable<AnswerViewModel>>("_IndexCanEdit", (IEnumerable<AnswerViewModel>)cartAnswer, true);
            return Json(new { html = html });
        }

        [HttpGet]
        public IActionResult CreateAnswer(int questionId)
        {
            var answerCrudModel = _answerService.GetAnswerCrudModel(null);
            answerCrudModel.QuestionId = questionId;

            var html = this.RenderView<AnswerCrudModel>("__CreateAnswer", answerCrudModel, true);
            return Json(new { html = html });
        }

        [HttpPost]
        public IActionResult AddItemToSession(string txtAnswerContent, int txtAnswerQuestionId, string txtAnswerIsCorrect)
        {
            bool isCorrect = Boolean.Parse(txtAnswerIsCorrect);

            AnswerCrudModel model = new AnswerCrudModel
            {
                QuestionId = (int)txtAnswerQuestionId,
                IsCorrect = isCorrect,
                Content = txtAnswerContent,
            };

            //get tất cả đáp án hiện có của câu hỏi 
            List<AnswerCrudModel> cartEditAnswer = SessionExtension.GetObjectFromJson<List<AnswerCrudModel>>(HttpContext.Session, "cartEditAnswer");
            List<AnswerCrudModel> cartAnswer = SessionExtension.GetObjectFromJson<List<AnswerCrudModel>>(HttpContext.Session, "cartAnswer");
            if(cartEditAnswer != null)
            {
                cartAnswer = cartEditAnswer;
            }

            if (cartAnswer == null)
            {
                cartAnswer = new List<AnswerCrudModel>();
            }

            //kiểm tra đáp án mới có trùng với đáp án cũ, nếu có báo lỗi trùng phía view
            foreach (var i in cartAnswer)
            {
                if (i.Content.Equals(txtAnswerContent))
                {
                    return StatusCode(400, "fail");
                }
            }

            //nếu đáp án mới là correct thì:
            if (model.IsCorrect)
            {
                //kiểm tra xem trong danh sách đáp án đã có đáp án khác correct chưa, nếu chưa thì add bình thường, có rồi thì thay đổi
                foreach (var i in cartAnswer)
                {
                    if (i.IsCorrect)
                    {
                        i.IsCorrect = false;
                    }
                }
            }

            cartAnswer.Add(model);
            
            //lưu lại session mới
            if(cartEditAnswer != null)
            {
                SessionExtension.SetObjectAsJson(HttpContext.Session, "cartEditAnswer", cartAnswer);
            }
            else
            {
                SessionExtension.SetObjectAsJson(HttpContext.Session, "cartAnswer", cartAnswer);
            }
            
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveItemFromSession(string txtAnswerContent, string txtAnswerIsCorrect)
        {
            List<AnswerCrudModel> cartAnswer = SessionExtension.GetObjectFromJson<List<AnswerCrudModel>>(HttpContext.Session, "cartAnswer");
            List<AnswerCrudModel> cartEditAnswer = SessionExtension.GetObjectFromJson<List<AnswerCrudModel>>(HttpContext.Session, "cartEditAnswer");
            if(cartEditAnswer != null)
            {
                cartAnswer = cartEditAnswer;
            }

            AnswerCrudModel model = cartAnswer.FirstOrDefault(x => x.Content.Equals(txtAnswerContent));
            cartAnswer.Remove(model);

            if (cartEditAnswer != null)
            {
                SessionExtension.SetObjectAsJson(HttpContext.Session, "cartEditAnswer", cartAnswer);
            }
            else
            {
                SessionExtension.SetObjectAsJson(HttpContext.Session, "cartAnswer", cartAnswer);
            }
            return Ok();
        }

        public void ClearAnswerSession()
        {
                HttpContext.Session.Remove("cartAnswer");
        }

        public void ClearEditAnswerSession()
        {
            HttpContext.Session.Remove("cartEditAnswer");
        }
        
        [HttpPost]
        public IActionResult GetAnswerActiveByQuestionActiveId(int questionId)
        {
            var model = _questionService.GetQuestionActiveById(questionId);
            var html = this.RenderView<ExaminationQuestionsActiveViewModel>("_IndexNoEdit", model, true);
            return Json(new { html = html });
        }
    }
}
