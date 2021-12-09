using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class CostProjectViewModel
    {
        public int projectid { get; set; }
        public string projectname { get; set; }
        public DateTime startplan { get; set; }
        public DateTime endplan { get; set; }
        public DateTime? startactual { get; set; }
        public DateTime? endactual { get; set; }
        public string projectcode { get; set; }
        public int totalCost { get; set; }
        public List<CostTaskViewModel> CostTaskViewModel { get; set; }
    }
}
