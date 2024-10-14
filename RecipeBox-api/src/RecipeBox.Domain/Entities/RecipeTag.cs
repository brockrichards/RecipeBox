using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Cortside.AspNetCore.Auditable.Entities;

namespace RecipeBox.Domain.Entities {
    public class RecipeTag : AuditableEntity {
        public RecipeTag() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeTagId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid RecipeTagResourceId { get; private set; }

        public Recipe Recipe { get; private set; }
        public Tag Tag { get; private set; }
    }
}
