using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class AnswerActiveCrudModel
    {
        public static AnswerActiveCrudModel Convert(AnswerActive answerActive)
        {
            if (answerActive == null) return new AnswerActiveCrudModel();
            var model = new AnswerActiveCrudModel()
            {
                AnswerId = answerActive.AnswerId,
                ExaminationQuestionsActiveId = answerActive.ExaminationQuestionsActiveId,
                Content = answerActive.Content,
                IsCorrect = answerActive.IsCorrect,
                IsMultipleAnswer = answerActive.IsMultipleAnswer,
                IsActive = answerActive.IsActive,
                CreatedBy = answerActive.CreatedBy,
                CreatedAt = answerActive.CreatedAt,
                ModifiedBy = answerActive.ModifiedBy,
                ModifiedAt = answerActive.ModifiedAt
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
    }
}
