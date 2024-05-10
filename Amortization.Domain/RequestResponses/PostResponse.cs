using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Domain.RequestResponses
{
    public class PostResponse
    {
        public long Id { get; set; }
        public long Id2 { get; set; }
        public bool isSuccess { get; set; }
        public string Message { get; set; }
    }
}
