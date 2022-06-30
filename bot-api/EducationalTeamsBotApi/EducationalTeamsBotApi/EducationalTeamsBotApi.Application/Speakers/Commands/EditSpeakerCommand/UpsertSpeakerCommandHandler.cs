// -----------------------------------------------------------------------
// <copyright file="UpsertSpeakerCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Commands.EditSpeakerCommand
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Command handler of the speaker insertion and edition.
    /// </summary>
    public class UpsertSpeakerCommandHandler : IRequestHandler<UpsertSpeakerCommand, CosmosSpeaker?>
    {
        /// <summary>
        /// Speaker service.
        /// </summary>
        private readonly ISpeakerCosmosService speakerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertSpeakerCommandHandler"/> class.
        /// </summary>
        /// <param name="speakerService">Service of the speakers.</param>
        public UpsertSpeakerCommandHandler(ISpeakerCosmosService speakerService)
        {
            this.speakerService = speakerService;
        }

        /// <inheritdoc/>
        public async Task<CosmosSpeaker?> Handle(UpsertSpeakerCommand request, CancellationToken cancellationToken)
        {
            var speaker = this.speakerService.GetSpeaker(request.Speaker.Id);

            return speaker.Result == null ? await this.speakerService.AddSpeaker(request.Speaker) : await this.speakerService.EditSpeaker(request.Speaker);
        }
    }
}
