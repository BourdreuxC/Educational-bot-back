// -----------------------------------------------------------------------
// <copyright file="ITagCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Interface containing methods that call cosmosDB.
    /// </summary>
    public interface ITagCosmosService
    {
        /// <summary>
        /// Gets the list of tags of the cosmosDb.
        /// </summary>
        /// <returns>A list of tag objects.</returns>
        Task<IEnumerable<CosmosTag>> GetTags();

        /// <summary>
        /// Get a specific tag.
        /// </summary>
        /// <param name="id">Identifier of the tag.</param>
        /// <returns>Tag object.</returns>
        Task<CosmosTag?> GetTag(string id);

        /// <summary>
        /// Get a tag by searching a corresponding variant.
        /// </summary>
        /// <param name="tag">Variant to look for.</param>
        /// <returns>Tag object.</returns>
        Task<CosmosTag?> SearchTag(string tag);

        /// <summary>
        /// Insert a brand new tag in the CosmosDB.
        /// </summary>
        /// <param name="variants">New tag.</param>
        /// <returns>The inserted value.</returns>
        Task<CosmosTag?> AddTag(List<string> variants);

        /// <summary>
        /// Insert a new variant to an already existing tag.
        /// </summary>
        /// <param name="id">Identifier of the existing tag.</param>
        /// <param name="tagVariant">The new variant.</param>
        /// <returns>The edited object.</returns>
        Task<CosmosTag?> EditTagVariant(string id, string tagVariant);

        /// <summary>
        /// Insert a new variant to an already existing tag.
        /// </summary>
        /// <param name="id">Identifier of the tag to delete.</param>
        /// <returns>The edited object.</returns>
        Task<Unit> DeleteTag(string id);
    }
}
