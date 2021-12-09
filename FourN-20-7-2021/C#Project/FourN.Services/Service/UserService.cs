using FourN.Data;
using FourN.Data.Models;
using FourN.Data.ViewModel;
using FourN.Services.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Services.Service
{

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool checkEmail(string mail)
        {
            var email = _unitOfWork.Users.FirstOrDefaultAsync(x => x.email.Equals(mail)).Result;
            if(email == null)
            {
                return false;
            }
            return true;
        }

        public bool checkGroupName(string name)
        {
            var nameGr = _unitOfWork.Groups.FirstOrDefaultAsync(x => x.isdeleted == false && x.groupname.Equals(name)).Result;
            if(nameGr != null)
            {
                return false;
            }
            return true;
        }

        public async Task<GroupViewModel> CreateGroup(GroupViewModel group)
        {
            var newGroup = new Groups()
            {
                groupname = group.GroupName,
            };
            await _unitOfWork.Groups.AddAsync(newGroup);
            await _unitOfWork.CommitAsync();
            var newLeader = new Groupuser()
            {
                group = newGroup,
                userid = group.LeaderId,
                isleader = true,
            };
            await _unitOfWork.Groupusers.AddAsync(newLeader);
            if(group.Listmembersid != null && group.Listmembersid.Any())
            {
                foreach (var item in group.Listmembersid)
                {
                    var groupuser = new Groupuser()
                    {
                        group = newGroup,
                        userid = item,
                        isleader = false,
                    };
                    await _unitOfWork.Groupusers.AddAsync(groupuser);
                }
            }
            
            await _unitOfWork.CommitAsync();
            return group;
        }

        public async Task<ResultViewModel> DeleteGroup(int id)
        {
            try
            {
                var view = await _unitOfWork.Groups.FirstOrDefaultAsync(x => x.groupid == id, includes: x => x.Include(x => x.groupusers).ThenInclude(x => x.user));
                if (view.groupusers != null && view.groupusers.Any())
                {
                    foreach (var item in view.groupusers)
                    {
                        _unitOfWork.Groupusers.Delete(item);
                    }
                }
                view.isdeleted = true;
                await _unitOfWork.CommitAsync();
                return ResultViewModel.Success();
            }
            catch
            {
                return ResultViewModel.Fail("Error !");
            }

        }

        public async Task<GroupViewModel> EditGroup(GroupViewModel group)
        {
            var view = await _unitOfWork.Groups.FirstOrDefaultAsync(x => x.groupid == group.GroupId, includes: x => x.Include(x => x.groupusers).ThenInclude(x => x.user));
            view.groupname = group.GroupName;
            if(view.groupusers != null && view.groupusers.Any())
            {
                foreach (var item in view.groupusers)
                {
                    _unitOfWork.Groupusers.Delete(item);
                }
            }         
            var newLeader = new Groupuser()
            {
                groupid = group.GroupId,
                userid = group.LeaderId,
                isleader = true,
            };
            await _unitOfWork.Groupusers.AddAsync(newLeader);
            if(group.Listmembersid != null && group.Listmembersid.Any())
            {
                foreach (var item in group.Listmembersid)
                {
                    var groupuser = new Groupuser()
                    {
                        groupid = group.GroupId,
                        userid = item,
                        isleader = false,
                    };
                    await _unitOfWork.Groupusers.AddAsync(groupuser);
                }
            }       
            await _unitOfWork.CommitAsync();
            return group;
        }
        public List<GroupViewModel> GetGroup()
        {
            var groups =  _unitOfWork.Groups.Find(x => x.groupid != 0, includes: x => x.Include(x => x.groupusers).ThenInclude(x => x.user)).Where(x=>x.isdeleted == false)
                .Select(x => GroupViewModel.ConvertFromGroup(x)).ToList();

            foreach (var item in groups)
            {
                List<string> projectName = new List<string>();
                var grProjects = _unitOfWork.Projectgroup.Find(x => x.groupid == item.GroupId).Select(x => x.projectid);
                foreach (var group in grProjects)
                {
                    var project = _unitOfWork.Projects
                        .FirstOrDefaultAsync(x => x.projectid == group && (x.status == 1 || x.status == 2 || x.status == 3 || x.status == 4 || x.status == 5)).Result;
                    if(project != null)
                    {
                        projectName.Add(project.projectname);
                    }
                }
                item.ProjectName = string.Join(",", projectName);
            }
            return  groups;
        }

        public async Task<GroupViewModel> GetGroupById(int id)
        {
            var group = await _unitOfWork.Groups.FirstOrDefaultAsync(x => x.groupid == id, includes: x=>x.Include(x=>x.groupusers).ThenInclude(x=>x.user));
            return GroupViewModel.ConvertFromGroup(group);
        }

        public async Task<ResultViewModel> RoleForUser(User userid, int roleid)
        {
            try
            {
                var user = new Useruserrole()
                {
                    user = userid,
                    userroleid = roleid,
                };
                await _unitOfWork.UserUserRoles.AddAsync(user);
                await _unitOfWork.CommitAsync();
                return ResultViewModel.Success();
            }
            catch
            {
                return ResultViewModel.Fail("Error !");
            }
        }
    }
}
