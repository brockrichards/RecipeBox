#pragma warning disable CS1591 // Missing XML comments

using System;
using RecipeBox.Dto;
using RecipeBox.WebApi.Models.Requests;
using RecipeBox.WebApi.Models.Responses;

namespace RecipeBox.WebApi.Mappers {
    public class IngredientModelMapper {
        public IngredientModel Map(IngredientDto dto) {
            if (dto == null) {
                return null;
            }

            return new IngredientModel();
        }

        internal IngredientSearchDto MapToDto(IngredientSearchModel search) {
            throw new NotImplementedException();
        }

        internal IngredientDto MapToDto(CreateIngredientModel input) {
            return new IngredientDto {
                 Name = input.Name,
                 Description = input.Description,
            };
        }
    }
}

