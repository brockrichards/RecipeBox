using System;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class IngredientMapper {

        private readonly SubjectMapper subjectMapper;
        public IngredientMapper(SubjectMapper subjectMapper) {
            this.subjectMapper = subjectMapper;
        }
        public IngredientDto MapToDto(Ingredient entity) {
            if (entity == null) {
                return null;
            }

            return new IngredientDto {
                IngredientId = entity.IngredientId,
                IngredientResourceId = entity.IngredientResourceId,
                Name = entity.Name,
                Description = entity.Description,
                CreatedSubject = subjectMapper.MapToDto(entity.CreatedSubject),
                CreatedDate = entity.CreatedDate,
                LastModifiedSubject = subjectMapper.MapToDto(entity.LastModifiedSubject),
                LastModifiedDate = entity.LastModifiedDate,
            };
        }

        internal IngredientSearch Map(IngredientSearchDto search) {
            throw new NotImplementedException();
        }
    }
}

