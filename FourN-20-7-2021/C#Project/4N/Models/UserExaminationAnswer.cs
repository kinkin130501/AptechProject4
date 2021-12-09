using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FourN.Data.Models
{
    public class UserExaminationAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserExaminationAnswerId { get; set; }

        [ForeignKey("UserExamination")]
        public int UserExaminationId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsRightAnswer { get; set; }
        public bool IsEssayAnswer { get; set; }
        public double Score { get; set; }
        public int ExaminationQuestionsActiveId { get; set; } //for upgrade

        public UserExamination UserExamination { get; set; }
    }
}
