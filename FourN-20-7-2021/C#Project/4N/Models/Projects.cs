using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Projects
    {
        public int projectid { get; set; }
        public string projectname { get; set; }
        public DateTime startplan { get; set; }
        public DateTime endplan { get; set; }
        public DateTime? startactual { get; set; }
        public DateTime? endactual { get; set; }
        public int? leaderid { get; set; }
        public string note { get; set; }
        public int? status { get; set; }
        public int? docid { get; set; }
        public string projectcode { get; set; }
        public ICollection<Affairs> Affairs { get; set; }
        public string require { get; set; }
    }
}
