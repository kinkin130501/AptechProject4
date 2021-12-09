using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.Models;

namespace FourN.Data.ViewModel
{
    public class QuestionGroupViewModel
    {
        public string Content { get; set; }
        public int? QuestionType { get; set; }
        //public CourseViewModel Course { get; set; }
        //public SectionViewModel Section { get; set; }
        //public LessonViewModel Lesson { get; set; }
        public List<QuestionViewModel> QuestionViewModels { set; get; }
    }
}
