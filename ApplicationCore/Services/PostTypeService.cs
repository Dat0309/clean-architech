using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class PostTypeService : IPostTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostTypeRepository _postTypeRepository;
        public PostTypeService(IPostTypeRepository postTypeRepository, IUnitOfWork unitOfWork)
        {
            _postTypeRepository = postTypeRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all post types
        /// </summary>
        /// <returns>List all post types</returns>
        /// <exception cref="AppException"></exception>
        public async Task<IEnumerable<PostType>> GetAll()
        {
            var postTypes = await _postTypeRepository.GetAll();
            return postTypes;
        }

        /// <summary>
        /// Get post type by id
        /// </summary>
        /// <param name="id"> ID of post type want to get</param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<PostType> GetById(int id)
        {
            var postType = await _postTypeRepository.GetById(id);
            return postType;
        }
    }
}
