using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FourN.Data.ViewModel;

namespace FourN.Services.IService
{
    public interface IExaminationService
    {
        Task<ResultViewModel> CreateExamination(ExaminationCrudModel model, List<int> questionIdList);
        List<ExaminationViewModel> GetAllExaminations();
        List<ExaminationViewModel> GetAllExaminationsByCompany(int? companyId);
        ExaminationCrudModel GetExaminationCrudModel(int? id);
        ExaminationViewModel GetExaminationById(int id);
        Task<ResultViewModel> DeleteExamById(int id);
    }
}
