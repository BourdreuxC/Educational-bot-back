// -----------------------------------------------------------------------
// <copyright file="CreateReactionCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Reactions.Commands.CreateReactionCommand
{
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler for <see cref="CreateReactionCommand"/> command.
    /// </summary>
    public class CreateReactionCommandHandler : IRequestHandler<CreateReactionCommand, ReactionDto>
    {
        /// <summary>
        /// Cosmos service to use.
        /// </summary>
        private readonly IReactionCosmosService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReactionCommandHandler"/> class.
        /// </summary>
        /// <param name="service">Cosmos service.</param>
        public CreateReactionCommandHandler(IReactionCosmosService service)
        {
            this.service = service;
        }

        /// <inheritdoc/>
        public async Task<ReactionDto> Handle(CreateReactionCommand request, CancellationToken cancellationToken)
        {
            var reaction = await this.service.CreateReaction(new CosmosReaction(request.Id ?? string.Empty, request.ReactionId, request.Value));
            return new ReactionDto
            {
                Id = reaction.Id,
                ReactionId = request.ReactionId,
                Value = request.Value,
            };
        }
    }
}
