using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cortside.AspNetCore.Auditable.Entities;

namespace RecipeBox.Domain.Entities {
    public class Tag : AuditableEntity {
        protected Tag() { }

        public Tag(string name) {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; private set; }

        [StringLength(50)]
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

