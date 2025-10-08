namespace MVC.Repositories.Interfaces
{
    // only write operatio (SRP)
    public interface IWritableRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
