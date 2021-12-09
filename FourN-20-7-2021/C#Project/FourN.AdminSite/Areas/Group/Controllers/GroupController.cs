using FourN.AdminSite.Helper;
using FourN.Data.ViewModel;
using FourN.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FourN.AdminSite.Areas.Group.Controllers
{
    [Area("Group")]
    public class GroupController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string BASE_URI = "http://localhost:9999/groups/";
        private string USER_URI = "http://localhost:9999/users/";
        private IUserService _userService;
        public GroupController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: GroupController
        public ActionResult Index()
        {
            var view = _userService.GetGroup();
            return View(view);
        }
        public IActionResult Create()
        {
            var users = JsonConvert.DeserializeObject<IEnumerable<Data.Models.User>>(_httpClient.GetStringAsync(USER_URI).Result);

            var employees = users.Where(x => x.isemployee == true).Select(x => new System.Web.Mvc.SelectListItem()
            {
                Text = x.username,
                Value = x.userid.ToString()
            }).ToList();
            var leaders = users.Where(x => x.islead == true).Select(x => new System.Web.Mvc.SelectListItem()
            {
                Text = x.username,
                Value = x.userid.ToString()
            }).ToList();
            var view = new GroupViewModel();
            view.SelectListLeaders = leaders;
            view.SelectListStaffs = employees;
            return View(view);
        }
        [HttpPost]
        public IActionResult Create(GroupViewModel group)
        {
            _ = _userService.CreateGroup(group).Result;
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var users = JsonConvert.DeserializeObject<IEnumerable<Data.Models.User>>(_httpClient.GetStringAsync(USER_URI).Result);

            var employees = users.Where(x => x.isemployee == true).Select(x => new System.Web.Mvc.SelectListItem()
            {
                Text = x.username,
                Value = x.userid.ToString()
            }).ToList();
            var leaders = users.Where(x => x.islead == true).Select(x => new System.Web.Mvc.SelectListItem()
            {
                Text = x.username,
                Value = x.userid.ToString()
            }).ToList();
            var view = _userService.GetGroupById(id).Result;
            view.SelectListLeaders = leaders;
            view.SelectListStaffs = employees;
            return View(view);
        }
        [HttpPost]
        public IActionResult Edit(GroupViewModel group)
        {
            _ = _userService.EditGroup(group).Result;
            return RedirectToAction("Index");
        }
        public IActionResult IndexPartial()
        {
            var result = _userService.GetGroup();
            var html = this.RenderView<IEnumerable<GroupViewModel>>("_Index", result, true);
            return Json(new { html = html });
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _userService.DeleteGroup(id).Result;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult checkGroupName(string name)
        {
            var result = _userService.checkGroupName(name);
            return Json(new { result = result });
        }
    }
}
