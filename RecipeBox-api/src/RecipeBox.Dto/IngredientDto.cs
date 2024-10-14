using System;
using Cortside.AspNetCore.Common.Dtos;

namespace RecipeBox.Dto {
    public class IngredientDto : AuditableEntityDto {
        public int IngredientId { get; private set; }

        public Guid IngredientResourceId { get; private set; }

        public RecipeDto Recipe { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

    }
}
