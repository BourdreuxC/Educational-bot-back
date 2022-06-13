// -----------------------------------------------------------------------
// <copyright file="ReactionCosmosService.cs" company="DIIAGE">
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
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Linq;

    /// <summary>
    /// Class that will interact with the CosmosDB.
    /// </summary>
    public class ReactionCosmosService : IReactionCosmosService
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
        /// Initializes a new instance of the <see cref="ReactionCosmosService"/> class.
        /// </summary>
        public ReactionCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable(DatabaseConstants.ConnectionString);

            var options = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway };

            this.cosmosClient = new CosmosClient(cosmosConString, options);

            this.database = this.cosmosClient.GetDatabase(DatabaseConstants.Database);
        }

        /// <inheritdoc/>
        public async Task<CosmosReaction> CreateReaction(CosmosReaction reaction)
        {
            var container = this.database.GetContainer(DatabaseConstants.ReactionContainer);

            // Try to find a reaction with the same ReactionId.
            var r = container.GetItemLinqQueryable<CosmosReaction>();
            var iterator = r.Where(x => x.ReactionId == reaction.ReactionId).ToFeedIterator();
            var result = await iterator.ReadNextAsync();
            var existingReaction = Tools.ToIEnumerable(result.GetEnumerator()).FirstOrDefault();

            // If a reaction already exists, return it.
            if (existingReaction != null)
            {
                return existingReaction;
            }

            var id = Guid.NewGuid().ToString();

            reaction.Id = id;

            var createdReaction = await container.CreateItemAsync(reaction, new PartitionKey(id));

            return createdReaction;
        }

        /// <inheritdoc/>
        public async Task DeleteReaction(string id)
        {
            var container = this.database.GetContainer(DatabaseConstants.ReactionContainer);

            // Find the reaction to update.
            var reactionToDelete = await this.GetReaction(id);

            // If no reaction was found, set a new Id for the reaction.
            if (reactionToDelete != null)
            {
                await container.DeleteItemAsync<CosmosReaction>(id, new PartitionKey(id));
            }
        }

        /// <inheritdoc/>
        public async Task<CosmosReaction> EditReaction(CosmosReaction reaction)
        {
            var container = this.database.GetContainer(DatabaseConstants.ReactionContainer);

            // Find the reaction to update.
            var reactionToUpdate = await this.GetReaction(reaction.Id);

            // If no reaction was found, set a new Id for the reaction.
            if (reactionToUpdate == null)
            {
                reaction.Id = Guid.NewGuid().ToString();
            }

            // Upsert the reaction.
            var upsertedReaction = await container.UpsertItemAsync(reaction);

            return upsertedReaction;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CosmosReaction>> GetCosmosReactions()
        {
            var container = this.database.GetContainer(DatabaseConstants.ReactionContainer);
            var reactions = container.GetItemLinqQueryable<CosmosReaction>();
            var iterator = reactions.ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return Tools.ToIEnumerable(results.GetEnumerator());
        }

        /// <inheritdoc/>
        public async Task<CosmosReaction> GetReaction(string id)
        {
            var container = this.database.GetContainer(DatabaseConstants.ReactionContainer);
            var q = container.GetItemLinqQueryable<CosmosReaction>();
            var iterator = q.Where(x => x.Id == id).ToFeedIterator();
            var result = await iterator.ReadNextAsync();
            return Tools.ToIEnumerable(result.GetEnumerator()).First();
        }
    }
}
