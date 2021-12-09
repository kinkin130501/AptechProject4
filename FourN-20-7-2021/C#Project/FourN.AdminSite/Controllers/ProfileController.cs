using FourN.Data;
using FourN.Data.ViewModel;
using FourN.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FourN.AdminSite.Controllers
{
    public class ProfileController : Controller
    {
        private readonly FourNDbContext _context;
        private readonly HttpClient _httpClient = new HttpClient();
        private string USER_URI = "http://localhost:9999/users/";
        private string POST_URI = "http://localhost:9999/users";
        private IUserService _userService;
        public ProfileController(IUserService userService, FourNDbContext context)
        {
            _userService = userService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
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
