using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FourN.Data.ViewModel;

namespace FourN.Services.IService
{
    public interface IAnswerActiveService
    {
        Task<ResultViewModel> CreateAnswerActive(AnswerActiveCrudModel model);
    }
}
