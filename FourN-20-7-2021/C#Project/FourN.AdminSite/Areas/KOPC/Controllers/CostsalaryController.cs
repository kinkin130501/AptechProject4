using FourN.Data.Models;
using FourN.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FourN.AdminSite.Areas.KOPC.Controllers
{
    [Area("KOPC")]
    public class CostsalaryController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string BASE_URI = "http://localhost:9999//affairs/";
        private string BASE_URI2 = "http://localhost:9999//projects/";
        private string BASE_URI3 = "http://localhost:9999/users/";
        private string BASE_URI4 = "http://localhost:9999/requests/";

        public IActionResult Index()
        {
            var view = JsonConvert.DeserializeObject<IEnumerable<Projects>>(_httpClient.GetStringAsync(BASE_URI2).Result);
            ViewBag.affairList = JsonConvert.DeserializeObject<IEnumerable<Affairs>>(_httpClient.GetStringAsync(BASE_URI).Result);
            ViewBag.userList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI3).Result);
            ViewBag.requestList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Request>>(_httpClient.GetStringAsync(BASE_URI4).Result);

            var objectProject = JsonConvert.DeserializeObject<IEnumerable<Projects>>(_httpClient.GetStringAsync(BASE_URI2).Result);
            var objectTask = JsonConvert.DeserializeObject<IEnumerable<Affairs>>(_httpClient.GetStringAsync(BASE_URI).Result);
            var objectUser = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI3).Result);
            var objectRequest = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Request>>(_httpClient.GetStringAsync(BASE_URI4).Result);
            return View(view);
        }

        public IActionResult DetailProject(int id)
        {
            var view = JsonConvert.DeserializeObject<Projects>
                 (_httpClient.GetStringAsync(BASE_URI2 + id).Result);
            var affairsList = JsonConvert.DeserializeObject<IEnumerable<Affairs>>(_httpClient.GetStringAsync(BASE_URI).Result)
                .Where(a=>a.projectid == view.projectid).ToList();
            var userList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(BASE_URI3).Result);
            var requestList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Request>>
                (_httpClient.GetStringAsync(BASE_URI4).Result);

            ViewBag.affairList = affairsList;
            ViewBag.userList = userList;
            ViewBag.requestList = requestList;
            

            List<int> listAttend = new List<int>();
            List<int> list = new List<int>();

            foreach (var item in affairsList)
            {
                if (item.projectid == view.projectid)
                {
                    foreach (var itemUser in userList)
                    {
                        if (itemUser.userid == item.userid)
                        {
                            listAttend.Add(itemUser.userid);
                        }
                    }
                }
            }
            list = listAttend.Distinct().ToList();
            ViewBag.listUser = list;

            TimeSpan timeStart = TimeSpan.Parse("9:00"), timeEnd = TimeSpan.Parse("18:00"),
            timeMid = TimeSpan.Parse("12:00");
            DateTime startTask, endTask, startActual, endActual;
            int durationStart = 0, durationMid = 0, durationEnd = 0, totalCostProject = 0;
            int durationStartActual = 0, durationMidActual = 0, durationEndActual = 0;
            int totalHourTask = 0, totalHourTaskActual = 0;
            long moneyrequest = 0;
            double ot = 0;
            List<CostTaskViewModel> viewModels = new List<CostTaskViewModel>();
            CostProjectViewModel viewCostModel = new CostProjectViewModel();

            viewCostModel.projectid = view.projectid;
            viewCostModel.projectname = view.projectname;
            viewCostModel.projectcode = view.projectcode;
            viewCostModel.startplan = view.startplan;
            viewCostModel.endplan = view.endplan;
            viewCostModel.startactual = view.startactual;
            viewCostModel.endactual = view.endactual;




            foreach (var itemTask in affairsList.Where(a=> a.projectid == view.projectid))
            {
                CostTaskViewModel viewModel = new CostTaskViewModel();
                viewModel.affairname = itemTask.affairname;
                viewModel.starttimeplan = itemTask.starttimeplan;
                viewModel.endtimeplan = itemTask.endtimeplan;
                viewModel.starttimeactual = itemTask.starttimeactual;
                viewModel.endtimeactual = itemTask.endtimeactual;
                viewModel.typeofaffair = itemTask.typeofaffair;

                int days = 0, totalMidTask = 0, daysActual = 0, totalMidTaskActual = 0;
                startTask = itemTask.starttimeplan;
                endTask = itemTask.endtimeplan;
                startActual = itemTask.starttimeactual.Value;
                endActual = itemTask.endtimeactual.Value;
                durationStart = durationMid = durationEnd = 0;
                durationStartActual = durationMidActual = durationEndActual = 0;

                //bat dau - ket thuc trong cung ngay
                if (startTask.DayOfYear == endTask.DayOfYear)
                {
                    //bat dau truoc 12h
                    if(startTask.Hour < 12)
                    {
                        //ket thuc truoc 12h
                        if (endTask.Hour <= 12)
                        {
                            durationMid = endTask.Hour - startTask.Hour;
                        }
                        //ket thuc sau 12h va truoc 18h
                        else if (endTask.TimeOfDay > timeMid )
                        {
                            durationMid = (12 - startTask.Hour) + (endTask.Hour - 13);
                        }
                    }
                    //bat dau sau 12h
                    else if (startTask.Hour >= 12 )
                    {
                        //ket thuc sau 12h
                        if (endTask.Hour > 12)
                        {
                            durationMid = endTask.Hour - startTask.Hour;
                        }
                    }
                    totalHourTask = durationMid;
                }

                //bat dau ket thuc # ngay
                else
                {
                    //tinh ngay dau tien
                    //bat dau truoc 12h
                    if(startTask.Hour < 12)
                    {
                        durationStart = 12 - startTask.Hour + 5;
                    }
                    //bat dau sau 12h
                    else
                    {
                        durationStart = 18 - startTask.Hour; 
                    }
                    //ngay cuoi cung
                    //ket thuc truoc 12h
                    if (endTask.Hour <= 12)
                    {
                        durationEnd = endTask.Hour - 9;
                    }
                    //ket thuc sau 12h
                    else
                    {
                        durationEnd = 3 + endTask.Hour - 13;
                    }
                    //tinh ngay o giua
                    for (DateTime date = startTask; date.DayOfYear < endTask.DayOfYear; date = date.AddDays(1))
                    {

                        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            
                        }
                        else
                        {
                            days++;
                        }
                    }//end for
                    totalMidTask = ((days - 1) * 8);
                    totalHourTask = totalMidTask + durationStart + durationEnd;
                }//end else
                //task name, gio bat dau, ket thuc, tong h ly thuyet, thuc te, tong phi phat sinh,
                //tong tien(phi phat sinh + phi nhan cong)
                viewModel.totalPlan = totalHourTask;

                //bat dau - ket thuc trong cung ngay
                if (startActual.DayOfYear == endActual.DayOfYear)
                {
                    //bat dau truoc 12h
                    if (startActual.Hour < 12)
                    {
                        //ket thuc truoc 12h
                        if (endActual.Hour <= 12)
                        {
                            durationMidActual = endActual.Hour - startActual.Hour;
                        }
                        //ket thuc sau 12h va truoc 18h
                        else if (endActual.Hour > 12)
                        {
                            durationMidActual = (12 - startActual.Hour) + (endActual.Hour - 13);
                        }
                    }
                    //bat dau sau 12h
                    else if (startActual.Hour >= 12)
                    {
                        //ket thuc sau 12h
                        if (endActual.Hour > 12)
                        {
                            durationMidActual = endActual.Hour - startActual.Hour;
                        }
                    }
                    totalHourTaskActual = durationMidActual;
                }

                //bat dau ket thuc # ngay
                else
                {
                    //tinh ngay dau tien
                    //bat dau truoc 12h
                    if (startActual.Hour < 12)
                    {
                        durationStartActual = 12 - startActual.Hour + 5;
                    }
                    //bat dau sau 12h
                    else
                    {
                        durationStartActual = 18 - startActual.Hour;
                    }
                    //ngay cuoi cung
                    //ket thuc truoc 12h
                    if (endActual.Hour <= 12)
                    {
                        durationEndActual = endActual.Hour - 9;
                    }
                    //ket thuc sau 12h
                    else
                    {
                        durationEndActual = 3 + endActual.Hour - 13;
                    }
                    //tinh ngay o giua
                    for (DateTime date = startActual; date.DayOfYear <= endActual.DayOfYear; date = date.AddDays(1))
                    {

                        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        {

                        }
                        else
                        {
                            daysActual++;
                        }
                    }//end for
                    totalMidTaskActual = ((daysActual - 2) * 8);
                    totalHourTaskActual = totalMidTaskActual + durationStartActual + durationEndActual;
                }//end else
                //task name, gio bat dau, ket thuc, tong h ly thuyet, thuc te, tong phi phat sinh,
                //tong tien(phi phat sinh + phi nhan cong)
                viewModel.totalActual = totalHourTaskActual;
                //tinh request
                foreach (var itemRequest in requestList.Where(a=> a.taskid == itemTask.affairid))
                {
                    if(itemRequest.requestname == "RequestMoney" && itemRequest.status == 1)
                    {
                        moneyrequest = (long)itemRequest.requestmoney;
                    }
                    else if (itemRequest.requestname == "Overtime" && itemRequest.status == 1)
                    {
                        ot = (long)itemRequest.totaltime;
                    }
                }
                viewModel.moneyRequest = (int)moneyrequest;
                viewModel.moneyOvertime = (int)ot;
                //tinh tien user
                    var itemUser = userList.SingleOrDefault(a=>a.userid == itemTask.userid);
                    viewModel.User = itemUser;
                    int costTask = 0, costOT = 0;
                    if (itemUser.isfreelancer == true)
                    {
                        costTask = totalHourTaskActual * 80000;
                    }
                    else if (itemUser.isemployee == true)
                    {
                        costTask = totalHourTaskActual * 100000;
                    }
                    else if (itemUser.islead == true)
                    {
                        costTask = totalHourTaskActual * 200000;
                    }
                    else if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                    {
                        costTask = totalHourTaskActual * 300000;
                    }
                    viewModel.costUser = costTask;

                if (itemUser.isemployee == true)
                {
                    costOT = (int)(ot * 100000 * 2);
                }
                else if (itemUser.islead == true)
                {
                    costOT = (int)(ot * 200000 * 2);
                }
                else if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                {
                    costOT = (int)(ot * 300000 * 2);
                }
                viewModel.moneyOvertime = costOT;
                viewModel.totalCost = costTask + (int)(costOT + moneyrequest);
                totalCostProject += costTask + (int)(costOT + moneyrequest);
                viewModels.Add(viewModel);
            }//end foreach
            viewCostModel.totalCost = totalCostProject;
            viewCostModel.CostTaskViewModel = viewModels;
            
            return View(viewCostModel);
        }

        [HttpGet]
        public IActionResult ExportBiddingExcel(int id)
        {
            int totalTask = 0, hoursc = 0;
            TimeSpan timeStart = TimeSpan.Parse("9:00"), timeEnd = TimeSpan.Parse("18:00"),
            timeMid = TimeSpan.Parse("12:00");
            long costplanc = 0, gio1 = 0;
            var viewAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>(_httpClient.GetStringAsync(BASE_URI).Result);
            var viewProject = JsonConvert.DeserializeObject<Projects>
                 (_httpClient.GetStringAsync(BASE_URI2 + id).Result);
            var userList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(BASE_URI3).Result);
            var requestList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Request>>
                (_httpClient.GetStringAsync(BASE_URI4).Result);
            int rowIndex = 3;
            ExcelRange cell;
            ExcelFill fill;
            Border border;

            using (var workbook = new ExcelPackage())
            {
                var sheet = workbook.Workbook.Worksheets.Add("Project");
                sheet.Name = "Project Report";
                sheet.Column(4).Width = 25;
                sheet.Column(5).Width = 25;
                sheet.Column(6).Width = 25;
                sheet.Column(7).Width = 25;
                sheet.Column(8).Width = 25;
                sheet.Column(9).Width = 25;

                #region Report Header
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                sheet.Cells[rowIndex, 5, rowIndex, 9].Merge = true;
                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Project Name: " + viewProject.projectname;
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 18;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowIndex = rowIndex + 1;

                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                sheet.Cells[rowIndex, 5, rowIndex, 9].Merge = true;
                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Project Code: " + viewProject.projectcode;
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 15;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowIndex = rowIndex + 1;

                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Start (Plan): ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = viewProject.startplan.ToString("dd/MM/yyyy");
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "Note: ";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "Cost Plan Equal: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;

                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "End (Plan): ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = viewProject.endplan.ToString("dd/MM/yyyy");
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "Total Plan * 500,000";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 2;

                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Task Name: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "Total Plan: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "Cost Plan: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "Estimated Cost: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "Note: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table header
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 1: Analisys";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    long costplan1 = 0;
                    DateTime startTime, endTime;
                    int hours = 0, daysx = 0, dayss = 0;
                    double hFull, hCFull, hOFull;
                    long totalTimeUser = 0;
                    if (itemTask.typeofaffair == 0)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 7];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 8];
                        foreach (var itemUser in userList)
                        {
                            if (itemTask.userid == itemUser.userid)
                            {
                                startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                                endTime = DateTime.Parse(itemTask.endtimeplan.ToString());

                                for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                                {
                                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                    {

                                    }
                                    else
                                    {
                                        hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                        if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay <= timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                        }
                                        else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                            && startTime.TimeOfDay > timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                        }
                                        else
                                        {
                                            hCFull = hFull;
                                        }
                                        if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay > timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                        }
                                        else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay <= timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                        }
                                        else
                                        {
                                            hOFull = hFull;
                                        }
                                        dayss++;
                                        hours = (int)(hCFull + hOFull + (int)(dayss - 2) * hFull);
                                    }

                                }

                                if (itemUser.isemployee == true)
                                {
                                    totalTimeUser = hours * 100000;                
                                 }
                                else if (itemUser.islead == true)
                                {
                                    totalTimeUser = hours * 200000;
                                }
                                else if (itemUser.isfreelancer == true)
                                {
                                    totalTimeUser = hours * 80000;                   
                                }
                                else if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                                {
                                    totalTimeUser = hours * 300000;                 
                                }
                            }
                        }
                        cell.Value = string.Format("{0:#,##0.00}", totalTimeUser) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 9];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Table header
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 2: Design";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    long costplan1 = 0;
                    DateTime startTime, endTime;
                    int hours = 0, daysx = 0, dayss = 0;
                    double hFull, hCFull, hOFull;
                    long totalTimeUser = 0;
                    if (itemTask.typeofaffair == 1)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 7];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 8];
                        foreach (var itemUser in userList)
                        {
                            if (itemTask.userid == itemUser.userid)
                            {
                                startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                                endTime = DateTime.Parse(itemTask.endtimeplan.ToString());

                                for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                                {
                                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                    {

                                    }
                                    else
                                    {
                                        hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                        if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay <= timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                        }
                                        else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                            && startTime.TimeOfDay > timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                        }
                                        else
                                        {
                                            hCFull = hFull;
                                        }
                                        if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay > timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                        }
                                        else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay <= timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                        }
                                        else
                                        {
                                            hOFull = hFull;
                                        }
                                        dayss++;
                                        hours = (int)(hCFull + hOFull + (int)(dayss - 2) * hFull);
                                    }

                                }

                                if (itemUser.isemployee == true)
                                {
                                    totalTimeUser = hours * 100000;
                                }
                                else if (itemUser.islead == true)
                                {
                                    totalTimeUser = hours * 200000;
                                }
                                else if (itemUser.isfreelancer == true)
                                {
                                    totalTimeUser = hours * 80000;
                                }
                                else if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                                {
                                    totalTimeUser = hours * 300000;
                                }
                            }
                        }
                        cell.Value = string.Format("{0:#,##0.00}", totalTimeUser) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 9];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Table header
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 3: Implementation";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    long costplan1 = 0;
                    DateTime startTime, endTime;
                    int hours = 0, daysx = 0, dayss = 0;
                    double hFull, hCFull, hOFull;
                    long totalTimeUser = 0;
                    if (itemTask.typeofaffair == 2)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 7];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 8];
                        foreach (var itemUser in userList)
                        {
                            if (itemTask.userid == itemUser.userid)
                            {
                                startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                                endTime = DateTime.Parse(itemTask.endtimeplan.ToString());

                                for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                                {
                                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                    {

                                    }
                                    else
                                    {
                                        hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                        if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay <= timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                        }
                                        else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                            && startTime.TimeOfDay > timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                        }
                                        else
                                        {
                                            hCFull = hFull;
                                        }
                                        if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay > timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                        }
                                        else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay <= timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                        }
                                        else
                                        {
                                            hOFull = hFull;
                                        }
                                        dayss++;
                                        hours = (int)(hCFull + hOFull + (int)(dayss - 2) * hFull);
                                    }

                                }

                                if (itemUser.isemployee == true)
                                {
                                    totalTimeUser = hours * 100000;
                                }
                                else if (itemUser.islead == true)
                                {
                                    totalTimeUser = hours * 200000;
                                }
                                else if (itemUser.isfreelancer == true)
                                {
                                    totalTimeUser = hours * 80000;
                                }
                                else if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                                {
                                    totalTimeUser = hours * 300000;
                                }
                            }
                        }
                        cell.Value = string.Format("{0:#,##0.00}", totalTimeUser) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 9];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Table header
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 4: Testing";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    long costplan1 = 0;
                    DateTime startTime, endTime;
                    int hours = 0, daysx = 0, dayss = 0;
                    double hFull, hCFull, hOFull;
                    long totalTimeUser = 0;
                    if (itemTask.typeofaffair == 3)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 7];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 8];
                        foreach (var itemUser in userList)
                        {
                            if (itemTask.userid == itemUser.userid)
                            {
                                startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                                endTime = DateTime.Parse(itemTask.endtimeplan.ToString());

                                for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                                {
                                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                    {

                                    }
                                    else
                                    {
                                        hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                        if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay <= timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                        }
                                        else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                            && startTime.TimeOfDay > timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                        }
                                        else
                                        {
                                            hCFull = hFull;
                                        }
                                        if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay > timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                        }
                                        else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay <= timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                        }
                                        else
                                        {
                                            hOFull = hFull;
                                        }
                                        dayss++;
                                        hours = (int)(hCFull + hOFull + (int)(dayss - 2) * hFull);
                                    }

                                }

                                if (itemUser.isemployee == true)
                                {
                                    totalTimeUser = hours * 100000;
                                }
                                else if (itemUser.islead == true)
                                {
                                    totalTimeUser = hours * 200000;
                                }
                                else if (itemUser.isfreelancer == true)
                                {
                                    totalTimeUser = hours * 80000;
                                }
                                else if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                                {
                                    totalTimeUser = hours * 300000;
                                }
                            }
                        }
                        cell.Value = string.Format("{0:#,##0.00}", totalTimeUser) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 9];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Table header
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 5: Deployment";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    long costplan1 = 0;
                    DateTime startTime, endTime;
                    int hours = 0, daysx = 0, dayss = 0;
                    double hFull, hCFull, hOFull;
                    long totalTimeUser = 0;
                    if (itemTask.typeofaffair == 4)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 7];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 8];
                        foreach (var itemUser in userList)
                        {
                            if (itemTask.userid == itemUser.userid)
                            {
                                startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                                endTime = DateTime.Parse(itemTask.endtimeplan.ToString());

                                for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                                {
                                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                    {

                                    }
                                    else
                                    {
                                        hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                        if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay <= timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                        }
                                        else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                            && startTime.TimeOfDay > timeMid)
                                        {
                                            hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                        }
                                        else
                                        {
                                            hCFull = hFull;
                                        }
                                        if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay > timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                        }
                                        else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                            && endTime.TimeOfDay <= timeMid)
                                        {
                                            hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                        }
                                        else
                                        {
                                            hOFull = hFull;
                                        }
                                        dayss++;
                                        hours = (int)(hCFull + hOFull + (int)(dayss - 2) * hFull);
                                    }

                                }

                                if (itemUser.isemployee == true)
                                {
                                    totalTimeUser = hours * 100000;
                                }
                                else if (itemUser.islead == true)
                                {
                                    totalTimeUser = hours * 200000;
                                }
                                else if (itemUser.isfreelancer == true)
                                {
                                    totalTimeUser = hours * 80000;
                                }
                                else if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                                {
                                    totalTimeUser = hours * 300000;
                                }
                            }
                        }
                        cell.Value = string.Format("{0:#,##0.00}", totalTimeUser) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 9];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Report Footer
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "TOTAL: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 15;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                cell = sheet.Cells[rowIndex, 5];
                foreach (var item2 in viewAffair)
                {
                    if (item2.projectid == viewProject.projectid)
                    {
                        totalTask++;
                    }

                }
                cell.Value = totalTask + " (Task)";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                foreach (var itemTask in viewAffair)
                {
                    DateTime startTime, endTime;
                    double hFull = 0, hCFull = 0, hOFull = 0;
                    if (itemTask.projectid == viewProject.projectid)
                    {
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                        int dayss = 0, houra = 0;

                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                dayss++;
                                houra = (int)(hCFull + hOFull + (int)(dayss - 2) * hFull);
                            }

                        }
                        hoursc += houra;
                        costplanc = hoursc * 500000;
                    }
                }
                cell.Value = hoursc + " (hours)";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                //tien ly thuyet
                cell = sheet.Cells[rowIndex, 7];
                cell.Value = string.Format("{0:#,##0.00}", costplanc) + " (vnd)";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];

                foreach(var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    DateTime startTime, endTime;
                    int dayss = 0;
                    double hFull, hCFull, hOFull;
                    int hoursa = 0;
                    foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                    {

                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());

                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                dayss++;
                                hoursa = (int)(hCFull + hOFull + (int)(dayss - 2) * hFull);
                            }

                        }

                        if (itemUser.isemployee == true)
                        {

                            gio1 += hoursa * 100000;
                        }
                        else if (itemUser.islead == true)
                        {

                            gio1 += hoursa * 200000;
                        }
                        else if (itemUser.isfreelancer == true)
                        {

                            gio1 += hoursa * 80000;
                        }
                        else if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                        {

                            gio1 += hoursa * 300000;
                        }
                    }
                }

                cell.Value = string.Format("{0:#,##0.00}", gio1) + " (vnd)";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "BiddingProject.xlsx"
                        );
                }
            }
        }

        [HttpGet]
        public IActionResult ExportDoneExcel(int id)
        {
            int totalTask = 0, hoursc = 0, hoursd = 0;
            TimeSpan timeStart = TimeSpan.Parse("9:00"), timeEnd = TimeSpan.Parse("18:00"),
            timeMid = TimeSpan.Parse("12:00");
            long 
                costplanc = 0,
                gioc = 0, otc = 0, moneyrequestc = 0, costtotalc = 0;
            var viewAffair = JsonConvert.DeserializeObject<IEnumerable<Affairs>>(_httpClient.GetStringAsync(BASE_URI).Result);
            var viewProject = JsonConvert.DeserializeObject<Projects>
                 (_httpClient.GetStringAsync(BASE_URI2 + id).Result);
            var userList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(BASE_URI3).Result);
            var requestList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.Request>>
                (_httpClient.GetStringAsync(BASE_URI4).Result);
            int rowIndex = 3;
            ExcelRange cell;
            ExcelFill fill;
            Border border;
            
            using (var workbook = new ExcelPackage())
            {
                var sheet = workbook.Workbook.Worksheets.Add("Project");
                sheet.Name = "Project Report";
                sheet.Column(4).Width = 25;
                sheet.Column(5).Width = 25;
                sheet.Column(6).Width = 25;
                sheet.Column(7).Width = 25;
                sheet.Column(8).Width = 25;
                sheet.Column(9).Width = 25;
                sheet.Column(10).Width = 25;

                #region Report Header
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                sheet.Cells[rowIndex, 5, rowIndex, 10].Merge = true;
                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Project Name: " + viewProject.projectname;
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 18;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowIndex = rowIndex + 1;

                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                sheet.Cells[rowIndex, 5, rowIndex, 10].Merge = true;
                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Project Code: " + viewProject.projectcode;
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 15;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowIndex = rowIndex + 1;

                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Start (Plan): ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = viewProject.startplan.ToString("dd/MM/yyyy");
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "Start (Actual): ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 10];
                cell.Value = viewProject.startactual.Value.ToString("dd/MM/yyyy");
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;

                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "End (Plan): ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = viewProject.endplan.ToString("dd/MM/yyyy");
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "End (Actual): ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 10];
                cell.Value = viewProject.endactual.Value.ToString("dd/MM/yyyy");
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 13;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 2;

                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Task Name: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "Total Plan: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "Total Actual: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "Cost Plan: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "Cost Actual: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 10];
                cell.Value = "Note: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table header
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 1: Analisys";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 10];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;    
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                    foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                    {
                    long  moneyrequest = 0, costplan1 = 0, costactual1 = 0;
                    double costextra = 0, costtotal = 0, ot = 0;
                    DateTime startTime, endTime;
                    int hours = 0, days = 0, hours2 = 0, daysx = 0;
                    double hFull, hCFull, hOFull;
                    if (itemTask.typeofaffair == 0)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //thoi gian thuc te
                        cell = sheet.Cells[rowIndex, 7];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            startTime = DateTime.Parse(itemTask.starttimeactual.Value.ToString());
                            endTime = DateTime.Parse(itemTask.endtimeactual.Value.ToString());

                            for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                            {
                                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                {

                                }
                                else
                                {
                                    hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                    if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay <= timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                    }
                                    else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay > timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                    }
                                    else
                                    {
                                        hCFull = hFull;
                                    }
                                    if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay > timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                    }
                                    else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay <= timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                    }
                                    else
                                    {
                                        hOFull = hFull;
                                    }
                                    days++;
                                    hours2 = (int)(hCFull + hOFull + (int)(days - 2) * hFull);
                                }

                            }
                            if (itemUser.islead == true)
                            {
                                costactual1 = hours2 * 200000;
                            }
                            if (itemUser.isemployee == true)
                            {
                                costactual1 = hours2 * 100000;
                            }
                            if (itemUser.isfreelancer == true)
                            {
                                costactual1 = hours2 * 80000;
                            }
                            if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                            {
                                costactual1 = hours2 * 300000;
                            }

                        }
                        cell.Value = hours2 + " hours";
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                            

                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 8];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //tien thuc te
                        cell = sheet.Cells[rowIndex, 9];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            foreach (var itemRequest in requestList.Where(a => a.taskid == itemTask.affairid))
                            {
                                if (itemRequest.requestname == "Overtime" && itemRequest.status == 1)
                                {
                                    if (itemUser.islead == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 200000 * 2;
                                    }
                                    else if (itemUser.isemployee == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 100000 * 2;
                                    }
                                    else if (itemUser.isemployee == false && itemUser.islead == false && itemUser.isfreelancer == false)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 300000 * 2;
                                    }
                                }
                                if (itemRequest.requestname == "RequestMoney" && itemRequest.status == 1)
                                {
                                    moneyrequest = (long)itemRequest.requestmoney;
                                }
                                costextra = moneyrequest + ot;
                            }
                        }
                        costtotal = costextra + costactual1;
                        cell.Value = string.Format("{0:#,##0.00}", costtotal) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 10];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Table header
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 2: Design";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 10];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    long moneyrequest = 0, costplan1 = 0, costactual1 = 0;
                    double costextra = 0, costtotal = 0, ot = 0;
                    DateTime startTime, endTime;
                    int hours = 0, days = 0, hours2 = 0, daysx = 0;
                    double hFull, hCFull, hOFull;
                    if (itemTask.typeofaffair == 1)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //thoi gian thuc te
                        cell = sheet.Cells[rowIndex, 7];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            startTime = DateTime.Parse(itemTask.starttimeactual.Value.ToString());
                            endTime = DateTime.Parse(itemTask.endtimeactual.Value.ToString());

                            for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                            {
                                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                {

                                }
                                else
                                {
                                    hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                    if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay <= timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                    }
                                    else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay > timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                    }
                                    else
                                    {
                                        hCFull = hFull;
                                    }
                                    if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay > timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                    }
                                    else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay <= timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                    }
                                    else
                                    {
                                        hOFull = hFull;
                                    }
                                    days++;
                                    hours2 = (int)(hCFull + hOFull + (int)(days - 2) * hFull);
                                }

                            }
                            if (itemUser.islead == true)
                            {
                                costactual1 = hours2 * 200000;
                            }
                            if (itemUser.isemployee == true)
                            {
                                costactual1 = hours2 * 100000;
                            }
                            if (itemUser.isfreelancer == true)
                            {
                                costactual1 = hours2 * 80000;
                            }
                            if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                            {
                                costactual1 = hours2 * 300000;
                            }

                        }
                        cell.Value = hours2 + " hours";
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 8];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //tien thuc te
                        cell = sheet.Cells[rowIndex, 9];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            foreach (var itemRequest in requestList.Where(a => a.taskid == itemTask.affairid))
                            {
                                if (itemRequest.requestname == "Overtime" && itemRequest.status == 1)
                                {
                                    if (itemUser.islead == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 200000 * 2;
                                    }
                                    else if (itemUser.isemployee == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 100000 * 2;
                                    }
                                    else if (itemUser.isemployee == false && itemUser.islead == false && itemUser.isfreelancer == false)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 300000 * 2;
                                    }
                                }
                                if (itemRequest.requestname == "RequestMoney" && itemRequest.status == 1)
                                {
                                    moneyrequest = (long)itemRequest.requestmoney;
                                }
                                costextra = moneyrequest + ot;
                            }
                        }
                        costtotal = costextra + costactual1;
                        cell.Value = string.Format("{0:#,##0.00}", costtotal) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 10];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Table header
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 3: Implementation";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 10];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    long moneyrequest = 0, costplan1 = 0, costactual1 = 0;
                    double costextra = 0, costtotal = 0, ot = 0;
                    DateTime startTime, endTime;
                    int hours = 0, days = 0, hours2 = 0, daysx = 0;
                    double hFull, hCFull, hOFull;
                    if (itemTask.typeofaffair == 2)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //thoi gian thuc te
                        cell = sheet.Cells[rowIndex, 7];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            startTime = DateTime.Parse(itemTask.starttimeactual.Value.ToString());
                            endTime = DateTime.Parse(itemTask.endtimeactual.Value.ToString());

                            for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                            {
                                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                {

                                }
                                else
                                {
                                    hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                    if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay <= timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                    }
                                    else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay > timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                    }
                                    else
                                    {
                                        hCFull = hFull;
                                    }
                                    if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay > timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                    }
                                    else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay <= timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                    }
                                    else
                                    {
                                        hOFull = hFull;
                                    }
                                    days++;
                                    hours2 = (int)(hCFull + hOFull + (int)(days - 2) * hFull);
                                }

                            }
                            if (itemUser.islead == true)
                            {
                                costactual1 = hours2 * 200000;
                            }
                            if (itemUser.isemployee == true)
                            {
                                costactual1 = hours2 * 100000;
                            }
                            if (itemUser.isfreelancer == true)
                            {
                                costactual1 = hours2 * 80000;
                            }
                            if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                            {
                                costactual1 = hours2 * 300000;
                            }

                        }
                        cell.Value = hours2 + " hours";
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 8];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //tien thuc te
                        cell = sheet.Cells[rowIndex, 9];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            foreach (var itemRequest in requestList.Where(a => a.taskid == itemTask.affairid))
                            {
                                if (itemRequest.requestname == "Overtime" && itemRequest.status == 1)
                                {
                                    if (itemUser.islead == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 200000 * 2;
                                    }
                                    else if (itemUser.isemployee == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 100000 * 2;
                                    }
                                    else if (itemUser.isemployee == false && itemUser.islead == false && itemUser.isfreelancer == false)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 300000 * 2;
                                    }
                                }
                                if (itemRequest.requestname == "RequestMoney" && itemRequest.status == 1)
                                {
                                    moneyrequest = (long)itemRequest.requestmoney;
                                }
                                costextra = moneyrequest + ot;
                            }
                        }
                        costtotal = costextra + costactual1;
                        cell.Value = string.Format("{0:#,##0.00}", costtotal) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 10];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Table header
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 4: Testing";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 10];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    long moneyrequest = 0, costplan1 = 0, costactual1 = 0;
                    double costextra = 0, costtotal = 0, ot = 0;
                    DateTime startTime, endTime;
                    int hours = 0, days = 0, hours2 = 0, daysx = 0;
                    double hFull, hCFull, hOFull;
                    if (itemTask.typeofaffair == 3)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //thoi gian thuc te
                        cell = sheet.Cells[rowIndex, 7];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            startTime = DateTime.Parse(itemTask.starttimeactual.Value.ToString());
                            endTime = DateTime.Parse(itemTask.endtimeactual.Value.ToString());

                            for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                            {
                                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                {

                                }
                                else
                                {
                                    hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                    if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay <= timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                    }
                                    else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay > timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                    }
                                    else
                                    {
                                        hCFull = hFull;
                                    }
                                    if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay > timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                    }
                                    else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay <= timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                    }
                                    else
                                    {
                                        hOFull = hFull;
                                    }
                                    days++;
                                    hours2 = (int)(hCFull + hOFull + (int)(days - 2) * hFull);
                                }

                            }
                            if (itemUser.islead == true)
                            {
                                costactual1 = hours2 * 200000;
                            }
                            if (itemUser.isemployee == true)
                            {
                                costactual1 = hours2 * 100000;
                            }
                            if (itemUser.isfreelancer == true)
                            {
                                costactual1 = hours2 * 80000;
                            }
                            if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                            {
                                costactual1 = hours2 * 300000;
                            }

                        }
                        cell.Value = hours2 + " hours";
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 8];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //tien thuc te
                        cell = sheet.Cells[rowIndex, 9];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            foreach (var itemRequest in requestList.Where(a => a.taskid == itemTask.affairid))
                            {
                                if (itemRequest.requestname == "Overtime" && itemRequest.status == 1)
                                {
                                    if (itemUser.islead == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 200000 * 2;
                                    }
                                    else if (itemUser.isemployee == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 100000 * 2;
                                    }
                                    else if (itemUser.isemployee == false && itemUser.islead == false && itemUser.isfreelancer == false)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 300000 * 2;
                                    }
                                }
                                if (itemRequest.requestname == "RequestMoney" && itemRequest.status == 1)
                                {
                                    moneyrequest = (long)itemRequest.requestmoney;
                                }
                                costextra = moneyrequest + ot;
                            }
                        }
                        costtotal = costextra + costactual1;
                        cell.Value = string.Format("{0:#,##0.00}", costtotal) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 10];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Table header
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "";

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Stages 5: Deployment";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 11;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 9];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 10];
                cell.Value = "";
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    long moneyrequest = 0, costplan1 = 0, costactual1 = 0;
                    double costextra = 0, costtotal = 0, ot = 0;
                    DateTime startTime, endTime;
                    int hours = 0, days = 0, hours2 = 0, daysx = 0;
                    double hFull, hCFull, hOFull;
                    if (itemTask.typeofaffair == 4)
                    {
                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = itemTask.affairname;
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //thoi gian ly thuyet
                        cell = sheet.Cells[rowIndex, 6];
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                                    && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                daysx++;
                                hours = (int)(hCFull + hOFull + (int)(daysx - 2) * hFull);
                                costplan1 = hours * 500000;
                            }
                        }
                        cell.Value = hours + " hours";
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //thoi gian thuc te
                        cell = sheet.Cells[rowIndex, 7];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            startTime = DateTime.Parse(itemTask.starttimeactual.Value.ToString());
                            endTime = DateTime.Parse(itemTask.endtimeactual.Value.ToString());

                            for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                            {
                                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                {

                                }
                                else
                                {
                                    hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                    if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay <= timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                    }
                                    else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                        && startTime.TimeOfDay > timeMid)
                                    {
                                        hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                    }
                                    else
                                    {
                                        hCFull = hFull;
                                    }
                                    if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay > timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                    }
                                    else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                        && endTime.TimeOfDay <= timeMid)
                                    {
                                        hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                    }
                                    else
                                    {
                                        hOFull = hFull;
                                    }
                                    days++;
                                    hours2 = (int)(hCFull + hOFull + (int)(days - 2) * hFull);
                                }

                            }
                            if (itemUser.islead == true)
                            {
                                costactual1 = hours2 * 200000;
                            }
                            if (itemUser.isemployee == true)
                            {
                                costactual1 = hours2 * 100000;
                            }
                            if (itemUser.isfreelancer == true)
                            {
                                costactual1 = hours2 * 80000;
                            }
                            if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                            {
                                costactual1 = hours2 * 300000;
                            }

                        }
                        cell.Value = hours2 + " hours";
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //tien ly thuyet
                        cell = sheet.Cells[rowIndex, 8];
                        cell.Value = string.Format("{0:#,##0.00}", costplan1) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        //tien thuc te
                        cell = sheet.Cells[rowIndex, 9];
                        foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                        {
                            foreach (var itemRequest in requestList.Where(a => a.taskid == itemTask.affairid))
                            {
                                if (itemRequest.requestname == "Overtime" && itemRequest.status == 1)
                                {
                                    if (itemUser.islead == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 200000 * 2;
                                    }
                                    else if (itemUser.isemployee == true)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 100000 * 2;
                                    }
                                    else if (itemUser.isemployee == false && itemUser.islead == false && itemUser.isfreelancer == false)
                                    {
                                        ot = ((long)itemRequest.totaltime) * 300000 * 2;
                                    }
                                }
                                if (itemRequest.requestname == "RequestMoney" && itemRequest.status == 1)
                                {
                                    moneyrequest = (long)itemRequest.requestmoney;
                                }
                                costextra = moneyrequest + ot;
                            }
                        }
                        costtotal = costextra + costactual1;
                        cell.Value = string.Format("{0:#,##0.00}", costtotal) + " (vnd)";
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 10];
                        cell.Value = "";
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion

                #region Report Footer
                rowIndex = rowIndex + 1;
                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "TOTAL: ";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 15;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                cell = sheet.Cells[rowIndex, 5];
                foreach (var item2 in viewAffair)
                {
                    if (item2.projectid == viewProject.projectid)
                    {
                        totalTask++;
                    }

                }
                cell.Value = totalTask + " (Task)";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                //tong gio ly thuyet
                cell = sheet.Cells[rowIndex, 6];
                foreach (var itemTask in viewAffair)
                {
                    DateTime startTime, endTime;
                    double hFull = 0, hCFull = 0, hOFull = 0;
                    if (itemTask.projectid == viewProject.projectid)
                    {
                        startTime = DateTime.Parse(itemTask.starttimeplan.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeplan.ToString());
                        hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                        int dayss = 0, houra = 0;

                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                dayss++;
                                houra = (int)(hCFull + hOFull + (int)(dayss - 2) * hFull);
                            }

                        }
                        hoursc += houra;
                        costplanc = hoursc * 500000;
                    }
                }
                cell.Value = hoursc + " (hours)";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                //tong gio thuc te
                cell = sheet.Cells[rowIndex, 7];
                foreach (var itemTask in viewAffair)
                {
                    DateTime startTimeb, endTimeb;
                    double hFull, hCFull, hOFull;
                    int hourss = 0, dayse = 0;
                    if (itemTask.projectid == viewProject.projectid)
                    {
                        startTimeb = DateTime.Parse(itemTask.starttimeactual.Value.ToString());
                        endTimeb = DateTime.Parse(itemTask.endtimeactual.Value.ToString());
                        hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;

                        for (DateTime date = startTimeb; date.DayOfYear <= endTimeb.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTimeb.TimeOfDay && timeStart <= startTimeb.TimeOfDay
                                && startTimeb.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTimeb.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTimeb.TimeOfDay && timeStart <= startTimeb.TimeOfDay
                                    && startTimeb.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTimeb.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTimeb.TimeOfDay && timeStart <= endTimeb.TimeOfDay
                                    && endTimeb.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTimeb.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTimeb.TimeOfDay && timeStart <= endTimeb.TimeOfDay
                                    && endTimeb.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTimeb.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                dayse++;
                                hourss = (int)(hCFull + hOFull + (int)(dayse - 2) * hFull);
                            }

                        }
                        hoursd += hourss;
                    }
                }
                cell.Value = hoursd + " (hours)";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                //tien ly thuyet
                cell = sheet.Cells[rowIndex, 8];
                
                cell.Value = string.Format("{0:#,##0.00}", costplanc) + " (vnd)";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                //tien thuc te
                cell = sheet.Cells[rowIndex, 9];
                foreach (var itemTask in viewAffair.Where(a => a.projectid == viewProject.projectid))
                {
                    DateTime startTime, endTime;
                    int hours = 0;
                    double hFull, hCFull, hOFull;
                    foreach (var itemUser in userList.Where(a => a.userid == itemTask.userid))
                    {
                        startTime = DateTime.Parse(itemTask.starttimeactual.Value.ToString());
                        endTime = DateTime.Parse(itemTask.endtimeactual.Value.ToString());
                        int dayss = 0;
                        for (DateTime date = startTime; date.DayOfYear <= endTime.DayOfYear; date = date.AddDays(1))
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {

                            }
                            else
                            {
                                hFull = ((TimeSpan)(timeEnd - timeStart)).TotalHours - 1;
                                if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                && startTime.TimeOfDay <= timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours - 1);
                                }
                                else if (timeEnd > startTime.TimeOfDay && timeStart <= startTime.TimeOfDay
                                    && startTime.TimeOfDay > timeMid)
                                {
                                    hCFull = (((TimeSpan)(timeEnd - startTime.TimeOfDay)).TotalHours);
                                }
                                else
                                {
                                    hCFull = hFull;
                                }
                                if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay > timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours - 1;
                                }
                                else if (timeEnd > endTime.TimeOfDay && timeStart <= endTime.TimeOfDay
                                    && endTime.TimeOfDay <= timeMid)
                                {
                                    hOFull = ((TimeSpan)(endTime.TimeOfDay - timeStart)).TotalHours;
                                }
                                else
                                {
                                    hOFull = hFull;
                                }
                                dayss++;
                                hours = (int)(hCFull + hOFull + (int)(dayss - 2) * hFull);
                            }

                        }

                        if (itemUser.isemployee == true)
                        {
                            gioc += hours * 100000;
                        }
                        else if (itemUser.islead == true)
                        {

                            gioc += hours * 200000;
                        }
                        else if (itemUser.isfreelancer == true) { gioc += hours * 80000; }
                        else if (itemUser.islead == false && itemUser.isemployee == false && itemUser.isfreelancer == false)
                        {

                            gioc += hours * 300000;
                        }

                        foreach (var itemRequest in requestList.Where(a => a.taskid == itemTask.affairid))
                        {
                            if (itemRequest.requestname == "Overtime" && itemRequest.status == 1)
                            {
                                if (itemUser.islead == true)
                                {
                                    otc += ((long)itemRequest.totaltime) * 200000 * 2;
                                }
                                else if (itemUser.isemployee == true)
                                {
                                    otc += ((long)itemRequest.totaltime) * 100000 * 2;
                                }
                                else if (itemUser.isemployee == false && itemUser.islead == false && itemUser.isfreelancer == false)
                                {
                                    otc += ((long)itemRequest.totaltime) * 300000 * 2;
                                }
                            }
                            else if (itemRequest.requestname == "RequestMoney" && itemRequest.status == 1)
                            {
                                moneyrequestc += (long)itemRequest.requestmoney;
                            }
                        }
                    }
                }
                costtotalc = (long)gioc + otc + moneyrequestc;
                cell.Value = string.Format("{0:#,##0.00}", costtotalc) + " (vnd)";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 10];
                cell.Value = "";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.White);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Project.xlsx"
                        );
                }
            }
        }

        public IActionResult DetailBidding(int id)
        {
            var view = JsonConvert.DeserializeObject<Projects>
                 (_httpClient.GetStringAsync(BASE_URI2 + id).Result);
            var affairsList = JsonConvert.DeserializeObject<IEnumerable<Affairs>>(_httpClient.GetStringAsync(BASE_URI).Result)
                .Where(a => a.projectid == view.projectid).ToList();
            ViewBag.userList = JsonConvert.DeserializeObject<IEnumerable<FourN.Data.Models.User>>
                (_httpClient.GetStringAsync(BASE_URI3).Result);
            ViewBag.affairList = affairsList;
            return View(view);
        }
    }
}
