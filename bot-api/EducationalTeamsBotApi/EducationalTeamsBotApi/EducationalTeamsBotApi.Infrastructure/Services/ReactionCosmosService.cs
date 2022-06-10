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
            this.cosmosClient = new CosmosClient(cosmosConString);

            this.database = this.cosmosClient.GetDatabase(DatabaseConstants.Database);
        }

        /// <inheritdoc/>
        public Task<CosmosReaction> CreateReaction(CosmosReaction reaction)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DeleteReaction(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosReaction> EditReaction(CosmosReaction reaction)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosReaction>> GetCosmosReactions()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosReaction> GetReaction(string id)
        {
            throw new NotImplementedException();
        }
    }
}
