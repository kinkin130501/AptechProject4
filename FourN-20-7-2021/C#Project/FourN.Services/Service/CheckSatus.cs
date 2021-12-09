using FourN.Data;
using FourN.Data.ViewModel;
using FourN.Services.IService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FourN.Services.Service
{
    public class CheckSatus : IHostedService, IDisposable, ICheckStatus
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IUnitOfWork _unitOfWork;
        private ICheckStatus _checkStatusService;
        private IDepartmentService _departmentService;

        private Timer _timer;
        private AutoResetEvent autoResetEvent = new AutoResetEvent(true);
        public CheckSatus(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }

        public List<DepartmentModel> GetListDepartment()
        {
            var listDepartment = _unitOfWork.Departmentpartners.Find(x => x.status == (int)SystemEnum.DepartmentStatus.Apply).Select(x => new DepartmentModel
            {
                DepartmentId = x.departmentpartnerid,
                TimeEnd = x.timeend,
                Status = x.status
            }).ToList();
            return listDepartment;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Action action = () =>
            {
                var nextRunTime = DateTime.Now.AddMinutes(1);
                var curTime = DateTime.Now;
                var firstInterval = nextRunTime.Subtract(curTime);
                var t1 = Task.Delay(firstInterval);
                t1.Wait();
                TimeSpan TimeInterval = TimeSpan.FromMinutes(1);
                _timer = new Timer(CheckDepartmentStatus, autoResetEvent, TimeSpan.Zero, TimeInterval);
            };
            Task.Run(action);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        private async void CheckDepartmentStatus(object state)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {

                DateTime DateTimeNow = DateTime.Now;
                var dbContext = scope.ServiceProvider.GetRequiredService<FourNDbContext>();
                _unitOfWork = new UnitOfWork(dbContext);
                //Update Code
                _departmentService = new DepartmentService(_unitOfWork);
                foreach (var item in GetListDepartment())
                {
                    if (item.Status == (int)SystemEnum.DepartmentStatus.Apply)
                    {
                        if (item.TimeEnd <= DateTimeNow)
                        {
                            await _departmentService.UpdateDepartmentStatus(item.DepartmentId, (int)SystemEnum.DepartmentStatus.Expired);
                        }
                    }
                }

            }
        }
    }
}
