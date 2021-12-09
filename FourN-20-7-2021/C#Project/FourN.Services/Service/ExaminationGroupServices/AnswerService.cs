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
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> CreateAnswer(AnswerCrudModel model)
        {
            Answer answer = new Answer
            {
                Content = model.Content,
                CreatedBy = model.CreatedBy,
                CreatedAt = DateTime.Now,
                IsActive = model.IsActive,
                IsCorrect = model.IsCorrect,
                IsMultipleAnswer = model.IsMultipleAnswer,
                QuestionId = model.QuestionId
            };

            await _unitOfWork.Answers.AddAsync(answer);
            await _unitOfWork.CommitAsync();

            return new ResultViewModel
            {
                IsSuccess = true
            };
        }

        public AnswerCrudModel GetAnswerCrudModel(int? id)
        {
            if (id == null)
            {
                var model = new AnswerCrudModel();
                return model;
            }

            var answer = _unitOfWork.Answers.Find(x => x.AnswerId.Equals(id)).FirstOrDefault();
            AnswerCrudModel answerCrudModel = new AnswerCrudModel
            {
                AnswerId = answer.AnswerId,
                IsActive = answer.IsActive,
                Content = answer.Content,
                IsCorrect = answer.IsCorrect,
                CreatedAt = answer.CreatedAt,
                CreatedBy = answer.CreatedBy,
                IsMultipleAnswer = answer.IsMultipleAnswer,
                QuestionId = answer.QuestionId,
                ModifiedAt = answer.ModifiedAt,
                ModifiedBy = answer.ModifiedBy
            };

            return answerCrudModel;
        }
    }
}
