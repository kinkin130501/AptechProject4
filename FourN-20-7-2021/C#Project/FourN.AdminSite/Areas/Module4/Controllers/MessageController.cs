using FourN.AdminSite.Helper;
using FourN.AdminSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FourN.Data.Models;

using Newtonsoft.Json;
using FourN.Data.ViewModel;
using System.Net.Http.Json;

namespace FourN.AdminSite.Areas.Module4.Controllers
{
    [Area("Module4")]
    public class MessageController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string BASE_URI = "http://localhost:9999/";
        public IActionResult Index()
        {
            //var view = JsonConvert.DeserializeObject<IEnumerable<Zoom>>(_httpClient.GetStringAsync(BASE_URI).Result);
            //get my session
            var Authmodel = new AuthenticationModel();
            Authmodel = SessionExtension.GetCurrentAuthentication(HttpContext.Session);
            ViewData["username"] = Authmodel.UserName;
            ViewData["userid"] = Authmodel.UserId;
            //get all my inbox
            List<Privatemessage> listSent = JsonConvert.DeserializeObject<List<Privatemessage>>(_httpClient.GetStringAsync(BASE_URI + "getAllMessageSent/" + ViewData["userid"].ToString()).Result);
            List<Privatemessage> listInbox = JsonConvert.DeserializeObject<List<Privatemessage>>(_httpClient.GetStringAsync(BASE_URI + "getAllMessageInbox/" + ViewData["userid"].ToString()).Result);
            //get all user
            List<FourN.Data.Models.User> listUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI + "getAllUser/").Result);
            //get privatemodel
            //var pModelS = new PrivatemessageViewModel();
            //var pModelI = new PrivatemessageViewModel();
            List<PrivatemessageViewModel> listPmodelI = new List<PrivatemessageViewModel> { };
            List<PrivatemessageViewModel> listPmodelS = new List<PrivatemessageViewModel> { };
            //import send
            if (listSent != null)
            {
                foreach (var item1 in listSent)
                {
                    foreach (var item2 in listUser)
                    {
                        if (item1.messagereceiveid == item2.userid)
                        {
                            var pModelS = new PrivatemessageViewModel();
                            pModelS.messageid = item1.messageid;
                            pModelS.messagetitle = item1.messagetitle;
                            pModelS.messagecontent = item1.messagecontent;
                            pModelS.messagecreateat = item1.messagecreateat;
                            pModelS.messageupdateat = item1.messageupdateat;
                            pModelS.messageread = item1.messageread;
                            pModelS.UsersInbox = item2;
                            listPmodelS.Add(pModelS);
                        }
                    }
                }
            }

            //import inbox
            if (listInbox != null)
            {
                foreach (var item1 in listInbox)
                {
                    foreach (var item2 in listUser)
                    {
                        if (item1.messagesenderid == item2.userid)
                        {
                            var pModelI = new PrivatemessageViewModel();
                            pModelI.messageid = item1.messageid;
                            pModelI.messagetitle = item1.messagetitle;
                            pModelI.messagecontent = item1.messagecontent;
                            pModelI.messagecreateat = item1.messagecreateat;
                            pModelI.messageupdateat = item1.messageupdateat;
                            pModelI.messageread = item1.messageread;
                            pModelI.UsersSend = item2;
                            listPmodelI.Add(pModelI);
                        }
                    }
                }
            }

            ViewData["listInbox"] = listPmodelI;
            return View(listPmodelS);
        }
        [HttpGet]
        public IActionResult Messenger(String groupid = "0")
        {
            //groupid = "4";
            var Authmodel = new AuthenticationModel();
            Authmodel = SessionExtension.GetCurrentAuthentication(HttpContext.Session);
            ViewData["username"] = Authmodel.UserName;
            ViewData["userid"] = Authmodel.UserId;
            if (groupid.ToString() == "0")
            {
                ViewData["groupid"] = "0";
            }
            else
            {
                ViewData["groupid"] = groupid;
            }

            //get all group
            //FourN.Data.Models.Groups group = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groups>>(_httpClient.GetStringAsync(BASE_URI + "groups").Result).Where(g => g.groupid == groupid).SingleOrDefault();
            List<FourN.Data.Models.Groupuser> listGroupUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groupuser>>(_httpClient.GetStringAsync(BASE_URI + "getAllGroupUser/" + Int32.Parse(groupid)).Result);
            List<FourN.Data.Models.Chatroom> listChatRoom = JsonConvert.DeserializeObject<List<FourN.Data.Models.Chatroom>>(_httpClient.GetStringAsync(BASE_URI + "getAllChatRoom/" + groupid).Result);
            List<FourN.Data.ViewModel.ChatUserViewModel> listResult = new List<ChatUserViewModel>();
            if (listChatRoom != null)
            {
                listChatRoom = listChatRoom.OrderBy(c => c.chatroomid).ToList();
                List<FourN.Data.Models.User> listUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI + "getAllUser/").Result);
                if (listResult != null)
                {
                    foreach (var item in listChatRoom)
                    {
                        ChatUserViewModel result = new ChatUserViewModel();
                        result.chatroomid = item.chatroomid;
                        result.chatusercontent = item.chatusercontent;
                        result.chatusergroup = item.chatusergroup;
                        result.chatusercreateat = item.chatusercreateat;
                        result.Users = listUser.Where(l => l.userid == item.chatuserid).SingleOrDefault();
                        listResult.Add(result);
                    }
                }
            }
            return View(listResult);
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
        public JsonResult ChatAutocomplete(String filter_name)
        {
            List<FourN.Data.Models.Groups> listGroup = new List<FourN.Data.Models.Groups>();
            //get all group
            if (filter_name.Equals("all"))
            {
                listGroup = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groups>>(_httpClient.GetStringAsync(BASE_URI + "groups").Result).ToList();
            }
            else
            {
                listGroup = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groups>>(_httpClient.GetStringAsync(BASE_URI + "groups").Result).Where(g => g.groupname.ToLower().Contains(filter_name.ToLower())).ToList();
            }
            return Json(new
            {
                status = true,
                result = listGroup,
            }
            );
        }
        [HttpGet]
        public JsonResult ChatValidate(String filter_name)
        {
            //get all group
            List<FourN.Data.Models.Groups> listGroup = JsonConvert.DeserializeObject<List<FourN.Data.Models.Groups>>(_httpClient.GetStringAsync(BASE_URI + "groups").Result);
            if (listGroup != null)
            {
                listGroup = listGroup.Where(g => g.groupname.Equals(filter_name)).ToList();
                if (listGroup.Count > 0)
                {
                    return Json(new
                    {
                        status = true,
                        result = listGroup,
                    }
                );
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        result = listGroup,
                    }
                    );
                }

            }
            else
            {
                return Json(new
                {
                    status = false,
                    result = listGroup,
                }
               );
            }

        }
        [HttpPost]
        public JsonResult CreateMessage(String to, String title, String content)
        {
            //get session
            var Authmodel = new AuthenticationModel();
            Authmodel = SessionExtension.GetCurrentAuthentication(HttpContext.Session);
            var userid = Authmodel.UserId;
            var now = DateTime.Now;
            //get all user
            List<FourN.Data.Models.User> listUser = JsonConvert.DeserializeObject<List<FourN.Data.Models.User>>(_httpClient.GetStringAsync(BASE_URI + "getAllUser/").Result);
            Privatemessage p = new Privatemessage();
            p.messagetitle = title;
            p.messagecontent = content;
            p.messagesenderid = userid;
            p.messagereceiveid = Int32.Parse(to);
            p.messagecreateat = now.ToString();
            p.messageupdateat = now.ToString();
            p.messageread = 0;
            var response = _httpClient.PostAsJsonAsync<Data.Models.Privatemessage>(BASE_URI + "updateOneMessage/", p).Result;
            //create noti
            Notification n = new Notification();
            n.notitype = "message";
            n.notiread = 0;
            n.notiuserid = Int32.Parse(to);
            n.noticreate = now.ToString();
            n.notiupdate = now.ToString();
            n.notifromid = userid;
            var sendNoti = _httpClient.PostAsJsonAsync<Data.Models.Notification>(BASE_URI + "updateOneNotification/", n).Result;
            //end create noti
            var usernameR = listUser.Where(li => li.userid == Int32.Parse(to)).SingleOrDefault().username;
            if (response.IsSuccessStatusCode)
            {
                return Json(new
                {
                    status = true,
                    time = p.messagecreateat,
                    username = usernameR
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
        [HttpPost]
        public JsonResult ChangeRead(String id)
        {
            //get my session
            var Authmodel = new AuthenticationModel();
            Authmodel = SessionExtension.GetCurrentAuthentication(HttpContext.Session);
            ViewData["username"] = Authmodel.UserName;
            ViewData["userid"] = Authmodel.UserId;
            List<Privatemessage> listInbox = JsonConvert.DeserializeObject<List<Privatemessage>>(_httpClient.GetStringAsync(BASE_URI + "getAllMessageInbox/" + ViewData["userid"].ToString()).Result);
            Privatemessage p = listInbox.Where(l => l.messageid == Int32.Parse(id)).SingleOrDefault();
            p.messageread = 1;
            var response = _httpClient.PostAsJsonAsync<Data.Models.Privatemessage>(BASE_URI + "updateOneMessage/", p).Result;
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
        [HttpPost]
        public JsonResult DeleteMessage(String id)
        {
            List<Privatemessage> listSent = JsonConvert.DeserializeObject<List<Privatemessage>>(_httpClient.GetStringAsync(BASE_URI + "getAllMessage/").Result);
            Privatemessage p = listSent.Where(l => l.messageid == Int32.Parse(id)).SingleOrDefault();
            var response = _httpClient.DeleteAsync(BASE_URI + "deleteOneMessage/" + id).Result;
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
        [HttpPost]
        public JsonResult CreateChatRoom(String content, String groupid)
        {
            //get session
            var Authmodel = new AuthenticationModel();
            Authmodel = SessionExtension.GetCurrentAuthentication(HttpContext.Session);
            int userid = Authmodel.UserId;
            var now = DateTime.Now;
            Chatroom c = new Chatroom();
            c.chatuserid = userid;
            c.chatusercontent = content;
            c.chatusergroup = Int32.Parse(groupid);
            c.chatusercreateat = now.ToString();
            c.chatuserupdateat = now.ToString();
            var response = _httpClient.PostAsJsonAsync<Data.Models.Chatroom>(BASE_URI + "updateOneChat/", c).Result;
            if (response.IsSuccessStatusCode)
            {
                return Json(new
                {
                    status = true,
                    time = c.chatusercreateat,
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
