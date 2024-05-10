using Amortization.Infrastructure.Services.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Infrastructure.Services.DataServices
{
    public partial class DataService : IDataService
    {
        private readonly IDataRepository repository_;
        public DataService(IDataRepository repository)
        {
            repository_ = repository;
        }
    }
}
