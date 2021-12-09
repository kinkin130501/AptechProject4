using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class InterviewModel
    {
        public int departmentid { get; set; }
        public int userid { get; set; }
        public DateTime DateTime { get; set; }
        public List<UserViewModel> users { get; set; }
        public List<PartnerViewModel> partners { get; set; }
        public OldInterviewModel OldInterviewModel { get; set; }
    }
}
