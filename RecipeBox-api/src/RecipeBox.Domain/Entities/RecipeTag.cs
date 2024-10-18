using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Domain.Entities {
    public class RecipeTag {
        protected RecipeTag() {
            // Required by EF as it doesn't know about User
        }
        public RecipeTag(Recipe recipe, Tag tag) {
            Recipe = recipe;
            Tag = tag;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeTagId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid RecipeTagResourceId { get; private set; }

        public Recipe Recipe { get; private set; }
        public Tag Tag { get; private set; }
    }
}
