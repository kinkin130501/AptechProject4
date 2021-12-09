using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Affairs
    {
        public int affairid { get; set; }
        public string affairname { get; set; }
        public int? affairtag { get; set; }
        public DateTime starttimeplan { get; set; }
        public DateTime endtimeplan { get; set; }
        public DateTime? starttimeactual { get; set; }
        public DateTime? endtimeactual { get; set; }
        public int? userid { get; set; }
        public int? status { get; set; }
        public string notemember { get; set; }
        public string noteleader { get; set; }
        public int? projectid { get; set; }
        public int? typeofaffair { get; set; }
        public Projects Project { get; set; }
    }
}
