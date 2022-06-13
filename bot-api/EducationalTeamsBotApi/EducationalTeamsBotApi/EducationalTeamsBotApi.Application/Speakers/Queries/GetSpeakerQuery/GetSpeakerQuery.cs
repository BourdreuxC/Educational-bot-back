// -----------------------------------------------------------------------
// <copyright file="GetSpeakerQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakerQuery
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Get a speaker.
    /// </summary>
    public class GetSpeakerQuery : IRequest<CosmosSpeaker>
    {
        /// <summary>
        /// Gets or sets the id of the speaker.
        /// </summary>

        public string? SpeakerId { get; set; }
    }
}
