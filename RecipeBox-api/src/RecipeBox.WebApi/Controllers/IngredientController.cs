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

namespace IngredientBox.WebApi.Controllers {
    /// <summary>
    /// Represents the shared functionality/resources of the ingredient resource
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [ApiController]
    [Route("api/v{version:apiVersion}/ingredients")]
    public class IngredientController : ControllerBase {
        private readonly IngredientModelMapper ingredientMapper;
        private readonly IIngredientFacade facade;
        private readonly IDistributedLockProvider lockProvider;
        private readonly ILogger<IngredientController> logger;

        /// <summary>
        /// Initializes a new instance of the IngredientController
        /// </summary>
        public IngredientController(IIngredientFacade facade, IngredientModelMapper ingredientMapper, ILogger<IngredientController> logger, IDistributedLockProvider lockProvider) {
            this.facade = facade;
            this.ingredientMapper = ingredientMapper;
            this.lockProvider = lockProvider;
            this.logger = logger;
        }

        /// <summary>
        /// Gets ingredients
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedList<IngredientModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetIngredientsAsync([FromQuery] IngredientSearchModel search) {
            var searchDto = ingredientMapper.MapToDto(search);
            var results = await facade.SearchIngredientsAsync(searchDto).ConfigureAwait(false);
            return Ok(results.Convert(x => ingredientMapper.Map(x)));
        }

        /// <summary>
        /// Gets an ingredient by id
        /// </summary>
        /// <param name="id">the id of the ingredient to get</param>
        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetIngredientAsync))]
        [ProducesResponseType(typeof(IngredientModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetIngredientAsync(Guid id) {
            var dto = await facade.GetIngredientAsync(id).ConfigureAwait(false);
            return Ok(ingredientMapper.Map(dto));
        }

        /// <summary>
        /// Create a new ingredient
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("")]
        [ProducesResponseType(typeof(IngredientModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateIngredientAsync([FromBody] CreateIngredientModel input) {
            var dto = ingredientMapper.MapToDto(input);
            var ingredient = await facade.CreateIngredientAsync(dto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetIngredientAsync), new { id = ingredient.IngredientResourceId }, ingredientMapper.Map(ingredient));
        }
    }
}
