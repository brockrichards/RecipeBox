using System;
using Cortside.AspNetCore.EntityFramework.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Searches {
    public interface IUserSearch : ISearch, ISearchBuilder<User> {
        Guid? UserResourceId { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
    }
}

