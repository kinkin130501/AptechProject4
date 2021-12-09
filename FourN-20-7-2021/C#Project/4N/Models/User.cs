using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class User
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool isemployee { get; set; }
        public bool islead { get; set; }
        public string password { get; set; }
        public ICollection<Useruserrole> useruserroles { get; set; }
        public ICollection<Authuser> authusers { get; set; }
        [DefaultValue(false)]
        public bool isdeleted { get; set; }
        public string avatar { get; set; }
        public bool? isfreelancer { get; set; }
        public ICollection<Groupuser> groupusers { get; set; }
        public bool? gender { get; set; }
        public string address { get; set; }
        public DateTime? birthday { get; set; }
        public string cmndbefore { get; set; }
        public string cmndafter { get; set; }

    }
}
