using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Departmentpartner
    {
        public int departmentpartnerid { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public int duration { get; set; }
        public DateTime timeend { get; set; }
        public int department { get; set; }
        public ICollection<Partner> partners { get; set; }
        public string img { get; set; }
        public int status { get; set; }
        public string shortdesc { get; set; }
        public int? examid { get; set; }
        public int? quantity { get; set; }
    }
}
