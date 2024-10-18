#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using RecipeBox.Enumerations;

namespace RecipeBox.WebApi.Models.Requests {
    public class TagSearchModel {
        public string Name { get; set; }

        public CategoryType Category { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Sort { get; set; }
    }
}
