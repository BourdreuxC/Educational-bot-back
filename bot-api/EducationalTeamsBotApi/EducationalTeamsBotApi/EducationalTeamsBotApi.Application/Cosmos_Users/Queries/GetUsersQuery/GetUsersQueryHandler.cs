// -----------------------------------------------------------------------
// <copyright file="GetUsersQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Cosmos_Users.Queries.GetUsersQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    ///  Handler for the query that will get users.
    /// </summary>
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<CosmosUser>>
    {
        /// <summary>
        /// cosmos service.
        /// </summary>
        private readonly IUserCosmosService userCosmosService;

        /// <summary>
        ///  Initializes a new instance of the <see cref="GetUsersQueryHandler"/> class.
        /// </summary>
        /// <param name="userCosmosService"> cosmos service.</param>
        public GetUsersQueryHandler(IUserCosmosService userCosmosService)
        {
            this.userCosmosService = userCosmosService;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
