using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cortside.AspNetCore.Auditable.Entities;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Enumerations;

namespace RecipeBox.Domain.Entities {
    [Table("Tag")]
    [Comment("Tags for organizing recipes")]
    public class Tag : AuditableEntity {
        protected Tag() {
            // Required by EF as it doesn't know about User
        }

        public Tag(string name, CategoryType category) {
            Name = name;
            Category = category;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid TagResourceId { get; private set; }

        [StringLength(50)]
        [Comment("Tag name")]
        public string Name { get; private set; }

        [StringLength(50)]
        [Comment("Tag category")]
        public CategoryType Category { get; private set; }

        /// <summary>
        /// Updates the specified tag.
        /// </summary>
        /// <param name="name">The tag name.</param>
        public void Update(string name, CategoryType category) {
            Name = name;
            Category = category;
        }
    }
}

