using System;
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

        public async Task<Recipe> GetAsync(Guid id) {
            return await context.Recipes.FirstOrDefaultAsync(r => r.RecipeResourceId == id).ConfigureAwait(false);
        }

        public async Task<Recipe> AddAsync(Recipe recipe) {
            return (await context.Recipes.AddAsync(recipe).ConfigureAwait(false)).Entity;
        }

        public void Update(Recipe recipe) {
            context.Recipes.Update(recipe);
        }

        public void Delete(Recipe recipe) {
            context.Recipes.Remove(recipe);
        }

        public async Task<PagedList<Recipe>> SearchAsync(IRecipeSearch model) {
            var recipes = (IQueryable<Recipe>)context.Recipes
                .Include(x => x.RecipeIngredients)
                    .ThenInclude(x => x.Ingredient)
                .Include(x => x.RecipeTags)
                    .ThenInclude(x => x.Tag)
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

        public async Task<RecipeIngredient> GetRecipeIngredientAsync(Recipe recipe, Guid ingredientResourceId, Guid unitResourceId, decimal quantity) {
            var ingredient = await context.Ingredients.FirstOrDefaultAsync(i => i.IngredientResourceId == ingredientResourceId).ConfigureAwait(false);
            var unit = await context.Units.FirstOrDefaultAsync(u => u.UnitResourceId == unitResourceId).ConfigureAwait(false);
            return new RecipeIngredient(recipe, ingredient, unit, quantity);
        }

        public async Task<RecipeTag> GetRecipeTagAsync(Recipe recipe, Guid tagResourceId) {
            var tag = await context.Tags.FirstOrDefaultAsync(t=>t.TagResourceId == tagResourceId).ConfigureAwait(false);
            return new RecipeTag(recipe, tag);
        }
    }
}

