using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class DocumentModel
    {
        public int docid { get; set; }
        public string title { get; set; }
        public int? authorrole { get; set; }
        public string authorname { get; set; }
        public IFormFile files { get; set; }
        public string note { get; set; }
    }
}
