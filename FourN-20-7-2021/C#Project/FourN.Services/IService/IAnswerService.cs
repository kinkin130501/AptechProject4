using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FourN.Data.ViewModel;

namespace FourN.Services.IService
{
    public interface IAnswerService
    {
        Task<ResultViewModel> CreateAnswer(AnswerCrudModel model);
        AnswerCrudModel GetAnswerCrudModel(int? id);
    }
}
