using Amortization.Application.BusinessLogic.Buyers;
using Amortization.Application.Utilities;
using Amortization.Domain.Models;
using Amortization.Domain.RequestResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amortization.WebApp.Pages.Buyers
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IDependencyAggregate aggregate) : base(aggregate)
        {
            
        }
        [BindProperty(SupportsGet = true)]
        public Buyer Buyer { get; set; } = new();
        public List<Buyer> BuyerList { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public IdHolder holder { get; set; }
        public async Task<IActionResult> OnGetList()
        {
            BuyerList = await dataAccessService_.GetAllBuyers();
            return Partial("List", this);
        }

        public async Task<IActionResult> OnGetForm(long id = 0)
        {
            Buyer = await dataAccessService_.GetBuyerDetail(id);
            return Partial("Form", this);
        }

        public async Task<IActionResult> OnPostSaveNewBuyer()
        {
            Buyer.Imprint_Id = CreateBuyerImprint.CreateImprint();
            Buyer retVal = await dataAccessService_.SaveNewBuyer(Buyer);
            return new JsonResult(new PostResponse { Id = retVal.BuyerId, isSuccess = retVal.BuyerId > 0});
        }

        public async Task<IActionResult> OnPostUpdateBuyer()
        {
            Buyer retVal = await dataAccessService_.UpdateBuyer(Buyer);
            return new JsonResult(new PostResponse { Id = retVal.BuyerId, isSuccess = retVal.BuyerId > 0});
        }

        public async Task<IActionResult> OnPostDeleteBuyer()
        {
            bool retVal = await dataAccessService_.DeleteBuyer(holder.Id);
            return new JsonResult(new PostResponse { isSuccess = retVal });
        }
    }
}
