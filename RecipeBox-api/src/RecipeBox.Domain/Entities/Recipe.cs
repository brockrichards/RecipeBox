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

        public Recipe(string title, string description, bool isPublic, string imageUrl) {
            RecipeResourceId = Guid.NewGuid();
            Title = title;
            Description = description;
            IsPublic = isPublic;
            ImageUrl = imageUrl;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Primary Key")]
        public int RecipeId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid RecipeResourceId { get; private set; }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsPublic { get; private set; }
        public string ImageUrl { get; private set; } // URL for the recipe's image

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<RecipeTag> RecipeTags { get; set; }

        public void AddIngredients(List<Ingredient> ingredients) {
            throw new NotImplementedException();
        }

        public void AddTags(List<Tag> tags) {
            throw new NotImplementedException();
        }

        public void Update(string title, string description, bool isPublic, string imageUrl) {
            Title = title;
            Description = description;
            IsPublic = isPublic;
            ImageUrl = imageUrl;
        }
    }
}

