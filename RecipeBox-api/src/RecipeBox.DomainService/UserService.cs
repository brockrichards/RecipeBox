using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.DomainEvent.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using RecipeBox.Data.Repositories;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public class UserService : IUserService {
        private readonly ILogger<UserService> logger;
        private readonly IUserRepository UserRepository;

        public UserService(IUserRepository UserRepository, IDomainEventOutboxPublisher publisher, ILogger<UserService> logger) {
            this.logger = logger;
            this.UserRepository = UserRepository;
        }

        public Task<User> CreateUserAsync(UserDto dto) {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(Guid UserResourceId) {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ResetPasswordAsync(UserDto user, string newPassword) {
            throw new NotImplementedException();
        }

        public Task<PagedList<User>> SearchUsersAsync(UserSearch search) {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdatePasswordAsync(UserDto user, string currentPassword, string newPassword) {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(Guid resourceId, UserDto dto) {
            throw new NotImplementedException();
        }
    }
}

