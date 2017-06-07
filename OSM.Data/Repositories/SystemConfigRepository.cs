using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Repositories
{
    public interface ISystemConfigRepository : IRepository<SystemConfig>
    {
    }

    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(AppsDbContext context) : base(context)
        {
        }
    }
}