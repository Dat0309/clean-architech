using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Filer;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class SliderService : ISliderService
    {
        private ISliderRepository _sliderRepository;
        private IUnitOfWork _unitOfWork;

        public SliderService(ISliderRepository sliderRepository, IUnitOfWork unitOfWork)
        {
            _sliderRepository = sliderRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get slider by id
        /// </summary>
        /// <param name="id"> ID of slider want to get </param>
        /// <returns> Single slider by id </returns>
        /// <exception cref="AppException"></exception>
        public async Task<Slider> GetById(int id)
        {
            var slider = await _sliderRepository.GetById(id);
            return slider;
        }

        /// <summary>
        /// Get count of list slider
        /// </summary>
        /// <returns> Count of list slider </returns>
        public int GetCountDocument()
        {
            return _sliderRepository.GetCountDocument();
        }

        /// <summary>
        /// Get sliders by type
        /// </summary>
        /// <param name="typeId"> Type ID of sliders</param>
        /// <returns> List sliders by id </returns>
        /// <exception cref="AppException"></exception>
        public async Task<IEnumerable<Slider>> GetSliderByType(int typeId)
        {
            var sliders = await _sliderRepository.GetSliderByType(typeId);
            return sliders;
        }

        /// <summary>
        /// Get sliders by type support pagination
        /// </summary>
        /// <param name="type"> Type id of sliders want to get </param>
        /// <param name="filter"> Pagination filter from request body </param>
        /// <returns> List sliders by type id </returns>
        /// <exception cref="AppException"></exception>
        public async Task<IEnumerable<Slider>> GetSliderByTypeWithPagination(int type, PaginationFilter filter)
        {
            var sliders = await _sliderRepository.GetSliderByTypeWithPagination(type, filter);
            return sliders;
        }

        /// <summary>
        /// Get all sliders support pagination
        /// </summary>
        /// <param name="filter"> pagination filter from request body </param>
        /// <returns> List all sliders support pagination </returns>
        public async Task<IEnumerable<Slider>> GetSliderWithPagination(PaginationFilter filter)
        {
            return await _sliderRepository.GetSliderWithPagination(filter);
        }
    }
}
