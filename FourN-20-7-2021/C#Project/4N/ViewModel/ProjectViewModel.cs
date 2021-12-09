using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.ViewModel
{
    public class ProjectViewModel
    {
        public static ProjectViewModel ConvertFromProject(Projects project)
        {
            if (project == null) return new ProjectViewModel();
            var model = new ProjectViewModel()
            {
                ProjectId = project.projectid,
                ProjectName = project.projectname
            };
            return model;
        } 
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
