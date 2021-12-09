using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FourN.Data.Models;
using FourN.Data.ViewModel;

namespace FourN.Services.IService
{
    public interface IUserExaminationService
    {
        Task<ResultViewModel> CreateUserExamination(UserExaminationCrudModel model);
        Task<ResultViewModel> CreateUserExaminationAnswers(List<UserExaminationAnswerCrudModel> listModel);
        Task<ResultViewModel> UpdateUserExamination(UserExaminationCrudModel model);
        List<UserExaminationViewModel> GetAllUserExaminations();
        UserExaminationCrudModel GetUserExaminationCrudModel(string guid);
        UserExaminationViewModel GetUserExaminationById(int id);
        List<UserExaminationViewModel> SearchUserExaminations(SearchUserExaminationViewModel model);
        List<UserExaminationViewModel> SearchCandidateExaminations(SearchUserExaminationViewModel model);
    }
}
