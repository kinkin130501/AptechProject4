using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Authuser
    {
        public int authappliactionid { get; set; }
        public int userid { get; set; }
        public Authapplication authapplication { get; set; }
        public User user { get; set; }
    }
}
