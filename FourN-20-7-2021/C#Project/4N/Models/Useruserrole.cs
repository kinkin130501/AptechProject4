using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Useruserrole
    {
        public int userid { get; set; }
        public int userroleid { get; set; }
        public User user { get; set; }
        public Userrole userrole { get; set; }
    }
}
