// -----------------------------------------------------------------------
// <copyright file="EnableSpeakerCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Commands.EnableSpeakerCommand
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Command handler allowing the speaker enabling.
    /// </summary>
    public class EnableSpeakerCommandHandler : IRequestHandler<EnableSpeakerCommand, CosmosSpeaker?>
    {
        /// <summary>
        /// Speaker service.
        /// </summary>
        private readonly ISpeakerCosmosService speakerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnableSpeakerCommandHandler"/> class.
        /// </summary>
        /// <param name="speakerService">Service of the speakers.</param>
        public EnableSpeakerCommandHandler(ISpeakerCosmosService speakerService)
        {
            this.speakerService = speakerService;
        }

        /// <inheritdoc/>
        public async Task<CosmosSpeaker?> Handle(EnableSpeakerCommand request, CancellationToken cancellationToken)
        {
            return await this.speakerService.EnableSpeaker(request.Id);
        }
    }
}
