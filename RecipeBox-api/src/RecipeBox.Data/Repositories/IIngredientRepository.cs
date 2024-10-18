using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public interface IIngredientRepository {
        Task<PagedList<Ingredient>> SearchAsync(IIngredientSearch model);
        Task<Ingredient> AddAsync(Ingredient ingredient);
        Task<Ingredient> GetAsync(Guid id);
        void Update(Ingredient ingredient);
        void Delete(Ingredient ingredient);
    }
}

