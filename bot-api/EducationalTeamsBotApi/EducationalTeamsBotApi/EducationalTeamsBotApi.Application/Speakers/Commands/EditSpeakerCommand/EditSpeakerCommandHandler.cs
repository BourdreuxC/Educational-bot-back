// -----------------------------------------------------------------------
// <copyright file="EditSpeakerCommandHandler.cs" company="DIIAGE">
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
    /// Command handler of the speaker edition.
    /// </summary>
    public class EditSpeakerCommandHandler : IRequestHandler<EditSpeakerCommand, CosmosSpeaker?>
    {
        /// <summary>
        /// Speaker service.
        /// </summary>
        private readonly ISpeakerCosmosService speakerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditSpeakerCommandHandler"/> class.
        /// </summary>
        /// <param name="speakerService">Service of the speakers.</param>
        public EditSpeakerCommandHandler(ISpeakerCosmosService speakerService)
        {
            this.speakerService = speakerService;
        }

        /// <inheritdoc/>
        public async Task<CosmosSpeaker?> Handle(EditSpeakerCommand request, CancellationToken cancellationToken)
        {
            return await this.speakerService.EditSpeaker(request.Speaker);
        }
    }
}
