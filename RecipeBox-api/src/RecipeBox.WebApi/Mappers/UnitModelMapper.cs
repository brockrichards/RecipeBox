#pragma warning disable CS1591 // Missing XML comments

using System;
using RecipeBox.Dto;
using RecipeBox.WebApi.Models.Requests;
using RecipeBox.WebApi.Models.Responses;

namespace RecipeBox.WebApi.Mappers {
    public class UnitModelMapper {
        public UnitModel Map(UnitDto dto) {
            if (dto == null) {
                return null;
            }

            return new UnitModel();
        }

        internal UnitSearchDto MapToDto(UnitSearchModel search) {
            throw new NotImplementedException();
        }

        internal UnitDto MapToDto(CreateUnitModel input) {
            return new UnitDto {
                 Name = input.Name,
                 Description = input.Description,
            };
        }
    }
}

