using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public interface IUnitService {
        Unit CreateUnit(UnitDto dto);
        Unit UpdateUnit(Unit ingredient, UnitDto dto);
    }
}

