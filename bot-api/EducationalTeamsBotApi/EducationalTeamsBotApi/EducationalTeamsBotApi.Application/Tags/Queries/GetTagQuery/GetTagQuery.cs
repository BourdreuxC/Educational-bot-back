// -----------------------------------------------------------------------
// <copyright file="GetTagQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Queries.GetTagQuery
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Query for the research of tag.
    /// </summary>
    public class GetTagQuery : IRequest<CosmosTag>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTagQuery"/> class.
        /// </summary>
        /// <param name="id">Tag identifier.</param>
        public GetTagQuery(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or Sets identifier of a tag.
        /// </summary>
        public string Id { get; set; }
    }
}
