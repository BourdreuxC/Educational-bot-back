// -----------------------------------------------------------------------
// <copyright file="GetReactionQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Reactions.Queries.GetReactionQuery
{
    using EducationalTeamsBotApi.Application.Dto;
    using MediatR;

    /// <summary>
    /// Query allowing to get a reaction thanks to its identifier.
    /// </summary>
    public class GetReactionQuery : IRequest<ReactionDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetReactionQuery"/> class.
        /// </summary>
        /// <param name="id">Reaction identifier.</param>
        public GetReactionQuery(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }
    }
}
