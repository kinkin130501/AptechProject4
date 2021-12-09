using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class PartnerViewModel
    {
        public static string ConvertDepartmentToString(int department)
        {
            switch (department)
            {
                case (int)SystemEnum.DepartmentStatus.Apply:
                    return "Apply";
                case (int)SystemEnum.DepartmentStatus.Expired:
                    return "Expired";
                default:
                    return "Not Found";
            }
        }
        public static PartnerViewModel ConvertPartner(Partner partner)
        {
            if (partner == null) return new PartnerViewModel();
            var model = new PartnerViewModel()
            {
                PartnerId = partner.partnerid,
                Email = partner.email,
                Name = partner.name,
                FileURL = partner.fileurl,
                Time = partner.time,
                DepartmentId = partner.departmentpartnerid,
                Phone = partner.phone,
                StatusString = ConvertDepartmentToString(partner.status),
                Status = partner.status
            };
            return model;
        }
        public int PartnerId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FileURL { get; set; }
        public DateTime Time { get; set; }
        public string StatusString { get; set; }
        public int DepartmentId { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
    }
}
