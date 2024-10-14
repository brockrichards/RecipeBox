using System;
using System.Collections.Generic;
using Cortside.AspNetCore.Common.Dtos;

namespace RecipeBox.Dto {
    public class RecipeDto : AuditableEntityDto {
        public int RecipeId { get; set; }

        public Guid RecipeResourceId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string ImageUrl { get; set; }

        public List<RecipeIngredientDto> RecipeIngredients { get; set; }
        public List<RecipeTagDto> RecipeTags { get; set; }
    }
}
