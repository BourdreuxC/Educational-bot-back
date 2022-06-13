//-----------------------------------------------------------------------
// <copyright file="GetWithPaginationQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Pagination.Queries
{
    using EducationalTeamsBotApi.Application.Common.Models;
    using MediatR;

    /// <summary>
    /// Generic query with pagination. 
    /// </summary>
    /// <typeparam name="T">Entity that will be treated.</typeparam>
    public class GetWithPaginationQuery<T> : IRequest<PaginatedList<T>>
    {
        /// <summary>
        /// Gets or sets the PageNumber.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the PageSize.
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
