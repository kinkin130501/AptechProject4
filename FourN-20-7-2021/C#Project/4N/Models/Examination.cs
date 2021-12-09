using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FourN.Data.Models
{
    public class Examination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public int? TotalTime { get; set; }
        public bool IsDeleted { set; get; }
        public ICollection<ExaminationQuestion> ExaminationQuestions { get; set; }
        public ICollection<UserExamination> UserExaminations { get; set; }
        public ICollection<ExaminationQuestionsActive> ExaminationQuestionsActive { get; set; }
        public int? ContentProviderId { get; set; }
        public string UserMarkStringList { get; set; }
    }
}
