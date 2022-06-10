// -----------------------------------------------------------------------
// <copyright file="GetMessagesQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Application.Messages.Queries.GetMessagesQuery
{
    using MediatR;
    using Microsoft.Graph;

    /// <summary>
    /// Query allowing to get messages.
    /// </summary>
    public class GetMessagesQuery : IRequest<IEnumerable<SearchEntity>>
    {
    }
}
