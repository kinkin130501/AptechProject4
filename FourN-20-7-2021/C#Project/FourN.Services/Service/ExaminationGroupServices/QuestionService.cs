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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IAnswerService _answerService;

        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _answerService = new AnswerService(_unitOfWork);
        }

        public async Task<ResultViewModel> CreateQuestion(QuestionCrudModel model, List<AnswerCrudModel> answerCrudModelsList)
        {
            Question question = new Question
            {
                Content = model.Content,
                IsActive = model.IsActive,
                IsRandom = model.IsRandom,
                QuestionId = model.QuestionId,
                QuestionType = model.QuestionType,
                Score = model.Score,
                CreatedBy = model.CreatedBy,
                CreatedAt = DateTime.Now,
                IsGroupQuestion = model.IsGroupQuestion,
                OrderNo = model.OrderNo,
                ParentQuestionId = model.ParentQuestionId,
                QuestionGuid = model.QuestionGuid,
                ContentProviderId = model.ContentProviderId
            };

            await _unitOfWork.Questions.AddAsync(question);
            await _unitOfWork.CommitAsync();

            var createdQuestion = _unitOfWork.Questions.Find(x => x.Content.Equals(question.Content) && x.CreatedAt.Equals(question.CreatedAt)).FirstOrDefault();

            if (answerCrudModelsList != null)
            {
                foreach (var answer in answerCrudModelsList)
                {
                    answer.QuestionId = createdQuestion.QuestionId;
                    await _answerService.CreateAnswer(answer);
                }
            }

            return new ResultViewModel
            {
                IsSuccess = true
            };
        }

        public List<QuestionViewModel> GetAllActiveQuestions()
        {
            var result = _unitOfWork.Questions.Find(x => x.IsActive == true, x => x.Answers)
                .Select(x => QuestionViewModel.Convert(x)).ToList();
            return result;
        }

        public List<QuestionViewModel> GetAllQuestions()
        {
            var result = _unitOfWork.Questions.Find(x => x.QuestionId != 0, x => x.Answers)
                .Select(x => QuestionViewModel.Convert(x)).OrderByDescending(m => m.CreatedAt).ToList();
            return result;
        }

        public QuestionViewModel GetQuestionById(int id)
        {
            var result = _unitOfWork.Questions.Find(x => x.QuestionId.Equals(id),
                                                 includes: answer => answer.Include(x => x.Answers))
                .Select(x => QuestionViewModel.Convert(x)).FirstOrDefault();
            return result;
        }
        public ExaminationQuestionsActiveViewModel GetQuestionActiveById(int id)
        {
            var result = _unitOfWork.ExaminationQuestionsActives.Find(x => x.ExaminationQuestionsActiveId.Equals(id),
                                                 includes: answer => answer.Include(x => x.AnswerActive))
                .Select(x => ExaminationQuestionsActiveViewModel.Convert(x)).FirstOrDefault();
            return result;
        }

        public QuestionCrudModel GetQuestionCrudModel(int? id)
        {
            if (id == null)
            {
                var model = new QuestionCrudModel();
                return model;
            }

            var questionCrudModel = _unitOfWork.Questions.Find(x => x.QuestionId.Equals(id),
                                                 includes: answer => answer.Include(x => x.Answers))
                .Select(x => QuestionCrudModel.Convert(x)).FirstOrDefault();

            return questionCrudModel;
        }

        public async Task<ResultViewModel> UpdateQuestion(QuestionCrudModel model, List<AnswerCrudModel> answerCrudModelsList)
        {
            var question = await _unitOfWork.Questions.FirstOrDefaultAsync(m => m.QuestionId.Equals(model.QuestionId), includes: x=>x.Include(x=>x.Answers));
            question.Content = model.Content;
            question.IsActive = model.IsActive;
            question.IsRandom = model.IsRandom;
            question.QuestionId = model.QuestionId;
            question.QuestionType = model.QuestionType;
            question.Score = model.Score;
            var questionView = GetQuestionById(question.QuestionId);

            if (answerCrudModelsList != null)
            {
                foreach (var i in question.Answers)
                {
                    _unitOfWork.Answers.Delete(i);
                }

                foreach (var answer in answerCrudModelsList)
                {
                    answer.QuestionId = question.QuestionId;
                    await _answerService.CreateAnswer(answer);
                }
            }
            await _unitOfWork.CommitAsync();
            return new ResultViewModel
            {
                IsSuccess = true
            };
        }

        public async Task<ResultViewModel> DeleteQuestionById(int id)
        {
            var question = _unitOfWork.Questions.Find(x => x.QuestionId.Equals(id)).FirstOrDefault();

            _unitOfWork.Questions.Delete(question);
            await _unitOfWork.CommitAsync();
            return new ResultViewModel
            {
                IsSuccess = true
            };
        }

        public List<QuestionViewModel> GetAllQuestionByParentId(int parentId)
        {
            var result = _unitOfWork.Questions.Find(x => x.ParentQuestionId.Equals(parentId)
                                                 /*includes: answer => answer.Include(x => x.Answers)*/)
                .Select(x => QuestionViewModel.Convert(x)).ToList();
            return result;
        }

        public List<QuestionViewModel> SearchQuestions(SearchQuestionViewModel model)
        {
            var questions = _unitOfWork.Questions.BuildQuery(x => x.IsActive == true && x.Content != null && x.ParentQuestionId == null);


            if (model.HasSearch)
            {

                if (model.QuestionType != null && model.QuestionType != 0)
                {
                    questions = questions.Where(x => model.QuestionType.Equals(x.QuestionType));
                }

                

                if (model.DateStart != null)
                {
                    questions = questions.Where(x => model.DateStart.Value.Date <= x.CreatedAt.Value.Date);
                }

                if (model.DateEnd != null)
                {
                    questions = questions.Where(x => model.DateEnd.Value.Date >= x.CreatedAt.Value.Date);
                }

            }

            questions = questions.Include(i => i.Answers).OrderByDescending(x => x.CreatedAt);



            var result = questions.Select(x => QuestionViewModel.Convert(x)).ToList();
            return result;
        }
    }
}
