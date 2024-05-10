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
        public async Task<List<Unit>> GetUnitList(long projectId)
        {
            return await repository_.GetList<Unit>(p => p.ProjectId == projectId);
        }


        public async Task<List<Unit>> GetUnitListAvailable(long projectId)
        {
            return await repository_.GetList<Unit>(p => p.ProjectId == projectId && p.BuyerId == null);
        }

        public async Task<Unit> GetUnitDetail(long id)
        {
            return await repository_.GetDetail<Unit>(p => p.UnitId == id);
        }


        public async Task<Unit> SaveUnit(Unit Unit)
        {
            Unit Unit_ = await repository_.UpdateRecord(Unit);
            await repository_.SaveRecord();
            return Unit_;
        }

        public async Task<bool> DeleteUnit(long unitId)
        {
            bool is_deleted = await repository_.DeleteDetail<Unit>(p => p.UnitId == unitId);
            await repository_.SaveRecord();
            return is_deleted;
        }
    }
}
