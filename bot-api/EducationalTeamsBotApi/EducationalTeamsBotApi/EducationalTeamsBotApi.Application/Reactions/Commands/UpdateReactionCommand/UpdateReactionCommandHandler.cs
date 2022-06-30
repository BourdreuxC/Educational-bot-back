// ----------------------------------------------------------------
// <copyright file="UpdateReactionCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Reactions.Commands.UpdateReactionCommand
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler for <see cref="UpdateReactionCommand"/> command.
    /// </summary>
    public class UpdateReactionCommandHandler : IRequestHandler<UpdateReactionCommand, ReactionDto>
    {
        /// <summary>
        /// Cosmos service to use.
        /// </summary>
        private readonly IReactionCosmosService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateReactionCommandHandler"/> class.
        /// </summary>
        /// <param name="service">Cosmos service.</param>
        public UpdateReactionCommandHandler(IReactionCosmosService service)
        {
            this.service = service;
        }

        /// <inheritdoc/>
        public async Task<ReactionDto> Handle(UpdateReactionCommand request, CancellationToken cancellationToken)
        {
            var reaction = await this.service.EditReaction(new CosmosReaction(request.Id, request.Reaction, request.Value));

            return new ReactionDto
            {
                Id = reaction.Id,
                Reaction = reaction.Reaction,
                Value = reaction.Value,
            };
        }
    }
}
