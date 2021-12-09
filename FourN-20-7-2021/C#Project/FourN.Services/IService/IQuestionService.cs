using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FourN.Data.Models;
using FourN.Data.ViewModel;

namespace FourN.Services.IService
{
    public interface IQuestionService
    {
        Task<ResultViewModel> CreateQuestion(QuestionCrudModel model, List<AnswerCrudModel> answerCrudModelsList);
        Task<ResultViewModel> UpdateQuestion(QuestionCrudModel model, List<AnswerCrudModel> answerCrudModelsList);
        List<QuestionViewModel> GetAllQuestions();
        List<QuestionViewModel> GetAllActiveQuestions();
        QuestionCrudModel GetQuestionCrudModel(int? id);
        QuestionViewModel GetQuestionById(int id);
        ExaminationQuestionsActiveViewModel GetQuestionActiveById(int id);
        Task<ResultViewModel> DeleteQuestionById(int id);
        List<QuestionViewModel> GetAllQuestionByParentId(int parentId);

        List<QuestionViewModel> SearchQuestions(SearchQuestionViewModel model);
    }
}
