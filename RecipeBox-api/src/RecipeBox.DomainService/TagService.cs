using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RecipeBox.Data.Repositories;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public class TagService : ITagService {
        private readonly ILogger<TagService> logger;
        private readonly ITagRepository tagRepository;

        public TagService(ILogger<TagService> logger, ITagRepository tagRepository) {
            this.logger = logger;
            this.tagRepository = tagRepository;
        }

        public Tag CreateTag(TagDto dto) {
            var tag = new Tag(dto.Name, dto.Category);
            using (logger.BeginScope(new Dictionary<string, object> { ["TagResourceId"] = tag.TagResourceId })) {
                logger.LogInformation("Created new tag");
                return tag;
            }
        }

        public Tag UpdateTag(Tag tag, TagDto dto) {
            using (logger.BeginScope(new Dictionary<string, object> { ["TagResourceId"] = tag.TagResourceId })) {
                tag.Update(dto.Name, dto.Category);
                logger.LogInformation("Updated tag");
                return tag;
            }
        }
    }
}

