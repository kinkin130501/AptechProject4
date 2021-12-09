using FourN.Data.Configurations;
using FourN.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data
{
    public class FourNDbContext: DbContext
    {
        public FourNDbContext()
        {
        }

        public FourNDbContext(DbContextOptions<FourNDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
               .ApplyConfiguration(new UserConfiguration());
            builder
              .ApplyConfiguration(new UserRoleConfiguration());
            builder
              .ApplyConfiguration(new UserUserRoleConfiguration());
            builder
              .ApplyConfiguration(new AuthapplicationConfiguration());
            builder
              .ApplyConfiguration(new AuthcontrollerConfiguration());
            builder
             .ApplyConfiguration(new AuthuserroleConfiguration());
            builder
             .ApplyConfiguration(new AuthuserConfiguration());
            builder
               .ApplyConfiguration(new DocumentConfiguration());
            builder
                .ApplyConfiguration(new AffairConfiguration());
            builder
                .ApplyConfiguration(new GroupConfiguration());
            builder
                .ApplyConfiguration(new ProjectConfiguration());
            //module 4
            builder
                .ApplyConfiguration(new ZoomConfiguration());
            builder.
                ApplyConfiguration(new PrivateMessageConfiguration());
            builder.
                ApplyConfiguration(new ChatRoomConfiguration());
            //end module 4
            builder.
                ApplyConfiguration(new GroupuserConfiguration());
            builder.
                ApplyConfiguration(new DepartmentpartnerConfiguration());
            builder.
                ApplyConfiguration(new PartnerConfiguration());
            builder.Entity<ExaminationQuestion>().HasKey(k => new { k.ExamId, k.QuestionId });
        }
        public DbSet<User> User { get; set; }
        public DbSet<Userrole> Userrole { get; set; }
        public DbSet<Useruserrole> Useruserole { get; set; }
        public DbSet<Authapplication> Authapplication { get; set; }
        public DbSet<Authcontroller> Authcontroller { get; set; }
        public DbSet<Authuser> Authuser { get; set; }
        public DbSet<Authuserrole> Authuserrole { get; set; }
        public DbSet<Documents> Document { get; set; }
        public DbSet<Affairs> Affairs { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Projects> Projects { get; set; }

        //module 4
        public DbSet<Zoom> Zooms { get; set; }
        public DbSet<Privatemessage> Privatemessages { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }
        //end module 4
        public DbSet<Groupuser> Groupusers { get; set; }
        public DbSet<Departmentpartner> Departmentpartners { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<ExaminationQuestion> ExaminationQuestions { get; set; }
        public DbSet<UserExamination> UserExaminations { get; set; }
        public DbSet<UserExaminationAnswer> UserExaminationAnswers { get; set; }
        public DbSet<AnswerActive> AnswerActives { get; set; }
        public DbSet<ExaminationQuestionsActive> ExaminationQuestionsActives { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Interview> Interview { get; set; }
        public DbSet<Projectgroup> Projectgroups { get; set; }

    }
}
