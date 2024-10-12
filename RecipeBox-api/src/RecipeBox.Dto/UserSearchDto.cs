using System;
using Cortside.AspNetCore.Common.Dtos;

namespace RecipeBox.Dto {
    public class UserSearchDto : AuditableEntityDto {
        public int UserId { get; set; }
        public Guid UserResourceId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
