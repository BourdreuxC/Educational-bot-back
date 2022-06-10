// -----------------------------------------------------------------------
// <copyright file="GetTagByNameQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Queries.GetTagByNameQuery
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Query allowing to get a tag by it's name.
    /// </summary>
    public class GetTagByNameQuery : IRequest<CosmosTag>
    {
        /// <summary>
        /// Gets or sets name of the tag.
        /// </summary>
        public string? Name { get; set; }
    }
}
