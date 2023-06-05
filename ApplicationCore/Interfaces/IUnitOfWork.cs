namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();
    }
}
