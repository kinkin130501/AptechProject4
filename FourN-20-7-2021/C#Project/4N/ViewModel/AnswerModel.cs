using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class AnswerModel
    {
        public string AnswerContent { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public int AnswerCount { get; set; }
    }
}
