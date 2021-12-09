using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FourN.Data.ViewModel
{
    public class GroupViewModel
    {
        public static GroupViewModel ConvertFromGroup(Groups groups)
        {
            if (groups == null) return new GroupViewModel();
            var model = new GroupViewModel()
            {
                GroupId = groups.groupid,
                GroupName = groups.groupname,
                Users = groups?.groupusers?.Select(x => x.user)?.Where(x=>x.isdeleted == false).Select(x => UserViewModel.ConvertFromUser(x)).ToList(),
                SelectListLeaders = groups?.groupusers?.Select(x => x.user).Where(x => x.islead = true)?.Select(x => new SelectListItem() { Text = x.username, Value = x.userid.ToString() }).ToList(),
                SelectListStaffs = groups?.groupusers?.Select(x => x.user).Where(x => x.isemployee = true)?.Select(x => new SelectListItem() { Text = x.username, Value = x.userid.ToString() }).ToList()
            };
            return model;
        }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        //public ProjectViewModel Project { get; set; }
        public int LeaderId { get; set; }
        public List<UserViewModel> Users { get; set; }
        public List<SelectListItem> SelectListLeaders { get; set; }
        public List<SelectListItem> SelectListStaffs { get; set; }
        public List<int> Listmembersid { get; set; }
        public string ProjectName { get; set; }
    }
}
