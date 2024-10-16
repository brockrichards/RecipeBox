using System;
using Cortside.AspNetCore.Common.Models;

namespace RecipeBox.WebApi.Models.Responses {
    /// <summary>
    /// An Item on an Recipe
    /// </summary>
    public class UnitModel : AuditableEntityModel {
        /// <summary>
        /// Gets or sets the order item identifier.
        /// </summary>
        /// <value>
        /// The order item identifier.
        /// </value>
        public int UnitId { get; set; }
        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public Guid ItemId { get; set; }
        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        /// <value>
        /// The sku.
        /// </value>
        public string Sku { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public decimal UnitPrice { get; set; }
    }
}

