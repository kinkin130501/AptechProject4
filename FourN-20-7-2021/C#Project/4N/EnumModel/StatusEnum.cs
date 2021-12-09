using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.EnumModel
{
    public enum StatusEnum
    {
        [Display(Name = "Complete")]
        DaChamDiem = 1,
        [Display(Name = "Waiting")]
        ChoThi = 2,
        [Display(Name = "Examinating")]
        DangThi = 3,
    }
}
