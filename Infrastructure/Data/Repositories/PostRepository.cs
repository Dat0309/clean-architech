using ApplicationCore.Entities;
using ApplicationCore.Filer;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(TtwebContext context) : base(context)
        {
        }

        /// <summary>
        /// Get list posts by type
        /// </summary>
        /// <param name="typeId"> typeID of posts want to get </param>
        /// <returns> List posts by typeID </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IEnumerable<Post>> GetPostByType(int typeId)
        {
            IEnumerable<Post> posts = from obj in await Context.Posts.ToListAsync()
                                      where obj.Type == typeId
                                      select obj;
            posts = posts.OrderByDescending(o => o.Id).ToList();
            
            return posts;
        }

        /// <summary>
        /// Get list posts by type support pagination
        /// </summary>
        /// <param name="type"> TypeID of posts want to get </param>
        /// <param name="filter"> Pagination filer from request body </param>
        /// <returns> List posts by type support pagination </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IEnumerable<Post>> GetPostByTypeWithPagination(int type, PaginationFilter filter)
        {
            IEnumerable<Post> posts = await GetPostByType(type);
            posts = posts.OrderByDescending(o => o.Id).Skip(filter.PageSize * (filter.PageNumber - 1)).Take(filter.PageSize).ToList();
            
            return posts;
        }
    }
}
