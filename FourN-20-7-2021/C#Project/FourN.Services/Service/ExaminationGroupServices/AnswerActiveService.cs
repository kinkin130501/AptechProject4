using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourN.Data;
using FourN.Data.Models;
using FourN.Data.ViewModel;
using FourN.Services.IService;

namespace FourN.Services.ExaminationGroupServices
{
    public class AnswerActiveService : IAnswerActiveService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnswerActiveService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<ResultViewModel> CreateAnswerActive(AnswerActiveCrudModel model)
        {
            AnswerActive answerActive = new AnswerActive()
            {
                AnswerId = model.AnswerId,
                Content = model.Content,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                IsActive = model.IsActive,
                IsCorrect = model.IsCorrect,
                IsMultipleAnswer = model.IsMultipleAnswer,
                ModifiedAt = model.ModifiedAt,
                ModifiedBy = model.ModifiedBy,
                ExaminationQuestionsActiveId = model.ExaminationQuestionsActiveId
            };
            await _unitOfWork.AnswerActives.AddAsync(answerActive);
            await _unitOfWork.CommitAsync();

            return new ResultViewModel
            {
                IsSuccess = true
            };
        }
    }
}
