using OSM.Data.Infrastructure;

using OSM.Model.Entities;

namespace OSM.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppsDbContext context) : base(context)
        {
        }
    }
}