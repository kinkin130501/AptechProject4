using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Chatroom
    {
        public int chatroomid { get; set; }
        public int chatuserid { get; set; }
        public string chatusercontent { get; set; }
        public int chatusergroup { get; set; }
        public string chatusercreateat { get; set; }
        public string chatuserupdateat { get; set; }
    }
}
