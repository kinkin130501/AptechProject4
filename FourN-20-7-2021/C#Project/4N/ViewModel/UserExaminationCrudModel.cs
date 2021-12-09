using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class UserExaminationCrudModel
    {
        public static UserExaminationCrudModel Convert(UserExamination userExamination)
        {
            if (userExamination == null) return new UserExaminationCrudModel();

            var model = new UserExaminationCrudModel()
            {
                UserExaminationGuid = userExamination.UserExaminationGuid,
                CreatedAt = userExamination.CreatedAt,
                ExamId = userExamination.ExamId,
                ResultEnumValue = userExamination.ResultEnumValue,
                Score = userExamination.Score,
                StatusEnumValue = userExamination.StatusEnumValue,
                TimeConsumed = userExamination.TimeConsumed,
                UserExaminationId = userExamination.UserExaminationId,
                UserId = userExamination.UserId,
                UserMarkStringList = userExamination.UserMarkStringList,
                UserMarkedId = userExamination.UserMarkedId,
                PartnerId = userExamination.partnerid
                
            };
            return model;
        }

        public int UserExaminationId { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int StatusEnumValue { get; set; }
        public double Score { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TimeConsumed { get; set; }
        public int ResultEnumValue { get; set; }
        public Guid UserExaminationGuid { get; set; }
        public string UserMarkStringList { get; set; }
        public int? UserMarkedId { get; set; }
        public int? PartnerId { get; set; }
    }
}
