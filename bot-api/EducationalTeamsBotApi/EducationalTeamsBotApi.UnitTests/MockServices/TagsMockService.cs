

namespace EducationalTeamsBotApi.UnitTests.MockServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;
    /// <summary>
    /// Mock service for the tags.
    /// </summary>
    public class TagsMockService : ITagCosmosService
    {
        public List<CosmosTag> Tags { get; set; }

        public TagsMockService(List<CosmosTag> tags)
        {
            Tags = tags;
        }

        public Task<CosmosTag?> AddTag(List<string> variants)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> DeleteTag(string id)
        {
            var tag = Tags.FirstOrDefault(t => t.Id == id);
            if (tag == null)
            {
                throw new Exception("Tag not found");
            }
            Tags.Remove(tag);
            return default;
        }

        public Task<CosmosTag?> EditTagVariant(string id, string tagVariant)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CosmosTag> GetTags()
        {
            return Tags;
        }

        public async Task<CosmosTag?> GetTag(string id)
        {
            var tag = Tags.FirstOrDefault(t => t.Id == id);
            return await Task.FromResult(tag);
        }

        public Task<CosmosTag?> SearchTag(string tag)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<CosmosTag>> ITagCosmosService.GetTags()
        {
            throw new NotImplementedException();
        }

        public Task<CosmosTag?> AddTag(string id, List<string> variants)
        {
            throw new NotImplementedException();
        }
    }
}
