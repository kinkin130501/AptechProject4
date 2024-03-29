﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FourN.Data.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        [ForeignKey("Question")]
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

        public Question Question { get; set; }
    }
}
