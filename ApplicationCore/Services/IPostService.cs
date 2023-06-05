using ApplicationCore.Entities;
using ApplicationCore.Filer;

namespace ApplicationCore.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<Post>> GetPostByType(int typeId);
        public Task<IEnumerable<Post>> GetPostByTypeWithPagination(int type, PaginationFilter filter);
        public Task<Post> GetById(int id);
        public int GetCountDocument();
    }
}
