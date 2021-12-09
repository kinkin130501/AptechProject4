using FourN.Data.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        IUserUserRoleRepository UserUserRoles { get; }
        IAuthApplicationRepository AuthApplications { get; }
        IAuthControllerRepository AuthControllers { get; }
        IGroupRepository Groups { get; }
        IGroupuserRepository Groupusers { get; }
        IDepartmentpartnerRepository Departmentpartners { get; }
        IPartnerRepository Partners { get; }
        IQuestionRepository Questions { get; }
        IAnswerRepository Answers { get; }
        IExaminationRepository Examinations { get; }
        IExaminationQuestionRepository ExaminationQuestions { get; }
        IUserExaminationRepository UserExaminations { get; }
        IUserExaminationAnswerRepository UserExaminationAnswers { get; }
        IAnswerActiveRepository AnswerActives { get; }
        IExaminationQuestionsActiveRepository ExaminationQuestionsActives { get; }
        IRequestRepository Request { get; }
        IProjectRepository Projects { get; }
        IAffairRepository Affairs { get; }
        IInterviewRepository Interview { get; }
        IProjectgroupsRepository Projectgroup { get; }
        Task<int> CommitAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
