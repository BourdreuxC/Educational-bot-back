// -----------------------------------------------------------------------
// <copyright file="IAnswerCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using EducationalTeamsBotApi.Domain.Entities;

    /// <summary>
    /// Interface containing methods that call cosmosDB.
    /// </summary>
    public interface IAnswerCosmosService
    {
        /// <summary>
        /// Gets the list of answers.
        /// </summary>
        /// <returns>A list of <see cref="CosmosAnswer"/>.</returns>
        Task<IEnumerable<CosmosAnswer>> GetAnswers();

        /// <summary>
        /// Create à new answer.
        /// </summary>
        /// <param name="answer">New answer object.</param>
        /// <returns>The inserted answer object.</returns>
        Task<CosmosAnswer> CreateAnswer(CosmosAnswer answer);

        /// <summary>
        /// Update the answer informations.
        /// </summary>
        /// <param name="answer">the answer to update.</param>
        /// <returns>the updated answer.</returns>
        Task<CosmosAnswer> EditAnswer(CosmosAnswer answer);
    }
}
