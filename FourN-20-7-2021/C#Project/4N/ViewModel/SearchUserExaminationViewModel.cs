using System;
using System.Collections.Generic;
using System.Text;

namespace FourN.Data.ViewModel
{
    public class SearchUserExaminationViewModel
    {
        public string TxtSearch { get; set; }
        public int? CourseId { get; set; }
        public int? ExamType { get; set; }
        public int? ResultStatus { get; set; }
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

                if (ExamType != null && ExamType != 0)
                {
                    return true;
                }

                if (ResultStatus != null && ResultStatus != 0)
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
