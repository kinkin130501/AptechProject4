using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FourN.Data.Models
{
    public class ExaminationQuestionsActive
    {
        [Key]
        public int ExaminationQuestionsActiveId { get; set; }
        
        [ForeignKey("Examination")]
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int? OrderNo { get; set; }
        public string Content { get; set; }
        public int? QuestionType { get; set; }
        public double? Score { get; set; }
        [DefaultValue(true)]
        public bool IsRandom { get; set; }
        public bool? IsGroupQuestion { get; set; }
        public int? ParentQuestionId { get; set; }
        public Examination Examination { get; set; }
        public Guid? QuestionGuid { get; set; }
        public ICollection<AnswerActive> AnswerActive { get; set; }
    }
}
