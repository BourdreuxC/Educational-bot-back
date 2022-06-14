// -----------------------------------------------------------------------
// <copyright file="EnableSpeakerCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Commands.EnableSpeakerCommand
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Command allowing the choice of the status of a speaker.
    /// </summary>
    public class EnableSpeakerCommand : IRequest<CosmosSpeaker>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnableSpeakerCommand"/> class.
        /// </summary>
        /// <param name="id">Speaker identifier.</param>
        public EnableSpeakerCommand(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or Sets the identifier of the speaker.
        /// </summary>
        public string Id { get; set; }
    }
}
