using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class RequestViewModel
    {
        public static RequestViewModel ConvertFromModel(Request request)
        {
            if (request == null) return new RequestViewModel();
            var model = new RequestViewModel()
            {
                RequestName = request.requestname,
                Time = request.sentdate,
                Content = request.content,
                affairid = request.taskid
            };
            return model;
        }
        public string RequestName { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
        public string Project { get; set; }
        public string Required { get; set; }
        public int? affairid { get; set; }
    }
}
