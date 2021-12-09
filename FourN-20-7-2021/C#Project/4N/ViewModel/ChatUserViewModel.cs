using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class ChatUserViewModel
    {
        public int chatroomid { get; set; }
        public User Users { get; set; }
        public string chatusercontent { get; set; }
        public int chatusergroup { get; set; }
        public string chatusercreateat { get; set; }
        public string chatuserupdateat { get; set; }

    }
}
