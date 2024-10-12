using System;
using Cortside.AspNetCore.EntityFramework.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Searches {
    public interface IRecipeSearch : ISearch, ISearchBuilder<Recipe> {
        Guid? RecipeResourceId { get; set; }
    }
}

