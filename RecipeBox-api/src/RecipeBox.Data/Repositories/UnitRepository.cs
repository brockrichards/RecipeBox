using System;
using System.Linq;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public class UnitRepository : IUnitRepository {
        private readonly IDatabaseContext context;

        public UnitRepository(IDatabaseContext context) {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> GetAsync(Guid id) {
            return await context.Units.FirstOrDefaultAsync(r => r.UnitResourceId == id).ConfigureAwait(false);
        }

        public async Task<Unit> AddAsync(Unit unit) {
            return (await context.Units.AddAsync(unit).ConfigureAwait(false)).Entity;
        }

        public void Update(Unit unit) {
            context.Units.Update(unit);
        }

        public void Delete(Unit unit) {
            context.Units.Remove(unit);
        }

        public async Task<PagedList<Unit>> SearchAsync(IUnitSearch model) {
            var units = (IQueryable<Unit>)context.Units
                .Include(x => x.CreatedSubject)
                .Include(x => x.LastModifiedSubject);

            units = model.Build(units);
            var result = new PagedList<Unit> {
                PageNumber = model.PageNumber,
                PageSize = model.PageSize,
                TotalItems = await units.CountAsync().ConfigureAwait(false),
                Items = [],
            };

            units = units.ToSortedQuery(model.Sort);
            result.Items = await units.ToPagedQuery(model.PageNumber, model.PageSize).ToListAsync().ConfigureAwait(false);

            return result;
        }
    }
}

