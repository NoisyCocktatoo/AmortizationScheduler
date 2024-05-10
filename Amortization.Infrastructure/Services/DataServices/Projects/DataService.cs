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
        public async Task<List<Project>> GetProjectList()
        {
            return await repository_.GetList<Project>();
        }
        public async Task<Project> GetProjectDetail(long projectId)
        {
            return await repository_.GetDetail<Project>(p => p.ProjectId == projectId);
        }
        public async Task<Project> SaveProject(Project Project)
        {
            Project Project_ = await repository_.UpdateRecord(Project);
            await repository_.SaveRecord();
            return Project_;
        }

        public async Task<bool> DeleteProject(long projectId)
        {
            bool is_deleted = await repository_.DeleteDetail<Project>(p => p.ProjectId == projectId);
            await repository_.SaveRecord();
            return is_deleted;
        }
    }
}
