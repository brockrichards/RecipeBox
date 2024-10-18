using System;
using System.Linq;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public class IngredientRepository : IIngredientRepository {
        private readonly IDatabaseContext context;

        public IngredientRepository(IDatabaseContext context) {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Ingredient> GetAsync(Guid id) {
            return await context.Ingredients.FirstOrDefaultAsync(r => r.IngredientResourceId == id).ConfigureAwait(false);
        }

        public async Task<Ingredient> AddAsync(Ingredient ingredient) {
            return (await context.Ingredients.AddAsync(ingredient).ConfigureAwait(false)).Entity;
        }

        public void Update(Ingredient ingredient) {
            context.Ingredients.Update(ingredient);
        }

        public void Delete(Ingredient ingredient) {
            context.Ingredients.Remove(ingredient);
        }

        public async Task<PagedList<Ingredient>> SearchAsync(IIngredientSearch model) {
            var ingredients = (IQueryable<Ingredient>)context.Ingredients
                .Include(x => x.CreatedSubject)
                .Include(x => x.LastModifiedSubject);

            ingredients = model.Build(ingredients);
            var result = new PagedList<Ingredient> {
                PageNumber = model.PageNumber,
                PageSize = model.PageSize,
                TotalItems = await ingredients.CountAsync().ConfigureAwait(false),
                Items = [],
            };

            ingredients = ingredients.ToSortedQuery(model.Sort);
            result.Items = await ingredients.ToPagedQuery(model.PageNumber, model.PageSize).ToListAsync().ConfigureAwait(false);

            return result;
        }
    }
}

