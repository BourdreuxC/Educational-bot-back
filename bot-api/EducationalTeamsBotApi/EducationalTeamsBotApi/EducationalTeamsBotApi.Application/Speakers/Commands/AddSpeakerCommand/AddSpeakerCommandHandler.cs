// -----------------------------------------------------------------------
// <copyright file="AddSpeakerCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Commands.AddSpeakerCommand
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    public class AddSpeakerCommandHandler : IRequestHandler<AddSpeakerCommand, CosmosSpeaker?>
    {
        /// <summary>
        /// Speaker service.
        /// </summary>
        private readonly ISpeakerCosmosService speakerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddSpeakerCommand"/> class.
        /// </summary>
        /// <param name="speakerService">Service of the speakers.</param>
        public AddSpeakerCommandHandler(ISpeakerCosmosService speakerService)
        {
            this.speakerService = speakerService;
        }

        /// <inheritdoc/>
        public async Task<CosmosSpeaker?> Handle(AddSpeakerCommand request, CancellationToken cancellationToken)
        {
            return await this.speakerService.AddSpeaker(request.Speaker);
        }
    }
}
