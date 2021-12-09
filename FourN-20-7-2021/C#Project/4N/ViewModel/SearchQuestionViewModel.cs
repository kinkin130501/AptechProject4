using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.Models;
using FourN.Data.ViewModel;

namespace FourN.Data.ViewModel
{
    public class SearchQuestionViewModel
    {
        public string TxtSearch { get; set; }
        public int? CourseId { get; set; }
        public int? QuestionType { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public int? CompanyId { get; set; }

        public bool HasSearch
        {
            get
            {
                if (CourseId != null && CourseId != 0)
                {
                    return true;
                }

                if (QuestionType != null && QuestionType != 0)
                {
                    return true;
                }

                if (TxtSearch != null)
                {
                    return true;
                }

                if (DateStart != null)
                {
                    return true;
                }

                if (DateEnd != null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
