using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {
    }

    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(AppsDbContext context) : base(context)
        {
        }
    }
}