using System;
using Cortside.AspNetCore.EntityFramework.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Searches {
    public interface IIngredientSearch : ISearch, ISearchBuilder<Ingredient> {
        Guid? IngredientResourceId { get; set; }
    }
}

