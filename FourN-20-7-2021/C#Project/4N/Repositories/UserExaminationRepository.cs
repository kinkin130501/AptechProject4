using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.IRepositories;
using FourN.Data.Models;

namespace FourN.Data.Repositories
{
    public class UserExaminationRepository : Repository<UserExamination>, IUserExaminationRepository
    {
        public UserExaminationRepository(FourNDbContext context)
           : base(context)
        { }

        private FourNDbContext FourNDbContext
        {
            get { return Context as FourNDbContext; }
        }
    }
}
