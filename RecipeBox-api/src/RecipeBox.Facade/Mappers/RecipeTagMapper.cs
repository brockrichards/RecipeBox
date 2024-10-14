using System.Collections.Generic;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class RecipeTagMapper {
        private readonly SubjectMapper subjectMapper;
        public RecipeTagMapper(SubjectMapper subjectMapper) {
            this.subjectMapper = subjectMapper;
        }

        public List<RecipeTagDto> MapToDto(ICollection<RecipeTag> entities) {
            List<RecipeTagDto> dto = [];

            if (entities != null && entities.Count > 0) {
                foreach (var entity in entities) {
                    dto.Add(MapToDto(entity));
                };
            }
            return dto;
        }

        private RecipeTagDto MapToDto(RecipeTag entity) {
            if (entity == null) {
                return null;
            }

            return new RecipeTagDto {
                CreatedDate = entity.CreatedDate,
                CreatedSubject = subjectMapper.MapToDto(entity.CreatedSubject),
                LastModifiedDate = entity.LastModifiedDate,
                LastModifiedSubject = subjectMapper.MapToDto(entity.LastModifiedSubject),
                RecipeTagId = entity.RecipeTagId,
                RecipeTagResourceId = entity.RecipeTagResourceId,
            };
        }
    }
}
