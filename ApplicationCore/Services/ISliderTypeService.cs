using ApplicationCore.Entities;

namespace ApplicationCore.Services
{
    public interface ISliderTypeService
    {
        public Task<IEnumerable<SliderType>> GetAllWithDataSlides();
        public Task<SliderType> GetByIdWithDataSlides(int id);
        public Task<SliderType> GetById(int id);
        public Task<IEnumerable<SliderType>> GetAll();
    }
}
