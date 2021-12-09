using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class ApplyModel
    {
        public string Email { get; set; }
        public IFormFile File { get; set; }
        public string FileURL { get; set; }
        public DateTime Time { get; set; }
        public int DepartmentId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
    }
}
