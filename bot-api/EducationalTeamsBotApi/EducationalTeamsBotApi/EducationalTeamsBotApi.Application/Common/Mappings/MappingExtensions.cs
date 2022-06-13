// -----------------------------------------------------------------------
// <copyright file="MappingExtensions.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Application.Common.Mappings
{
    using System.Linq;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Models;

    /// <summary>
    /// Mapping extensions class.
    /// </summary>
    public static class MappingExtensions
    {
        /// <summary>
        /// Creates an asynchronous paginated list.
        /// </summary>
        /// <typeparam name="TDestination">Destination of the list.</typeparam>
        /// <param name="queryable">Base list of items.</param>
        /// <param name="pageNumber">Index of the current page.</param>
        /// <param name="pageSize">Size of the current page.</param>
        /// <returns>An asynchronous paginated list.</returns>
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);
    }
}
