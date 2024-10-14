using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cortside.AspNetCore.Auditable.Entities;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Domain.Entities {
    public class Unit : AuditableEntity {
        protected Unit() { }

        public Unit(string name) {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnitId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid UnitResourceId { get; private set; }

        [StringLength(50)]
        [Comment("Unit name")]
        public string Name { get; private set; }

        /// <summary>
        /// Updates the specified tag.
        /// </summary>
        /// <param name="name">The tag name.</param>
        internal void Update(string name) {
            Name = name;
        }
    }
}

