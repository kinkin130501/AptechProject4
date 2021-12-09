using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Authcontroller
    {
        public int authcontrollerid { get; set; }
        // tên function cụ thể của controller
        public string name { get; set; }
        // tên chức năng cụ thể hiển thị lên
        public string display { get; set; }
        // dùng để chứa tên các icon hiển thị lên cùng display name
        public string iconclass { get; set; }
        public int authapplicationid { get; set; }
        [ForeignKey("authapplicationid")]
        public Authapplication authapplication { get; set; }
    }
}
