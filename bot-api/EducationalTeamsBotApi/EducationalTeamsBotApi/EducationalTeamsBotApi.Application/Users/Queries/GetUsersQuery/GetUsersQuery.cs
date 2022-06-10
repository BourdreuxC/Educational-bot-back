// -----------------------------------------------------------------------
// <copyright file="GetUsersQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Application.Users.Queries.GetUsersQuery
{
    using MediatR;
    using Microsoft.Graph;

    /// <summary>
    /// Query allowing to get users.
    /// </summary>
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
