using System.Collections.Generic;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class RecipeIngredientMapper {
        private readonly UnitMapper unitMapper;
        public RecipeIngredientMapper(UnitMapper unitMapper) {
            this.unitMapper = unitMapper;
        }
        public List<RecipeIngredientDto> MapToDto(ICollection<RecipeIngredient> entities) {
            List<RecipeIngredientDto> dto = [];

            if (entities != null && entities.Count > 0) {
                foreach (var entity in entities) {
                    dto.Add(MapToDto(entity));
                };
            }
            return dto;
        }

        private RecipeIngredientDto MapToDto(RecipeIngredient entity) {
            if (entity == null) {
                return null;
            }

            return new RecipeIngredientDto {
                IngredientResourceId = entity.Ingredient.IngredientResourceId,
                Unit = unitMapper.MapToDto(entity.Unit),
                Quantity = entity.Quantity,
            };
        }
    }
}
