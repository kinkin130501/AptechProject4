using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Privatemessage
    {
        public int messageid { get; set; }
        public string messagetitle { get; set; }
        public int messagesenderid { get; set; }
        public int messagereceiveid { get; set; }
        public string messagecontent { get; set; }
        public string messagecreateat { get; set; }
        public string messageupdateat { get; set; }
        public int messageread { get; set; }
        //public User Users { get; set; }
    }
}
