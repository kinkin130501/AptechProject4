using FourN.Data;
using FourN.Data.ViewModel;
using FourN.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Partner.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Partner.Controllers
{
    public class PartnerController : Controller
    {
        private readonly FourNDbContext _context;
        private readonly IDepartmentService _deparmentService;
        public PartnerController(FourNDbContext context, IDepartmentService deparmentService)
        {
            _context = context;
            _deparmentService = deparmentService;
        }

        public IActionResult Index()
        {
            var listPartner = _deparmentService.findAll();

            return View(listPartner);
        }
        public ViewResult Detail(int id)
        {
            var deparment = _deparmentService.findOne(id);
            return View(deparment);
        }
        public ViewResult Apply(int id)
        {
            var view = new ApplyModel();
            view.DepartmentId = id;
            return View(view);
        }
        [HttpPost]
        public IActionResult Apply(ApplyModel model)
        {
            model.FileURL = UploadImage(model.File).Result;
            var result = _deparmentService.ApplyPartner(model).Result;
            ViewBag.msg = result.SuccessMessage;
            ViewBag.error = result.ErrorMessage;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private async Task<string> UploadImage(IFormFile file)
        {
            string path = Path.Combine("wwwroot/Partner", file.FileName);
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

            await file.CopyToAsync(stream);
            var url = "/Partner/" + file.FileName;
            return url;
        }
    }
}
