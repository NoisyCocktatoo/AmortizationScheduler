using Amortization.Application.BusinessLogic.Buyers;
using Amortization.Application.Utilities;
using Amortization.Domain.Models;
using Amortization.Domain.RequestResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amortization.WebApp.Pages.Projects
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IDependencyAggregate aggregate) : base(aggregate)
        {
        }

        [BindProperty(SupportsGet = true)]
        public Project Project { get; set; } = new();
        public List<Project> ProjectList { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public IdHolder holder { get; set; }
        public async Task<IActionResult> OnGetList()
        {
            ProjectList = await dataAccessService_.GetProjectList();
            return Partial("List", this);
        }

        public async Task<IActionResult> OnGetForm(long id = 0)
        {
            Project = await dataAccessService_.GetProjectDetail(id);
            return Partial("Form", this);
        }

        public async Task<IActionResult> OnPostSaveProject()
        {
            Project retVal = await dataAccessService_.SaveProject(Project);
            return new JsonResult(new PostResponse { Id = retVal.ProjectId, isSuccess = retVal.ProjectId > 0 });
        }

        public async Task<IActionResult> OnPostDeleteProject()
        {
            bool retVal = await dataAccessService_.DeleteProject(holder.Id);
            return new JsonResult(new PostResponse { isSuccess = retVal });
        }
    }
}
