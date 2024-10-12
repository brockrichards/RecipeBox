using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data {
    public interface IDatabaseContext {
        DbSet<User> Users { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Tag> Tags { get; set; }

        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Remove(object entity);
    }
}

