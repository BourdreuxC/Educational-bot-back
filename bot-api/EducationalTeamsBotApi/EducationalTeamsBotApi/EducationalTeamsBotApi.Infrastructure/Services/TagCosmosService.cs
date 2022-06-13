// -----------------------------------------------------------------------
// <copyright file="TagCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Constants;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Linq;

    /// <summary>
    /// Class that will interact with the CosmosDB.
    /// </summary>
    public class TagCosmosService : ITagCosmosService
    {
        /// <summary>
        /// Cosmos client used in this service.
        /// </summary>
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Database used in this service.
        /// </summary>
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagCosmosService"/> class.
        /// </summary>
        public TagCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable(DatabaseConstants.ConnectionString);
            var options = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway };
            this.cosmosClient = new CosmosClient(cosmosConString, options);
            this.database = this.cosmosClient.GetDatabase(DatabaseConstants.Database);
        }

        /// <inheritdoc/>
        public Task<CosmosTag?> AddTag(List<string> variants)
        {
            var container = this.database.GetContainer(DatabaseConstants.TagContainer);
            if (!variants.Any())
            {
                throw new Exception("No variants");
            }

            var id = Guid.NewGuid().ToString();
            container.CreateItemAsync<CosmosTag>(new CosmosTag { Id = id, Variants = variants }, new PartitionKey(id));

            return this.SearchTag(variants.First());
        }

        /// <inheritdoc/>
        public Task<CosmosTag?> EditTagVariant(string id, string tagVariant)
        {
            var container = this.database.GetContainer(DatabaseConstants.TagContainer);

            var existingTag = this.GetTag(id).Result;

            if (existingTag != null)
            {
                var tags = existingTag.Variants.ToList();

                if (tags.Contains(tagVariant))
                {
                    tags.Remove(tagVariant);
                }
                else
                {
                    tags.Add(tagVariant);
                }

                existingTag.Variants = tags;
                container.ReplaceItemAsync(existingTag, existingTag.Id);
            }

            return this.GetTag(id);
        }

        /// <inheritdoc/>
        public async Task<CosmosTag?> GetTag(string id)
        {
            var container = this.database.GetContainer(DatabaseConstants.TagContainer);

            var q = container.GetItemLinqQueryable<CosmosTag>();
            var iterator = q.Where(t => t.Id == id).ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return results.FirstOrDefault<CosmosTag>();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CosmosTag>> GetTags()
        {
            var container = this.database.GetContainer(DatabaseConstants.TagContainer);
            var tags = container.GetItemLinqQueryable<CosmosTag>();
            var iterator = tags.ToFeedIterator();

            var results = await iterator.ReadNextAsync();
            return Tools.ToIEnumerable<CosmosTag>(results.GetEnumerator());
        }

        /// <inheritdoc/>
        public async Task<CosmosTag?> SearchTag(string tag)
        {
            var container = this.database.GetContainer(DatabaseConstants.TagContainer);

            var q = container.GetItemLinqQueryable<CosmosTag>();
            var iterator = q.Where(t => t.Variants.Contains(tag)).ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return results.FirstOrDefault<CosmosTag>();
        }

        /// <inheritdoc/>
        public async Task<Unit> DeleteTag(string id)
        {
            var containerTag = this.database.GetContainer(DatabaseConstants.TagContainer);
            var containerSpeaker = this.database.GetContainer(DatabaseConstants.SpeakerContainer);

            await containerTag.DeleteItemAsync<CosmosTag>(id, new PartitionKey(id));
            return default(Unit);
        }
    }
}