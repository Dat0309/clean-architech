using ApplicationCore.Entities;
using ApplicationCore.Filer;

namespace ApplicationCore.Services
{
    public interface ISliderService
    {
        public Task<IEnumerable<Slider>> GetSliderByType(int typeId);
        public Task<IEnumerable<Slider>> GetSliderByTypeWithPagination(int type, PaginationFilter filter);
        public Task<IEnumerable<Slider>> GetSliderWithPagination(PaginationFilter filter);
        public Task<Slider> GetById(int id);
        public int GetCountDocument();
    }
}
