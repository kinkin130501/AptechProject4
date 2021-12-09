using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FourN.Data.Models;
using FourN.Data.ViewModel;

namespace FourN.Data.ViewModel
{
    public class QuestionCrudModel
    {
        public static QuestionCrudModel Convert(Question question)
        {
            if (question == null) return new QuestionCrudModel();

            var model = new QuestionCrudModel()
            {
                Content = question.Content,
                IsActive = question.IsActive,
                IsRandom = question.IsRandom,
                QuestionId = question.QuestionId,
                QuestionType = question.QuestionType,
                Score = question.Score,
                ModifiedBy = question.ModifiedBy,
                ModifiedAt = question.ModifiedAt,
                CreatedBy = question.CreatedBy,
                CreatedAt = question.CreatedAt,
                IsGroupQuestion = question.IsGroupQuestion,
                OrderNo = question.OrderNo,
                ParentQuestionId = question.ParentQuestionId,
                QuestionGuid = question.QuestionGuid,
                ContentProviderId = question.ContentProviderId,
            };
            return model;
        }
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public int? QuestionType { get; set; }
        public double? Score { get; set; }
        [DefaultValue(true)]
        public bool IsRandom { get; set; }
        [DefaultValue(true)]
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

    }

}

