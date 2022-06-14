// -----------------------------------------------------------------------
// <copyright file="GetReactionQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Reactions.Queries.GetReactionQuery
{
    using AutoMapper;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Dto;
    using MediatR;

    /// <summary>
    /// Handler for <see cref="GetReactionQuery"/> query.
    /// </summary>
    public class GetReactionQueryHandler : IRequestHandler<GetReactionQuery, ReactionDto>
    {
        /// <summary>
        /// Cosmos service to use.
        /// </summary>
        private readonly IReactionCosmosService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetReactionQueryHandler"/> class.
        /// </summary>
        /// <param name="service">Cosmos service.</param>
        public GetReactionQueryHandler(IReactionCosmosService service)
        {
            this.service = service;
        }

        /// <inheritdoc/>
        public async Task<ReactionDto> Handle(GetReactionQuery request, CancellationToken cancellationToken)
        {
            var reaction = await this.service.GetReaction(request.Id);

            return new ReactionDto
            {
                Id = reaction.Id,
                ReactionId = reaction.Id,
                Value = reaction.Value,
            };
        }
    }
}
