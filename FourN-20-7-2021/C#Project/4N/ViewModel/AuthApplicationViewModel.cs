using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class AuthApplicationViewModel
    {
        public static AuthApplicationViewModel ConvertfromAuthapplication(Authapplication app)
        {
            if (app == null) return new AuthApplicationViewModel();
            var model = new AuthApplicationViewModel()
            {
                authapplicationid = app.authapplicationid,
                name = app.name,
                displayname = app.displayname,
                authcontrollers = app.authcontrollers.Select(x => AuthcontrollerViewModel.ConvertFromModel(x)).ToList()
            };
            return model;
        }
        public int authapplicationid { get; set; }
        // tên của controller
        public string name { get; set; }
        //tên area của chức năng
        public string displayname { get; set; }
        public List<AuthcontrollerViewModel> authcontrollers { get; set; }
    }
}
