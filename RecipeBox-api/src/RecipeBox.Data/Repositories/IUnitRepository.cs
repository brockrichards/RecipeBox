using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public interface IUnitRepository {
        Task<PagedList<Unit>> SearchAsync(IUnitSearch model);
        Task<Unit> AddAsync(Unit unit);
        Task<Unit> GetAsync(Guid id);
        void Update(Unit unit);
        void Delete(Unit unit);
    }
}

