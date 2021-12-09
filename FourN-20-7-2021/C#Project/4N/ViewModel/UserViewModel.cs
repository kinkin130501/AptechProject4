using FourN.Data.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace FourN.Data.ViewModel
{
    public class UserViewModel
    {
        public static UserViewModel ConvertFromUser(User user)
        {
            if (user == null) return new UserViewModel();
            var model = new UserViewModel()
            {
                UserID = user.userid,
                Username = user.username,
                Email = user.email,
                Phone = user.phone,
                Password = user.password,
                Avatar = user.avatar != null ? user.avatar : "/img/avatar2.png",
                Isleader = user.islead,
                isActive = !user.isdeleted,
                Address = user.address,
                CMNDBeforeUrl = user.cmndbefore,
                CMNDAfterUrl = user.cmndafter,
                Birthday = user.birthday,
                Gender = user.gender,
            };
            if (user.isemployee)
            {
                model.Department = "Developer";
            }else if (user.islead)
            {
                model.Department = "Leader";
            }else if ((bool)user.isfreelancer)
            {
                model.Department = "Freelance";
            }
            else
            {
                model.Department = "PM";
            }
            if (user.isemployee)
            {
                model.RoleNumber = (int)SystemEnum.RoleNumber.Developer;
            }
            else if (user.islead)
            {
                model.RoleNumber = (int)SystemEnum.RoleNumber.Leader;
            }
            else if ((bool)user.isfreelancer)
            {
                model.RoleNumber = (int)SystemEnum.RoleNumber.Partner;
            }
            else
            {
                model.RoleNumber = (int)SystemEnum.RoleNumber.PM;
            }
            return model;
        }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserRolename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public IFormFile AvatarUrl { get; set; }
        public bool Isleader { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string CMNDBeforeUrl { get; set; }
        public IFormFile CMNDBefore { get; set; }
        public string CMNDAfterUrl { get; set; }
        public IFormFile CMNDAfter { get; set; }
        public string Department { get; set; }
        public bool isActive { get; set; }
        public string GroupName { get; set; }
        public int DepartmentInt { get; set; }
        public int RoleNumber { get; set; }
    }
}
