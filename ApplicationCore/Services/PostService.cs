using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Filer;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"> ID of post want to get </param>
        /// <returns> Single post </returns>
        /// <exception cref="AppException"></exception>
        public async Task<Post> GetById(int id)
        {
            var post = await _postRepository.GetById(id);
            return post;
        }

        /// <summary>
        /// Count of list posts
        /// </summary>
        /// <returns> Count of list posts </returns>
        public int GetCountDocument()
        {
            return _postRepository.GetCountDocument();
        }

        /// <summary>
        /// Get posts by type
        /// </summary>
        /// <param name="typeId">Post Type ID of posts want to get</param>
        /// <returns> List posts by TypeID </returns>
        /// <exception cref="AppException"></exception>
        public async Task<IEnumerable<Post>> GetPostByType(int typeID)
        {
            var posts = await _postRepository.GetPostByType(typeID);
            return posts;
        }

        /// <summary>
        /// Get posts by typeid support pagination
        /// </summary>
        /// <param name="type"> Post type id of posts </param>
        /// <param name="filter"> Pagination filter from request body </param>
        /// <returns> List Posts by type id support pagination </returns>
        /// <exception cref="AppException"></exception>
        public async Task<IEnumerable<Post>> GetPostByTypeWithPagination(int typeID, PaginationFilter filter)
        {
            var posts = await _postRepository.GetPostByTypeWithPagination(typeID, filter);
            return posts;
        }
    }
}
