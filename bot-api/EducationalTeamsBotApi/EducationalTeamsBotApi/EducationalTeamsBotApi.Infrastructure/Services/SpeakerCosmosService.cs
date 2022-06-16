// -----------------------------------------------------------------------
// <copyright file="SpeakerCosmosService.cs" company="DIIAGE">
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
    public class SpeakerCosmosService : ISpeakerCosmosService
    {
        /// <summary>
        /// Cosmos client used in this service.
        /// </summary>
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Container used in this service.
        /// </summary>
        private readonly Container container;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeakerCosmosService"/> class.
        /// </summary>
        public SpeakerCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable(DatabaseConstants.ConnectionString);
            var options = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway };
            this.cosmosClient = new CosmosClient(cosmosConString, options);
            var database = this.cosmosClient.GetDatabase(DatabaseConstants.Database);
            this.container = database.GetContainer(DatabaseConstants.SpeakerContainer);
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker?> AddSpeaker(CosmosSpeaker speaker)
        {
            this.container.CreateItemAsync<CosmosSpeaker>(speaker, new PartitionKey(speaker.Id));

            return this.GetSpeaker(speaker.Id);
        }

        /// <inheritdoc/>
        public async Task<Unit> DeleteSpeaker(string id)
        {
            await this.container.DeleteItemAsync<CosmosSpeaker>(id, new PartitionKey(id));

            return default;
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker?> EditSpeaker(CosmosSpeaker speaker)
        {
            this.container.ReplaceItemAsync(speaker, speaker.Id);

            return this.GetSpeaker(speaker.Id);
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> EnableSpeaker(string id)
        {
            var existingSpeaker = this.GetSpeaker(id).Result;

            if (existingSpeaker == null)
            {
                throw new BusinessException("Speaker not found");
            }

            if (!existingSpeaker.Enabled.HasValue || existingSpeaker.Enabled == false)
            {
                existingSpeaker.Enabled = true;
            }
            else
            {
                existingSpeaker.Enabled = false;
            }

            this.container.ReplaceItemAsync(existingSpeaker, existingSpeaker.Id);

            return this.GetSpeaker(id);
        }

        /// <inheritdoc/>
        public async Task<IQueryable<CosmosSpeaker>> GetCosmosSpeakers()
        {
            var speakers = this.container.GetItemLinqQueryable<CosmosSpeaker>();
            var iterator = speakers.ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results.AsQueryable();
        }

        /// <inheritdoc/>
        public async Task<CosmosSpeaker?> GetSpeaker(string id)
        {
            var q = this.container.GetItemLinqQueryable<CosmosSpeaker>();
            var iterator = q.Where(x => x.Id == id).ToFeedIterator();
            var result = await iterator.ReadNextAsync();
            return result.FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<Unit> RemoveTagFromSpeakers(string id)
        {
            var containerSpeakerQueryable = this.container.GetItemLinqQueryable<CosmosSpeaker>();
            var iterator = containerSpeakerQueryable.Where(s => s.Tags.Contains(id)).ToFeedIterator();
            var speakersWithTag = await iterator.ReadNextAsync();

            IEnumerable<string> tagList;
            CosmosSpeaker speaker;
            foreach (var item in speakersWithTag)
            {
                speaker = await this.GetSpeaker(item.Id);
                tagList = item.Tags.Where(t => t != id);
                speaker.Tags = tagList;
                await this.EditSpeaker(speaker);
            }

            return default;
        }
    }
}
