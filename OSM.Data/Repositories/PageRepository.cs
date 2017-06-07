using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Repositories
{
    public interface IPageRepository : IRepository<Page>
    {
    }

    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(AppsDbContext context) : base(context)
        {
        }
    }
}