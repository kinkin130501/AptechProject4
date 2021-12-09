using FourN.Data;
using FourN.Data.Models;
using FourN.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Partner.Helper;
using Partner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partner.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly FourNDbContext _context;
        public AuthenticationController(FourNDbContext context)
        {
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
                              .ThenInclude(x => x.authcontrollers)
                              .Include(x => x.useruserroles)
                              .ThenInclude(x => x.userrole)
                              .ThenInclude(x => x.authuserroles)
                              .ThenInclude(x => x.authapplication)
                              .ThenInclude(x => x.authcontrollers)
                              .FirstOrDefaultAsync(x => x.email == model.email && x.password == model.password && x.isdeleted == false && x.isemployee != true &&  x.isfreelancer != true).Result;
            if (user == null)
            {
                ModelState.AddModelError("error", "Email or password is invalid");
                return View();
            }
            if (user != null)
            {
                foreach (var item in user.authusers)
                {
                    //app.Add(item.authapplication);
                    app.Add(AuthApplicationViewModel.ConvertfromAuthapplication(item.authapplication));
                }
                foreach (var item in user.useruserroles.Select(x => x.userrole).Select(x => x.authuserroles))
                {
                    //app.AddRange(item.Select(x => x.authapplication));
                    app.AddRange(item.Select(x => AuthApplicationViewModel.ConvertfromAuthapplication(x.authapplication)));
                }
            }
            app = app.Distinct().ToList();
            var applicationController = app.Distinct().ToList();
            var Authmodel = new AuthenticationModel();

            List<Authcontroller> authcontrollers = new List<Authcontroller>();
            List<Authapplication> authapplications = new List<Authapplication>();
            foreach (var item in user.authusers?.Select(x => x.authapplication?.authcontrollers))
            {
                authcontrollers.AddRange(item);
            }

            Authmodel.UserName = user.username;
            Authmodel.Applications = app;
            Authmodel.Email = user.email;
            Authmodel.UserId = user.userid;
            HttpContext.Session.SetCurrentAuthentication(Authmodel);
            return RedirectToAction("Index", "Recruit");
        }
    }
}
