// -----------------------------------------------------------------------
// <copyright file="GetJoinedTeamsQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Teams.Queries.GetJoinedTeamsQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.Graph;

    /// <summary>
    /// Handler for <see cref="GetJoinedTeamsQuery"/>.
    /// </summary>
    public class GetJoinedTeamsQueryHandler : IRequestHandler<GetJoinedTeamsQuery, IEnumerable<Team>>
    {
        /// <summary>
        /// Graph service.
        /// </summary>
        private readonly IGraphService graphService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetJoinedTeamsQueryHandler"/> class.
        /// </summary>
        /// <param name="graphService">Graph service.</param>
        public GetJoinedTeamsQueryHandler(IGraphService graphService)
        {
            this.graphService = graphService;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Team>> Handle(GetJoinedTeamsQuery request, CancellationToken cancellationToken)
        {
            return await this.graphService.GetJoinedTeams();
        }
    }
}
