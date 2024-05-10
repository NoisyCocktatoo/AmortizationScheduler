using Amortization.Infrastructure.Services.DataRepositories;
using Amortization.Infrastructure.Services.DataServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amortization.WebApp.Pages
{
    public interface IDependencyAggregate
    {
        IDataService DataService { get; }
        IDataRepository DataRepository { get; }
        IWebHostEnvironment WebHostEnvironment { get; }
    }
    public class DependencyAggregate : IDependencyAggregate
    {
        public DependencyAggregate(
            IDataService dataAccessService,
            IWebHostEnvironment webHostEnvironment,
            IDataRepository dataRepository)
        {
            DataService = dataAccessService;
            WebHostEnvironment = webHostEnvironment;
            DataRepository = dataRepository;
        }

        public IDataService DataService { get; }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public IDataRepository DataRepository { get; }

    }
    public abstract partial class BasePageModel : PageModel
    {
        protected readonly IDataService dataAccessService_;

        protected readonly IDataRepository dataRepository_;

        protected readonly IWebHostEnvironment env_;

        public string RootPath
        {
            get
            {
                return env_.WebRootPath;
            }
        }

        public BasePageModel(IDependencyAggregate aggregate)
        {
            dataAccessService_ = aggregate.DataService;
            dataRepository_ = aggregate.DataRepository;
            env_ = aggregate.WebHostEnvironment;
        }
    }
}
