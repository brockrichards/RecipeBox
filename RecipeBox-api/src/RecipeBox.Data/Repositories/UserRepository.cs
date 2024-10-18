using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public class UserRepository : IUserRepository {
        private readonly IDatabaseContext context;

        public UserRepository(IDatabaseContext context) {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PagedList<User>> SearchAsync(IUserSearch model) {
            var Users = model.Build(context.Users);
            var result = new PagedList<User> {
                PageNumber = model.PageNumber,
                PageSize = model.PageSize,
                TotalItems = await Users.CountAsync().ConfigureAwait(false),
                Items = [],
            };

            Users = Users.ToSortedQuery(model.Sort);
            result.Items = await Users.ToPagedQuery(model.PageNumber, model.PageSize).ToListAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<User> AddAsync(User user) {
            var entity = await context.Users.AddAsync(user);
            return entity.Entity;
        }

        public Task<User> GetAsync(Guid id) {
            return context.Users.FirstOrDefaultAsync(o => o.UserResourceId == id);
        }

        public void Update(User user) {
            context.Users.Update(user);
        }

        public void Delete(User user) {
            context.Remove(user);
        }
    }
}

