using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class UserExaminationViewModel
    {
        public static UserExaminationViewModel Convert(UserExamination userExamination)
        {
            if (userExamination == null) return new UserExaminationViewModel();

            var model = new UserExaminationViewModel()
            {
                //UserId = userExamination.UserId,
                UserExaminationId = userExamination.UserExaminationId,
                TimeConsumed = userExamination.TimeConsumed,
                StatusEnumValue = userExamination.StatusEnumValue,
                Score = userExamination.Score,
                ResultEnumValue = userExamination.ResultEnumValue,
                ExamId = userExamination.ExamId,
                CreatedAt = userExamination.CreatedAt,
                Examination = userExamination.Examination == null ? null : ExaminationViewModel.ConvertBasicWithCourse(userExamination.Examination),
                //User = userExamination.User == null ? null : UserViewModel.CovertBasic(userExamination.User),
                UserExaminationAnswers = userExamination.UserExaminationAnswers == null ? null : userExamination.UserExaminationAnswers.Select(x => UserExaminationAnswerViewModel.Convert(x)).ToList(),
                UserExaminationGuid = userExamination.UserExaminationGuid,
                UserMarkStringList = userExamination.UserMarkStringList,
                UserMarkedId = userExamination.UserMarkedId,
                Partner = userExamination.partner != null ? PartnerViewModel.ConvertPartner(userExamination.partner) : null,
                DepartmentTitle = userExamination.partner?.departmentpartner?.title
            };
            return model;
        }

        public static UserExaminationViewModel ConvertBasic(UserExamination userExamination)
        {
            if (userExamination == null) return new UserExaminationViewModel();

            var model = new UserExaminationViewModel()
            {
                //UserId = userExamination.UserId,
                UserExaminationId = userExamination.UserExaminationId,
                TimeConsumed = userExamination.TimeConsumed,
                StatusEnumValue = userExamination.StatusEnumValue,
                Score = userExamination.Score,
                ResultEnumValue = userExamination.ResultEnumValue,
                ExamId = userExamination.ExamId,
                CreatedAt = userExamination.CreatedAt,
                UserExaminationGuid = userExamination.UserExaminationGuid,
                UserMarkStringList = userExamination.UserMarkStringList,
                UserMarkedId = userExamination.UserMarkedId
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

        public ExaminationViewModel Examination { get; set; }
        public UserViewModel User { get; set; }
        public PartnerViewModel Partner { get; set; }
        public string DepartmentTitle { get; set; }
        public ICollection<UserExaminationAnswerViewModel> UserExaminationAnswers { get; set; }
    }
}
