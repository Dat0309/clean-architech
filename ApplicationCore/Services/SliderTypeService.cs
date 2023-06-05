using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class SliderTypeService : ISliderTypeService
    {
        private readonly ISliderTypeRepository _sliderTypeReponsitory;
        private readonly IUnitOfWork _unitOfWork;

        public SliderTypeService(ISliderTypeRepository sliderTypeReponsitory, IUnitOfWork unitOfWork)
        {
            _sliderTypeReponsitory = sliderTypeReponsitory;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all slider type
        /// </summary>
        /// <returns> List all of slider types </returns>
        /// <exception cref="AppException"></exception>
        public async Task<IEnumerable<SliderType>> GetAll()
        {
            var sliderTypes = await _sliderTypeReponsitory.GetAll();
            return sliderTypes;
        }

        /// <summary>
        /// Get all slider types attach data sliders of them
        /// </summary>
        /// <returns> List all slider types attach data sliders of them </returns>
        public async Task<IEnumerable<SliderType>> GetAllWithDataSlides()
        {
            return await _sliderTypeReponsitory.GetAllWithDataSlides();
        }

        /// <summary>
        /// Get slider type by id
        /// </summary>
        /// <param name="id"> ID of slider type want to get </param>
        /// <returns> Single slider type </returns>
        /// <exception cref="AppException"></exception>
        public async Task<SliderType> GetById(int id)
        {
            var sliderType = await _sliderTypeReponsitory.GetById(id);
            return sliderType;
        }

        /// <summary>
        /// Get slider type by id attach data sliders of them
        /// </summary>
        /// <param name="id"> ID of slider type want to get </param>
        /// <returns> Single slider type attach sliders of them </returns>
        /// <exception cref="AppException"></exception>
        public async Task<SliderType> GetByIdWithDataSlides(int id)
        {
            var sliderType = await _sliderTypeReponsitory.GetByIdWithDataSlides(id);
            return sliderType;
        }
    }
}
