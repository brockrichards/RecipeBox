using System;
using Cortside.AspNetCore.Common.Dtos;

namespace RecipeBox.Dto {
    public class UnitDto : AuditableEntityDto {
        public int UnitId { get; set; }

        public Guid UnitResourceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
