using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using Microsoft.AspNetCore.Identity;
using RecipeBox.DomainService;
using RecipeBox.Dto;
using RecipeBox.Facade.Mappers;

namespace RecipeBox.Facade {
    public class UserFacade : IUserFacade {
        private readonly IUnitOfWork uow;
        private readonly IUserService UserService;
        private readonly UserMapper mapper;

        public UserFacade(IUnitOfWork uow, IUserService UserService, UserMapper mapper) {
            this.uow = uow;
            this.UserService = UserService;
            this.mapper = mapper;
        }

        public async Task<UserDto> CreateUserAsync(UserDto dto) {
            var User = await UserService.CreateUserAsync(dto).ConfigureAwait(false);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(User);
        }

        public async Task<UserDto> GetUserAsync(Guid resourceId) {
            // Using BeginNoTracking on GET endpoints for a single entity so that data is read committed
            // with assumption that it might be used for changes in future calls
            await using (var tx = uow.BeginNoTracking()) {
                var User = await UserService.GetUserAsync(resourceId);
                return mapper.MapToDto(User);
            }
        }

        public Task<IdentityResult> ResetPasswordAsync(UserDto user, string newPassword) {
            throw new NotImplementedException();
        }

        public async Task<PagedList<UserDto>> SearchUsersAsync(UserSearchDto search) {
            var UserSearch = mapper.Map(search);
            // Using BeginReadUncommittedAsync on GET endpoints that return a list, this will read uncommitted and
            // as notracking in ef core.  this will result in a non-blocking dirty read, which is accepted best practice for mssql
            await using (var tx = await uow.BeginReadUncommitedAsync().ConfigureAwait(false)) {
                var Users = await UserService.SearchUsersAsync(UserSearch).ConfigureAwait(false);

                return new PagedList<UserDto> {
                    PageNumber = Users.PageNumber,
                    PageSize = Users.PageSize,
                    TotalItems = Users.TotalItems,
                    Items = Users.Items.ConvertAll(x => mapper.MapToDto(x))
                };
            }
        }

        public Task<IdentityResult> UpdatePasswordAsync(UserDto user, string currentPassword, string newPassword) {
            throw new NotImplementedException();
        }

        public async Task<UserDto> UpdateUserAsync(Guid resourceId, UserDto dto) {
            var User = await UserService.UpdateUserAsync(resourceId, dto).ConfigureAwait(false);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(User);
        }
    }
}

