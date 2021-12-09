using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Notification
    {
        public int notiid { get; set; }
        public string notitype { get; set; }
        public int notiuserid { get; set; }
        public int notifromid { get; set; }
        public int notiread { get; set; }
        public string noticreate { get; set; }
        public string notiupdate { get; set; }
    }
}
