using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class ExaminationCrudModel
    {
        public static ExaminationCrudModel Convert(Examination examination)
        {
            if (examination == null) return new ExaminationCrudModel();

            var model = new ExaminationCrudModel()
            {
                
                ModifiedBy = examination.ModifiedBy,
                ModifiedAt = examination.ModifiedAt,
                CreatedBy = examination.CreatedBy,
                CreatedAt = examination.CreatedAt,
                ExamId = examination.ExamId,
                ExamType = examination.ExamType,
                IsActive = examination.IsActive,
                MaxScore = examination.MaxScore,
                Name = examination.Name,
                PassScore = examination.PassScore,
                TotalQuestion = examination.TotalQuestion,
                TotalTime = examination.TotalTime,
                ContentProviderId = examination.ContentProviderId,
                UserMarkStringList = examination.UserMarkStringList,
                IsDeleted = examination.IsDeleted
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
        public string UserMarkStringList { get; set; }
    }
}
