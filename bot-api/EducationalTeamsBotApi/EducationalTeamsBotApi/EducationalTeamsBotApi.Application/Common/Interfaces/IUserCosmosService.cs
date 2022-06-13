// -----------------------------------------------------------------------
// <copyright file="IUserCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Domain.Entities;

    /// <summary>
    /// Class that will interact with the CosmosDB.
    /// </summary>
    public interface IUserCosmosService
    {
        /// <summary>
        /// Gets the list of users of the cosmosDb.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        Task<IEnumerable<CosmosUser>> GetUsers();

        /// <summary>
        /// Get a specific user (useless).
        /// </summary>
        /// <param name="id">identifier of the user.</param>
        /// <returns>User object.</returns>
        Task<CosmosUser> GetUser(string id);

        /// <summary>
        /// Add a new user in the cosmos.
        /// </summary>
        /// <param name="user">User to add.</param>
        /// <returns>the created entity.</returns>
        Task<CosmosUser> AddUser(CosmosUser user);
    }
}
