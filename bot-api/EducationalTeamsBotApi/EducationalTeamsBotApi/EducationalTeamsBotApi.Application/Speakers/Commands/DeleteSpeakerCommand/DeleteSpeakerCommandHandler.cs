// -----------------------------------------------------------------------
// <copyright file="DeleteSpeakerCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Commands.DeleteSpeakerCommand
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Command handler allowing the deletion of speakers.
    /// </summary>
    public class DeleteSpeakerCommandHandler : IRequestHandler<DeleteSpeakerCommand, Unit>
    {
        /// <summary>
        /// Speaker service.
        /// </summary>
        private readonly ISpeakerCosmosService speakerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSpeakerCommandHandler"/> class.
        /// </summary>
        /// <param name="speakerService">Service of the speakers.</param>
        public DeleteSpeakerCommandHandler(ISpeakerCosmosService speakerService)
        {
            this.speakerService = speakerService;
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(DeleteSpeakerCommand request, CancellationToken cancellationToken)
        {
            return await this.speakerService.DeleteSpeaker(request.Id);
        }
    }
}
