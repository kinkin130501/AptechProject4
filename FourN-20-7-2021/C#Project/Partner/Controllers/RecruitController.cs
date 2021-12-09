using FourN.Data.ViewModel;
using FourN.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Partner.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Partner.Controllers
{
    public class RecruitController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IExaminationService _examinationService;
        public RecruitController(IDepartmentService departmentService, IExaminationService examinationService)
        {
            _departmentService = departmentService;
            _examinationService = examinationService;
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.GetCurrentAuthentication() == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            var view = _departmentService.findAllForManage();
            return View(view);
        }
        public IActionResult IndexPartial()
        {
            var result = _departmentService.findAllForManage();
            var html = this.RenderView<IEnumerable<DepartmentViewModel>>("_IndexPartial", result, true);
            return Json(new { html = html });
        }
        public IActionResult ListCandicate(int id)
        {
            var view = _departmentService.GetListCandicateFromDepartmentId(id);
            return View(view);
        }
        public IActionResult Create()
        {
            var model = new DepartmentModel();
            model.Examinations = _examinationService.GetAllExaminations();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(DepartmentModel department)
        {
            if(department.Image != null)
            {
                department.ImageURL = UploadImage(department.Image).Result;
            }
            var result = _departmentService.CreateDepartment(department).Result;
            return RedirectToAction("Index");
        }
        private async Task<string> UploadImage(IFormFile file)
        {
            string path = Path.Combine("wwwroot/Partner", file.FileName);
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

            await file.CopyToAsync(stream);
            var url = "/Partner/" + file.FileName;
            return url;
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _departmentService.DeleteDepartment(id).Result;
            return Json(new { isSuccess = result.IsSuccess, message = result.SuccessMessage });
        }
        [HttpGet]
        public IActionResult CreateInterview(int departmentid)
        {
            var interview = new InterviewModel();
            interview.users = _departmentService.getAllLead();
            interview.partners = _departmentService.GetListCandicateFromDepartmentId(departmentid);
            interview.departmentid = departmentid;
            interview.DateTime = DateTime.Now.AddDays(5);
            interview.OldInterviewModel = _departmentService.getlateInterView(departmentid).Result;
            var html = this.RenderView<InterviewModel>("_Interview", interview, true);
            return Json(new { html = html });
        }
        public IActionResult CreateInterview(InterviewModel model)
        {
            var result = _departmentService.CreateInterview(model).Result;
            return RedirectToAction("Index");
        }
        public IActionResult Request()
        {
            var listRequest = _departmentService.findAllRequest();
            return View(listRequest);
        }
        public IActionResult Detail(int departmentid)
        {
            var result = _departmentService.findOne(departmentid);
            var html = this.RenderView<DepartmentViewModel>("_Detail", result, true);
            return Json(new { html = html });
        }
        //public IActionResult Edit(int departmentid)
        //{
        //    var result = _departmentService.showEdit(departmentid);
        //    result.Examinations = _examinationService.GetAllExaminations();
        //    var html = this.RenderView<DepartmentModel>("_Edit", result, true);
        //    return Json(new { html = html });
        //}
        public IActionResult Edit(int departmentid)
        {
            var result = _departmentService.showEdit(departmentid);
            result.Examinations = _examinationService.GetAllExaminations();
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentModel model)
        {
            if(model.Image != null)
            {
                model.ImageURL = UploadImage(model.Image).Result;
            }
            var result = _departmentService.Edit(model).Result;
            return RedirectToAction("Index");
        }
    }
}
