// -----------------------------------------------------------------------
// <copyright file="AddSpeakerCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Commands.AddSpeakerCommand
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Command for the creation of speaker.
    /// </summary>
    public class AddSpeakerCommand : IRequest<CosmosSpeaker>
    {
        /// <summary>
        /// Gets or Sets the speaker to create.
        /// </summary>
        public CosmosSpeaker? Speaker { get; set; }
    }
}
