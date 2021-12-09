using FourN.Data.Models;
using FourN.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partner.Models
{
    public class AuthenticationModel
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public int? CompanyId { get; set; }
        //module 4
        public string Email { get; set; }
        public List<Authcontroller> Authcontrollers { get; set; }
        public List<AuthApplicationViewModel> Applications { get; set; }
    }
}
