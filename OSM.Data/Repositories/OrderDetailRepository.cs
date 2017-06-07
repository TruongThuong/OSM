using OSM.Data.Infrastructure;
using OSM.Model.Entities;

namespace OSM.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(AppsDbContext context) : base(context)
        {
        }
    }
}