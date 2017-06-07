using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(AppsDbContext context) : base(context)
        {
        }
    }
}