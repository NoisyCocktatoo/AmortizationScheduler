using Amortization.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Infrastructure.Services.DataRepositories
{
    public class DataRepository : IDataRepository
    {
        private readonly AmortizationDBContext context_;
        public DataRepository(AmortizationDBContext context)
        {

            context_ = context;

        }

        public AmortizationDBContext Context
        {
            get
            {
                return context_;
            }
        }

        public async Task<List<TT>> GetList<TT>() where TT : class, new()
        {
            return await context_.Set<TT>().AsNoTracking().ToListAsync();
        }

        public async Task<List<TT>> GetList<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new()
        {
            return await context_.Set<TT>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<TT> GetDetail<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new()
        {
            var result = await context_.Set<TT>().AsNoTracking().FirstOrDefaultAsync(predicate);
            return result ?? new TT();
        }

        public async Task<TT> UpdateRecord<TT>(TT model) where TT : class, new()
        {
            context_.Update(model);
            return model;
        }

        public async Task<int> SaveRecord()
        {
            var retValue = await context_.SaveChangesAsync();
            return retValue;
        }

        public async Task<bool> DeleteDetail<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new()
        {
            int result = 0;
            var toRemove = await context_.Set<TT>().FirstOrDefaultAsync(predicate);
            if (toRemove != null)
            {
                context_.Set<TT>().Remove(toRemove);
                result = await context_.SaveChangesAsync();
            }
            return Convert.ToBoolean(result);
        }
    }
}
