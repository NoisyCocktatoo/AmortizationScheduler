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
        public async Task<List<spGetLoanerDropdownResult>> GetBuyerNames()
        {
            return await repository_.Context.Procedures.spGetLoanerDropdownAsync();
        }
        public async Task<List<spGetAllBuyerTransactionsResult>> AllBuyerInformationTransactions(long buyerId)
        {
           return await repository_.Context.Procedures.spGetAllBuyerTransactionsAsync(buyerId);
        }

        public async Task<spGetBuyerInformationResult> BuyerInformationDetail(long buyerId, long unitId)
        {
            List<spGetBuyerInformationResult> retVal = await repository_.Context.Procedures.spGetBuyerInformationAsync(buyerId, unitId);
            return retVal.FirstOrDefault();
        }
        public async Task<Buyer> GetBuyerDetail(long id)
        {
            return await repository_.GetDetail<Buyer>(p => p.BuyerId == id);
        }
        public async Task<List<Buyer>> GetAllBuyers()
        {
            return await repository_.GetList<Buyer>();
        }

        public async Task<Buyer> SaveNewBuyer(Buyer buyer)
        {
            Buyer buyer_retVal = new();
            bool check_existence = await Check_if_buyer_exists(buyer);
            if (!check_existence)
            {
                buyer_retVal = await repository_.UpdateRecord(buyer);
                await repository_.SaveRecord();
            }
            return buyer_retVal;
        }

        private async Task<bool> Check_if_buyer_exists(Buyer buyer)
        {
            Buyer value_checker_buyer = await repository_.GetDetail<Buyer>(p => p.Imprint_Id == buyer.Imprint_Id);
            return value_checker_buyer.BuyerId > 0;
        }

        public async Task<Buyer> UpdateBuyer(Buyer buyer)
        {
            Buyer buyer_retVal = await repository_.UpdateRecord(buyer);
            await repository_.SaveRecord();
            return buyer_retVal;
        }

        public async Task<bool> DeleteBuyer(long buyerId)
        {
            bool is_deleted = await repository_.DeleteDetail<Buyer>(p => p.BuyerId == buyerId);
            await repository_.SaveRecord();
            return is_deleted;
        }
    }
}
