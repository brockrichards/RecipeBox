using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class RecipeMapper {
        private readonly UserMapper UserMapper;
        private readonly TagMapper TagMapper;
        private readonly SubjectMapper subjectMapper;

        public RecipeMapper(UserMapper UserMapper, TagMapper TagMapper, SubjectMapper subjectMapper) {
            this.UserMapper = UserMapper;
            this.TagMapper = TagMapper;
            this.subjectMapper = subjectMapper;
        }

        public RecipeDto MapToDto(Recipe entity) {
            if (entity == null) {
                return null;
            }

            var dto = new RecipeDto();

            return dto;
        }

        public IngredientDto MapToDto(Ingredient entity) {
            if (entity == null) {
                return null;
            }

            return new IngredientDto();
        }

        public RecipeSearch Map(RecipeSearchDto dto) {
            if (dto == null) {
                return null;
            }

            return new RecipeSearch();
        }
    }
}

