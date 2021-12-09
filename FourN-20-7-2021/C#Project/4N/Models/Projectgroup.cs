using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Models
{
    public class Projectgroup
    {
        [Key]
        public int projectid { get; set; }
        public int? groupid { get; set; }
    }
}
