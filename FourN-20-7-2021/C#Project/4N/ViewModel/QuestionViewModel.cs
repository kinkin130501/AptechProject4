using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class QuestionViewModel
    {
        public static QuestionViewModel Convert(Question question)
        {
            if (question == null) return new QuestionViewModel();

            var model = new QuestionViewModel()
            {
                Answers = question.Answers == null ? null : question.Answers.Select(x => AnswerViewModel.Convert(x)).ToList(),
                Content = question.Content,
                IsActive = question.IsActive,
                IsRandom = question.IsRandom,
                QuestionId = question.QuestionId,
                QuestionType = question.QuestionType,
                Score = question.Score,
                CreatedAt = question.CreatedAt,
                CreatedBy = question.CreatedBy,
                ModifiedAt = question.ModifiedAt,
                ModifiedBy = question.ModifiedBy,
                IsGroupQuestion = question.IsGroupQuestion,
                OrderNo = question.OrderNo,
                ParentQuestionId = question.ParentQuestionId,
                QuestionGuid = question.QuestionGuid,
                ContentProviderId = question.ContentProviderId,
            };
            return model;
        }

        public static QuestionViewModel ConvertBasic(Question question)
        {
            if (question == null) return new QuestionViewModel();

            var model = new QuestionViewModel()
            {
                Content = question.Content,
                IsActive = question.IsActive,
                IsRandom = question.IsRandom,
                QuestionId = question.QuestionId,
                QuestionType = question.QuestionType,
                Score = question.Score,
                CreatedAt = question.CreatedAt,
                CreatedBy = question.CreatedBy,
                ModifiedAt = question.ModifiedAt,
                ModifiedBy = question.ModifiedBy,
                IsGroupQuestion = question.IsGroupQuestion,
                OrderNo = question.OrderNo,
                ParentQuestionId = question.ParentQuestionId,
                QuestionGuid = question.QuestionGuid,
                ContentProviderId = question.ContentProviderId,
            };
            return model;
        }
        public int QuestionId { get; set; }
        public int? ExamId { get; set; }
        public string Content { get; set; }
        public int? QuestionType { get; set; }
        public double? Score { get; set; }
        public bool IsRandom { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool? IsGroupQuestion { get; set; }
        public int? OrderNo { get; set; }
        public int? ParentQuestionId { get; set; }
        public Guid? QuestionGuid { get; set; }
        public int? ContentProviderId { get; set; }

        public ICollection<AnswerViewModel> Answers { get; set; }
    }


}
