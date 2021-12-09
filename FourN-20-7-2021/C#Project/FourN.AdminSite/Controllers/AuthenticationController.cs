using FourN.AdminSite.Helper;
using FourN.AdminSite.Models;
using FourN.Data;
using FourN.Data.Models;
using FourN.Data.ViewModel;
using FourN.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourN.AdminSite.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly FourNDbContext _context;
        public AuthenticationController(IUserService userService, FourNDbContext context)
        {
            _userService = userService;
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            //_userService.Login(model);
            var app = new List<AuthApplicationViewModel>();
            var user = _context.User.Include(x => x.authusers)
                              .ThenInclude(x => x.authapplication)
                              .ThenInclude(x=>x.authcontrollers)
                              .Include(x => x.useruserroles)
                              .ThenInclude(x => x.userrole)
                              .ThenInclude(x => x.authuserroles)
                              .ThenInclude(x => x.authapplication)
                              .ThenInclude(x => x.authcontrollers)
                              .FirstOrDefaultAsync(x => x.email == model.email && x.password == model.password).Result;
            if(user == null)
            {
                ModelState.AddModelError("error", "Email or password is invalid");
                return View();
            }
            if (user != null)
            {
                foreach (var item in user.useruserroles.Select(x => x.userrole).Select(x => x.authuserroles))
                {
                    //app.AddRange(item.Select(x => x.authapplication));
                    app.AddRange(item.Select(x => AuthApplicationViewModel.ConvertfromAuthapplication(x.authapplication)));
                }
                foreach (var item in user.authusers)
                {
                    //app.Add(item.authapplication);
                    var appItem = AuthApplicationViewModel.ConvertfromAuthapplication(item.authapplication);
                    if (app.FirstOrDefault(x=>x.authapplicationid == appItem.authapplicationid) == null)
                    {
                        app.Add(AuthApplicationViewModel.ConvertfromAuthapplication(item.authapplication));
                    }
                }

            }
            //app = app.Distinct().ToList();
            //var applicationController = ;
            var Authmodel = new AuthenticationModel();
           
            List<Authcontroller> authcontrollers = new List<Authcontroller>();
            List<Authapplication> authapplications = new List<Authapplication>();
            foreach (var item in user.authusers?.Select(x=>x.authapplication?.authcontrollers))
            {
                authcontrollers.AddRange(item);
            }
            Authmodel.UserName = user.username;
            Authmodel.Applications = app;
            Authmodel.Email = user.email;
            Authmodel.UserId = user.userid;
            if (user.isemployee)
            {
                Authmodel.department = (int)SystemEnum.RoleNumber.Developer;
            }else if (user.islead)
            {
                Authmodel.department = (int)SystemEnum.RoleNumber.Leader;
            }else if ((bool)user.isfreelancer)
            {
                Authmodel.department = (int)SystemEnum.RoleNumber.Partner;
            }
            else
            {
                Authmodel.department = (int)SystemEnum.RoleNumber.PM;
            }
            HttpContext.Session.SetCurrentAuthentication(Authmodel);
            return Redirect("https://localhost:44316/Module4/Calendar");
        }
        public IActionResult NotAllow()
        {
            return View();
        }
    }
}
