// -----------------------------------------------------------------------
// <copyright file="GetSpeakerQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakerQuery
{
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Get a speaker.
    /// </summary>
    public class GetSpeakerQuery : IRequest<SpeakerDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSpeakerQuery"/> class.
        /// </summary>
        /// <param name="speakerId">Speaker identifier.</param>
        public GetSpeakerQuery(string speakerId)
        {
            this.SpeakerId = speakerId;
        }

        /// <summary>
        /// Gets or sets the id of the speaker.
        /// </summary>
        public string SpeakerId { get; set; }
    }
}
