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
        public async Task<GetDashboardDataResult> GetDashboardData()
        {
            List<GetDashboardDataResult> dashboard_data = await repository_.Context.Procedures.GetDashboardDataAsync();
            return dashboard_data.FirstOrDefault();
        }
    }
}
