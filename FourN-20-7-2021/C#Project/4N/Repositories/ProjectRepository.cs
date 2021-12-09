using FourN.Data.IRepositories;
using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Repositories
{
    public class ProjectRepository : Repository<Projects>, IProjectRepository
    {
        public ProjectRepository(FourNDbContext context)
           : base(context)
        { }

        private FourNDbContext FourNDbContext
        {
            get { return Context as FourNDbContext; }
        }
    }
}
