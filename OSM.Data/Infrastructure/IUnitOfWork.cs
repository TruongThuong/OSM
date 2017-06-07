namespace OSM.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}