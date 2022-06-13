// -----------------------------------------------------------------------
// <copyright file="UserCosmosService.cs" company="DIIAGE">
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
    public class UserCosmosService : IUserCosmosService
    {
        /// <summary>
        /// Cosmos client to use in the service.
        /// </summary>
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCosmosService"/> class.
        /// </summary>
        public UserCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable(DatabaseConstants.ConnectionString);
            this.cosmosClient = new CosmosClient(cosmosConString);
        }

        /// <inheritdoc/>
        public Task<CosmosUser> AddUser(CosmosUser user)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosUser> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosUser>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
