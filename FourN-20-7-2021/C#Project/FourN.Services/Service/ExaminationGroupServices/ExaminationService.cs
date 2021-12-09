using Microsoft.EntityFrameworkCore;
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
    public class ExaminationService : IExaminationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IQuestionService _questionService;

        public ExaminationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _questionService = new QuestionService(unitOfWork);
        }
        public async Task<ResultViewModel> CreateExamination(ExaminationCrudModel model, List<int> questionIdList)
        {
            Examination examination = new Examination
            {
                ExamType = model.ExamType,
                MaxScore = model.MaxScore,
                Name = model.Name,
                PassScore = model.PassScore,
                TotalQuestion = model.TotalQuestion,
                IsActive = model.IsActive,
                CreatedBy = model.CreatedBy,
                CreatedAt = DateTime.Now,
                TotalTime = model.TotalTime,
                ContentProviderId = model.ContentProviderId,
                UserMarkStringList = model.UserMarkStringList
            };

            await _unitOfWork.Examinations.AddAsync(examination);
            await _unitOfWork.CommitAsync();
            var createdExam = _unitOfWork.Examinations.Find(x => x.Name.Equals(examination.Name) && x.CreatedAt.Equals(examination.CreatedAt)).FirstOrDefault();

            if (questionIdList != null)
            {
                var listExamQuestion = new List<ExaminationQuestionsActive>();
                var order = 0;
                foreach (var questionId in questionIdList)
                {
                    order++;
                    var question = _questionService.GetQuestionById(questionId);
                    var examQuestionActive = new ExaminationQuestionsActive
                    {
                        ExamId = createdExam.ExamId,
                        QuestionId = questionId,
                        OrderNo = order,
                        Content = question.Content,
                        IsGroupQuestion = question.IsGroupQuestion,
                        IsRandom = question.IsRandom,
                        ParentQuestionId = question.ParentQuestionId,
                        QuestionGuid = Guid.NewGuid(),
                        QuestionType = question.QuestionType,
                        Score = question.Score,
                    };
                    await _unitOfWork.ExaminationQuestionsActives.AddAsync(examQuestionActive);
                    await _unitOfWork.CommitAsync();

                    var examQuestionActiveId = _unitOfWork.ExaminationQuestionsActives.Find(x => x.QuestionGuid.ToString().Equals(examQuestionActive.QuestionGuid.ToString())).FirstOrDefault().ExaminationQuestionsActiveId;
                    foreach(var q in question.Answers)
                    {
                        var answerActive = new AnswerActive
                        {
                            ExaminationQuestionsActiveId = examQuestionActiveId,
                            Content = q.Content,
                            CreatedAt = q.CreatedAt,
                            CreatedBy = q.CreatedBy,
                            IsActive = q.IsActive,
                            IsCorrect = q.IsCorrect,
                            IsMultipleAnswer = q.IsMultipleAnswer,
                            ModifiedAt = q.ModifiedAt,
                            ModifiedBy = q.ModifiedBy
                        };
                        await _unitOfWork.AnswerActives.AddAsync(answerActive);
                    }
                    await _unitOfWork.CommitAsync();
                }
            }
            

            return new ResultViewModel
            {
                IsSuccess = true
            };
        }

        public List<ExaminationViewModel> GetAllExaminations()
        {
            var result = _unitOfWork.Examinations.Find(x => x.ExamId != 0 && x.IsDeleted != true, 
                                                includes: answer => answer.Include(x => x.ExaminationQuestions).ThenInclude(q => q.Question))
                .Select(x => ExaminationViewModel.Convert(x)).OrderByDescending(m => m.CreatedAt.Value).ToList();
            return result;
        }

        public ExaminationViewModel GetExaminationById(int id)
        {
            var result = _unitOfWork.Examinations.Find(x => x.ExamId.Equals(id),
                                                 includes: eq => eq.Include(x => x.ExaminationQuestions)
                                                 .ThenInclude(q => q.Question)
                                                 .ThenInclude(a => a.Answers)
                                                 .Include(qa => qa.ExaminationQuestionsActive)
                                                 .ThenInclude(z => z.AnswerActive))
                .Select(x => ExaminationViewModel.Convert(x)).FirstOrDefault();
            return result;
        }

        public ExaminationCrudModel GetExaminationCrudModel(int? id)
        {
            if (id == null)
            {
                var model = new ExaminationCrudModel();
                return model;
            }

            var questionCrudModel = _unitOfWork.Examinations.Find(x => x.ExamId.Equals(id),
                                                 includes: eq => eq.Include(x => x.ExaminationQuestions).ThenInclude(q => q.Question))
                .Select(x => ExaminationCrudModel.Convert(x)).FirstOrDefault();

            return questionCrudModel;
        }

        public async Task<ResultViewModel> DeleteExamById(int id)
        {
            var exam = _unitOfWork.Examinations.Find(x => x.ExamId.Equals(id)).FirstOrDefault();
            exam.IsDeleted = true;
            await _unitOfWork.CommitAsync();
            return new ResultViewModel
            {
                IsSuccess = true
            };
        }

        public List<ExaminationViewModel> GetAllExaminationsByCompany(int? companyId)
        {
            var result = _unitOfWork.Examinations.Find(x => x.IsDeleted != true,
                                                includes: answer => answer.Include(x => x.ExaminationQuestions).ThenInclude(q => q.Question))
                .Select(x => ExaminationViewModel.Convert(x)).OrderByDescending(m => m.CreatedAt.Value).ToList();
            return result;
        }
    }
}
