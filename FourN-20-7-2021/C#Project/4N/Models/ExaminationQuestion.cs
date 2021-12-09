using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FourN.Data.Models
{
    public class ExaminationQuestion
    {
        [Key]
        [ForeignKey("Examination")]
        public int ExamId { get; set; }
        [Key]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public int? OrderNo { get; set; }
        public Examination Examination { get; set; }

        public Question Question { get; set; }
    }
}
