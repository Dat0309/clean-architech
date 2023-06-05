using ApplicationCore.Entities;

namespace ApplicationCore.Services
{
    public interface IPostTypeService
    {
        public Task<PostType> GetById(int id);
        public Task<IEnumerable<PostType>> GetAll();
    }
}
