using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cortside.AspNetCore.Auditable.Entities;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Domain.Entities {
    [Table("Unit")]
    [Comment("Units of measurement for Ingredients")]
    public class Unit : AuditableEntity {
        protected Unit() {
            // Required by EF as it doesn't know about User
        }

        public Unit(string name, string description) {
            Name = name;
            Description = description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnitId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid UnitResourceId { get; private set; }

        [StringLength(50)]
        [Comment("Unit name")]
        public string Name { get; private set; }

        [StringLength(250)]
        [Comment("Unit description")]
        public string Description { get; private set; }
        /// <summary>
        /// Updates the specified unit.
        /// </summary>
        /// <param name="name">The unit name.</param>
        public void Update(string name, string description) {
            Name = name;
            Description = description;
        }
    }
}

