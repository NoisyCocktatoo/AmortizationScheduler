using Amortization.Application.BusinessLogic.Buyers;
using Amortization.Application.BusinessLogic.Schedulers;
using Amortization.Application.Utilities;
using Amortization.Domain.Models;
using Amortization.Domain.RequestResponses;
using Amortization.WebApp.Pages.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amortization.WebApp.Pages.Loans
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IDependencyAggregate aggregate) : base(aggregate)
        {
        }
        [BindProperty(SupportsGet = true)]
        public Loan Loan { get; set; } = new();
        public List<Loan> LoanList { get; set; } = new();
        public List<Project> ProjectList { get; set; } = new();
        public List<Unit> UnitList { get; set; } = new();
        public List<spGetAllLoanListResult> spLoanList { get; set; } = new();
        public List<spGetLoanerDropdownResult> BuyerList { get; set; } = new();
        public List<spGetAllBuyerTransactionsResult> BuyerLoans { get; set; } = new();
        public spGetBuyerInformationResult spBuyerInfo { get; set; } = new();

        public List<spAmortizationScheduleResult> AmortizationScheduleList { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public IdHolder holder { get; set; }
        public Project Project { get; set; }
        public Unit Unit { get; set; }
        public long LoanId { get; set; }
        public long ProjectId { get; set; }
        public int Origin { get; set; }
        public async Task<IActionResult> OnGetList()
        {
            spLoanList = await dataAccessService_.GetspLoanList();
            return Partial("List", this);
        }

        public async Task<IActionResult> OnGetFilteredList(long buyerId)
        {
            BuyerLoans = await dataAccessService_.AllBuyerInformationTransactions(buyerId);
            return Partial("BuyerLoans", this);
        }

        public async Task<IActionResult> OnGetForm(long projectId = 0, long id = 0)
        {
            LoanId = id;
            ProjectId = projectId;
            Loan = await dataAccessService_.GetLoanDetail(id);
            Project = await dataAccessService_.GetProjectDetail(projectId);
            Unit = await dataAccessService_.GetUnitDetail((long)(Loan.UnitId ?? 0));
            ProjectList = await dataAccessService_.GetProjectList();
            UnitList = await dataAccessService_.GetUnitListAvailable(projectId);
            BuyerList = await dataAccessService_.GetBuyerNames();
            return Partial("Form", this);
        }


        public async Task<IActionResult> OnGetAmortizationSchedule(long buyerId, long unitId, long loanId, int origin)
        {
            Origin = origin;
            AmortizationScheduleList = await dataAccessService_.GetAmortizationScheduleList(loanId);
            spBuyerInfo = await dataAccessService_.BuyerInformationDetail(buyerId, unitId);
            return Partial("AmortizationSchedule", this);
        }


        public async Task<IActionResult> OnPostSaveLoan()
        {
            Loan retVal = await dataAccessService_.SaveLoan(Loan);
            if(retVal.LoanId > 0)
            {
                await UpdateUnitOwner((long)retVal.UnitId, (long)retVal.BuyerId);
                await Build_Schedule(retVal);
            }
            return new JsonResult(new PostResponse { Id = retVal.LoanId, isSuccess = retVal.LoanId > 0 });
        }

        private async Task UpdateUnitOwner(long unitId, long buyerId)
        {
            Unit unit_ = await dataAccessService_.GetUnitDetail(unitId);
            unit_.BuyerId = buyerId;
            await dataAccessService_.SaveUnit(unit_);
        }

        private async Task Build_Schedule(Loan loan) {
            AmortizationScheduler Amortization_Scheduler = new(loan);
            List<Schedule> Schedules = await Amortization_Scheduler.ProvideSchedule();
            foreach(Schedule sched in Schedules)
            {
                await dataAccessService_.SaveSchedule(sched);
            }
        }
        public async Task<IActionResult> OnPostDeleteLoan()
        {
            bool retVal = await dataAccessService_.DeleteLoan(holder.Id);
            return new JsonResult(new PostResponse { isSuccess = retVal });
        }
    }
}
