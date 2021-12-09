using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class QuestionModel
    {
        public string QuestionContent { get; set; }
        public int Mark { get; set; }
        public int QuestionCount { get; set; }
        public ICollection<AnswerModel> Answers { get; set; }
    }
}
