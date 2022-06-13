﻿// -----------------------------------------------------------------------
// <copyright file="GetMessagesQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Application.Messages.Queries.GetMessagesQuery
{
    using System;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.Graph;

    /// <summary>
    /// Handler for the query that will get messages.
    /// </summary>
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, IEnumerable<SearchEntity>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMessagesQueryHandler"/> class.
        /// </summary>
        public GetMessagesQueryHandler()
        {
        }

        /// <inheritdoc/>
        public Task<IEnumerable<SearchEntity>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<SearchEntity>().AsEnumerable());
        }
    }
}
