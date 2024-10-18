using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public interface ITagRepository {
        Task<PagedList<Tag>> SearchAsync(ITagSearch model);
        Task<Tag> AddAsync(Tag tag);
        Task<Tag> GetAsync(Guid id);
        void Update(Tag tag);
        void Delete(Tag tag);
    }
}

