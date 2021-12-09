using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class CostTaskViewModel
    {
        public string affairname { get; set; }
        public DateTime starttimeplan { get; set; }
        public DateTime endtimeplan { get; set; }
        public DateTime? starttimeactual { get; set; }
        public DateTime? endtimeactual { get; set; }
        public int? projectid { get; set; }
        public int? typeofaffair { get; set; }
        public int totalPlan { get; set; }
        public int totalActual { get; set; }
        public int moneyRequest { get; set; }
        public int moneyOvertime { get; set; }
        public int totalCost { get; set; }
        public int costUser { get; set; }
        public int costExtra { get; set; }
        public User User { get; set; }
        
    }
}
