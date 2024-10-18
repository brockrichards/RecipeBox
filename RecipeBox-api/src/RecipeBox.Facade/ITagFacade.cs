using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Dto;

namespace RecipeBox.Facade {
    public interface ITagFacade {
        Task<TagDto> CreateTagAsync(TagDto dto);
        Task<TagDto> GetTagAsync(Guid id);
        Task<PagedList<TagDto>> SearchTagsAsync(TagSearchDto search);
        Task<TagDto> UpdateTagAsync(Guid id, TagDto dto);
    }
}

