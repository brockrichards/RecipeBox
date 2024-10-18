using System;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class UnitMapper {
        private readonly SubjectMapper subjectMapper;
        public UnitMapper(SubjectMapper subjectMapper) {
            this.subjectMapper = subjectMapper;
        }

        internal IUnitSearch Map(UnitSearchDto search) {
            throw new NotImplementedException();
        }

        internal UnitDto MapToDto(Unit unit) {
            return new UnitDto {
                UnitId = unit.UnitId,
                UnitResourceId = unit.UnitResourceId,
                Name = unit.Name,
                CreatedDate = unit.CreatedDate,
                CreatedSubject = subjectMapper.MapToDto(unit.CreatedSubject),
                LastModifiedDate = unit.LastModifiedDate,
                LastModifiedSubject = subjectMapper.MapToDto(unit.LastModifiedSubject),
            };
        }
    }
}
