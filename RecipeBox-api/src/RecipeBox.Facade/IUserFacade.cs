using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Microsoft.AspNetCore.Identity;
using RecipeBox.Dto;

namespace RecipeBox.Facade {
    public interface IUserFacade {
        Task<UserDto> CreateUserAsync(UserDto dto);
        Task<UserDto> GetUserAsync(Guid resourceId);
        Task<PagedList<UserDto>> SearchUsersAsync(UserSearchDto search);
        Task<UserDto> UpdateUserAsync(Guid resourceId, UserDto dto);
        Task<IdentityResult> ResetPasswordAsync(UserDto user, string newPassword);
        Task<IdentityResult> UpdatePasswordAsync(UserDto user, string currentPassword, string newPassword);
    }
}

