using Amortization.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Infrastructure.Services.DataServices
{
    public partial class DataService : IDataService
    {

        public async Task<List<spAmortizationScheduleResult>> GetAmortizationScheduleList(long loanId)
        {
            return await repository_.Context.Procedures.spAmortizationScheduleAsync(loanId);
        }

        public async Task<Schedule> SaveSchedule(Schedule Schedule)
        {
            Schedule Schedule_ = await repository_.UpdateRecord(Schedule);
            await repository_.SaveRecord();
            return Schedule_;
        }

        public async Task<bool> DeleteSchedule(long scheduleId)
        {
            bool is_deleted = await repository_.DeleteDetail<Schedule>(p => p.ScheduleId == scheduleId);
            await repository_.SaveRecord();
            return is_deleted;
        }
    }
}
