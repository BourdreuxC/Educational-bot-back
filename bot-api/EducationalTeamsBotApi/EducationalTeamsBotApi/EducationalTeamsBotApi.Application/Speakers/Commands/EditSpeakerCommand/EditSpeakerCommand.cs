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
        /// Gets or Sets the speaker to edit.
        /// </summary>
        public CosmosSpeaker? Speaker { get; set; }
    }
}
