using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FourN.Data.SystemEnum;

namespace FourN.Data.ViewModel
{
    public class DepartmentViewModel
    {
        public static string ConvertDepartmentToString(int department)
        {
            switch (department)
            {
                case (int)SystemEnum.Department.Dev:
                    return "Developer";
                case (int)SystemEnum.Department.Ba:
                    return "Business Analyst";
                case (int)SystemEnum.Department.PM:
                    return "Project Manager";
                case (int)SystemEnum.Department.Tester:
                    return "Tester";
                case (int)SystemEnum.Department.HelpDesk:
                    return "Help Desk";
                default:
                    return "Employee";
            }
        }
        public static DepartmentViewModel ConvertDepartment(Departmentpartner departmentpartner)
        {
            if (departmentpartner == null) return new DepartmentViewModel();
            var model = new DepartmentViewModel()
            {
                DepartmentId = departmentpartner.departmentpartnerid,
                Title = departmentpartner.title,
                Desc = departmentpartner.desc,
                Duration = departmentpartner.duration,
                TimeEnd = departmentpartner.timeend,
                Department = ConvertDepartmentToString(departmentpartner.department),
                Image = departmentpartner.img,
                ShortDesc = departmentpartner.shortdesc,
                DepartmentStatus = departmentpartner.status,
                Quantity = departmentpartner.quantity,
                ListCandidate = departmentpartner.partners?.Select(x => PartnerViewModel.ConvertPartner(x)).ToList()
            };
            return model;
        }
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Duration { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Department { get; set; }
        public string Image { get; set; }
        public string ShortDesc { get; set; }
        public int DepartmentStatus { get; set; }
        public int? Quantity { get; set; }
        public List<PartnerViewModel> ListCandidate { get; set; }
    }
}
