// -----------------------------------------------------------------------
// <copyright file="EditSpeakerCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Commands.EditSpeakerCommand
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Command allowing the edition of a speaker.
    /// </summary>
    public class EditSpeakerCommand : IRequest<CosmosSpeaker?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditSpeakerCommand"/> class.
        /// </summary>
        /// <param name="speaker">Speaker to handle.</param>
        public EditSpeakerCommand(CosmosSpeaker speaker)
        {
            this.Speaker = speaker;
        }

        /// <summary>
        /// Gets or Sets the speaker to edit.
        /// </summary>
        public CosmosSpeaker Speaker { get; set; }
    }
}
