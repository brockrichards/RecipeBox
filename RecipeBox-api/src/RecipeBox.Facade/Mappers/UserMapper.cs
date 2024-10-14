using System;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.Facade.Mappers {
    public class UserMapper {
        private readonly SubjectMapper subjectMapper;

        public UserMapper(SubjectMapper subjectMapper) {
            this.subjectMapper = subjectMapper;
        }

        public UserDto MapToDto(User entity) {
            if (entity == null) {
                return null;
            }

            return new UserDto {
                UserId = entity.UserId,
                UserResourceId = entity.UserResourceId,
                UserName = entity.UserName,
                Email = entity.Email,
                CreatedDate = entity.CreatedDate,
                LastModifiedDate = entity.LastModifiedDate,
                CreatedSubject = subjectMapper.MapToDto(entity.CreatedSubject),
                LastModifiedSubject = subjectMapper.MapToDto(entity.LastModifiedSubject),
            };
        }

        internal UserSearch Map(UserSearchDto search) {
            throw new NotImplementedException();
        }
    }
}

