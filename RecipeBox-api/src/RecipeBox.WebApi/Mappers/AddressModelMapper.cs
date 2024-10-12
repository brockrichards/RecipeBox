#pragma warning disable CS1591 // Missing XML comments

using RecipeBox.Dto;
using RecipeBox.WebApi.Models;

namespace RecipeBox.WebApi.Mappers {
    public class TagModelMapper {
        public TagModel Map(TagDto dto) {
            if (dto == null) {
                return null;
            }

            return new TagModel();
        }
    }
}

