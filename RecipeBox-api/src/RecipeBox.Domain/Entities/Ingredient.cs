using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cortside.AspNetCore.Auditable.Entities;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Domain.Entities {
    [Table("Ingredient")]
    [Comment("Ingredients that belong to an Recipe")]
    public class Ingredient : AuditableEntity {
        public Ingredient(string name) {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Primary Key")]
        public int IngredientId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid IngredientResourceId { get; private set; }

        /// <summary>
        /// FK to Recipe that the Ingredient belongs to
        /// </summary>
        /// <remarks>RecipeId added explicitly here so that it does not become nullable when inferred by relationships</remarks>
        [Comment("FK to Recipe that the Ingredient belongs to")]
        [ForeignKey(nameof(RecipeId))]
        public int RecipeId { get; private set; }

        /// <summary>
        /// Name of the ingredient
        /// </summary>
        [Comment("Name of the ingredient")]
        public string Name { get; private set; }

        /// <summary>
        /// Description of the ingredient
        /// </summary>
        [Comment("Description of the ingredient")]
        public string Description { get; private set; }
    }
}

