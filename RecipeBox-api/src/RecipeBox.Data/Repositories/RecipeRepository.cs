using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public class RecipeRepository : IRecipeRepository {
        private readonly IDatabaseContext context;

        public RecipeRepository(IDatabaseContext context) {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PagedList<Recipe>> SearchAsync(IRecipeSearch model) {
            var recipes = (IQueryable<Recipe>)context.Recipes
                .Include(x => x.CreatedSubject)
                .Include(x => x.LastModifiedSubject);

            recipes = model.Build(recipes);
            var result = new PagedList<Recipe> {
                PageNumber = model.PageNumber,
                PageSize = model.PageSize,
                TotalItems = await recipes.CountAsync().ConfigureAwait(false),
                Items = [],
            };

            recipes = recipes.ToSortedQuery(model.Sort);
            result.Items = await recipes.ToPagedQuery(model.PageNumber, model.PageSize).ToListAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<Recipe> AddAsync(Recipe recipe) {
            var entity = await context.Recipes.AddAsync(recipe);
            return entity.Entity;
        }

        public async Task<Recipe> GetAsync(Guid id) {
            var recipe = await context.Recipes
                .Include(x => x.CreatedSubject)
                .Include(x => x.LastModifiedSubject)
                .FirstOrDefaultAsync(o => o.RecipeResourceId == id).ConfigureAwait(false);

            return recipe;
        }

        public void RemoveIngredients(List<Ingredient> ingredientsToRemove) {
            context.RemoveRange(ingredientsToRemove);
        }
    }
}

