using FourN.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourN.AdminSite.Areas.Backup.Controllers
{
    [Area("Backup")]
    public class BackupController : Controller
    {
        private readonly IDatabaseService _databaseService;
        public BackupController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost()]
        public IActionResult CreateBackup(string pathFolder)
        {
            var result = _databaseService.CreateBackup(pathFolder).Result;
            return Json(new { result = result });
        }
    }
}
