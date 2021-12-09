using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class UserExaminationAnswerViewModel
    {
        public static UserExaminationAnswerViewModel Convert(UserExaminationAnswer answer)
        {
            if (answer == null) return new UserExaminationAnswerViewModel();

            var model = new UserExaminationAnswerViewModel()
            {
                UserExamination = answer.UserExamination == null ? null : UserExaminationViewModel.ConvertBasic(answer.UserExamination),
                UserExaminationAnswerId = answer.UserExaminationAnswerId,
                UserExaminationId = answer.UserExaminationId,
                QuestionId = answer.QuestionId,
                AnswerContent = answer.AnswerContent,
                IsEssayAnswer = answer.IsEssayAnswer,
                IsRightAnswer = answer.IsRightAnswer,
                Score = answer.Score,
                ExaminationQuestionsActiveId = answer.UserExaminationAnswerId
            };
            return model;
        }
        public int UserExaminationAnswerId { get; set; }
        public int UserExaminationId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsRightAnswer { get; set; }
        public bool IsEssayAnswer { get; set; }
        public double Score { get; set; }
        public int ExaminationQuestionsActiveId { get; set; } //for upgrade

        public UserExaminationViewModel UserExamination { get; set; }
    }
}
