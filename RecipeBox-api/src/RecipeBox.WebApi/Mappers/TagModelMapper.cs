#pragma warning disable CS1591 // Missing XML comments

using RecipeBox.Dto;
using RecipeBox.WebApi.Models;
using RecipeBox.WebApi.Models.Requests;

namespace RecipeBox.WebApi.Mappers {
    public class TagModelMapper {
        public TagModel Map(TagDto dto) {
            if (dto == null) {
                return null;
            }

            return new TagModel {
                Name = dto.Name,
                Category = dto.Category,
                TagResourceId = dto.TagResourceId,
            };
        }

        internal TagSearchDto MapToDto(TagSearchModel model) {
            return new TagSearchDto {
                Name = model.Name,
                Category = model.Category,
                PageSize = model.PageSize,
                PageNumber = model.PageNumber,
                Sort = model.Sort,
            };
        }

        internal TagDto MapToDto(CreateTagModel input) {
            return new TagDto {
                Name = input.Name,
                Category = input.Category,
            };
        }
    }
}

