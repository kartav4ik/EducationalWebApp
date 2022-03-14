namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T> 
    {
        Task<T> Get(Guid id);
        Task<T> Update(Guid id,T entity);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<bool> Remove(Guid id);
    }
}
