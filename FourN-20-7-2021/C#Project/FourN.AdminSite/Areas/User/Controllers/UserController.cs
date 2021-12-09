using FourN.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FourN.Data.ViewModel;
using FourN.Data.Models;
using System.Net.Http.Json;
using FourN.AdminSite.Helper;
using Microsoft.AspNetCore.Http;
using System.IO;
using FourN.Data;
using Microsoft.EntityFrameworkCore;

namespace FourN.AdminSite.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        private readonly FourNDbContext _context;
        private readonly HttpClient _httpClient = new HttpClient();
        private string USER_URI = "http://localhost:9999/users/";
        private string POST_URI = "http://localhost:9999/users";
        private IUserService _userService;
        public UserController(IUserService userService, FourNDbContext context)
        {
            _userService = userService;
            _context = context;
        }
        public IActionResult Index()
        {
            var result = JsonConvert.DeserializeObject<IEnumerable<Data.Models.User>>(_httpClient.GetStringAsync(USER_URI).Result)
                .Select(x=>UserViewModel.ConvertFromUser(x)).ToList();
            foreach (var item in result)
            {
                var grUser = _context.Groupusers.Include(x => x.group).Where(x => x.userid == item.UserID);
                item.GroupName = string.Join(",", grUser.Where(x=>x.group.isdeleted == false).Select(x => x.group.groupname));
            }
            return View(result);
        }
        public IActionResult Detail(int id)
        {
            var user = JsonConvert.DeserializeObject<Data.Models.User>(_httpClient.GetStringAsync(USER_URI + id).Result);
            var userView = UserViewModel.ConvertFromUser(user);
            return View(userView);
        }
        public async Task<IActionResult> Edit(UserViewModel user)
        {
            var oldUser = JsonConvert.DeserializeObject<Data.Models.User>(_httpClient.GetStringAsync(USER_URI + user.UserID).Result);
            oldUser.userid = user.UserID;
            oldUser.username = user.Username;
            oldUser.email = user.Email;
            oldUser.phone = user.Phone;
            oldUser.address = user.Address;
            oldUser.gender = user.Gender;
            // upload hình nếu có 
            if(user.AvatarUrl != null)
            {
               var url = UploadImage(user.AvatarUrl).Result;
               oldUser.avatar = url;
            }
            if (user.CMNDBefore != null)
            {
                var url = UploadImage(user.CMNDBefore).Result;
                oldUser.cmndbefore = url;
            }
            if (user.CMNDAfter != null)
            {
                var url = UploadImage(user.CMNDAfter).Result;
                oldUser.cmndafter = url;
            }
            if(user.Password != null)
            {
                oldUser.password = user.Password;
            }
            var response = await _httpClient.PostAsJsonAsync<Data.Models.User>(POST_URI, oldUser);
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Create()
        {
            var user = new UserViewModel();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            var newUser = new Data.Models.User()
            {
             username = user.Username,
             phone = user.Phone,
             email = user.Email,
             password = user.Password,
             avatar = user.AvatarUrl != null ? UploadImage(user.AvatarUrl).Result : null,
             cmndbefore = user.CMNDBefore != null ? UploadImage(user.CMNDBefore).Result : null,
             cmndafter = user.CMNDAfter != null ? UploadImage(user.CMNDAfter).Result : null,
             address = user.Address,
             birthday = user.Birthday,
             // true is male, false is female
             gender = user.Gender
            };
            if (user.DepartmentInt == (int)SystemEnum.RoleNumber.Developer)
            {
                newUser.isemployee = true;
                newUser.isfreelancer = false;
                newUser.islead = false;
            }
            else if(user.DepartmentInt == (int)SystemEnum.RoleNumber.Partner)
            {
                newUser.isemployee = false;
                newUser.isfreelancer = true;
                newUser.islead = false;
            }
            //var response = await _httpClient.PostAsJsonAsync<Data.Models.User>(POST_URI, newUser);
            if (user.DepartmentInt == (int)SystemEnum.RoleNumber.Developer)
            {
                var result = _userService.RoleForUser(newUser, 3).Result;
            }
            else if (user.DepartmentInt == (int)SystemEnum.RoleNumber.Partner)
            {
               var result = _userService.RoleForUser(newUser, 4).Result;
            } 
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var reponse = await _httpClient.PutAsJsonAsync<Data.Models.User>(USER_URI + id, null);
            if (reponse.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
        public IActionResult IndexPartial()
        {
            var result = JsonConvert.DeserializeObject<IEnumerable<Data.Models.User>>(_httpClient.GetStringAsync(USER_URI).Result)
                .Select(x => UserViewModel.ConvertFromUser(x)).ToList();
            var html = this.RenderView<IEnumerable<UserViewModel>>("_Index", result, true);
            return Json(new { html = html });
        }
        private async Task<string> UploadImage(IFormFile file)
        {
            string path = Path.Combine("wwwroot/img/User", file.FileName);
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

            await file.CopyToAsync(stream);
            var url = "/img/User/" + file.FileName;
            return url;
        }
        [HttpGet]
        public IActionResult Profile(int userid)
        {
            var user = JsonConvert.DeserializeObject<Data.Models.User>(_httpClient.GetStringAsync(USER_URI + userid).Result);
            var userView = UserViewModel.ConvertFromUser(user);
            return View(userView);
        }
        [HttpPost]
        public IActionResult checkEmail(string email)
        {
            var result = _userService.checkEmail(email);
            return Json(new { result = result});
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserViewModel user)
        {
            var oldUser = JsonConvert.DeserializeObject<Data.Models.User>(_httpClient.GetStringAsync(USER_URI + user.UserID).Result);
            oldUser.userid = user.UserID;
            oldUser.username = user.Username;
            oldUser.email = user.Email;
            oldUser.phone = user.Phone;
            oldUser.address = user.Address;
            oldUser.gender = user.Gender;
            // upload hình nếu có 
            if (user.AvatarUrl != null)
            {
                var url = UploadImage(user.AvatarUrl).Result;
                oldUser.avatar = url;
            }
            if (user.CMNDBefore != null)
            {
                var url = UploadImage(user.CMNDBefore).Result;
                oldUser.cmndbefore = url;
            }
            if (user.CMNDAfter != null)
            {
                var url = UploadImage(user.CMNDAfter).Result;
                oldUser.cmndafter = url;
            }
            if (user.Password != null)
            {
                oldUser.password = user.Password;
            }
            var response = await _httpClient.PostAsJsonAsync<Data.Models.User>(POST_URI, oldUser);
            ModelState.AddModelError("error", "Edit successfully");
            var account = JsonConvert.DeserializeObject<Data.Models.User>(_httpClient.GetStringAsync(USER_URI + user.UserID).Result);
            var userView = UserViewModel.ConvertFromUser(account);
            return View(userView);
        }
    }
}
