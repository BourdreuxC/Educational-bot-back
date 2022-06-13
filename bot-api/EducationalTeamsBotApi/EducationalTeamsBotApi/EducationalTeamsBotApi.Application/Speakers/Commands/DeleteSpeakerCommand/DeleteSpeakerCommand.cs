﻿// -----------------------------------------------------------------------
// <copyright file="DeleteSpeakerCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Commands.DeleteSpeakerCommand
{
    using MediatR;

    /// <summary>
    /// Command fot the suppression of speakers.
    /// </summary>
    public class DeleteSpeakerCommand : IRequest<Unit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSpeakerCommand"/> class.
        /// </summary>
        /// <param name="id">Speaker identifier.</param>
        public DeleteSpeakerCommand(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or Sets the identifier of the speaker.
        /// </summary>
        public string Id { get; set; }
    }
}
