using System;
using System.Linq;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public class TagRepository : ITagRepository {
        private readonly IDatabaseContext context;

        public TagRepository(IDatabaseContext context) {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Tag> GetAsync(Guid id) {
            return await context.Tags.FirstOrDefaultAsync(r => r.TagResourceId == id).ConfigureAwait(false);
        }

        public async Task<Tag> AddAsync(Tag tag) {
            return (await context.Tags.AddAsync(tag).ConfigureAwait(false)).Entity;
        }

        public void Update(Tag tag) {
            context.Tags.Update(tag);
        }

        public void Delete(Tag tag) {
            context.Tags.Remove(tag);
        }

        public async Task<PagedList<Tag>> SearchAsync(ITagSearch model) {
            var tags = (IQueryable<Tag>)context.Tags
                .Include(x => x.CreatedSubject)
                .Include(x => x.LastModifiedSubject);

            tags = model.Build(tags);
            var result = new PagedList<Tag> {
                PageNumber = model.PageNumber,
                PageSize = model.PageSize,
                TotalItems = await tags.CountAsync().ConfigureAwait(false),
                Items = [],
            };

            tags = tags.ToSortedQuery(model.Sort);
            result.Items = await tags.ToPagedQuery(model.PageNumber, model.PageSize).ToListAsync().ConfigureAwait(false);

            return result;
        }
    }
}

