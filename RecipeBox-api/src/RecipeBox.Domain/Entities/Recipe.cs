using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cortside.AspNetCore.Auditable.Entities;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Domain.Entities {
    [Index(nameof(RecipeResourceId), IsUnique = true)]
    [Table("Recipe")]
    [Comment("Recipes")]
    public class Recipe : AuditableEntity {
        protected Recipe() {
            // Required by EF as it doesn't know about User
        }

        public Recipe(string name, string description, List<Tag> tags, List<Ingredient> ingredients) {
            RecipeResourceId = Guid.NewGuid();
            Title = name;
            Description = description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Primary Key")]
        public int RecipeId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid RecipeResourceId { get; private set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string ImageUrl { get; set; } // URL for the recipe's image

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<RecipeTag> RecipeTags { get; set; }
    }
}

