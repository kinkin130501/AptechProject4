using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class ExaminationQuestionsActiveCrudModel
    {
        public static ExaminationQuestionsActiveCrudModel Convert(ExaminationQuestionsActive questionActive)
        {
            if (questionActive == null) return new ExaminationQuestionsActiveCrudModel();
            var model = new ExaminationQuestionsActiveCrudModel()
            {
                ExamId = questionActive.ExamId,
                QuestionId = questionActive.QuestionId,
                OrderNo = questionActive.OrderNo,
                Content = questionActive.Content,
                QuestionType = questionActive.QuestionType,
                Score = questionActive.Score,
                IsRandom = questionActive.IsRandom,
                IsGroupQuestion = questionActive.IsGroupQuestion,
                ParentQuestionId = questionActive.ParentQuestionId,
                QuestionGuid = questionActive.QuestionGuid,
                ExaminationQuestionsActiveId = questionActive.ExaminationQuestionsActiveId
            };
            return model;
        }

        public int ExaminationQuestionsActiveId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int? OrderNo { get; set; }
        public string Content { get; set; }
        public int? QuestionType { get; set; }
        public double? Score { get; set; }
        public bool IsRandom { get; set; }

        public bool? IsGroupQuestion { get; set; }
        public int? ParentQuestionId { get; set; }
        public Guid? QuestionGuid { get; set; }
        public List<ExaminationQuestionsActiveViewModel> AllQuestionActive { set; get; }
    }
}
