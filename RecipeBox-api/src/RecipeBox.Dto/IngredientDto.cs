using System;
using Cortside.AspNetCore.Common.Dtos;

namespace RecipeBox.Dto {
    public class IngredientDto : AuditableEntityDto {
        public int IngredientId { get; set; }

        public Guid IngredientResourceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
