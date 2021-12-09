using FourN.Data.IRepositories;
using FourN.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FourNDbContext _context;
        private UserRepository _userRepository;
        private UserRoleRepository _userRoleRepository;
        private UserUserRoleRepository _useruserRoleRepository;
        private AuthApplicationRepository _authApplicationRepository;
        private AuthControllerRepository _authControllerRepository;
        private GroupRepository _groupRepository;
        private GroupuserRepository _groupuserRepository;
        private DepartmentpartnerRepository _departmentpartnerRepository;
        private PartnerRepository _partnerRepository;
        private QuestionRepository _questionRepository;
        private AnswerRepository _answerRepository;
        private AnswerActiveRepository _answerActiveRepository;
        private ExaminationQuestionsActiveRepository _examinationQuestionsActiveRepository;
        //private AnswerRepository _answerRepository;
        //private QuestionRepository _questionRepository;
        private ExaminationRepository _examinationRepository;
        private ExaminationQuestionRepository _examinationQuestionRepository;
        private UserExaminationRepository _userExaminationRepository;
        private UserExaminationAnswerRepository _userExaminationAnswerRepository;
        private RequestRepository _requestRepository;
        private ProjectRepository _projectRepository;
        private AffairRepository _affairRepository;
        private InterviewRepository _interviewRepository;
        private ProjectgroupsRepository _projectgroupsRepository;
        public UnitOfWork(FourNDbContext context)
        {
            this._context = context;
        }
        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public IUserRoleRepository UserRoles => _userRoleRepository ??= new UserRoleRepository(_context);
        public IUserUserRoleRepository UserUserRoles => _useruserRoleRepository ??= new UserUserRoleRepository(_context);
        public IAuthApplicationRepository AuthApplications => _authApplicationRepository ??= new AuthApplicationRepository(_context);

        public IAuthControllerRepository AuthControllers => _authControllerRepository ??= new AuthControllerRepository(_context);

        public IGroupRepository Groups => _groupRepository ??= new GroupRepository(_context);

        public IGroupuserRepository Groupusers => _groupuserRepository ??= new GroupuserRepository(_context);

        public IDepartmentpartnerRepository Departmentpartners => _departmentpartnerRepository ??= new DepartmentpartnerRepository(_context);

        public IPartnerRepository Partners => _partnerRepository ??= new PartnerRepository(_context);

        public IQuestionRepository Questions => _questionRepository ??= new QuestionRepository(_context);

        public IAnswerRepository Answers => _answerRepository ??= new AnswerRepository(_context);
        public IExaminationRepository Examinations => _examinationRepository ??= new ExaminationRepository(_context);
        public IExaminationQuestionRepository ExaminationQuestions => _examinationQuestionRepository ??= new ExaminationQuestionRepository(_context);
        public IUserExaminationAnswerRepository UserExaminationAnswers => _userExaminationAnswerRepository ??= new UserExaminationAnswerRepository(_context);
        public IUserExaminationRepository UserExaminations => _userExaminationRepository ??= new UserExaminationRepository(_context);
        public IAnswerActiveRepository AnswerActives => _answerActiveRepository ??= new AnswerActiveRepository(_context);
        public IExaminationQuestionsActiveRepository ExaminationQuestionsActives => _examinationQuestionsActiveRepository ??= new ExaminationQuestionsActiveRepository(_context);

        public IRequestRepository Request => _requestRepository ??= new RequestRepository(_context);

        public IProjectRepository Projects => _projectRepository ??= new ProjectRepository(_context);

        public IAffairRepository Affairs => _affairRepository ??= new AffairRepository(_context);

        public IInterviewRepository Interview => _interviewRepository ??= new InterviewRepository(_context);

        public IProjectgroupsRepository Projectgroup => _projectgroupsRepository ??= new ProjectgroupsRepository(_context);

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
