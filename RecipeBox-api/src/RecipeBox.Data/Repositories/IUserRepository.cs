using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public interface IUserRepository {
        Task<PagedList<User>> SearchAsync(IUserSearch model);
        Task<User> AddAsync(User user);
        Task<User> GetAsync(Guid id);
        void Update(User user);
        void Delete(User user);
    }
}

