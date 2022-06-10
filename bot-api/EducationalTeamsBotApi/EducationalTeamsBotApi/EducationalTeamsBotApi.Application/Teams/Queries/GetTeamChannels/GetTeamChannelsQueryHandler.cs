// -----------------------------------------------------------------------
// <copyright file="GetTeamChannelsQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Teams.Queries.GetTeamChannels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.Graph;

    /// <summary>
    /// Handler for <see cref="GetTeamChannelsQuery"/>.
    /// </summary>
    public class GetTeamChannelsQueryHandler : IRequestHandler<GetTeamChannelsQuery, IEnumerable<Channel>>
    {
        /// <summary>
        /// Graph service.
        /// </summary>
        private readonly IGraphService graphService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTeamChannelsQueryHandler"/> class.
        /// </summary>
        /// <param name="graphService">Graph service.</param>
        public GetTeamChannelsQueryHandler(IGraphService graphService)
        {
            this.graphService = graphService;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Channel>> Handle(GetTeamChannelsQuery request, CancellationToken cancellationToken)
        {
            return await this.graphService.GetTeamChannels(request.TeamId);
        }
    }
}
