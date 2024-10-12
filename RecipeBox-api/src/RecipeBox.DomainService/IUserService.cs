using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Microsoft.AspNetCore.Identity;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public interface IUserService {
        Task<User> CreateUserAsync(UserDto dto);
        Task<User> GetUserAsync(Guid UserResourceId);
        Task<PagedList<User>> SearchUsersAsync(UserSearch search);
        Task<User> UpdateUserAsync(Guid resourceId, UserDto dto);
        Task<IdentityResult> ResetPasswordAsync(UserDto user, string newPassword);
        Task<IdentityResult> UpdatePasswordAsync(UserDto user, string currentPassword, string newPassword);
    }
}

