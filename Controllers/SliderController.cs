using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Filer;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using ApplicationCore.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace TitanWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IUriReposiroty _uriReposiroty;
        private readonly ILogger<SliderController> _logger;

        public SliderController(ISliderService sliderService, IUriReposiroty uriReposiroty, ILogger<SliderController> logger)
        {
            _sliderService = sliderService;
            _uriReposiroty = uriReposiroty;
            _logger = logger;
        }

        /// <summary>
        /// Get slider by type id 
        /// </summary>
        /// <param name="typeId"> type id of this slider </param>
        /// <returns> Response of Slider list or any Response attach response code, message, status </returns>
        [HttpGet]
        [Route("type/{typeId}")]
        public async Task<IActionResult> GetSliderByTypeId([FromRoute] int typeId)
        {
            _logger.LogInformation(ContentManager.LogGetSliderByTypeID);

            var sliders = await _sliderService.GetSliderByType(typeId);
            if (sliders.Count() == 0)
            {
                return Ok(new Response<IEnumerable<Slider>>(HttpStatusCode.OK, ContentManager.NotFoundSliderByTypeIDMsg + typeId));
            }
            return Ok(new Response<IEnumerable<Slider>>(sliders, HttpStatusCode.OK, ContentManager.SuccessGetSliderByTypeID));
        }

        /// <summary>
        /// Get slider support pagination
        /// </summary>
        /// <param name="filter"> Filter from query of Pagination: PageSize, PageNumber. </param>
        /// <returns> Response of Slider list (support pagination) or any Response attach response code, message, status </returns>
        [HttpGet]
        [Route("withPagination")]
        public async Task<IActionResult> GetSliderWithPage([FromQuery] PaginationFilter filter)
        {
            _logger.LogInformation(ContentManager.LogGetSliderPagination);

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalRecords = _sliderService.GetCountDocument();
            var sliders = await _sliderService.GetSliderWithPagination(validFilter);

            var pagedResponse = PaginationHelper.CreatePagedReponse<Slider>(sliders, validFilter, totalRecords, _uriReposiroty, route!,ContentManager.SuccessGetSliderPagination, true, HttpStatusCode.OK);
            return Ok(pagedResponse);
        }

        /// <summary>
        /// Get single slider by id
        /// </summary>
        /// <param name="id"> slider id need to find </param>
        /// <returns> Response of Single slider by this id attach response code, message, status</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            _logger.LogInformation(ContentManager.SuccessGetSliderByID);

            var slider = await _sliderService.GetById(id);
            if (slider == null)
            {
                return Ok(new Response<Post>(HttpStatusCode.OK, ContentManager.NotFoundSliderByIDMsg + id));
            }
            return Ok(new Response<Slider>(slider, HttpStatusCode.OK, ContentManager.SuccessGetSliderByID));
        }
    }
}
