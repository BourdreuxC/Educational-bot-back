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
        /// Database used in this service.
        /// </summary>
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeakerCosmosService"/> class.
        /// </summary>
        public SpeakerCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable(DatabaseConstants.ConnectionString);
            var options = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway };
            this.cosmosClient = new CosmosClient(cosmosConString, options);
            this.database = this.cosmosClient.GetDatabase(DatabaseConstants.Database);
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> AddSpeaker(CosmosSpeaker speaker)
        {
            var container = this.database.GetContainer(DatabaseConstants.SpeakerContainer);

            var id = Guid.NewGuid().ToString();
            speaker.Id = id;
            container.CreateItemAsync<CosmosSpeaker>(speaker, new PartitionKey(id));

            return this.GetSpeaker(speaker.Id);
        }

        /// <inheritdoc/>
        public async Task<Unit> DeleteSpeaker(string id)
        {
            var container = this.database.GetContainer(DatabaseConstants.SpeakerContainer);

            await container.DeleteItemAsync<CosmosSpeaker>(id, new PartitionKey(id));

            return default(Unit);
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker?> EditSpeaker(CosmosSpeaker speaker)
        {
            var container = this.database.GetContainer(DatabaseConstants.SpeakerContainer);
            var existingSpeaker = this.GetSpeaker(speaker.Id).Result;

            if (existingSpeaker == null)
            {
                throw new Exception("Speaker not found");
            }

            container.ReplaceItemAsync(speaker, speaker.Id);

            return this.GetSpeaker(speaker.Id);
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> EnableSpeaker(string id)
        {
            var container = this.database.GetContainer(DatabaseConstants.SpeakerContainer);
            var existingSpeaker = this.GetSpeaker(id).Result;

            if (existingSpeaker == null)
            {
                throw new Exception("Speaker not found");
            }

            if (!existingSpeaker.Enabled.HasValue || existingSpeaker.Enabled == false)
            {
                existingSpeaker.Enabled = true;
            }
            else
            {
                existingSpeaker.Enabled = false;
            }

            container.ReplaceItemAsync(existingSpeaker, existingSpeaker.Id);

            return this.GetSpeaker(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CosmosSpeaker>> GetCosmosSpeakers()
        {
            var container = this.database.GetContainer(DatabaseConstants.SpeakerContainer);
            var speakers = container.GetItemLinqQueryable<CosmosSpeaker>();
            var iterator = speakers.ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return Tools.ToIEnumerable(results.GetEnumerator());
        }

        /// <inheritdoc/>
        public async Task<CosmosSpeaker?> GetSpeaker(string id)
        {
            var container = this.database.GetContainer(DatabaseConstants.SpeakerContainer);
            var q = container.GetItemLinqQueryable<CosmosSpeaker>();
            var iterator = q.Where(x => x.Id == id).ToFeedIterator();
            var result = await iterator.ReadNextAsync();
            return Tools.ToIEnumerable(result.GetEnumerator()).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<Unit> RemoveTagFromSpeakers(string id)
        {
            var container = this.database.GetContainer(DatabaseConstants.SpeakerContainer);
            var containerSpeakerQueryable = container.GetItemLinqQueryable<CosmosSpeaker>();
            var iterator = containerSpeakerQueryable.Where(s => s.Tags.Contains(id)).ToFeedIterator();
            var SpeakersWithTag = await iterator.ReadNextAsync();

            IEnumerable<string> tagList;
            CosmosSpeaker speaker;
            foreach (var item in SpeakersWithTag)
            {
                speaker = await this.GetSpeaker(item.Id);
                tagList = item.Tags.Where(t => t != id);
                speaker.Tags = tagList;
                this.EditSpeaker(speaker);
            }

            return default(Unit);
        }
    }
}
