using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Microsoft.Extensions.Logging;
using RecipeBox.Data.Repositories;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public class RecipeService : IRecipeService {
        private readonly ILogger<RecipeService> logger;
        private readonly IRecipeRepository recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository, ILogger<RecipeService> logger) {
            this.logger = logger;
            this.recipeRepository = recipeRepository;
        }

        public Task<Recipe> AddRecipeIngredientAsync(Guid resourceId, IngredientDto dto) {
            throw new NotImplementedException();
        }

        public Task<Recipe> CreateRecipeAsync(RecipeDto dto) {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetRecipeAsync(Guid RecipeResourceId) {
            throw new NotImplementedException();
        }

        public Task<PagedList<Recipe>> SearchRecipesAsync(RecipeSearch search) {
            throw new NotImplementedException();
        }

        public Task<Recipe> UpdateRecipeAsync(Guid resourceId, RecipeDto dto) {
            throw new NotImplementedException();
        }
    }
}

