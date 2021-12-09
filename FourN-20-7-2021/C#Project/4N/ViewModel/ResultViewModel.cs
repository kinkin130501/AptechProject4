using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class ResultViewModel
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public string FilePath { get; set; }
        public static ResultViewModel Fail(string message)
        {
            return new ResultViewModel()
            {
                IsSuccess = false,
                ErrorMessage = message
            };
        }

        public static ResultViewModel FailException(Exception ex)
        {
            return new ResultViewModel()
            {
                IsSuccess = false,
                ErrorMessage = ex == null ? "lỗi" : "Có lỗi xảy ra: " + ex.Message + "InnerException: " + ex.InnerException
            };
        }

        public static ResultViewModel Success(string message = null)
        {
            return new ResultViewModel()
            {
                IsSuccess = true,
                SuccessMessage = message
            };
        }
    }
}
