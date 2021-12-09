using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Interview
    {
        public int interviewid { get; set; }
        public int userid { get; set; }
        public int deparmentid { get; set; }
        public DateTime time {get; set;}
    }
}
