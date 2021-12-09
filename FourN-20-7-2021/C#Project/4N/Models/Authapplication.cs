using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Authapplication
    {
        public int authapplicationid { get; set; }
        // tên của controller
        public string name { get; set; }
        //tên area của chức năng
        public string displayname { get; set; }
        public ICollection<Authcontroller> authcontrollers { get; set; }
        public ICollection<Authuser> authuser { get; set; }
        public ICollection<Authuserrole> authuserroles { get; set; }
    }
}
