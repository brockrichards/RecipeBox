using System.Collections.Generic;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class RecipeIngredientMapper {
        private readonly SubjectMapper subjectMapper;
        public RecipeIngredientMapper(SubjectMapper subjectMapper) {
            this.subjectMapper = subjectMapper;
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
                CreatedDate = entity.CreatedDate,
                CreatedSubject = subjectMapper.MapToDto(entity.CreatedSubject),
                LastModifiedDate = entity.LastModifiedDate,
                LastModifiedSubject = subjectMapper.MapToDto(entity.LastModifiedSubject),
                RecipeIngredientId = entity.RecipeIngredientId,
                RecipeIngredientResourceId = entity.RecipeIngredientResourceId,
            };
        }
    }
}
