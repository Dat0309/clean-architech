using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using ApplicationCore.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace TitanWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderTypeController : ControllerBase
    {
        private readonly ISliderTypeService _sliderTypeService;
        private readonly ILogger<SliderTypeController> _logger;

        public SliderTypeController(ISliderTypeService sliderTypeService, ILogger<SliderTypeController> logger)
        {
            _sliderTypeService = sliderTypeService;
            _logger = logger;
        }

        /// <summary>
        /// Get ll slider type attach data slider table
        /// </summary>
        /// <returns> Response of list slider type </returns>
        [HttpGet]
        [Route("getAllWithSliderTable")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(ContentManager.LogGetAllSliderTypeTable);

            var sliderTypes = await _sliderTypeService.GetAllWithDataSlides();
            return Ok(new Response<IEnumerable<SliderType>>(sliderTypes, HttpStatusCode.OK, ContentManager.SuccessGetAllSliderType));
        }

        /// <summary>
        /// Get slider type by id
        /// </summary>
        /// <param name="id"> slider type id </param>
        /// <returns> Response of slider by id</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            _logger.LogInformation(ContentManager.LogGetSliderByTypeID);

            var sliderTypes = await _sliderTypeService.GetById(id);
            if (sliderTypes == null)
            {
                return Ok(new Response<SliderType>(HttpStatusCode.OK, ContentManager.NotFoundSliderTypeByIDMsg + id));
            }
            return Ok(new Response<SliderType>(sliderTypes, HttpStatusCode.OK, ContentManager.SuccessGetSliderTypeByID));
        }

        /// <summary>
        /// Get slider type attach data slider of them
        /// </summary>
        /// <param name="id"> slider type id </param>
        /// <returns> Response of slider type </returns>
        [HttpGet]
        [Route("getByIdWithSlider/{id}")]
        public async Task<IActionResult> GetByIdWithSlider([FromRoute] int id)
        {
            _logger.LogInformation(ContentManager.LogGetSliderTypeByID);

            var sliderType = await _sliderTypeService.GetByIdWithDataSlides(id);
            if (sliderType == null)
            {
                return Ok(new Response<SliderType>(HttpStatusCode.OK, ContentManager.NotFoundSliderTypeByIDMsg + id));
            }
            return Ok(new Response<SliderType>(sliderType, HttpStatusCode.OK, ContentManager.SuccessGetSliderTypeByID));
        }
    }
}
