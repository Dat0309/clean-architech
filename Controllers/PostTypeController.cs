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
    public class PostTypeController : ControllerBase
    {
        private readonly IPostTypeService _postTypeService;
        private readonly ILogger<PostTypeController> _logger;
        public PostTypeController(IPostTypeService postTypeService, ILogger<PostTypeController> logger)
        {
            _postTypeService = postTypeService;
            _logger = logger;
        }

        /// <summary>
        /// Get all post type
        /// </summary>
        /// <returns> Response of list post type </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(ContentManager.LogGetAllPostTypeTable);
            var postTypes = await _postTypeService.GetAll();

            return Ok(new Response<IEnumerable<PostType>>(postTypes, HttpStatusCode.OK, ContentManager.SuccessGetAllPostType));
        }

        /// <summary>
        /// Get post type by id
        /// </summary>
        /// <param name="id"> Id of post type </param>
        /// <returns> Response of single post type get by id </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            _logger.LogInformation(ContentManager.LogGetPostTypeByID);
            var postType = await _postTypeService.GetById(id);
            if (postType == null)
            {
                return Ok(new Response<PostType>(HttpStatusCode.OK, ContentManager.NotFoundPostTypeIDMsg + id));
            }

            return Ok(new Response<PostType>(postType, HttpStatusCode.OK, ContentManager.SuccessGetPostTypeByID));
        }
    }
}
