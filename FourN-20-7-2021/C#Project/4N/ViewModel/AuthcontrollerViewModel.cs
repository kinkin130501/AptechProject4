using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class AuthcontrollerViewModel
    {
        public static AuthcontrollerViewModel ConvertFromModel(Authcontroller authcontroller)
        {
            if (authcontroller == null) return new AuthcontrollerViewModel();
            var model = new AuthcontrollerViewModel()
            {
                authcontrollerid = authcontroller.authcontrollerid,
                name = authcontroller.name,
                display = authcontroller.display,
                iconclass = authcontroller.iconclass
            };
            return model;
        }
        public int authcontrollerid { get; set; }
        public string name { get; set; }
        public string display { get; set; }
        public string iconclass { get; set; }
    }
}
