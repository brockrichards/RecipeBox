using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cortside.AspNetCore.Auditable.Entities;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Domain.Entities {
    [Table("Ingredient")]
    [Comment("Ingredients that belong to an Recipe")]
    public class Ingredient : AuditableEntity {
        protected Ingredient() {
            // Required by EF as it doesn't know about User
        }

        public Ingredient(string name, string description) {
            Name = name;
            Description = description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Primary Key")]
        public int IngredientId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid IngredientResourceId { get; private set; }

        /// <summary>
        /// Name of the ingredient
        /// </summary>
        [Comment("Name of the ingredient")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the ingredient
        /// </summary>
        [Comment("Description of the ingredient")]
        public string Description { get; set; }
    }
}

