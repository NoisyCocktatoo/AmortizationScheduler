using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Amortization.Application.Helpers
{
    public static class StringHelpers
    {
        public static T ConvertToClass<T>(this string data)
            where T : new()
        {
            var retValue = new T();
            try
            {
                if (string.IsNullOrEmpty(data))
                    return new();
                var dict = HttpUtility.ParseQueryString(data);
                string json = JsonConvert.SerializeObject(dict.Cast<string>().ToDictionary(k => k, v => dict[v]));
                retValue = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw;
            }
            return retValue;
        }
    }
}
