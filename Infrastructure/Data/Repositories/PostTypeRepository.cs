using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class PostTypeRepository : GenericRepository<PostType>, IPostTypeRepository
    {
        public PostTypeRepository(TtwebContext context) : base(context)
        {
        }
    }
}
