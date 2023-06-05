namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        int GetCountDocument();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
    }
}
