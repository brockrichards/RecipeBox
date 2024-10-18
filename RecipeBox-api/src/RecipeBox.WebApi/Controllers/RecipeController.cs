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
using RecipeBox.WebApi.Models.Requests;
using RecipeBox.WebApi.Models.Responses;

namespace RecipeBox.WebApi.Controllers {
    /// <summary>
    /// Represents the shared functionality/resources of the recipe resource
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [ApiController]
    [Route("api/v{version:apiVersion}/recipes")]
    public class RecipeController : ControllerBase {
        private readonly RecipeModelMapper recipeMapper;
        private readonly IRecipeFacade facade;
        private readonly IDistributedLockProvider lockProvider;
        private readonly ILogger<RecipeController> logger;

        /// <summary>
        /// Initializes a new instance of the RecipeController
        /// </summary>
        public RecipeController(IRecipeFacade facade, RecipeModelMapper recipeMapper, ILogger<RecipeController> logger, IDistributedLockProvider lockProvider) {
            this.facade = facade;
            this.recipeMapper = recipeMapper;
            this.lockProvider = lockProvider;
            this.logger = logger;
        }

        /// <summary>
        /// Gets recipes
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedList<RecipeModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecipesAsync([FromQuery] RecipeSearchModel search) {
            var searchDto = recipeMapper.MapToDto(search);
            var results = await facade.SearchRecipesAsync(searchDto).ConfigureAwait(false);
            return Ok(results.Convert(x => recipeMapper.Map(x)));
        }

        /// <summary>
        /// Gets an recipe by id
        /// </summary>
        /// <param name="id">the id of the recipe to get</param>
        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetRecipeAsync))]
        [ProducesResponseType(typeof(RecipeModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecipeAsync(Guid id) {
            var dto = await facade.GetRecipeAsync(id).ConfigureAwait(false);
            return Ok(recipeMapper.Map(dto));
        }

        /// <summary>
        /// Create a new recipe
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("")]
        [ProducesResponseType(typeof(RecipeModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateRecipeAsync([FromBody] CreateRecipeModel input) {
            var dto = recipeMapper.MapToDto(input);
            var recipe = await facade.CreateRecipeAsync(dto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetRecipeAsync), new { id = recipe.RecipeResourceId }, recipeMapper.Map(recipe));
        }
    }
}
