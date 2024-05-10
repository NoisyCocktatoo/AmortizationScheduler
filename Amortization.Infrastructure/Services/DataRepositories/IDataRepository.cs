using Amortization.Domain.Contexts;
using System.Linq.Expressions;

namespace Amortization.Infrastructure.Services.DataRepositories
{
    public interface IDataRepository
    {
        AmortizationDBContext Context { get; }

        Task<bool> DeleteDetail<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new();
        Task<TT> GetDetail<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new();
        Task<List<TT>> GetList<TT>() where TT : class, new();
        Task<List<TT>> GetList<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new();
        Task<int> SaveRecord();
        Task<TT> UpdateRecord<TT>(TT model) where TT : class, new();
    }
}