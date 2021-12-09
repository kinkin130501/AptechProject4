using FourN.AdminSite.Helper;
using FourN.Data;
using FourN.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;

namespace FourN.AdminSite.Areas.ProjectManagement.Controllers
{
    [Area("ProjectManagement")]
    public class AffairController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string Affair_URI = "http://localhost:9999/affairs/";
        private string Project_URI = "http://localhost:9999/projects/";
        private string User_URI = "http://localhost:9999/users/";
        private string Doc_URI = "http://localhost:9999/documents/";
        private string PGroup_URI = "http://localhost:9999/pgroups/";
        private string GroupUser_URI = "http://localhost:9999/groupusers/";

        // GET: AffairController
        public ActionResult Index(int id)
        {
            var viewAnalisys = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
            (_httpClient.GetStringAsync(Affair_URI).Result)
            .Where(a => a.projectid == id && a.typeofaffair == 0);
            var viewDesign = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
            (_httpClient.GetStringAsync(Affair_URI).Result)
            .Where(a => a.projectid == id && a.typeofaffair == 1);
            var viewImple = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
            (_httpClient.GetStringAsync(Affair_URI).Result)
            .Where(a => a.projectid == id && a.typeofaffair == 2);
            var viewTest = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
            (_httpClient.GetStringAsync(Affair_URI).Result)
            .Where(a => a.projectid == id && a.typeofaffair == 3);
            var viewDeploy = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
            (_httpClient.GetStringAsync(Affair_URI).Result)
            .Where(a => a.projectid == id && a.typeofaffair == 4);
            var userId = HttpContext.Session.GetCurrentAuthentication().UserId;
            var department = HttpContext.Session.GetCurrentAuthentication().department;
            if(department == (int)SystemEnum.RoleNumber.Developer || department == (int)SystemEnum.RoleNumber.Partner)
            {
                viewAnalisys = viewAnalisys.Where(a => a.userid == userId);
                viewDesign = viewDesign.Where(a => a.userid == userId);
                viewImple = viewImple.Where(a => a.userid == userId);
                viewTest = viewTest.Where(a => a.userid == userId);
                viewDeploy = viewDeploy.Where(a => a.userid == userId);
            }

            var viewProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result)
                .Where(p => p.projectid == id);

            var viewUser = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(User_URI).Result);
            var viewGroupUser = JsonConvert.DeserializeObject<IEnumerable<Groupuser>>
                (_httpClient.GetStringAsync(GroupUser_URI).Result);

            foreach (var userAll in viewUser)
            {
                if (userAll.islead == true)
                {
                    ViewData["Member"] = "LEADER";
                }
                else
                {
                    ViewData["Member"] = "EMPLOYEE";
                }
            }

            if (viewProject.Count() == 1)
            {
                ViewData["projectid"] = id;
            }
            else
            {
                ViewData["projectid"] = 0;
            }

            ViewData["start"] = viewProject.SingleOrDefault()?.startplan.ToString("dd/MM/yyyy HH:mm:ss");
            ViewData["end"] = viewProject.SingleOrDefault()?.endplan.ToString("dd/MM/yyyy HH:mm:ss");

            ViewData["id"] = id;
            ViewData["projectname"] = viewProject.SingleOrDefault()?.projectname;
            ViewBag.user = viewUser;
            ViewBag.viewAnalisys = viewAnalisys;
            ViewBag.viewDesign = viewDesign;
            ViewBag.viewImple = viewImple;
            ViewBag.viewTest = viewTest;
            ViewBag.viewDeploy = viewDeploy;
            return View();
        }

        public ActionResult Detail(int id)
        {
            var view = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(m => m.affairid == id).SingleOrDefault();

            var viewUser = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(User_URI).Result);

            var viewDoc = JsonConvert.DeserializeObject<IEnumerable<Documents>>
                (_httpClient.GetStringAsync(Doc_URI).Result);

            var viewProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result)
                .Where(m => m.projectid == view.projectid).SingleOrDefault();
            ViewData["projectname"] = viewProject.projectname;
            ViewBag.viewDoc = viewDoc;
            ViewBag.user = viewUser;

            return View(view);
        }

        [HttpGet]
        public ActionResult Create(int id, int type)
        {
            ViewData["projectid"] = id;
            ViewData["type"] = type;

            var viewProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result)
                .Where(p => p.projectid == id);

            var viewAffairDesign = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(p => p.projectid == id && p.typeofaffair == 1);
            var viewAffairImplement = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(p => p.projectid == id && p.typeofaffair == 2);
            var viewAffairTest = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(p => p.projectid == id && p.typeofaffair == 3);

            var viewPGroup = JsonConvert.DeserializeObject<IEnumerable<Projectgroup>>
                (_httpClient.GetStringAsync(PGroup_URI).Result)
                .Where(p => p.projectid == id).SingleOrDefault();

            var viewGroup = JsonConvert.DeserializeObject<IEnumerable<Groupuser>>
            (_httpClient.GetStringAsync(GroupUser_URI).Result)
                .Where(g => g.groupid == viewPGroup.groupid);

            var viewUser = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(User_URI).Result);
            List<FourN.Data.Models.User> users = new List<FourN.Data.Models.User>();
            foreach (var g in viewGroup)
            {
                foreach (var u in viewUser)
                {
                    if (g.userid == u.userid)
                    {
                        users.Add(u);
                    }
                }
            }
            ViewData["nameProject"] = viewProject.SingleOrDefault().projectname;
            ViewData["start"] = viewProject.SingleOrDefault().startplan.ToString("yyyy/MM/dd HH:mm:ss");
            ViewData["end"] = viewProject.SingleOrDefault().endplan.ToString("yyyy/MM/dd HH:mm:ss");
            ViewData["startformat"] = viewProject.SingleOrDefault().startplan.ToString("dd/MM/yyyy HH:mm:ss");
            ViewData["endformat"] = viewProject.SingleOrDefault().endplan.ToString("dd/MM/yyyy HH:mm:ss");
            ViewBag.viewDesign = viewAffairDesign;
            ViewBag.viewImplement = viewAffairImplement;
            ViewBag.viewTest = viewAffairTest;
            ViewBag.viewUser = users;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Affairs getmodel, string checkstatus)
        {
            try
            {
                getmodel.affairtag = 0;
                getmodel.starttimeplan = getmodel.starttimeplan.AddHours(-7);
                getmodel.endtimeplan = getmodel.endtimeplan.AddHours(-7);
                var model = _httpClient.PostAsJsonAsync<Affairs>(Affair_URI, getmodel).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Affair", new { id = getmodel.projectid });
                }
                else
                {
                    ViewBag.Msg = "Error";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index", "Affair", new { id = getmodel.projectid });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            int percent = 0;
            var view = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(m => m.affairid == id).SingleOrDefault();
            var viewAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(m => m.projectid == view.projectid);

            ViewData["value"] = view.affairtag.Value;

            var viewPGroup = JsonConvert.DeserializeObject<IEnumerable<Projectgroup>>
                (_httpClient.GetStringAsync(PGroup_URI).Result)
                .Where(p => p.projectid == view.projectid).SingleOrDefault();

            var viewGroup = JsonConvert.DeserializeObject<IEnumerable<Groupuser>>
                (_httpClient.GetStringAsync(GroupUser_URI).Result)
                .Where(p => p.groupid == viewPGroup.groupid).ToList();
            var viewUser = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(User_URI).Result);
            List<FourN.Data.Models.User> users = new List<FourN.Data.Models.User>();
            foreach (var g in viewGroup)
            {
                foreach (var u in viewUser)
                {
                    if (g.userid == u.userid)
                    {
                        users.Add(u);
                    }
                }
            }
            ViewBag.viewUser = users;
            return View(view);
        }

        [HttpPost]
        public ActionResult Edit(Affairs getmodel, int checkstatus,
            DateTime starttimeplan,
            DateTime endtimeplan,
            DateTime starttimeactual,
            DateTime endtimeactual)
        {
            long max = 0, min = 0;
            int statusProject = 0;
            int analyze = 0, design = 0, imple = 0, test = 0, deploy = 0;
            try
            {
                getmodel.status = checkstatus;
                getmodel.starttimeplan = getmodel.starttimeplan.AddHours(-7);
                getmodel.endtimeplan = getmodel.endtimeplan.AddHours(-7);
                getmodel.starttimeactual = getmodel.starttimeactual?.AddHours(-7);
                getmodel.endtimeactual = getmodel.endtimeactual?.AddHours(-7);
                var modelA = _httpClient.PostAsJsonAsync<Affairs>(Affair_URI, getmodel).Result;

                var viewAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                    (_httpClient.GetStringAsync(Affair_URI).Result)
                    .Where(a => a.projectid == getmodel.projectid);
                foreach (var affair in viewAffair.Where(a => a.typeofaffair == 0))
                {
                    if (affair.status != 4)
                    {
                        analyze++;
                    }
                }
                foreach (var affair in viewAffair.Where(a => a.typeofaffair == 1))
                {
                    if (affair.status != 4)
                    {
                        design++;
                    }
                }
                foreach (var affair in viewAffair.Where(a => a.typeofaffair == 2))
                {
                    if (affair.status != 4)
                    {
                        imple++;
                    }
                }
                foreach (var affair in viewAffair.Where(a => a.typeofaffair == 3))
                {
                    if (affair.status != 4)
                    {
                        test++;
                    }
                }
                foreach (var affair in viewAffair.Where(a => a.typeofaffair == 4))
                {
                    if (affair.status != 4)
                    {
                        deploy++;
                    }
                }
                if (design == 0 || analyze == 0)
                {
                    statusProject = 3;
                }
                if (imple == 0)
                {
                    statusProject = 4;
                }
                if (test == 0)
                {
                    statusProject = 5;
                }
                if ((analyze + design + imple + test + deploy) == 0)
                {
                    statusProject = 6;
                }
                if (deploy != 0)
                {
                    statusProject = 5;
                }
                if (test != 0)
                {
                    statusProject = 4;
                }
                if (imple != 0)
                {
                    statusProject = 3;
                }
                if (design != 0)
                {
                    statusProject = 2;
                }

                var viewProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                   (_httpClient.GetStringAsync(Project_URI).Result)
                   .Where(a => a.projectid == getmodel.projectid).SingleOrDefault();
                if (statusProject == 6)
                {
                    min = DateTime.Now.Ticks;
                    foreach (var affair in viewAffair)
                    {
                        if (affair.starttimeactual.Value.Ticks < min)
                        {
                            min = affair.starttimeactual.Value.Ticks;
                        }
                        if (affair.endtimeactual.Value.Ticks > max)
                        {
                            max = affair.endtimeactual.Value.Ticks;
                        }
                    }
                    if (max == 0)
                    {
                        max = min;
                    }
                }
                viewProject.status = statusProject;

                if (statusProject == 6)
                {
                    viewProject.startactual = new DateTime(min).AddHours(-7);
                    viewProject.endactual = new DateTime(max).AddHours(-7);
                }

                var modelP = _httpClient.PostAsJsonAsync<Projects>(Project_URI, viewProject).Result;

                if (modelA.IsSuccessStatusCode && modelP.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Affair", new { id = getmodel.projectid });
                }
                else
                {
                    ViewBag.Msg = "Error";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index", "Affair", new { id = getmodel.projectid });
        }

        public ActionResult Delete(int id)
        {
            var viewAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                   (_httpClient.GetStringAsync(Affair_URI).Result)
                   .Where(a => a.affairid == id).SingleOrDefault();

            var projectid = viewAffair.projectid;
            try
            {
                var model = _httpClient.DeleteAsync(Affair_URI + id).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Affair", new { id = projectid });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult getNotification()
        {
            int countNew = 0, countProcess = 0, countChecking = 0, countDebug = 0, countDone = 0;
            var getProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result)
                .Where(p => p.status != 0 && p.status != 6);
            if (getProject.Count() != 0)
            {
                var getAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                    (_httpClient.GetStringAsync(Affair_URI).Result);
                countNew = getAffair.Where(a => a.status == 0 || a.status == 5).Count();
                countProcess = getAffair.Where(a => a.status == 1).Count();
                countChecking = getAffair.Where(a => a.status == 3).Count();
                countDebug = getAffair.Where(a => a.status == 2).Count();
                countDone = getAffair.Where(a => a.status == 4).Count();
                return Json(new
                {
                    countNew = countNew,
                    countProcess = countProcess,
                    countChecking = countChecking,
                    countDebug = countDebug,
                    countDone = countDone
                });
            }
            else
            {
                return Json(new
                {
                    countNew = countNew,
                    countProcess = countProcess,
                    countChecking = countChecking,
                    countDebug = countDebug,
                    countDone = countDone
                });
            }
        }

        [HttpPost]
        public JsonResult changeChartAffair(int chartid)
        {
            Dictionary<string, int> affName = new Dictionary<string, int>();
            int news = 0, checknew = 0;
            int process = 0;
            int check = 0;
            int debug = 0;
            int done = 0;
            int action = 0;

            var viewAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result).Where(a => a.projectid == chartid);
            if (viewAffair.Count() > 0)
            {
                if ((viewAffair.Where(a => a.status == 0 || a.status == 5)).Count() > 0)
                {
                    foreach (var b in viewAffair.Where(a => a.status == 0))
                    {
                        news += b.affairtag.Value;
                    }
                }
                if ((viewAffair.Where(a => a.status == 3)).Count() > 0)
                {
                    foreach (var b in viewAffair.Where(a => a.status == 3))
                    {
                        check += b.affairtag.Value;
                    }
                }
                if ((viewAffair.Where(a => a.status == 1)).Count() > 0)
                {
                    foreach (var b in viewAffair.Where(a => a.status == 1))
                    {
                        process += b.affairtag.Value;
                    }
                }
                if ((viewAffair.Where(a => a.status == 2)).Count() > 0)
                {
                    foreach (var b in viewAffair.Where(a => a.status == 2))
                    {
                        debug += b.affairtag.Value;
                    }
                }
                if ((viewAffair.Where(a => a.status == 4)).Count() > 0)
                {
                    foreach (var b in viewAffair.Where(a => a.status == 4))
                    {
                        done += b.affairtag.Value;
                    }
                }
            }
            checknew = news + process + debug + check + done;
            if (checknew > 100)
            {
                news = news - (checknew - 100);
                affName.Add("NEW", news);
            }
            else
            {
                affName.Add("NEW", news);
            }
            action = news + process + debug + check + done;
            affName.Add("PROCESSING", process);
            affName.Add("DEBUG", debug);
            affName.Add("CHECKING", check);
            affName.Add("DONE", done + (100 - action));

            return Json(new
            {
                name = affName
            });
        }

        [HttpPost]
        public JsonResult changeTimeMember(int memberid, int projectid)
        {
            var datetimemax = new DateTime();
            var getProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result)
                .Where(p => p.projectid == projectid).SingleOrDefault();
            var maxtime = getProject.startplan.Ticks;
            datetimemax = getProject.startplan;
            var getAffairs = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(a => a.projectid == projectid && a.userid == memberid);

            if (getAffairs != null)
            {
                foreach(var affair in getAffairs)
                {
                    if(affair.endtimeplan.Ticks > maxtime)
                    {
                        datetimemax = affair.endtimeplan;
                        maxtime = affair.endtimeplan.Ticks;
                    }
                }
            }

            return Json(new
            {
                time = datetimemax.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
    }
}