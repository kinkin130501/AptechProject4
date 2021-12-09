using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Authuserrole
    {
        public int authapplicationid { get; set; }
        public int userroleid { get; set; }
        public Authapplication authapplication { get; set; }
        public Userrole userrole { get; set; }
    }
}
