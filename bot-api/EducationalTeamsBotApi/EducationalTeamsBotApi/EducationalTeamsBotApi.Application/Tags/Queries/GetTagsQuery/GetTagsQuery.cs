// -----------------------------------------------------------------------
// <copyright file="GetTagsQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Queries.GetTagsQuery
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Query allowing to get tags.
    /// </summary>
    public class GetTagsQuery : IRequest<IEnumerable<CosmosTag>>
    {

        /// <summary>
        /// Gets or Sets the name of the tag.
        /// </summary>
        public string Name { get; set; }
    }
}
