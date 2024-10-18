using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Dto;

namespace RecipeBox.Facade {
    public interface IUnitFacade {
        Task<UnitDto> CreateUnitAsync(UnitDto dto);
        Task<UnitDto> GetUnitAsync(Guid id);
        Task<PagedList<UnitDto>> SearchUnitsAsync(UnitSearchDto search);
        Task<UnitDto> UpdateUnitAsync(Guid id, UnitDto dto);
    }
}

