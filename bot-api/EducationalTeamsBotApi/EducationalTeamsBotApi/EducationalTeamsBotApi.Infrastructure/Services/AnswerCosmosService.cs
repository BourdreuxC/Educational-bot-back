// -----------------------------------------------------------------------
// <copyright file="AnswerCosmosService.cs" company="DIIAGE">
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
    public class AnswerCosmosService : IAnswerCosmosService
    {
        /// <summary>
        /// Cosmos client to use in the service.
        /// </summary>
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Database used in this service.
        /// </summary>
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerCosmosService"/> class.
        /// </summary>
        public AnswerCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable(DatabaseConstants.ConnectionString);
            this.cosmosClient = new CosmosClient(cosmosConString);

            this.database = this.cosmosClient.GetDatabase(DatabaseConstants.Database);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CosmosAnswer>> GetAnswers()
        {
            var container = this.database.GetContainer(DatabaseConstants.QuestionContainer);

            var answers = container.GetItemLinqQueryable<CosmosAnswer>();
            var iterator = answers.ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return Tools.ToIEnumerable(results.GetEnumerator());
        }

        /// <inheritdoc/>
        public Task<CosmosAnswer> CreateAnswer(CosmosAnswer answer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosAnswer> EditAnswer(CosmosAnswer answer)
        {
            throw new NotImplementedException();
        }
    }
}
