using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Request
    {
        public int requestid { get; set; }
        public string requestname { get; set; }
        public string content { get; set; }
        public string responecontent { get; set; }
        public int userid { get; set; }
        public int receiverid { get; set; }
        public DateTime sentdate { get; set; }
        public DateTime? moretime { get; set; }
        public int status { get; set; }
        public bool reply { get; set; }
        public int? taskid { get; set; }
        public decimal requestmoney { get; set; }
        public decimal totaltime { get; set; }
        public User user { get; set; }
    }
}
