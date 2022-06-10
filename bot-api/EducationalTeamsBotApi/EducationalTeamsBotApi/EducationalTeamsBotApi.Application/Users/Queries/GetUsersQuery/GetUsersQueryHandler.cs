// -----------------------------------------------------------------------
// <copyright file="GetUsersQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Application.Users.Queries.GetUsersQuery
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.Graph;

    /// <summary>
    /// Handler for the query that will get users.
    /// </summary>
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        /// <summary>
        /// Graph service.
        /// </summary>
        private readonly IGraphService graphService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersQueryHandler"/> class.
        /// </summary>
        /// <param name="graphService">Graph service.</param>
        public GetUsersQueryHandler(IGraphService graphService)
        {
            this.graphService = graphService;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return this.graphService.GetUsers();
        }
    }
}
