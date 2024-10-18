using System;
using Cortside.AspNetCore.Common.Dtos;
using RecipeBox.Enumerations;

namespace RecipeBox.Dto {
    public class TagDto : AuditableEntityDto {
        public int TagId { get; set; }

        public Guid TagResourceId { get; set; }

        public string Name { get; set; }

        public CategoryType Category { get; set; }
    }
}
