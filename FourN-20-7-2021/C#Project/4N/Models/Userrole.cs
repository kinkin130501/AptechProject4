using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Userrole
    {
        public int userroleid { get; set; }
        public string name { get; set; }
        public string displayname { get; set; }
        public bool isprivate { get; set; }
        public ICollection<Useruserrole> useruserroles { get; set; }
        public ICollection<Authuserrole> authuserroles { get; set; }
    }
}
