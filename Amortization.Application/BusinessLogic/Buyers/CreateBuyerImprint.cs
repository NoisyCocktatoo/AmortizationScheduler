using Amortization.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Application.BusinessLogic.Buyers
{
    public static class CreateBuyerImprint
    {
        public static string CreateImprint()
        {
            string randomPart = CodeGenerator.RandomString(8);
            string imprint = $"{randomPart.Substring(4)}-{randomPart.Substring(0, 4)}";
            return imprint;
        }

    }
}
