using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.EnumModel
{
    public enum ResultEnum
    {
        [Display(Name = "Passed")]
        Vuot = 1,
        [Display(Name = "Failed")]
        KhongVuot = 2,
        [Display(Name = "Waiting")]
        Dangcho = 3
    }
}
