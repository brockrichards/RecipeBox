using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Cortside.AspNetCore.Auditable.Entities;

namespace RecipeBox.Domain.Entities {
    public class RecipeIngredient : AuditableEntity {
        public RecipeIngredient() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeIngredientId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid RecipeIngredientResourceId { get; private set; }

        public Recipe Recipe { get; private set; }
        public Ingredient Ingredient { get; private set;}
        public decimal Quantity {  get; private set; }
    }
}
