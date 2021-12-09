using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Duration { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Department { get; set; }
        public IFormFile Image { get; set; }
        public string ImageURL { get; set; }
        public int Status { get; set; }
        public int DepartmentInt { get; set; }
        public List<ExaminationViewModel> Examinations { get; set; }
        public int ExaminatinId { get; set; }
        public string ShortDesc { get; set; }
        public int? Quantity { get; set; }
    }
}
