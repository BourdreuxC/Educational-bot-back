// -----------------------------------------------------------------------
// <copyright file="GetUsersQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Application.Cosmos_Users.Queries.GetUsersQuery
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Query allowing to get Cosmos users.
    /// </summary>
    public class GetUsersQuery : IRequest<IEnumerable<CosmosUser>>
    {
    }
}
