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
    using EducationalTeamsBotApi.CrossCuting;
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
        private readonly CosmosClient? cosmosClient;

        /// <summary>
        /// Database used in this service.
        /// </summary>
        private readonly Database database;

        /// <summary>
        /// Container used in this service.
        /// </summary>
        private readonly Container container;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagCosmosService"/> class.
        /// </summary>
        public TagCosmosService(ICosmosLinqQuery myCosmosLinqQuery)
        {
            var cosmosConString = Environment.GetEnvironmentVariable(DatabaseConstants.ConnectionString);
            var options = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway };
            this.cosmosClient = new CosmosClient(cosmosConString, options);
            this.database = this.cosmosClient.GetDatabase(DatabaseConstants.Database);
            this.container = this.database.GetContainer(DatabaseConstants.TagContainer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TagCosmosService"/> class dedicated to unit testing.
        /// </summary>
        /// <param name="testContainer">Mock container used in the unit testing.</param>
        /// <param name="testDatabase">Mock database used in the unit testing.</param>
        public TagCosmosService(Database testDatabase, Container testContainer)
        {
            this.cosmosClient = null;
            this.database = testDatabase;
            this.container = testContainer;
        }

        /// <inheritdoc/>
        public Task<CosmosTag?> AddTag(List<string> variants)
        {
            if (!variants.Any())
            {
                throw new BusinessException("No variants");
            }

            var id = Guid.NewGuid().ToString();
            this.container.CreateItemAsync(new CosmosTag(id, variants), new PartitionKey(id));

            return this.SearchTag(variants.First());
        }

        /// <inheritdoc/>
        public Task<CosmosTag?> EditTagVariant(string id, string tagVariant)
        {
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
                this.container.ReplaceItemAsync(existingTag, existingTag.Id);
            }

            return this.GetTag(id);
        }

        /// <inheritdoc/>
        public async Task<CosmosTag?> GetTag(string id)
        {
            var q = this.container.GetItemLinqQueryable<CosmosTag>();
            var iterator = q.Where(t => t.Id == id).ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return results.FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<IQueryable<CosmosTag>> GetTags()
        {
            var tags = this.container.GetItemLinqQueryable<CosmosTag>();
            var iterator = tags.ToFeedIterator();

            var results = await iterator.ReadNextAsync();
            return results.AsQueryable();
        }

        /// <inheritdoc/>
        public async Task<CosmosTag?> SearchTag(string tag)
        {
            var q = this.container.GetItemLinqQueryable<CosmosTag>();
            var iterator = q.Where(t => t.Variants.Contains(tag)).ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return results.FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<Unit> DeleteTag(string id)
        {
            await this.container.DeleteItemAsync<CosmosTag>(id, new PartitionKey(id));
            return default;
        }
    }
}