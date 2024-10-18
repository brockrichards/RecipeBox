#pragma warning disable CS1591 // Missing XML comments

using System;
using RecipeBox.Dto;
using RecipeBox.WebApi.Models.Requests;
using RecipeBox.WebApi.Models.Responses;

namespace RecipeBox.WebApi.Mappers {
    public class RecipeModelMapper {

    private readonly IngredientModelMapper ingredientMapper;
        public RecipeModelMapper(IngredientModelMapper ingredientMapper) {
            this.ingredientMapper = ingredientMapper;
        }

        public RecipeModel Map(RecipeDto dto) {
            if (dto == null) {
                return null;
            }

            return new RecipeModel();
        }

        internal RecipeSearchDto MapToDto(RecipeSearchModel search) {
            throw new NotImplementedException();
        }

        internal RecipeDto MapToDto(CreateRecipeModel input) {
            return new RecipeDto {
                Title = input.Title,
                Description = input.Description,
                IsPublic = input.IsPublic,
                ImageUrl = input.ImageUrl,
            };
        }
    }
}

