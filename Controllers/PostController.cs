using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Filer;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using ApplicationCore.Wrappers;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TitanWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IUriReposiroty _uriReposiroty;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostService postService, IUriReposiroty uriReposiroty, ILogger<PostController> logger)
        {
            _postService = postService;
            _uriReposiroty = uriReposiroty;
            _logger = logger;
        }

        /// <summary>
        /// Get post by type id
        /// </summary>
        /// <param name="typeId"> Id of post type </param>
        /// <returns> Response of list post by type id </returns>
        [HttpGet]
        [Route("type/{typeId}")]
        public async Task<IActionResult> GetPostByTypeId([FromRoute] int typeId)
        {
            _logger.LogInformation(ContentManager.LogGetPostTypeByID);
            var posts = await _postService.GetPostByType(typeId);
            if(posts.Count() == 0)
            {
                return Ok(new Response<IEnumerable<Post>>(HttpStatusCode.OK, ContentManager.NotFoundPostByTypeID + typeId));
            }

            return Ok(new Response<IEnumerable<Post>>(posts, HttpStatusCode.OK, ContentManager.SuccessGetPostByTypeID + typeId));
        }

        /// <summary>
        /// Get post by type support pagination
        /// </summary>
        /// <param name="typeId"> Id of post type </param>
        /// <param name="filter"> filter of pagination: PageSize, PageNumber </param>
        /// <returns> Response of list post by type id, support pagination </returns>
        [HttpGet]
        [Route("typeWithPagination/{typeId}")]
        public async Task<IActionResult> GetPostByTypeWithPagination([FromRoute] int typeId, [FromQuery] PaginationFilter filter)
        {
            _logger.LogInformation(ContentManager.LogGetPostPagination);
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var postByTypes = await _postService.GetPostByType(typeId);
            var totalRecords = postByTypes.Count();

            var posts = await _postService.GetPostByTypeWithPagination(typeId, validFilter);

            var pageResponse = PaginationHelper.CreatePagedReponse<Post>(posts, validFilter, totalRecords, _uriReposiroty, route!, ContentManager.SuccessGetPostPagination, true, HttpStatusCode.OK);

            return Ok(pageResponse);
        }
    }
}
