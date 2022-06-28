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
    /// Command allowing the edition and insertion of a speaker.
    /// </summary>
    public class UpsertSpeakerCommand : IRequest<CosmosSpeaker?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertSpeakerCommand"/> class.
        /// </summary>
        /// <param name="speaker">Speaker to handle.</param>
        public UpsertSpeakerCommand(CosmosSpeaker speaker)
        {
            this.Speaker = speaker;
        }

        /// <summary>
        /// Gets or Sets the speaker to edit.
        /// </summary>
        public CosmosSpeaker Speaker { get; set; }
    }
}
