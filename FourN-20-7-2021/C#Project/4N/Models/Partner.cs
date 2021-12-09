using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Partner
    {
        public int partnerid { get; set; }
        public string email { get; set; }
        public string fileurl { get; set; }
        public DateTime time { get; set; }
        public int status { get; set; }
        public int departmentpartnerid { get; set; }
        public Departmentpartner departmentpartner { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public UserExamination UserExamination { get; set; }
    }
}
