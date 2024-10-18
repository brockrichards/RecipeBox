using System;
using System.Linq;
using Cortside.AspNetCore.EntityFramework.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Searches {
    public class IngredientSearch : Search, IIngredientSearch {
        public Guid? IngredientResourceId { get; set; }

        public IQueryable<Ingredient> Build(IQueryable<Ingredient> entities) {
            if (IngredientResourceId.HasValue) {
                entities = entities.Where(x => x.IngredientResourceId == IngredientResourceId);
            }

            return entities;
        }
    }
}

