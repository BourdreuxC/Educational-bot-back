// -----------------------------------------------------------------------
// <copyright file="GetSpeakersQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakersQuery
{
    using EducationalTeamsBotApi.Application.Common.Models;
    using EducationalTeamsBotApi.Application.Dto;
    using MediatR;

    /// <summary>
    /// Get the list of speakers.
    /// </summary>
    public class GetSpeakersQuery : IRequest<PaginatedList<SpeakerDto>>
    {
    }
}
