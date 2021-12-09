using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Partner.Helper;
using FourN.Services.IService;
using FourN.Data.ViewModel;
using Partner.Helper;
using FourN.Data.EnumModel;

namespace Partner.Controllers
{
    public class UserExaminationController : Controller
    {
        private readonly IUserExaminationService _userExaminationService;
        private readonly IExaminationService _examinationService;
        private readonly IUserService _userService;

        public UserExaminationController(IUserExaminationService userExaminationService, IExaminationService examinationService, IUserService userService)
        {
            _examinationService = examinationService;
            _userExaminationService = userExaminationService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var displayModel = new UserExaminationDisplayModel();
            
            displayModel.UserExaminations = _userExaminationService.GetAllUserExaminations();
            return View(displayModel);
        }

        public IActionResult IndexPartial()
        {
            
            var list = _userExaminationService.GetAllUserExaminations();
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
            if (exam.ExamType == (int)ExamTypes.TracNghiem) {
                ViewBag.UserExamRightAnswerList = userExam.UserExaminationAnswers.Where(ex => ex.IsRightAnswer == true && ex.IsEssayAnswer == false);
                ViewBag.UserExamUnRightAnswerList = userExam.UserExaminationAnswers.Where(ex => ex.IsRightAnswer == false && ex.IsEssayAnswer == false);
                var html = this.RenderView<ExaminationViewModel>("_Details", exam, true);
                return Json(new { html = html });
            }

            return StatusCode(500, "Error in Controller");

        }

        public IActionResult SearchUserExaminations(SearchUserExaminationViewModel model)
        {
            var list = _userExaminationService.SearchUserExaminations(model);
            var html = this.RenderView<IEnumerable<UserExaminationViewModel>>("_IndexPartial", list, true);
            return Json(new { html = html });
        }
    }
}
