using Amortization.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amortization.WebApp.Pages.Dashboards
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IDependencyAggregate aggregate) : base(aggregate)
        {
            
        }
        public GetDashboardDataResult DashboardData { get; set; }
        public async Task<IActionResult> OnGet()
        {
            DashboardData = await dataAccessService_.GetDashboardData();
            return Partial("Dashboard", this);
        }
    }
}
