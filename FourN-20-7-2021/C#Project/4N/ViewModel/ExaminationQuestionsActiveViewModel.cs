using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class ExaminationQuestionsActiveViewModel
    {
        public static ExaminationQuestionsActiveViewModel Convert(ExaminationQuestionsActive examinationQuestionsActive)
        {
            if (examinationQuestionsActive == null) return new ExaminationQuestionsActiveViewModel();
            var model = new ExaminationQuestionsActiveViewModel(){
                ExamId = examinationQuestionsActive.ExamId,
                QuestionId = examinationQuestionsActive.QuestionId,
                OrderNo = examinationQuestionsActive.OrderNo,
                Content = examinationQuestionsActive.Content,
                QuestionType = examinationQuestionsActive.QuestionType,
                ExaminationQuestionsActiveId = examinationQuestionsActive.ExaminationQuestionsActiveId,
                Score = examinationQuestionsActive.Score,
                IsRandom = examinationQuestionsActive.IsRandom,
                IsGroupQuestion = examinationQuestionsActive.IsGroupQuestion,
                ParentQuestionId = examinationQuestionsActive.ParentQuestionId,
                Examination = examinationQuestionsActive.Examination == null ? null : ExaminationViewModel.ConvertBasic(examinationQuestionsActive.Examination),
                QuestionGuid = examinationQuestionsActive.QuestionGuid,
                AnswerActive = examinationQuestionsActive.AnswerActive == null ? null : examinationQuestionsActive.AnswerActive.Select(x => AnswerActiveViewModel.Convert(x)).ToList() 
            };
            return model;
        }

        public static ExaminationQuestionsActiveViewModel ConvertBasic(ExaminationQuestionsActive examinationQuestionsActive)
        {
            if (examinationQuestionsActive == null) return new ExaminationQuestionsActiveViewModel();
            var model = new ExaminationQuestionsActiveViewModel()
            {
                ExamId = examinationQuestionsActive.ExamId,
                ExaminationQuestionsActiveId = examinationQuestionsActive.ExaminationQuestionsActiveId,
                QuestionId = examinationQuestionsActive.QuestionId,
                OrderNo = examinationQuestionsActive.OrderNo,
                Content = examinationQuestionsActive.Content,
                QuestionType = examinationQuestionsActive.QuestionType,
                Score = examinationQuestionsActive.Score,
                IsRandom = examinationQuestionsActive.IsRandom,
                IsGroupQuestion = examinationQuestionsActive.IsGroupQuestion,
                ParentQuestionId = examinationQuestionsActive.ParentQuestionId,
                QuestionGuid = examinationQuestionsActive.QuestionGuid,
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
        [DefaultValue(true)]
        public bool IsRandom { get; set; }
        public bool? IsGroupQuestion { get; set; }
        public int? ParentQuestionId { get; set; }
        public ExaminationViewModel Examination { get; set; }
        public Guid? QuestionGuid { get; set; }
        public List<AnswerActiveViewModel> AnswerActive { get; set; }
    }
}
