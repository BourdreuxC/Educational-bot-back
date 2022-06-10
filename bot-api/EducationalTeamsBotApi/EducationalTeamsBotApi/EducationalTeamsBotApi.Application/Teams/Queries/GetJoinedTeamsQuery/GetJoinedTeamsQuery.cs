// -----------------------------------------------------------------------
// <copyright file="GetJoinedTeamsQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Teams.Queries.GetJoinedTeamsQuery
{
    using MediatR;
    using Microsoft.Graph;

    /// <summary>
    /// Query parameters to get joined teams.
    /// </summary>
    public class GetJoinedTeamsQuery : IRequest<IEnumerable<Team>>
    {
    }
}
