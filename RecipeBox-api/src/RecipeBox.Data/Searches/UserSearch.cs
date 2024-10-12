using System;
using System.Linq;
using Cortside.AspNetCore.EntityFramework.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Searches {
    public class UserSearch : Search, IUserSearch {
        public Guid? UserResourceId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public IQueryable<User> Build(IQueryable<User> entities) {
            if (UserResourceId.HasValue) {
                entities = entities.Where(x => x.UserResourceId == UserResourceId);
            }

            entities = UserNameFilter(entities);
            entities = EmailFilter(entities);

            return entities;
        }

        private IQueryable<User> UserNameFilter(IQueryable<User> entities) {
            if (!string.IsNullOrEmpty(UserName)) {
                entities = entities.Where(x => x.UserName.StartsWith(UserName));
            }

            return entities;
        }

        private IQueryable<User> EmailFilter(IQueryable<User> entities) {
            if (!string.IsNullOrEmpty(Email)) {
                entities = entities.Where(x => x.Email.StartsWith(Email));
            }

            return entities;
        }
    }
}

