using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FourN.Data.ViewModel
{
    public class AnswerViewModel
    {
        public static AnswerViewModel Convert(Answer answer)
        {
            if (answer == null) return new AnswerViewModel();

            var model = new AnswerViewModel()
            {
                IsMultipleAnswer = answer.IsMultipleAnswer,
                AnswerId = answer.AnswerId,
                Content = answer.Content,
                IsActive = answer.IsActive,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId,
                Question = answer.Question == null ? null : QuestionViewModel.ConvertBasic(answer.Question),
                CreatedAt = answer.CreatedAt,
                CreatedBy = answer.CreatedBy,
                ModifiedAt = answer.ModifiedAt,
                ModifiedBy = answer.ModifiedBy
            };
            return model;
        }
        public static Answer ConvertToModel(AnswerViewModel answer)
        {
            if (answer == null) return new Answer();

            var model = new Answer()
            {
                IsMultipleAnswer = answer.IsMultipleAnswer,
                AnswerId = answer.AnswerId,
                Content = answer.Content,
                IsActive = answer.IsActive,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId,
                CreatedAt = answer.CreatedAt,
                CreatedBy = answer.CreatedBy,
                ModifiedAt = answer.ModifiedAt,
                ModifiedBy = answer.ModifiedBy
            };
            return model;
        }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsMultipleAnswer { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}
