// -----------------------------------------------------------------------
// <copyright file="GetTeamChannelsQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Teams.Queries.GetTeamChannels
{
    using System.Collections.Generic;
    using MediatR;
    using Microsoft.Graph;

    /// <summary>
    /// Query parameters to get channels of a team.
    /// </summary>
    public class GetTeamChannelsQuery : IRequest<IEnumerable<Channel>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTeamChannelsQuery"/> class.
        /// </summary>
        /// <param name="teamId">Team identifier.</param>
        public GetTeamChannelsQuery(string teamId)
        {
            this.TeamId = teamId;
        }

        /// <summary>
        /// Gets or sets the team ID.
        /// </summary>
        public string TeamId { get; set; }
    }
}
