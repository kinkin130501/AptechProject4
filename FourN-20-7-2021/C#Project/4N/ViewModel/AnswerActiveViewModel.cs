using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class AnswerActiveViewModel
    {
        public static AnswerActiveViewModel Convert(AnswerActive answer)
        {
            if (answer == null) return new AnswerActiveViewModel();
            var model = new AnswerActiveViewModel()
            {
                AnswerId = answer.AnswerId,
                ExaminationQuestionsActiveId = answer.ExaminationQuestionsActiveId,
                Content = answer.Content,
                IsCorrect = answer.IsCorrect,
                IsMultipleAnswer = answer.IsMultipleAnswer,
                IsActive = answer.IsActive,
                CreatedBy = answer.CreatedBy,
                CreatedAt = answer.CreatedAt,
                ModifiedBy = answer.ModifiedBy,
                ModifiedAt = answer.ModifiedAt,
                ExaminationQuestionsActive = answer.ExaminationQuestionsActive == null ? null : ExaminationQuestionsActiveViewModel.ConvertBasic(answer.ExaminationQuestionsActive)
            };
            return model;
        }
        public int AnswerId { get; set; }
        public int ExaminationQuestionsActiveId { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsMultipleAnswer { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ExaminationQuestionsActiveViewModel ExaminationQuestionsActive { get; set; }
    }
}
