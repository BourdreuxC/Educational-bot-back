// -----------------------------------------------------------------------
// <copyright file="ISpeakerCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Interface containing methods that call cosmosDB.
    /// </summary>
    public interface ISpeakerCosmosService
    {
        /// <summary>
        /// Get a list of all the speakers.
        /// </summary>
        /// <returns>Enumerable of speaker objects.</returns>
        Task<IEnumerable<CosmosSpeaker>> GetCosmosSpeakers();

        /// <summary>
        /// Get a specific speaker.
        /// </summary>
        /// <param name="id">identifier of the speaker.</param>
        /// <returns>A speaker object.</returns>
        Task<CosmosSpeaker?> GetSpeaker(string id);

        /// <summary>
        /// Update the speacker informations.
        /// </summary>
        /// <param name="speaker">the changed speaker.</param>
        /// <returns>Updated speaker object.</returns>
        Task<CosmosSpeaker?> EditSpeaker(CosmosSpeaker speaker);

        /// <summary>
        /// Disable the speaker.
        /// </summary>
        /// <param name="id">identifier of the speaker to disable.</param>
        /// <returns>The result object of the update.</returns>
        Task<Unit> DeleteSpeaker(string id);

        /// <summary>
        /// Enable a disabled speaker.
        /// </summary>
        /// <param name="id">identifier of the speaker to enable.</param>
        /// <returns>The result of the update.</returns>
        Task<CosmosSpeaker> EnableSpeaker(string id);

        /// <summary>
        /// Create a new speaker.
        /// </summary>
        /// <param name="speaker">Speaker to insert.</param>
        /// <returns>The newly created speaker object.</returns>
        Task<CosmosSpeaker> AddSpeaker(CosmosSpeaker speaker);

        /// <summary>
        /// Remove a tag from every speaker.
        /// </summary>
        /// <param name="id">Identifier of the tag to remove.</param>
        /// <returns>Empty Unit.</returns>
        Task<Unit> RemoveTagFromSpeakers(string id);
    }
}
