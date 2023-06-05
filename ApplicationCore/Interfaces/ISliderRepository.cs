using ApplicationCore.Entities;
using ApplicationCore.Filer;

namespace ApplicationCore.Interfaces
{
    public interface ISliderRepository : IGenericRepository<Slider>
    {
        Task<IEnumerable<Slider>> GetSliderByType(int typeId);
        Task<IEnumerable<Slider>> GetSliderByTypeWithPagination(int type, PaginationFilter filter);
        Task<IEnumerable<Slider>> GetSliderWithPagination(PaginationFilter filter);
    }
}
