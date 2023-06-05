using ApplicationCore.Entities;
using ApplicationCore.Filer;

namespace ApplicationCore.Interfaces
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostByType(int typeId);
        Task<IEnumerable<Post>> GetPostByTypeWithPagination(int type, PaginationFilter filter);
    }
}
