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

        public async Task<List<spGetAllLoanListResult>> GetspLoanList()
        {
            return await repository_.Context.Procedures.spGetAllLoanListAsync();
        }

        public async Task<List<Loan>> GetAllLoanList()
        {
            return await repository_.GetList<Loan>();
        }

        public async Task<List<Loan>> GetBuyerLoanList(long buyerId)
        {
            return await repository_.GetList<Loan>(p => p.BuyerId == buyerId);
        }

        public async Task<Loan> GetLoanDetail(long loanId)
        {
            return await repository_.GetDetail<Loan>(p => p.LoanId == loanId);
        }
        public async Task<Loan> SaveLoan(Loan loan)
        {
            Loan loan_ = await repository_.UpdateRecord(loan);
            await repository_.SaveRecord();
            return loan_;
        }

        public async Task<bool> DeleteLoan(long loanId)
        {
            bool is_deleted = await repository_.DeleteDetail<Loan>(p => p.LoanId == loanId);
            await repository_.SaveRecord();
            return is_deleted;
        }
    }
}
