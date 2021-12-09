using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FourN.Data.ViewModel
{
    public class AnswerCrudModel
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }
        [DefaultValue(false)]
        public bool IsCorrect { get; set; }
        [DefaultValue(false)]
        public bool IsMultipleAnswer { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        //extension for view Create Answer
        public int QuestionType { get; set; }
    }
}
