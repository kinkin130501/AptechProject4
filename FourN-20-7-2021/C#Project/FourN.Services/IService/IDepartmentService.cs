using FourN.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Services.IService
{
    public interface IDepartmentService
    {
        List<DepartmentViewModel> findAll();
        List<DepartmentViewModel> findAllForManage();
        DepartmentViewModel findOne(int id);
        Task<ResultViewModel> ApplyPartner(ApplyModel model);
        Task<ResultViewModel> UpdateDepartmentStatus(int departmentid, int status);
        List<PartnerViewModel> GetListCandicateFromDepartmentId(int id);
        Task<ResultViewModel> CreateDepartment(DepartmentModel department);
        Task<ResultViewModel> DeleteDepartment(int departmentid);
        List<RequestViewModel> findAllRequest();
        Task<ResultViewModel> CreateInterview(InterviewModel model);
        List<UserViewModel> getAllLead();
        DepartmentModel showEdit(int departmentid);
        Task<ResultViewModel> Edit(DepartmentModel model);
        Task<OldInterviewModel> getlateInterView(int departmentid);
    }
}
