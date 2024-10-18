using System;
using System.Linq;
using Cortside.AspNetCore.EntityFramework.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Enumerations;

namespace RecipeBox.Data.Searches {
    public class TagSearch : Search, ITagSearch {
        public Guid? TagResourceId { get; set; }

        public string Name { get; set; }
        public CategoryType? Category { get; set; }

        public IQueryable<Tag> Build(IQueryable<Tag> entities) {
            if (TagResourceId.HasValue) {
                entities = entities.Where(x => x.TagResourceId == TagResourceId);
            }
            entities = CategoryFilter(entities);
            entities = NameFilter(entities);

            return entities;
        }

        private IQueryable<Tag> NameFilter(IQueryable<Tag> entities) {
            if (!string.IsNullOrEmpty(Name)) {
                entities = entities.Where(x => x.Name.StartsWith(Name));
            }

            return entities;
        }

        private IQueryable<Tag> CategoryFilter(IQueryable<Tag> entities) {
            if (Category.HasValue) {
                entities = entities.Where(x => x.Category == Category);
            }

            return entities;
        }
    }
}

