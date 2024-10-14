using System;
using Cortside.AspNetCore.Common.Dtos;

namespace RecipeBox.Dto {
    public class RecipeTagDto : AuditableEntityDto {
        public int RecipeTagId { get; set; }

        public Guid RecipeTagResourceId { get; set; }

        public RecipeDto Recipe { get; set; }
        public TagDto Tag { get; set; }
    }
}
