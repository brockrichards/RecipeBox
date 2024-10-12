using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class TagMapper {
        public TagDto MapToDto(Tag entity) {
            if (entity == null) {
                return null;
            }

            return new TagDto();
        }
    }
}

