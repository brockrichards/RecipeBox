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

namespace UnitBox.WebApi.Controllers {
    /// <summary>
    /// Represents the shared functionality/resources of the unit resource
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [ApiController]
    [Route("api/v{version:apiVersion}/units")]
    public class UnitController : ControllerBase {
        private readonly UnitModelMapper unitMapper;
        private readonly IUnitFacade facade;
        private readonly IDistributedLockProvider lockProvider;
        private readonly ILogger<UnitController> logger;

        /// <summary>
        /// Initializes a new instance of the UnitController
        /// </summary>
        public UnitController(IUnitFacade facade, UnitModelMapper unitMapper, ILogger<UnitController> logger, IDistributedLockProvider lockProvider) {
            this.facade = facade;
            this.unitMapper = unitMapper;
            this.lockProvider = lockProvider;
            this.logger = logger;
        }

        /// <summary>
        /// Gets units
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedList<UnitModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUnitsAsync([FromQuery] UnitSearchModel search) {
            var searchDto = unitMapper.MapToDto(search);
            var results = await facade.SearchUnitsAsync(searchDto).ConfigureAwait(false);
            return Ok(results.Convert(x => unitMapper.Map(x)));
        }

        /// <summary>
        /// Gets an unit by id
        /// </summary>
        /// <param name="id">the id of the unit to get</param>
        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetUnitAsync))]
        [ProducesResponseType(typeof(UnitModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUnitAsync(Guid id) {
            var dto = await facade.GetUnitAsync(id).ConfigureAwait(false);
            return Ok(unitMapper.Map(dto));
        }

        /// <summary>
        /// Create a new unit
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("")]
        [ProducesResponseType(typeof(UnitModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUnitAsync([FromBody] CreateUnitModel input) {
            var dto = unitMapper.MapToDto(input);
            var unit = await facade.CreateUnitAsync(dto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetUnitAsync), new { id = unit.UnitResourceId }, unitMapper.Map(unit));
        }
    }
}
