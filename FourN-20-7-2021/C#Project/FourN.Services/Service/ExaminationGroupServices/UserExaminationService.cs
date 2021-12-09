using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourN.Data;
using FourN.Data.Models;
using FourN.Data.ViewModel;
using FourN.Services.IService;

namespace FourN.Services.ExaminationGroupServices
{
    public class UserExaminationService : IUserExaminationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserExaminationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> CreateUserExamination(UserExaminationCrudModel model)
        {

            UserExamination userExamination = new UserExamination
            {
                ExamId = model.ExamId,
                StatusEnumValue = model.StatusEnumValue,
                Score = model.Score,
                CreatedAt = model.CreatedAt,
                ResultEnumValue = model.ResultEnumValue,
                TimeConsumed = model.TimeConsumed,
                UserExaminationGuid = model.UserExaminationGuid,
                UserId = 1,
                partnerid = model.PartnerId
        };
            if (model.Score == 0)
            {
                userExamination.Score = 0.0;
            }

            await _unitOfWork.UserExaminations.AddAsync(userExamination);
            await _unitOfWork.CommitAsync();
            return new ResultViewModel
            {
                IsSuccess = true
            };
        }

        public async Task<ResultViewModel> CreateUserExaminationAnswers(List<UserExaminationAnswerCrudModel> listModel)
        {
            foreach(var item in listModel)
            {
                UserExaminationAnswer model = new UserExaminationAnswer()
                {
                    AnswerContent = item.AnswerContent,
                    IsRightAnswer = item.IsRightAnswer,
                    QuestionId = item.QuestionId,
                    UserExaminationAnswerId = item.UserExaminationAnswerId,
                    UserExaminationId = item.UserExaminationId,
                    IsEssayAnswer = item.IsEssayAnswer,
                    Score = item.Score,
                    ExaminationQuestionsActiveId = item.ExaminationQuestionsActiveId

                };
                await _unitOfWork.UserExaminationAnswers.AddAsync(model);
            }

            await _unitOfWork.CommitAsync();
            return new ResultViewModel
            {
                IsSuccess = true
            };
        }

        public List<UserExaminationViewModel> GetAllUserExaminations()
        {
            var result = _unitOfWork.UserExaminations.Find(x => x.UserExaminationId != 0, x => x.partner , x => x.UserExaminationAnswers, x => x.Examination, x => x.partner.departmentpartner)
                .Select(x => UserExaminationViewModel.Convert(x)).OrderByDescending(x => x.CreatedAt).ToList();
            return result;
        }

        public UserExaminationViewModel GetUserExaminationById(int id)
        {
            var result = _unitOfWork.UserExaminations.Find(x => x.UserExaminationId.Equals(id),
                                                 includes: userExam => userExam.Include(x => x.UserExaminationAnswers))
                .Select(x => UserExaminationViewModel.Convert(x)).FirstOrDefault();
            return result;
        }

        public UserExaminationCrudModel GetUserExaminationCrudModel(string guid)
        {
            if (guid == null)
            {
                var model = new UserExaminationCrudModel();
                return model;
            }

            var userExamCrudModel = _unitOfWork.UserExaminations.Find(x => x.UserExaminationGuid.ToString().Equals(guid),
                                                 includes: eq => eq.Include(x => x.UserExaminationAnswers))
                .Select(x => UserExaminationCrudModel.Convert(x)).FirstOrDefault();

            return userExamCrudModel;
        }

        public async Task<ResultViewModel> UpdateUserExamination(UserExaminationCrudModel model)
        {
            var userExam = await _unitOfWork.UserExaminations.FirstOrDefaultAsync(m => m.UserExaminationId == model.UserExaminationId);
            userExam.StatusEnumValue = model.StatusEnumValue;
            userExam.TimeConsumed = model.TimeConsumed;
            userExam.ResultEnumValue = model.ResultEnumValue;
            userExam.Score = model.Score;
            userExam.UserMarkStringList = model.UserMarkStringList;
            userExam.UserMarkedId = model.UserMarkedId;
            userExam.UserId = 1;
           
            try
            {
                await _unitOfWork.CommitAsync();
                return new ResultViewModel
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return ResultViewModel.Fail(ex.Message);
            }
            
        }

        public List<UserExaminationViewModel> SearchUserExaminations(SearchUserExaminationViewModel model)
        {
            var userExaminations = _unitOfWork.UserExaminations.BuildQuery(x=>x.UserExaminationId != 0);


            if (model.HasSearch)
            {
                if (model.TxtSearch != null)
                {
                    userExaminations = userExaminations.Where(x => x.partner.name.Contains(model.TxtSearch) 
                        || x.partner.email.Contains(model.TxtSearch) || x.partner.phone.Contains(model.TxtSearch));
                }


                if (model.ExamType != null && model.ExamType != 0)
                {
                    userExaminations = userExaminations.Where(x => model.ExamType.Equals(x.Examination.ExamType));
                }

                if (model.ResultStatus != null && model.ResultStatus != 0)
                {
                    userExaminations = userExaminations.Where(x => model.ResultStatus.Equals(x.ResultEnumValue));
                }

                if (model.DateStart != null)
                {
                    userExaminations = userExaminations.Where(x => model.DateStart.Value.Date <= x.CreatedAt.Date);
                }

                if (model.DateEnd != null)
                {
                    userExaminations = userExaminations.Where(x => model.DateEnd.Value.Date >= x.CreatedAt.Date);
                }

            }

            userExaminations = userExaminations.Include(i => i.User).Include(m => m.UserExaminationAnswers).Include(x => x.Examination).OrderByDescending(x => x.CreatedAt);



            var result = userExaminations.Select(x => UserExaminationViewModel.Convert(x)).ToList();
            return result;
        }
        public List<UserExaminationViewModel> SearchCandidateExaminations(SearchUserExaminationViewModel model)
        {
            var userExaminations = _unitOfWork.UserExaminations.BuildQuery(x => x.UserExaminationId != 0);


            if (model.HasSearch)
            {
                if (model.TxtSearch != null)
                {
                    userExaminations = userExaminations.Where(x => x.partner.email.Equals(model.TxtSearch));
                }

            }

            userExaminations = userExaminations.Include(i => i.User).Include(m => m.UserExaminationAnswers).Include(x => x.Examination)
                .Include(x=>x.partner).ThenInclude(x=>x.departmentpartner)
                .OrderByDescending(x => x.CreatedAt);



            var result = userExaminations.Select(x => UserExaminationViewModel.Convert(x)).ToList();
            return result;
        }

    }
}
