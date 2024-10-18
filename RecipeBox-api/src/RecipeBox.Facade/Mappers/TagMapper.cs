using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class TagMapper {

        private readonly SubjectMapper subjectMapper;
        public TagMapper(SubjectMapper subjectMapper) {
            this.subjectMapper = subjectMapper;
        }
        public TagDto MapToDto(Tag entity) {
            if (entity == null) {
                return null;
            }

            return new TagDto {
                TagId = entity.TagId,
                TagResourceId = entity.TagResourceId,
                Name = entity.Name,
                Category = entity.Category,
                CreatedSubject = subjectMapper.MapToDto(entity.CreatedSubject),
                CreatedDate = entity.CreatedDate,
                LastModifiedSubject = subjectMapper.MapToDto(entity.LastModifiedSubject),
                LastModifiedDate = entity.LastModifiedDate,
            };
        }

        internal TagSearch Map(TagSearchDto dto) {
            return new TagSearch {
                TagResourceId = dto.TagResourceId,
                Name = dto.Name,
                Category = dto.Category,
                PageNumber = dto.PageNumber,
                PageSize = dto.PageSize,
                Sort = dto.Sort
            };
        }
    }
}

