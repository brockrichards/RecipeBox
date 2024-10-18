using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public interface ITagService {
        Tag CreateTag(TagDto dto);
        Tag UpdateTag(Tag tag, TagDto dto);
    }
}

