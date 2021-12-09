using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FourN.Data.Models
{
    public class UserExamination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserExaminationId { get; set; }  
        public int UserId { get; set; }
        [ForeignKey("Examination")]
        public int ExamId { get; set; }
        public int StatusEnumValue { get; set; }
        public double Score { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TimeConsumed { get; set; }
        public int ResultEnumValue { get; set; }
        public Guid UserExaminationGuid { get; set; }
        public string UserMarkStringList { get; set; }
        public int? UserMarkedId { get; set; }

        public Examination Examination { get; set; }
        public User User { get; set; }
        public ICollection<UserExaminationAnswer> UserExaminationAnswers { get; set; }
        public Partner partner { get; set; }
        [ForeignKey("Partner")]
        public int? partnerid { get; set; }
    }
}
