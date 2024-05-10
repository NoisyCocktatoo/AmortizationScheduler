using Amortization.Domain.Models;

namespace Amortization.Infrastructure.Services.DataServices
{
    public interface IDataService
    {
        Task<List<spGetAllBuyerTransactionsResult>> AllBuyerInformationTransactions(long buyerId);
        Task<spGetBuyerInformationResult> BuyerInformationDetail(long buyerId, long unitId);
        Task<bool> DeleteBuyer(long buyerId);
        Task<bool> DeleteLoan(long loanId);
        Task<bool> DeleteProject(long projectId);
        Task<bool> DeleteSchedule(long scheduleId);
        Task<bool> DeleteUnit(long unitId);
        Task<List<Buyer>> GetAllBuyers();
        Task<List<Loan>> GetAllLoanList();
        Task<List<spAmortizationScheduleResult>> GetAmortizationScheduleList(long loanId);
        Task<Buyer> GetBuyerDetail(long id);
        Task<List<Loan>> GetBuyerLoanList(long buyerId);
        Task<List<spGetLoanerDropdownResult>> GetBuyerNames();
        Task<GetDashboardDataResult> GetDashboardData();
        Task<Loan> GetLoanDetail(long loanId);
        Task<Project> GetProjectDetail(long projectId);
        Task<List<Project>> GetProjectList();
        Task<List<spGetAllLoanListResult>> GetspLoanList();
        Task<Unit> GetUnitDetail(long id);
        Task<List<Unit>> GetUnitList(long projectId);
        Task<List<Unit>> GetUnitListAvailable(long projectId);
        Task<Loan> SaveLoan(Loan loan);
        Task<Buyer> SaveNewBuyer(Buyer buyer);
        Task<Project> SaveProject(Project Project);
        Task<Schedule> SaveSchedule(Schedule Schedule);
        Task<Unit> SaveUnit(Unit Unit);
        Task<Buyer> UpdateBuyer(Buyer buyer);
    }
}