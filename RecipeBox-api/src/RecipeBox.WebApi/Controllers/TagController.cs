using System;
using System.Threading.Tasks;
using Asp.Versioning;
using Cortside.AspNetCore.Common.Paging;
using Medallion.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeBox.Facade;
using RecipeBox.WebApi.Mappers;
using RecipeBox.WebApi.Models;
using RecipeBox.WebApi.Models.Requests;

namespace TagBox.WebApi.Controllers {
    /// <summary>
    /// Represents the shared functionality/resources of the tag resource
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [ApiController]
    [Route("api/v{version:apiVersion}/tags")]
    public class TagController : ControllerBase {
        private readonly TagModelMapper tagMapper;
        private readonly ITagFacade facade;
        private readonly IDistributedLockProvider lockProvider;
        private readonly ILogger<TagController> logger;

        /// <summary>
        /// Initializes a new instance of the TagController
        /// </summary>
        public TagController(ITagFacade facade, TagModelMapper tagMapper, ILogger<TagController> logger, IDistributedLockProvider lockProvider) {
            this.facade = facade;
            this.tagMapper = tagMapper;
            this.lockProvider = lockProvider;
            this.logger = logger;
        }

        /// <summary>
        /// Gets tags
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedList<TagModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTagsAsync([FromQuery] TagSearchModel search) {
            var searchDto = tagMapper.MapToDto(search);
            var results = await facade.SearchTagsAsync(searchDto).ConfigureAwait(false);
            return Ok(results.Convert(x => tagMapper.Map(x)));
        }

        /// <summary>
        /// Gets an tag by id
        /// </summary>
        /// <param name="id">the id of the tag to get</param>
        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetTagAsync))]
        [ProducesResponseType(typeof(TagModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTagAsync(Guid id) {
            var dto = await facade.GetTagAsync(id).ConfigureAwait(false);
            return Ok(tagMapper.Map(dto));
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("")]
        [ProducesResponseType(typeof(TagModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateTagAsync([FromBody] CreateTagModel input) {
            var dto = tagMapper.MapToDto(input);
            var tag = await facade.CreateTagAsync(dto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetTagAsync), new { id = tag.TagResourceId }, tagMapper.Map(tag));
        }
    }
}
