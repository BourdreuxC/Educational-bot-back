// -----------------------------------------------------------------------
// <copyright file="DeleteReactionCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Reactions.Commands.DeleteReactionCommand
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handler for <see cref="DeleteReactionCommand"/> command.
    /// </summary>
    public class DeleteReactionCommandHandler : IRequestHandler<DeleteReactionCommand, bool>
    {
        /// <summary>
        /// Cosmos service to use.
        /// </summary>
        private readonly IReactionCosmosService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteReactionCommandHandler"/> class.
        /// </summary>
        /// <param name="service">Cosmos service.</param>
        public DeleteReactionCommandHandler(IReactionCosmosService service)
        {
            this.service = service;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(DeleteReactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await this.service.DeleteReaction(request.Id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
