using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FourN.Data.ViewModel;

namespace FourN.Services.IService
{
    public interface IExaminationQuestionsActiveService
    {
        ExaminationQuestionsActiveViewModel GetQuestionActiveById(int id);

    }
}
