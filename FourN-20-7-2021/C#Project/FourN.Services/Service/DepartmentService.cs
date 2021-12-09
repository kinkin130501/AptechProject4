using FourN.Data;
using FourN.Data.ViewModel;
using FourN.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourN.Data.Models;
using FourN.Data.EnumModel;
using FourN.Data.Helper;
using Microsoft.EntityFrameworkCore;

namespace FourN.Services.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultViewModel> ApplyPartner(ApplyModel model)
        {
            try
            {
                var candicateInfor = new Partner()
                {
                    departmentpartnerid = model.DepartmentId,
                    name = model.Name,
                    email = model.Email,
                    fileurl = model.FileURL,
                    time = DateTime.Now,
                    status = (int)SystemEnum.PartnerStatus.Pending,
                    phone = model.Phone
                };
                var departmentExam = _unitOfWork.Departmentpartners.FirstOrDefaultAsync(x => x.departmentpartnerid == model.DepartmentId).Result;
                var userExam = new UserExamination()
                {
                    ExamId = (int)departmentExam.examid,
                    StatusEnumValue = (int)StatusEnum.ChoThi,
                    Score = 0,
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    TimeConsumed = 0,
                    UserExaminationGuid = Guid.NewGuid(),
                    ResultEnumValue = (int)ResultEnum.Dangcho,
                    partner = candicateInfor
                };
                await _unitOfWork.Partners.AddAsync(candicateInfor);
                await _unitOfWork.UserExaminations.AddAsync(userExam);
                var email = new EmailObject();
                email.EmailSubject = "Please take your examination for department";
                email.EmailContent = "<p>You have a examination for Department, please complete it. You can be access Examination For Candidate, enter your email" +
                    " and take it.</p>" + "<p>You can click <a href='https://localhost:44379/CandidateExamination'>here</a></p>";
                email.EmailTo = candicateInfor.email;
                var result = SendEmail.SendMail(email);
                await _unitOfWork.CommitAsync();
                return ResultViewModel.Success("Please enter your email in CandidateExamination and complete your exam.Thank you.");
            }
            catch
            {
                return ResultViewModel.Fail("Process has an error, pls reload page and resubmit form");
            }
        }
        public async Task<ResultViewModel> CreateDepartment(DepartmentModel department)
        {
            try 
            {
                var departmentpartner = new Departmentpartner()
                {
                    title = department.Title,
                    desc = department.Desc,
                    duration = department.Duration,
                    timeend = department.TimeEnd,
                    department = department.DepartmentInt,
                    img = department.ImageURL,
                    status = (int)SystemEnum.DepartmentStatus.Apply,
                    shortdesc = department.ShortDesc,
                    examid = department.ExaminatinId, 
                    quantity = department.Quantity
                };
                await _unitOfWork.Departmentpartners.AddAsync(departmentpartner);
                await _unitOfWork.CommitAsync();
                return ResultViewModel.Success("Success");
            }
            catch
            {
                return ResultViewModel.Fail("Failed");
            }
        }
        public async Task<ResultViewModel> CreateInterview(InterviewModel model)
        {
            try
            {
                var interview = new Interview()
                {
                    userid = model.userid,
                    deparmentid = model.departmentid,
                    time = model.DateTime,
                };
                await _unitOfWork.Interview.AddAsync(interview);
                await _unitOfWork.CommitAsync();
                var department = _unitOfWork.Partners.BuildQuery(x => x.departmentpartnerid == model.departmentid
                && x.UserExamination.ResultEnumValue == (int)ResultEnum.Vuot).Select(x => x.email);
                var leaderid = _unitOfWork.Users.FirstOrDefaultAsync(x => x.userid == model.userid).Result.email;
                var emailforlead = new EmailObject()
                {
                    EmailTo = leaderid,
                    EmailContent = "<p> Pm created an interview schedule for you at " + interview.time.ToString() +"</p>" + "<p>Contact PM for details.</p>",
                    EmailSubject = "Interview schedule"
                };
                var resultemail = SendEmail.SendMail(emailforlead);
                foreach (var item in department)
                {
                    var emailforpartner = new EmailObject()
                    {
                        EmailTo = item,
                        EmailContent = "<p>You have an interview at" + interview.ToString() + "</p>.<p>Don't late. Thank you and good luck to you</p>",
                        EmailSubject = "Interview schedule"
                    };
                    var result = SendEmail.SendMail(emailforlead);
                }
                return ResultViewModel.Success("Create interview successed");
            }
            catch(Exception ex) 
            {
                return ResultViewModel.Fail("Failed");
            }
        }
        public async Task<ResultViewModel> DeleteDepartment(int departmentid)
        {
            try
            {
                var department = await _unitOfWork.Departmentpartners.FirstOrDefaultAsync(x => x.departmentpartnerid == departmentid);
                _unitOfWork.Departmentpartners.Delete(department);
                await _unitOfWork.CommitAsync();
                return ResultViewModel.Success("Delete is successed !");
            }
            catch(Exception ex)
            {
                return ResultViewModel.Fail("Processing has error,please try again !");
            }
        }

        public async Task<ResultViewModel> Edit(DepartmentModel model)
        {
            try
            {
                var deparment = await _unitOfWork.Departmentpartners.FirstOrDefaultAsync(x => x.departmentpartnerid == model.DepartmentId);
                deparment.title = model.Title;
                deparment.desc = model.Desc;
                deparment.timeend = model.TimeEnd;
                deparment.status = (int)SystemEnum.DepartmentStatus.Apply;
                deparment.shortdesc = model.ShortDesc;
                deparment.examid = model.ExaminatinId;
                deparment.quantity = model.Quantity;
                if(model.ImageURL != null)
                {
                    deparment.img = model.ImageURL;
                }
                await _unitOfWork.CommitAsync();
                return ResultViewModel.Success("Success");
            }
            catch
            {
                return ResultViewModel.Fail("Failed");
            }
        }

        public List<DepartmentViewModel> findAll()
        {
            try
            {
                var departments = _unitOfWork.Departmentpartners.Find(x => x.status == (int)SystemEnum.DepartmentStatus.Apply).OrderByDescending(x=>x.departmentpartnerid)
                    .Select(x => DepartmentViewModel.ConvertDepartment(x)).ToList();
                return departments;
            }
            catch(Exception ex)
            {
                return new List<DepartmentViewModel>();
            }
        }
        public List<DepartmentViewModel> findAllForManage()
        {
            try
            {
                var departments = _unitOfWork.Departmentpartners.Find(x => x.status == (int)SystemEnum.DepartmentStatus.Apply || x.status == (int)SystemEnum.DepartmentStatus.Expired)
                    .OrderBy(x=>x.status)
                    .ThenByDescending(x=>x.departmentpartnerid)
                    .Select(x => DepartmentViewModel.ConvertDepartment(x)).ToList();
                return departments;
            }
            catch (Exception ex)
            {
                return new List<DepartmentViewModel>();
            }
        }
        public List<RequestViewModel> findAllRequest()
        {
            var requests = _unitOfWork.Request.Find(x => x.content != null && x.requestname == "Recruitment" && x.status == 1)
                .OrderByDescending(x=>x.sentdate)
                .Select(x => RequestViewModel.ConvertFromModel(x)).ToList();
            foreach (var item in requests)
            {
                var task = _unitOfWork.Affairs.FirstOrDefaultAsync(x => x.affairid == item.affairid).Result;
                if(task != null)
                {
                    var project = _unitOfWork.Projects.FirstOrDefaultAsync(x => x.projectid == task.projectid).Result;
                    item.Project = project.projectname;
                    item.Required = project.require;
                }
            }
            return requests;
        }
        public DepartmentViewModel findOne(int id)
        {
            var departments = _unitOfWork.Departmentpartners.FirstOrDefaultAsync(x =>x.departmentpartnerid == id, includes: x=>x.Include(x=>x.partners)).Result;
            return DepartmentViewModel.ConvertDepartment(departments);
        }
        public List<UserViewModel> getAllLead()
        {
            var list = _unitOfWork.Users.Find(x => x.isdeleted == false && x.islead == true).Select(x => UserViewModel.ConvertFromUser(x)).ToList();
            return list;
        }

        public async Task<OldInterviewModel> getlateInterView(int departmentid)
        {
            var interview = _unitOfWork.Interview.Find(x => x.deparmentid == departmentid).OrderByDescending(x => x.deparmentid).FirstOrDefault();
            if (interview != null)
            {
                var view = new OldInterviewModel()
                {
                    DateTime = interview.time,
                    userid = interview.userid
                };
                return view;
            }
            else
            {
                return null;
            }
        }

        public List<PartnerViewModel> GetListCandicateFromDepartmentId(int id)
        {
            try
            {
                var partners = _unitOfWork.Partners.BuildQuery(x => x.departmentpartnerid == id && x.UserExamination.ResultEnumValue == (int)ResultEnum.Vuot).Select(x => PartnerViewModel.ConvertPartner(x)).ToList();
                return partners;
            }
            catch
            {
                return new List<PartnerViewModel>();
            }
        }
        public DepartmentModel showEdit(int departmentid)
        {
            var departments = _unitOfWork.Departmentpartners.FirstOrDefaultAsync(x => x.departmentpartnerid == departmentid).Result;
            var model = new DepartmentModel()
            {
                DepartmentId = departments.departmentpartnerid,
                Title = departments.title,
                Desc = departments.desc,
                ShortDesc = departments.shortdesc,
                Duration = departments.duration,
                TimeEnd = departments.timeend,
                ImageURL = departments.img,
                ExaminatinId = (int)departments.examid,
                Quantity = departments.quantity
            };
            return model;
        }
        public async Task<ResultViewModel> UpdateDepartmentStatus(int departmentid, int status)
        {
            try
            {
                var deparment = await _unitOfWork.Departmentpartners.FirstOrDefaultAsync(x => x.departmentpartnerid == departmentid);
                deparment.status = status;
                await _unitOfWork.CommitAsync();
                return ResultViewModel.Success("OK");
            }
            catch
            {
                return ResultViewModel.Fail("Failed");
            }
        }
    }
}
