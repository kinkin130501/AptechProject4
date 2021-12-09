using FourN.Data.Models;
using FourN.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Services.IService
{
    public interface IUserService
    {
        List<GroupViewModel> GetGroup();
        Task<GroupViewModel> GetGroupById(int id);
        Task<GroupViewModel> EditGroup(GroupViewModel group);
        Task<GroupViewModel> CreateGroup(GroupViewModel group);
        Task<ResultViewModel> DeleteGroup(int id);
        bool checkEmail(string email);
        Task<ResultViewModel> RoleForUser(User userid, int roleid);
        bool checkGroupName(string name);
    }
}
