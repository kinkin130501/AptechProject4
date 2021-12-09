using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourN.Data;
using FourN.Data.Models;
using FourN.Data.ViewModel;
using FourN.Services.IService;

namespace FourN.Services.Service
{
    public class ExaminationQuestionsActiveService : IExaminationQuestionsActiveService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IAnswerActiveService _answerActiveService;

        public ExaminationQuestionsActiveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ExaminationQuestionsActiveViewModel GetQuestionActiveById(int id)
        {
            var result = _unitOfWork.ExaminationQuestionsActives.Find(x => x.QuestionId.Equals(id))
                .Select(x => ExaminationQuestionsActiveViewModel.Convert(x)).FirstOrDefault();
            return result;
        }
        
    }
}
