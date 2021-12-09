using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FourN.Data.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public int? QuestionType { get; set; }
        public double? Score { get; set; }
        [DefaultValue(true)]
        public bool IsRandom { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public bool? IsGroupQuestion { get; set; }
        public int? OrderNo { get; set; }
        public int? ParentQuestionId { get; set; }

        [JsonIgnore]
        public ICollection<Answer> Answers { get; set; }
        public Guid? QuestionGuid { get; set; }
        public int? ContentProviderId { get; set; }

    }
}
