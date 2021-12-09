using FourN.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using FourN.AdminSite.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.CodeAnalysis.Host;
using FourN.AdminSite.Helper;
using System.Net.Http.Json;
using FourN.Data.ViewModel;
namespace FourN.AdminSite.Areas.Module4.Controllers
{
    [Area("Module4")]
    public class CalendarController : Controller
    {
       
        private readonly HttpClient _httpClient = new HttpClient();
        private string BASE_URI = "http://localhost:9999/";
        // GET: 
        public IActionResult Index()
        {
            //get my session
            var Authmodel = new AuthenticationModel();
            Authmodel = SessionExtension.GetCurrentAuthentication(HttpContext.Session);
            List<Zoom> myZoom = JsonConvert.DeserializeObject<List<Zoom>>(_httpClient.GetStringAsync(BASE_URI + "getAllZoom/"+ Authmodel.UserId).Result);
            List<Zoom> otherZoom = JsonConvert.DeserializeObject<List<Zoom>>(_httpClient.GetStringAsync(BASE_URI + "getAllZoomOther/" + Authmodel.UserId).Result);
            if(otherZoom != null)
                 otherZoom = otherZoom.Where(li => li.zoomteam == 0).ToList();
            List<CalendarEvent> myEvent = new List<CalendarEvent>();
            List<TableZoom> myTableZoom = new List<TableZoom>(); 
            List<FourN.Data.Models.User> u = JsonConvert.DeserializeObject<List<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI + "users").Result);
            List<FourN.Data.Models.Affairs> listTasks = JsonConvert.DeserializeObject<List<FourN.Data.Models.Affairs>>(_httpClient.GetStringAsync(BASE_URI + "affairs").Result);
            if(listTasks != null)
                listTasks = listTasks.Where(l => l.userid == Authmodel.UserId).OrderByDescending(l => l.affairid).ToList();
            List<FourN.Data.Models.Groups> listGroup = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groups>>(_httpClient.GetStringAsync(BASE_URI + "groups").Result);
            List<FourN.Data.Models.Groupuser> listGroupUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groupuser>>(_httpClient.GetStringAsync(BASE_URI + "getAllMyGroupUser/" + Authmodel.UserId).Result);
            
            List<Zoom> teamZoom = JsonConvert.DeserializeObject<List<Zoom>>(_httpClient.GetStringAsync(BASE_URI + "getAllTeamZoom/").Result);
            if (teamZoom != null)
                teamZoom = teamZoom.Where(li => li.zoommember == 0 && li.zoomhost != Authmodel.UserId).ToList();
            if (myZoom != null)
            {
                if (myZoom.Count > 0)
                {
                    foreach (var item in myZoom)
                    {
                        CalendarEvent c = new CalendarEvent();
                        c.title = item.zoomtitle;
                        c.url = item.zoomjoinurl;
                        c.start = item.zoomstarttime;
                        c.agenda = item.zoomagenda;
                        c.backgroundColor = "red";
                        myEvent.Add(c);

                        if (item.zoomcode == "0")
                        {
                            TableZoom t = new TableZoom();
                            t.zoomid = item.zoomid;
                            t.zoomtitle = item.zoomtitle;
                            t.zoomagenda = item.zoomagenda;
                            t.zoompartner = u.Where(m => m.userid == item.zoommember).SingleOrDefault().username;
                            t.zoomname = "";
                            t.zoomtime = item.zoomstarttime;
                            t.zoomcreateat = item.zoomcreateat;
                            t.zoomupdateat = item.zoomupdateat;
                            t.zoomcode = item.zoomcode;
                            t.zoompass = item.zoompass;
                            myTableZoom.Add(t);
                        }
                        else
                        {
                            TableZoom t = new TableZoom();
                            t.zoomid = item.zoomid;
                            t.zoomtitle = item.zoomtitle;
                            t.zoomagenda = item.zoomagenda;
                            t.zoompartner = "";
                            t.zoomname = listGroup.Where(g => g.groupid == item.zoomteam).SingleOrDefault().groupname;
                            t.zoomtime = item.zoomstarttime;
                            t.zoomcreateat = item.zoomcreateat;
                            t.zoomupdateat = item.zoomupdateat;
                            t.zoomcode = item.zoomcode;
                            t.zoompass = item.zoompass;
                            myTableZoom.Add(t);
                        }

                    }
                }
            }
            if(otherZoom != null )
            {
                if (otherZoom.Count > 0)
                {
                    foreach (var item2 in otherZoom)
                    {

                        CalendarEvent c = new CalendarEvent();
                        c.title = item2.zoomtitle;
                        c.url = item2.zoomhost.ToString();
                        c.start = item2.zoomstarttime;
                        c.backgroundColor = "red";
                        c.agenda = item2.zoomagenda;
                        myEvent.Add(c);

                        if (item2.zoomcode == "0")
                        {
                            TableZoom t = new TableZoom();
                            t.zoomid = item2.zoomid;
                            t.zoomtitle = item2.zoomtitle;
                            t.zoomagenda = item2.zoomagenda;
                            t.zoompartner = u.Where(m => m.userid == item2.zoommember).SingleOrDefault().username;
                            t.zoomname = "";
                            t.zoomtime = item2.zoomstarttime;
                            t.zoomcreateat = item2.zoomcreateat;
                            t.zoomupdateat = item2.zoomupdateat;
                            t.zoomcode = item2.zoomcode;
                            t.zoompass = item2.zoompass;
                            myTableZoom.Add(t);
                        }
                        else
                        {
                            TableZoom t = new TableZoom();
                            t.zoomid = item2.zoomid;
                            t.zoomtitle = item2.zoomtitle;
                            t.zoomagenda = item2.zoomagenda;
                            t.zoompartner = "";
                            t.zoomname = listGroup.Where(g => g.groupid == item2.zoommember).SingleOrDefault().groupname;
                            t.zoomtime = item2.zoomstarttime;
                            t.zoomcreateat = item2.zoomcreateat;
                            t.zoomupdateat = item2.zoomupdateat;
                            t.zoomcode = item2.zoomcode;
                            t.zoompass = item2.zoompass;
                            myTableZoom.Add(t);
                        }
                    }
                }
            }
            if(teamZoom != null)
            {
                if (teamZoom.Count > 0)
                {
                    foreach (var item3 in teamZoom)
                    {
                        if(listGroupUser != null)
                        {
                            foreach (var item4 in listGroupUser)
                            {
                                if (item3.zoomteam == item4.groupid)
                                {
                                    CalendarEvent c = new CalendarEvent();
                                    c.title = item3.zoomtitle;
                                    c.url = item3.zoomhost.ToString();
                                    c.start = item3.zoomstarttime;
                                    c.backgroundColor = "green";
                                    c.agenda = item3.zoomagenda;
                                    myEvent.Add(c);
                                    if (item3.zoomcode == "0")
                                    {
                                        TableZoom t = new TableZoom();
                                        t.zoomid = item3.zoomid;
                                        t.zoomtitle = item3.zoomtitle;
                                        t.zoomagenda = item3.zoomagenda;
                                        t.zoompartner = u.Where(m => m.userid == item3.zoommember).SingleOrDefault().username;
                                        t.zoomname = "";
                                        t.zoomtime = item3.zoomstarttime;
                                        t.zoomcreateat = item3.zoomcreateat;
                                        t.zoomupdateat = item3.zoomupdateat;
                                        t.zoomcode = item3.zoomcode;
                                        t.zoompass = item3.zoompass;
                                        myTableZoom.Add(t);
                                    }
                                    else
                                    {
                                        TableZoom t = new TableZoom();
                                        t.zoomid = item3.zoomid;
                                        t.zoomtitle = item3.zoomtitle;
                                        t.zoomagenda = item3.zoomagenda;
                                        t.zoompartner = "";
                                        t.zoomname = listGroup.Where(g => g.groupid == item4.groupid).SingleOrDefault().groupname;
                                        t.zoomtime = item3.zoomstarttime;
                                        t.zoomcreateat = item3.zoomcreateat;
                                        t.zoomupdateat = item3.zoomupdateat;
                                        t.zoomcode = item3.zoomcode;
                                        t.zoompass = item3.zoompass;
                                        myTableZoom.Add(t);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(listTasks != null)
            {
                foreach (var item5 in listTasks)
                {
                    string dateStart = item5.starttimeplan.ToString("yyyy-MM-ddTHH:mm:ss");
                    string dateEnd = item5.endtimeplan.ToString("yyyy-MM-ddTHH:mm:ss");
                    CalendarEvent c = new CalendarEvent();
                    c.title = item5.affairname;
                    c.url = "";
                    c.start = dateStart;
                    c.end = dateEnd;
                    c.agenda = dateEnd;
                    myEvent.Add(c);
                }
            }
            
            //list all meeting
            ViewData["myTableZoom"] = myTableZoom;
            if (listTasks != null)
            {
                ViewData["checkTask"] = "0";
                ViewData["listTasks"] = listTasks.Where(li=>li.status != 6 && li.status != 0).ToList();
            }
            else
            {
                ViewData["listTasks"] = "0";
                ViewData["checkTask"] = "1";
            }
                
            
            return View(myEvent);
        }
        

        public ActionResult Zoom()
        {
            //ZoomModel z = new ZoomModel();
            //Now declare the variables
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;
            var apiSecret = "PCi35v4IYnqZzyFfP4otsgEIuQdjFmdqry1n"; // my api secret
            byte[] symmetricKey = Encoding.ASCII.GetBytes(apiSecret);
            //Create the Token Descriptor and change it to Token String for the Authorization Header
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "nI3TbMQuSsOjs-aRR0HQSw",
                Expires = now.AddSeconds(300),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            //Now use the code for the Request
            var client = new RestClient("https://api.zoom.us/v2/users/buibavuong123456@gmail.com/meetings");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { topic = "Meeting with Ussain", duration = "10", start_time = "2021-06-24T05:00:00", type = "2" });
            request.AddHeader("authorization", String.Format("Bearer {0}", tokenString));
            //Now use the code to get the Response
            IRestResponse restResponse = client.Execute(request);
            HttpStatusCode statusCode = restResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            var jObject = JObject.Parse(restResponse.Content);
            //z.Host = (string)jObject["start_url"];
            //z.Join = (string)jObject["join_url"];
            //z.Code = Convert.ToString(numericStatusCode);
            //ViewData["code"] = Convert.ToString(numericStatusCode); ;
            ViewData["Host"] = (string)jObject["start_url"];
            //ViewData["Join"] = (string)jObject["join_url"];

            return View();
        }
        public ActionResult ChatJS()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Autocomplete(String filter_name)
        {
            //get all user
            List<FourN.Data.Models.User> listUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI + "getAllUser/").Result);
            List<FourN.Data.Models.User> listResult = (List<FourN.Data.Models.User>)listUser.Where(x => x.username.ToLower().Contains(filter_name.ToLower())).ToList();
            return Json(new
            {
                status = true,
                result = listResult,
            }
            );
        }
        [HttpGet]
        public JsonResult AutocompleteTeam(String filter_name)
        {
            //get all user
            List<FourN.Data.Models.Groups> listGroup = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groups>>(_httpClient.GetStringAsync(BASE_URI + "groups").Result);
            List<FourN.Data.Models.Groups> listResult = (List<FourN.Data.Models.Groups>)listGroup.Where(x => x.groupname.ToLower().Contains(filter_name.ToLower())).ToList();
            return Json(new
            {
                status = true,
                result = listResult,
            }
            );
        }
        [HttpGet]
        public JsonResult ValidateName(String filter_name)
        {
            //get all user
            List<FourN.Data.Models.User> listUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI + "getAllUser/").Result);
            List<FourN.Data.Models.User> listResult = (List<FourN.Data.Models.User>)listUser.Where(x => x.email.Equals(filter_name)).ToList();
            if (listResult.Count > 0)
            {
                    return Json(new
                    {
                        status = true,
                        result = listResult,
                    }
                );
            }
            else
            {
                return Json(new
                {
                    status = false,
                    result = listResult,
                }
                );
            }
           
        }
        [HttpGet]
        public JsonResult ValidateNameTeam(String filter_name)
        {
            //get all user
            List<FourN.Data.Models.Groups> listGroup = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groups>>(_httpClient.GetStringAsync(BASE_URI + "groups").Result);
            List<FourN.Data.Models.Groups> listResult = (List<FourN.Data.Models.Groups>)listGroup.Where(x => x.groupname.Equals(filter_name)).ToList();
            if (listResult.Count > 0)
            {
                return Json(new
                {
                    status = true,
                    result = listResult,
                }
            );
            }
            else
            {
                return Json(new
                {
                    status = false,
                    result = listResult,
                }
                );
            }
        }
        [HttpPost]
        public JsonResult CreateZoom(String to, String title, String time,String agenda, String pass,String member)
        {
            //create Zoom
            //Now declare the variables
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var now = DateTime.Now;
            var apiSecret = "PCi35v4IYnqZzyFfP4otsgEIuQdjFmdqry1n"; // my api secret
            byte[] symmetricKey = Encoding.ASCII.GetBytes(apiSecret);
            //Create the Token Descriptor and change it to Token String for the Authorization Header
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "nI3TbMQuSsOjs-aRR0HQSw",
                Expires = now.AddSeconds(300),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            //Now use the code for the Request
            var client = new RestClient("https://api.zoom.us/v2/users/buibavuong123456@gmail.com/meetings");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new 
                { 
                    topic = title,  
                    duration= 40,
                    start_time = time, 
                    password = pass,
                    jbh_time = 10,
                    timezone = "UTC",
                    type = "2" ,
                    join_before_host = true,
                    allow_multiple_devices = true,

                }
            );
            request.AddHeader("authorization", String.Format("Bearer {0}", tokenString));
            //Now use the code to get the Response
            IRestResponse restResponse = client.Execute(request);
            HttpStatusCode statusCode = restResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            var jObject = JObject.Parse(restResponse.Content); //end create
            //get session
            var Authmodel = new AuthenticationModel();
            Authmodel = SessionExtension.GetCurrentAuthentication(HttpContext.Session);
            var userid = Authmodel.UserId;
            Zoom z = new Zoom();

            if (member == "0")
            {
                //create object
                z.zoomtitle = title;
                z.zoomhost = userid;
                z.zoommember = Int32.Parse(to);
                z.zoomteam = 0;
                z.zoompass = pass;
                z.zoomcode = member;
                z.zoomstarturl = (string)jObject["start_url"];
                z.zoomjoinurl = (string)jObject["join_url"];
                z.zoomstarttime = time;
                z.zoomagenda = agenda;
                z.zoomcreateat = now.ToString();
                z.zoomupdateat = now.ToString();
            }
            else
            {
                //create object
                z.zoomtitle = title;
                z.zoomhost = userid;
                z.zoomteam = Int32.Parse(to);
                z.zoommember = 0;
                z.zoompass = pass;
                z.zoomcode = member;
                z.zoomstarturl = (string)jObject["start_url"];
                z.zoomjoinurl = (string)jObject["join_url"];
                z.zoomstarttime = time;
                z.zoomagenda = agenda;
                z.zoomcreateat = now.ToString();
                z.zoomupdateat = now.ToString();
            }
            
          

            var response = _httpClient.PostAsJsonAsync<Data.Models.Zoom>(BASE_URI + "updateOneZoom/", z).Result;
            //find user to send email
            List<FourN.Data.Models.User> uList = JsonConvert.DeserializeObject<List<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI + "users").Result);
            List<FourN.Data.Models.User> uListJson = new List<FourN.Data.Models.User>();
            if (member == "0")
            {
                //send email
                FourN.Data.Models.User u = uList.Where(ul => ul.userid == Int32.Parse(to)).SingleOrDefault();
                EmailObject em = new EmailObject();
                em.EmailTo = u.email;
                em.EmailSubject = "FourN";
                String content = "<html dir='ltr' lang='en'>" + "\n" + "<head>" + "\n" + "<title>" + title + "</title>" + "\n" + "<meta http-equiv='Content - Type' content='text / html; charset = UTF - 8'>" + "\n" + "</head>" + "\n";
                content += "<body>";
                content += "<h3>" + title + "</h3>";
                content += "<p> Hi " + u.username + ".</p>";
                content += "<p> You has a meeting when " + time + "</p>";
                content += "<p><a href=" + (string)jObject["join_url"] + "> Click to join</a></p>";
                content += "<p>Password is: " + pass + "</p>";
                content += "</body>" + "\n" + "</html>" + "\n";
                em.EmailContent = content;
                var resultemail = SendEmail.SendMail(em);

                //end send email
            }
            else
            {
                //get all user in group
                List<FourN.Data.Models.Groupuser> listGroupUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groupuser>>(_httpClient.GetStringAsync(BASE_URI + "getAllGroupUser/"+ Int32.Parse(to)).Result);
                foreach (var grU in listGroupUser)
                {
                    if( grU.userid != userid)
                    {
                        //send email
                        FourN.Data.Models.User u = uList.Where(ul => ul.userid == grU.userid).SingleOrDefault();
                        EmailObject em = new EmailObject();
                        em.EmailTo = u.email;
                        em.EmailSubject = "FourN";
                        String content = "<html dir='ltr' lang='en'>" + "\n" + "<head>" + "\n" + "<title>" + title + "</title>" + "\n" + "<meta http-equiv='Content - Type' content='text / html; charset = UTF - 8'>" + "\n" + "</head>" + "\n";
                        content += "<body>";
                        content += "<h3>" + title + "</h3>";
                        content += "<p> Hi " + u.username + ".</p>";
                        content += "<p> You has a meeting when " + time + "</p>";
                        content += "<p><a href=" + (string)jObject["join_url"] + "> Click to join</a></p>";
                        content += "<p>Password is: " + pass + "</p>";
                        content += "</body>" + "\n" + "</html>" + "\n";
                        em.EmailContent = content;
                        var resultemail = SendEmail.SendMail(em);
                        uListJson.Add(u);
                        //end send email
                    }
                }
            }

            //create noti
            if(member == "0")
            {
                foreach(var noti in uListJson)
                {
                    Notification n = new Notification();
                    n.notitype = "meeting";
                    n.notiread = 0;
                    n.notiuserid = noti.userid;
                    n.noticreate = now.ToString();
                    n.notiupdate = now.ToString();
                    n.notifromid = userid;
                    var sendNoti = _httpClient.PostAsJsonAsync<Data.Models.Notification>(BASE_URI + "updateOneNotification/", n).Result;
                }
            }
            else
            {
                Notification n = new Notification();
                n.notitype = "meeting";
                n.notiread = 0;
                n.notiuserid = Int32.Parse(to);
                n.noticreate = now.ToString();
                n.notiupdate = now.ToString();
                n.notifromid = userid;
                var sendNoti = _httpClient.PostAsJsonAsync<Data.Models.Notification>(BASE_URI + "updateOneNotification/", n).Result;
            }
            
            //end create noti
            if (response.IsSuccessStatusCode && numericStatusCode < 400 )
            {   
                if(member == "0")
                {
                    return Json(new
                    {   
                        status = true,
                        member = 0,
                        username =  uList.Where(ul => ul.userid == Int32.Parse(to)).SingleOrDefault().username
                    }
                    );
                }
                else
                {
                    List<FourN.Data.Models.Groupuser> listGroupUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groupuser>>(_httpClient.GetStringAsync(BASE_URI + "getAllGroupUser/" + Int32.Parse(to)).Result);
                    return Json(new
                    {
                        status = true,
                        member = 1,
                        listUser = uListJson.ToArray(),
                    }
                    );
                }
               
            }
            else
            {
                return Json(new
                {
                    status = false,
                }
               );
            }

        }
        [HttpGet]
        public JsonResult GetAllNotification()
        {
            //get all user
            List<FourN.Data.Models.User> listUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI + "getAllUser/").Result);
            //get my session
            var Authmodel = new AuthenticationModel();
            Authmodel = SessionExtension.GetCurrentAuthentication(HttpContext.Session);
            List<Notification> listNoti = JsonConvert.DeserializeObject<List<Notification>>(_httpClient.GetStringAsync(BASE_URI + "getAllNotification/").Result);
            if(listNoti != null)
            {
                List<Notification> listResult = listNoti.Where(li => li.notiuserid == Authmodel.UserId).OrderBy(li => li.notiread).Take(10).ToList();
                if(listResult.Count > 0)
                {
                    List<NotificationViewModel> listResultView = new List<NotificationViewModel>();
                    foreach (var item in listResult)
                    {
                        NotificationViewModel r = new NotificationViewModel();
                        r.notiid = item.notiid;
                        r.notitype = item.notitype;
                        r.notiread = item.notiread;
                        r.notiuserid = item.notiuserid;
                        FourN.Data.Models.User lu = listUser.Where(l => l.userid == item.notifromid).SingleOrDefault();
                        if (lu != null)
                        {
                            r.UsersSend = lu;
                        }
                        r.noticreate = item.noticreate;
                        listResultView.Add(r);
                    }
                    return Json(new
                    {
                        status = true,
                        count = listResult.Count,
                        result = listResultView.ToArray(),
                        countNoti = listNoti.Where(li => li.notiuserid == Authmodel.UserId && li.notiread == 0).ToList().Count,
                    }
                    );;
                }
                else
                {
                    return Json(new
                    {
                        status = true,
                        count = 0
                    }
                    ); 
                }               
            }
            else
            {
                return Json(new
                {
                    status = false,

                }
               );
            }
        }
        [HttpPost]
        public JsonResult ReadAllNotification(String id)
        {
            //get my session
            var Authmodel = new AuthenticationModel();
            Authmodel = SessionExtension.GetCurrentAuthentication(HttpContext.Session);
            //List<Notification> listNoti = JsonConvert.DeserializeObject<List<Notification>>(_httpClient.GetStringAsync(BASE_URI + "getAllNotification/").Result);
            var response = JsonConvert.DeserializeObject<List<Notification>>(_httpClient.GetStringAsync(BASE_URI + "readAllNotification/"+Authmodel.UserId).Result);
                return Json(new
                {
                    status = true,

                }
               );

        }
        [HttpPost]
        public JsonResult Logout()
        {
            SessionExtension.Clear(HttpContext.Session);
            return Json(new
            {
                status = true,
            });
        }
        [HttpPost]
        public JsonResult UpdateZoom(String id, String time)
        {
            //find zoom
            Zoom z = JsonConvert.DeserializeObject<List<Data.Models.Zoom>>(_httpClient.GetStringAsync(BASE_URI + "getAllTeamZoom/").Result).Where(lz => lz.zoomid == Int32.Parse(id)).SingleOrDefault();
            //update zoom
            z.zoomstarttime = time;
            var response = _httpClient.PostAsJsonAsync<Data.Models.Zoom>(BASE_URI + "updateOneZoom/", z).Result;
            if (response.IsSuccessStatusCode)
            {
                return Json(new
                {
                    status = true,
                }
            );
            }
            else
            {
                return Json(new
                {
                    status = false,
                }
                );
            }
        }
    }
}
