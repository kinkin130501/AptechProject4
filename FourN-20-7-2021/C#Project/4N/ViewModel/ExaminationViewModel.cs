using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class ExaminationViewModel
    {
        public static ExaminationViewModel Convert(Examination examination)
        {
            if (examination == null) return new ExaminationViewModel();

            var model = new ExaminationViewModel()
            {
                IsActive = examination.IsActive,
                CreatedAt = examination.CreatedAt,
                CreatedBy = examination.CreatedBy,
                ExamType = examination.ExamType,
                ExamId = examination.ExamId,
                ModifiedAt = examination.ModifiedAt,
                MaxScore = examination.MaxScore,
                ModifiedBy = examination.ModifiedBy,
                Name = examination.Name,
                PassScore = examination.PassScore,
                TotalQuestion = examination.TotalQuestion,
                //Course = examination.Course == null ? null : CourseViewModel.ConvertBasic(examination.Course),
                //Lesson = examination.Lesson == null ? null : LessonViewModel.ConvertBasic(examination.Lesson),
                ExaminationQuestions = examination.ExaminationQuestions == null ? null : examination.ExaminationQuestions.Select(x => ExaminationQuestionViewModel.Convert(x)).ToList(),
                //Section = examination.Section == null ? null : SectionViewModel.ConvertBasic(examination.Section),
                IsDeleted = examination.IsDeleted,
                TotalTime = examination.TotalTime,
                UserExaminations = examination.UserExaminations == null ? null : examination.UserExaminations.Select(x => UserExaminationViewModel.Convert(x)).ToList(),
                ContentProviderId = examination.ContentProviderId,
                UserMarkStringList = examination.UserMarkStringList,
                ExaminationQuestionsActives = examination.ExaminationQuestionsActive == null ? null : examination.ExaminationQuestionsActive.Select( x=> ExaminationQuestionsActiveViewModel.Convert(x)).ToList()
            };
            return model;
        }

        public static ExaminationViewModel ConvertBasic(Examination examination)
        {
            if (examination == null) return new ExaminationViewModel();

            var model = new ExaminationViewModel()
            {
                IsActive = examination.IsActive,
                CreatedAt = examination.CreatedAt,
                CreatedBy = examination.CreatedBy,
                ExamType = examination.ExamType,
                ExamId = examination.ExamId,
                ModifiedAt = examination.ModifiedAt,
                MaxScore = examination.MaxScore,
                ModifiedBy = examination.ModifiedBy,
                Name = examination.Name,
                PassScore = examination.PassScore,
                IsDeleted = examination.IsDeleted,
                TotalQuestion = examination.TotalQuestion,
                TotalTime = examination.TotalTime,
                ContentProviderId = examination.ContentProviderId,
                UserMarkStringList = examination.UserMarkStringList
            };
            return model;
        }

        public static ExaminationViewModel ConvertBasicWithCourse(Examination examination)
        {
            if (examination == null) return new ExaminationViewModel();

            var model = new ExaminationViewModel()
            {
                IsActive = examination.IsActive,
                CreatedAt = examination.CreatedAt,
                CreatedBy = examination.CreatedBy,
                ExamType = examination.ExamType,
                ExamId = examination.ExamId,
                ModifiedAt = examination.ModifiedAt,
                MaxScore = examination.MaxScore,
                ModifiedBy = examination.ModifiedBy,
                Name = examination.Name,
                PassScore = examination.PassScore,
                IsDeleted = examination.IsDeleted,
                TotalQuestion = examination.TotalQuestion,
                TotalTime = examination.TotalTime,
                ContentProviderId = examination.ContentProviderId,
                UserMarkStringList = examination.UserMarkStringList,
            };
            return model;
        }

        public int ExamId { get; set; }
        public string Name { get; set; }
        public int ExamType { get; set; }
        public double? MaxScore { get; set; }
        public double? PassScore { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? TotalQuestion { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { set; get; }
        public int? TotalTime { get; set; }
        public int? ContentProviderId { get; set; }
        public int? CompanyId { get; set; }
        public string UserMarkStringList { get; set; }

        public ICollection<ExaminationQuestionViewModel> ExaminationQuestions { get; set; }
        public ICollection<UserExaminationViewModel> UserExaminations { get; set; }
        public ICollection<ExaminationQuestionsActiveViewModel> ExaminationQuestionsActives { get; set; }

        //extention for MockExam
        public Guid? UserExaminationGuid { get; set; }

        //extension for view detail userExam
        public List<UserExaminationAnswerViewModel> UserExamRightAnswerList { get; set; }
        public List<UserExaminationAnswerViewModel> UserExamUnRightAnswerList { get; set; }
        public List<UserExaminationAnswerViewModel> UserExamAnswerList { get; set; }
        public int UserExaminationId { get; set; }
        public double CurrentScore { get; set; }
        public int StatusValue { get; set; }


    }
}
