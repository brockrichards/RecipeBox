using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RecipeBox.Data.Repositories;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public class UnitService : IUnitService {
        private readonly ILogger<UnitService> logger;
        private readonly IUnitRepository ingredientRepository;

        public UnitService(ILogger<UnitService> logger, IUnitRepository ingredientRepository) {
            this.logger = logger;
            this.ingredientRepository = ingredientRepository;
        }

        public Unit CreateUnit(UnitDto dto) {
            var ingredient = new Unit(dto.Name, dto.Description);
            using (logger.BeginScope(new Dictionary<string, object> { ["UnitResourceId"] = ingredient.UnitResourceId })) {
                logger.LogInformation("Created new ingredient");
                return ingredient;
            }
        }

        public Unit UpdateUnit(Unit ingredient, UnitDto dto) {
            using (logger.BeginScope(new Dictionary<string, object> { ["UnitResourceId"] = ingredient.UnitResourceId })) {
                ingredient.Update(dto.Name, dto.Description);
                logger.LogInformation("Updated ingredient");
                return ingredient;
            }
        }
    }
}

