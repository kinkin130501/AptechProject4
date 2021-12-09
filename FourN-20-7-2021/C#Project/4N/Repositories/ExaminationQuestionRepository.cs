using System;
using System.Collections.Generic;
using System.Text;
using FourN.Data.IRepositories;
using FourN.Data.Models;

namespace FourN.Data.Repositories
{
    public class ExaminationQuestionRepository : Repository<ExaminationQuestion>, IExaminationQuestionRepository
    {
        public ExaminationQuestionRepository(FourNDbContext context)
           : base(context)
        { }

        private FourNDbContext FourNDbContext
        {
            get { return Context as FourNDbContext; }
        }
    }
}
