namespace MVC.Repositories.Interfaces
{
    // splitinto two interfaces 
    public interface IRepository<T> where T : class
    {
        // OCP : we can use the repository without modifying 
        // the interfaces itself
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);

    }
}
