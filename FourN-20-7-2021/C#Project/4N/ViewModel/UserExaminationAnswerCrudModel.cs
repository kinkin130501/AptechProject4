using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class UserExaminationAnswerCrudModel
    {
        public static UserExaminationAnswerCrudModel Convert(UserExaminationAnswer userExamination)
        {
            if (userExamination == null) return new UserExaminationAnswerCrudModel();

            var model = new UserExaminationAnswerCrudModel()
            {
                UserExaminationAnswerId = userExamination.UserExaminationAnswerId,
                AnswerContent = userExamination.AnswerContent,
                IsEssayAnswer = userExamination.IsEssayAnswer,
                IsRightAnswer = userExamination.IsRightAnswer,
                QuestionId = userExamination.QuestionId,
                Score = userExamination.Score,
                UserExaminationId = userExamination.UserExaminationId,
                ExaminationQuestionsActiveId = userExamination.ExaminationQuestionsActiveId

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
        //for upgrade
        public int ExaminationQuestionsActiveId { get; set; }
    }
}
