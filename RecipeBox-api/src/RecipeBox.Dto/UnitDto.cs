using System;
using Cortside.AspNetCore.Common.Dtos;

namespace RecipeBox.Dto {
    public class UnitDto : AuditableEntityDto {
        public int UnitId { get; private set; }

        public Guid UnitResourceId { get; private set; }

        public string Name { get; private set; }
    }
}
