using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface ISliderTypeRepository : IGenericRepository<SliderType>
    {
        Task<IEnumerable<SliderType>> GetAllWithDataSlides();
        Task<SliderType> GetByIdWithDataSlides(int id);
    }
}
