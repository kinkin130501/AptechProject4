using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class PrivatemessageViewModel
    {
        
        public int messageid { get; set; }
        public string messagetitle { get; set; }
        public string messagecontent { get; set; }
        public string messagecreateat { get; set; }
        public string messageupdateat { get; set; }
        public int messageread { get; set; }
        public User UsersSend { get; set; }
        public User UsersInbox { get; set; }
    }
}
