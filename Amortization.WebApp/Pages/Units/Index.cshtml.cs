using Amortization.Application.Utilities;
using Amortization.Domain.Models;
using Amortization.Domain.RequestResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amortization.WebApp.Pages.Units
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IDependencyAggregate aggregate) : base(aggregate)
        {
            
        }
        [BindProperty(SupportsGet = true)]
        public Unit Unit { get; set; } = new();
        public List<Unit> UnitList { get; set; } = new();
        public Project Project { get; set; } = new();
        public string ProjectName { get; set; }
        public long ProjectId { get; set; }

        [BindProperty(SupportsGet = true)]
        public IdHolder holder { get; set; }
        public async Task<IActionResult> OnGetList(long projectId)
        {
            Project project_ = await dataAccessService_.GetProjectDetail(projectId);
            ProjectName = project_.Name;
            ProjectId = projectId;
            UnitList = await dataAccessService_.GetUnitList(projectId);
            return Partial("List", this);
        }

        public async Task<IActionResult> OnGetForm(long id = 0)
        {
            Unit = await dataAccessService_.GetUnitDetail(id);
            return Partial("Form", this);
        }

        public async Task<IActionResult> OnPostSaveUnit(long projectId)
        {
            Unit.ProjectId = projectId;
            Unit retVal = await dataAccessService_.SaveUnit(Unit);
            return new JsonResult(new PostResponse { Id = retVal.UnitId, isSuccess = retVal.UnitId > 0, Id2 = projectId });
        }

        public async Task<IActionResult> OnPostDeleteUnit(long projectId)
        {
            bool retVal = await dataAccessService_.DeleteUnit(holder.Id);
            return new JsonResult(new PostResponse { isSuccess = retVal, Id2 = projectId });
        }
    }
}
