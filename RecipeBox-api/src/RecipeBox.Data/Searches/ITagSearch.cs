using System;
using Cortside.AspNetCore.EntityFramework.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Enumerations;

namespace RecipeBox.Data.Searches {
    public interface ITagSearch : ISearch, ISearchBuilder<Tag> {
        Guid? TagResourceId { get; set; }
        string Name { get; set; }
        CategoryType? Category { get; set; }
    }
}

