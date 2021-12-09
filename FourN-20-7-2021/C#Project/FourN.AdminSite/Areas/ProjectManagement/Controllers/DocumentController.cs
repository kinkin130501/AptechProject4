using FourN.Data.Models;
using FourN.Data.ViewModel;
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

namespace FourN.AdminSite.Areas.ProjectManagement.Controllers
{
    [Area("ProjectManagement")]
    public class DocumentController : Controller
    {

        private readonly HttpClient _httpClient = new HttpClient();
        private string Document_URI = "http://localhost:9999/documents/";
        private string User_URI = "http://localhost:9999/users/";

        // GET: DocumentController
        public ActionResult Index()
        {
            var view = JsonConvert.DeserializeObject<IEnumerable<Documents>>(_httpClient.GetStringAsync(Document_URI).Result);
            return View(view);
        }

        // GET: DocumentController/Create
        [HttpGet]
        public IActionResult Create()
        {
            var userview = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User >>(_httpClient.GetStringAsync(User_URI).Result);
            var listLeader = userview.Where(m => m.islead == true).ToList();
            ViewBag.listLeader = listLeader;
            return View();
        }

        //// POST: DocumentController/Create
        [HttpPost]
        public IActionResult Create(DocumentModel getmodel, IFormFile file)
        {
            var userview = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>(_httpClient.GetStringAsync(User_URI).Result);

            //Documents document = new Documents();
            string fileName = "Chưa get được file";
            try
            {
                //string filePath = Path.Combine("wwwroot/files", file.FileName);
                //var stream = new FileStream(filePath, FileMode.Create);
                //file.CopyToAsync(stream);
                int authorid = getmodel.authorrole.Value;
                var Leader = userview.Where(m => m.userid == authorid).SingleOrDefault();
                getmodel.authorrole = Leader.userid;
                getmodel.authorname = Leader.username;
                fileName = UploadFile(getmodel.files).Result;

                var modelupdate = new Documents()
                {
                    authorrole = getmodel.authorrole,
                    authorname = getmodel.authorname,
                    files = fileName,
                    note = getmodel.note,
                    title = getmodel.title,
                };
                var model = _httpClient.PostAsJsonAsync<Documents>(Document_URI, modelupdate).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Document");
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
            return RedirectToAction("Index", "Document");
        }


        //// POST: DocumentController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _httpClient.DeleteAsync(Document_URI + id).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Document");
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
        private async Task<string> UploadFile(IFormFile file)
        {
            string path = Path.Combine("wwwroot/Doc", file.FileName);
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

            await file.CopyToAsync(stream);
            var url = "/Doc/" + file.FileName;
            return url;
        }
    }
}
