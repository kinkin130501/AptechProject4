using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Groups
    {
        public int groupid { get; set; }
        public string groupname { get; set; }
        public bool isdeleted { get; set; }
        public ICollection<Groupuser> groupusers { get; set; }
    }
}
