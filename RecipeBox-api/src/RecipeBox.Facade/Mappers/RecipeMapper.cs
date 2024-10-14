using System;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class RecipeMapper {

        private readonly SubjectMapper subjectMapper;
        private readonly RecipeIngredientMapper recipeIngredientMapper;
        private readonly RecipeTagMapper recipeTagMapper;
        public RecipeMapper(SubjectMapper subjectMapper, RecipeIngredientMapper recipeIngredientMapper, RecipeTagMapper recipeTagMapper) {
            this.subjectMapper = subjectMapper;
            this.recipeIngredientMapper = recipeIngredientMapper;
            this.recipeTagMapper = recipeTagMapper;
        }
        public RecipeDto MapToDto(Recipe entity) {
            if (entity == null) {
                return null;
            }

            return new RecipeDto {
                RecipeId = entity.RecipeId,
                RecipeResourceId = entity.RecipeResourceId,
                Title = entity.Title,
                Description = entity.Description,
                IsPublic = entity.IsPublic,
                ImageUrl = entity.ImageUrl,
                RecipeIngredients = recipeIngredientMapper.MapToDto(entity.RecipeIngredients),
                RecipeTags = recipeTagMapper.MapToDto(entity.RecipeTags),
                CreatedSubject = subjectMapper.MapToDto(entity.CreatedSubject),
                CreatedDate = entity.CreatedDate,
                LastModifiedSubject = subjectMapper.MapToDto(entity.LastModifiedSubject),
                LastModifiedDate = entity.LastModifiedDate,
            };
        }

        internal RecipeSearch Map(RecipeSearchDto search) {
            throw new NotImplementedException();
        }
    }
}

