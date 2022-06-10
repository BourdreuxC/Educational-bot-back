// -----------------------------------------------------------------------
// <copyright file="IReactionCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using EducationalTeamsBotApi.Domain.Entities;

    /// <summary>
    /// Interface containing methods that call cosmosDB.
    /// </summary>
    public interface IReactionCosmosService
    {
        /// <summary>
        /// Get all reactions.
        /// </summary>
        /// <returns>List of reactions.</returns>
        Task<IEnumerable<CosmosReaction>> GetCosmosReactions();

        /// <summary>
        /// Get a scpecific reaction.
        /// </summary>
        /// <param name="id">Identifier of the reaction.</param>
        /// <returns>The reaction object.</returns>
        Task<CosmosReaction> GetReaction(string id);

        /// <summary>
        /// Edit the reactions informations.
        /// </summary>
        /// <param name="reaction">the modified reaction.</param>
        /// <returns>the new object.</returns>
        Task<CosmosReaction> EditReaction(CosmosReaction reaction);

        /// <summary>
        /// Create a new reaction element.
        /// </summary>
        /// <param name="reaction">The new reaction.</param>
        /// <returns>The new object.</returns>
        Task<CosmosReaction> CreateReaction(CosmosReaction reaction);

        /// <summary>
        /// Delete a reaction.
        /// </summary>
        /// <param name="id">Id of the reaction to delete.</param>
        /// <returns>void.</returns>
        Task DeleteReaction(string id);
    }
}
