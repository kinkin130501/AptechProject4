using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class NotificationViewModel
    {
        public int notiid { get; set; }
        public string notitype { get; set; }
        public int notiuserid { get; set; }
        public int notifromid { get; set; }
        public int notiread { get; set; }
        public string noticreate { get; set; }
        public string notiupdate { get; set; }
        public User UsersSend { get; set; }
    }
}
