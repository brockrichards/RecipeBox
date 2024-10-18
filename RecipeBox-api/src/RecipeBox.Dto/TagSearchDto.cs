using System;
using RecipeBox.Enumerations;

namespace RecipeBox.Dto {
    public class TagSearchDto {
        public int TagId { get; set; }
        public Guid? TagResourceId { get; set; }

        public string Name { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Sort { get; set; }
        public CategoryType Category { get; set; }
    }
}
