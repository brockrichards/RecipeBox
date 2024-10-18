using System;
using Cortside.AspNetCore.EntityFramework.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Searches {
    public interface IUnitSearch : ISearch, ISearchBuilder<Unit> {
        Guid? UnitResourceId { get; set; }
    }
}

