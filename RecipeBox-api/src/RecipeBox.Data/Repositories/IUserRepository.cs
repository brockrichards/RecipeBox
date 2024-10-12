using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public interface IUserRepository {
        Task<User> AddAsync(User User);
        Task<User> GetAsync(Guid id);
        Task<PagedList<User>> SearchAsync(UserSearch model);
    }
}

