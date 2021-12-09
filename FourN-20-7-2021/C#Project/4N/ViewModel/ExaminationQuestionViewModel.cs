using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class ExaminationQuestionViewModel
    {
        public static ExaminationQuestionViewModel Convert(ExaminationQuestion examinationQuestion)
        {
            if (examinationQuestion == null) return new ExaminationQuestionViewModel();

            var model = new ExaminationQuestionViewModel()
            {
             ExamId = examinationQuestion.ExamId,
             QuestionId = examinationQuestion.QuestionId,
             OrderNo = examinationQuestion.OrderNo,
             Examination = examinationQuestion.Examination == null ? null : ExaminationViewModel.ConvertBasic(examinationQuestion.Examination),
             Question = examinationQuestion.Question == null ? null : QuestionViewModel.ConvertBasic(examinationQuestion.Question)
            };
            return model;
        }

        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int? OrderNo { get; set; }
        public ExaminationViewModel Examination { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}
