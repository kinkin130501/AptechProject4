using FourN.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FourN.AdminSite.Areas.KOPC.Controllers
{
    [Area("KOPC")]
    public class RequestpmController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string BASE_URI = "http://localhost:9999/requests/";
        private string BASE_URI2 = "http://localhost:9999/users/";
        private string BASE_URI3 = "http://localhost:9999/affairs/";
        private string BASE_URI4 = "http://localhost:9999/projects/";
        public IActionResult Index()
        {
            var view = JsonConvert.DeserializeObject<IEnumerable<Request>>(_httpClient.GetStringAsync(BASE_URI).Result);
            ViewBag.requestList = view;
            ViewBag.userList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI2).Result).ToList();
            ViewBag.affairList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Affairs>>(_httpClient.GetStringAsync(BASE_URI3).Result).ToList();
            ViewBag.projectList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Projects>>(_httpClient.GetStringAsync(BASE_URI4).Result).ToList();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Request request, int rid, Affairs affairs)
        {
            try
            {
                DateTime now = DateTime.Now;
                request.sentdate = now.AddHours(-7);
                request.status = 0;
                request.reply = false;
                if(request.moretime != null)
                {
                    request.moretime = request.moretime.Value.AddHours(-7);
                }
                var model = _httpClient.PostAsJsonAsync<Request>(BASE_URI, request).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;

            }
            return View();
        }

        public IActionResult Reply(int id)
        {
            var result = JsonConvert.DeserializeObject<Request>
                 (_httpClient.GetStringAsync(BASE_URI + id).Result);
            ViewBag.userList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI2).Result).ToList();
            ViewBag.affairList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Affairs>>(_httpClient.GetStringAsync(BASE_URI3).Result).ToList();
            ViewBag.projectList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Projects>>(_httpClient.GetStringAsync(BASE_URI4).Result).ToList();
            return View(result);
        }

        [HttpPost]
        public IActionResult Reply(Request request, int rid, DateTime sentdate, DateTime moretime)
        {
            try
            {
                request.reply = true;
                var model = _httpClient.PostAsJsonAsync<Request>(BASE_URI, request).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;

            }
            return View();

        }

        public JsonResult getTime(int name) {
            var getAffair = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Affairs>>
                (_httpClient.GetStringAsync(BASE_URI3).Result).Where(a => a.affairid == name).SingleOrDefault();
            var getTimeAffair = getAffair.endtimeplan;
            return Json(new
            {
                atime = getTimeAffair
            });
        }

        public JsonResult getProject(int name)
        {
            var getAffair = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Affairs>>
                (_httpClient.GetStringAsync(BASE_URI3).Result).Where(a => a.projectid == name && a.status != 4);
            return Json(new
            {
                task = getAffair
            });
        }
    }
}
