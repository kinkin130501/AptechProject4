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
    public class ProjectController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string Project_URI = "http://localhost:9999/projects/";
        private string User_URI = "http://localhost:9999/users/";
        private string Affair_URI = "http://localhost:9999/affairs/";
        private string Doc_URI = "http://localhost:9999/documents/";
        private string PGroup_URI = "http://localhost:9999/pgroups/";
        private string Group_URI = "http://localhost:9999/groups/";
        private string GroupUser_URI = "http://localhost:9999/groupusers/";
        // GET: DocumentController
        public ActionResult Index()
        {
            var userid = HttpContext.Session.GetCurrentAuthentication().UserId;
            var department = HttpContext.Session.GetCurrentAuthentication().department;

            var viewAffairs = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result).Reverse();
            var viewAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(m => m.status == 4);
            List<int> projectid = new List<int>();
            List<Data.Models.Projects> projectNew = new List<Data.Models.Projects>();
            List<Data.Models.Projects> projectProcess = new List<Data.Models.Projects>();
            List<Data.Models.Projects> projectDone = new List<Data.Models.Projects>();
            List<Data.Models.Projects> projectMaintain = new List<Data.Models.Projects>();


            var viewProjectNewTemp = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result).Where(p => p.status == 0);
            var viewProjectProcessTemp = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result).Where(p => p.status != 0 && p.status != 6 && p.status != 7);
            var viewProjectDoneTemp = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result).Where(p => p.status == 6);
            var viewProjectMaintainTemp = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result).Where(p => p.status == 7);
            var viewUser = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>(_httpClient.GetStringAsync(User_URI).Result);

            if (department == (int)SystemEnum.RoleNumber.Leader)
            {
                projectNew = viewProjectNewTemp.Where(p => p.leaderid == userid).ToList();
                projectProcess = viewProjectProcessTemp.Where(p => p.leaderid == userid).ToList();
                projectDone = viewProjectDoneTemp.Where(p => p.leaderid == userid).ToList();
                projectMaintain = viewProjectMaintainTemp.Where(p => p.leaderid == userid).ToList();
            }
            else if (department == (int)SystemEnum.RoleNumber.Partner || department == (int)SystemEnum.RoleNumber.Developer)
            {
                foreach (var affair in viewAffairs)
                {
                    if (affair.userid == userid)
                    {
                        projectid.Add(affair.projectid.Value);
                    }
                }
                foreach (var id in projectid.Distinct().ToList())
                {
                    if (viewProjectNewTemp.Where(p => p.projectid == id).SingleOrDefault() != null)
                    {
                        projectNew.Add(viewProjectNewTemp.Where(p => p.projectid == id).SingleOrDefault());
                    }
                    if (viewProjectProcessTemp.Where(p => p.projectid == id).SingleOrDefault() != null)
                    {
                        projectProcess.Add(viewProjectProcessTemp.Where(p => p.projectid == id).SingleOrDefault());
                    }
                    if (viewProjectDoneTemp.Where(p => p.projectid == id).SingleOrDefault() != null)
                    {
                        projectDone.Add(viewProjectDoneTemp.Where(p => p.projectid == id).SingleOrDefault());
                    }
                    if (viewProjectMaintainTemp.Where(p => p.projectid == id).SingleOrDefault() != null)
                    {
                        projectMaintain.Add(viewProjectMaintainTemp.Where(p => p.projectid == id).SingleOrDefault());
                    }
                }
            }
            else if (department == (int)SystemEnum.RoleNumber.PM)
            {
                projectNew = viewProjectNewTemp.ToList();
                projectProcess = viewProjectProcessTemp.ToList();
                projectDone = viewProjectDoneTemp.ToList();
                projectMaintain = viewProjectMaintainTemp.ToList();
            }

            ViewBag.viewAffairs = viewAffairs;
            ViewBag.viewAffair = viewAffair;
            ViewBag.viewProjectNew = projectNew.ToList();
            ViewBag.viewProjectProcess = projectProcess.ToList();
            ViewBag.viewProjectDone = projectDone.ToList();
            ViewBag.viewProjectMaintain = projectMaintain.ToList();
            ViewBag.viewUser = viewUser;

            return View();
        }

        public ActionResult Detail(int id)
        {
            int count = 0;
            List<int?> memberid = new List<int?>();
            var viewAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(a => a.projectid == id);
            var viewProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result)
                .Where(m => m.projectid == id).SingleOrDefault();
            var viewUser = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>(_httpClient.GetStringAsync(User_URI).Result);
            foreach (var a in viewUser)
            {
                if (a.userid == viewProject.leaderid)
                {
                    ViewData["leader"] = a.username;
                }
            }
            ViewBag.affair = viewAffair;
            ViewBag.user = viewUser;
            return View(viewProject);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewGroup = JsonConvert.DeserializeObject<IEnumerable<Groups>>
                (_httpClient.GetStringAsync(Group_URI).Result).Where(g => g.isdeleted == false);
            var viewDoc = JsonConvert.DeserializeObject<IEnumerable<Documents>>(_httpClient.GetStringAsync(Doc_URI).Result);
            var userview = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>(_httpClient.GetStringAsync(User_URI).Result);
            var listLeader = userview.Where(m => m.islead == true).ToList();
            ViewBag.group = viewGroup;
            ViewBag.listLeader = listLeader;
            ViewBag.viewDoc = viewDoc;
            return View();
        }

        //// POST: DocumentController/Create
        [HttpPost]
        public ActionResult Create(Projects getmodel, int getLeadGroup)
        {
            try
            {
                getmodel.status = 0;
                getmodel.startplan = getmodel.startplan.AddHours(-7);
                getmodel.endplan = getmodel.endplan.AddHours(-7);
                var model = _httpClient.PostAsJsonAsync<Projects>(Project_URI, getmodel).Result;

                var pgroup = new Projectgroup();
                var view = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                    (_httpClient.GetStringAsync(Project_URI).Result)
                    .OrderByDescending(p => p.projectid).First();
                pgroup.projectid = view.projectid;
                pgroup.groupid = getLeadGroup;
                var mod = _httpClient.PostAsJsonAsync<Projectgroup>(PGroup_URI, pgroup).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Project");
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
            return RedirectToAction("Index", "Project");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
               (_httpClient.GetStringAsync(Project_URI).Result)
               .Where(m => m.projectid == id).SingleOrDefault();

            var viewDoc = JsonConvert.DeserializeObject<IEnumerable<Documents>>(_httpClient.GetStringAsync(Doc_URI).Result);

            var viewUser = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(User_URI).Result);
            foreach (var user in viewUser)
            {
                if (user.userid == viewProject.leaderid)
                {
                    ViewData["leader"] = user.username;
                    ViewData["leaderid"] = user.userid;
                }
            }

            foreach (var doc in viewDoc)
            {
                if (doc.docid == viewProject.docid)
                {
                    ViewData["doc"] = doc.title;
                    ViewData["docid"] = doc.docid;
                }
            }
            var viewPGroup = JsonConvert.DeserializeObject<IEnumerable<Projectgroup>>
                (_httpClient.GetStringAsync(PGroup_URI).Result)
                .Where(p => p.projectid == viewProject.projectid).SingleOrDefault();
            var viewGroup = JsonConvert.DeserializeObject<IEnumerable<Groupuser>>
                (_httpClient.GetStringAsync(GroupUser_URI).Result)
                .Where(p => p.groupid == viewPGroup.groupid && p.isleader == true).ToList();
            List<FourN.Data.Models.User> leader = new List<FourN.Data.Models.User>();
            foreach (var g in viewGroup)
            {
                foreach (var p in viewUser)
                {
                    if (g.userid == p.userid)
                    {
                        leader.Add(p);
                    }
                }
            }
            //var listLeader = viewUser.Where(m => m.islead == true).ToList();
            ViewBag.listLeader = leader;
            ViewBag.doc = viewDoc;
            return View(viewProject);
        }

        //// POST: DocumentController/Create
        [HttpPost]
        public ActionResult Edit(Projects getmodel, int checkboxBID)
        {
            decimal duration = 0;
            decimal temp = 0;

            var viewAllAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result)
                .Where(a => a.projectid == getmodel.projectid);

            foreach (var affair in viewAllAffair)
            {
                decimal starttime, endtime;
                starttime = affair.starttimeplan.Ticks / 10000000;
                endtime = affair.endtimeplan.Ticks / 10000000;
                duration += (endtime - starttime) / 3600;
            }
            try
            {
                if (checkboxBID == 1)
                {
                    getmodel.status = 1;
                    foreach (var affair in viewAllAffair)
                    {
                        decimal starttime, endtime;
                        starttime = affair.starttimeplan.Ticks / 10000000;
                        endtime = affair.endtimeplan.Ticks / 10000000;

                        temp = ((endtime - starttime) / (36 * duration));
                        affair.affairtag = (int)Math.Round(temp);
                        var modelAffair = _httpClient.PostAsJsonAsync<Affairs>(Affair_URI, affair).Result;
                    }
                }
                else if (checkboxBID == 7)
                {
                    getmodel.status = 7;
                }
                else if (getmodel.status >= 1 && getmodel.status < 7)
                {
                    foreach (var affair in viewAllAffair)
                    {
                        decimal starttime, endtime;
                        starttime = affair.starttimeplan.Ticks / 10000000;
                        endtime = affair.endtimeplan.Ticks / 10000000;

                        temp = ((endtime - starttime) / (36 * duration));
                        affair.affairtag = (int)Math.Round(temp);
                        var modelAffair = _httpClient.PostAsJsonAsync<Affairs>(Affair_URI, affair).Result;
                    }
                }

                getmodel.startplan = getmodel.startplan.AddHours(-7);
                getmodel.endplan = getmodel.endplan.AddHours(-7);
                getmodel.startactual = getmodel.startactual?.AddHours(-7);
                getmodel.endactual = getmodel.endactual?.AddHours(-7);

                var model = _httpClient.PostAsJsonAsync<Projects>(Project_URI, getmodel).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Project");
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
            return RedirectToAction("Index", "Project");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var viewAffairs = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                (_httpClient.GetStringAsync(Affair_URI).Result).Where(a => a.projectid == id);
                if (viewAffairs.Count() > 0)
                {
                    return RedirectToAction("Error", "Project");
                }
                else
                {
                    var model = _httpClient.DeleteAsync(Project_URI + id).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Project");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public JsonResult changeChartProject()
        {
            Dictionary<string, int> proName = new Dictionary<string, int>();
            var viewProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result).Where(p => p.status != 0 && p.status != 6);

            if (viewProject.Count() > 0)
            {
                foreach (var project in viewProject)
                {
                    int proPercent = 0;
                    var viewAffairs = JsonConvert.DeserializeObject<IEnumerable<Affairs>>
                    (_httpClient.GetStringAsync(Affair_URI).Result)
                    .Where(a => a.projectid == project.projectid);
                    if (viewAffairs.Count() > 0)
                    {
                        var viewStatus = viewAffairs.Where(b => b.status == 4);
                        if (viewStatus.Count() > 0)
                        {
                            foreach (var v in viewStatus)
                            {
                                proPercent += v.affairtag.Value;
                            }
                        }
                        else
                        {
                            proPercent = 0;
                        }
                        proName.Add(project.projectcode, proPercent);
                    }
                    else
                    {
                        proName.Add(project.projectcode, 0);
                    }
                }
                if (proName.Count() > 10)
                {
                    proName.Reverse().ToDictionary(x => x.Key, x => x.Value);
                }
            }
            else
            {
                proName.Add("NO PROJECT IS PROCESSING", 50);
            }
            return Json(new
            {
                name = proName
            });
        }

        public JsonResult changeCode(string name = "")
        {
            bool status = true;
            var viewProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>
                (_httpClient.GetStringAsync(Project_URI).Result);
            foreach (var pro in viewProject)
            {
                if (pro.projectcode.Trim().ToLower() == name.Trim().ToLower())
                {
                    status = false;
                }
            }
            return Json(new
            {
                status = status
            });
        }

        [HttpPost]
        public JsonResult changeLeadGroup(int groupid)
        {
            List<FourN.Data.Models.User> users = new List<FourN.Data.Models.User>();
            var viewGroup = JsonConvert.DeserializeObject<IEnumerable<Groupuser>>
                (_httpClient.GetStringAsync(GroupUser_URI).Result)
                .Where(g => g.groupid == groupid && g.isleader == true);
            var viewUser = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(User_URI).Result).Where(u => u.islead == true && u.isdeleted == false);
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
            return Json(new
            {
                lead = users
            });
        }
    }
}