//-----------------------------------------------------------------------
// <copyright file="PaginatedList.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Linq;

    /// <summary>
    /// Paginated list item.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public class PaginatedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
        /// </summary>
        /// <param name="items">Wanted items.</param>
        /// <param name="count">Wanted count.</param>
        /// <param name="pageIndex">Current page.</param>
        /// <param name="pageSize">Page size.</param>
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.TotalCount = count;
            this.Items = items;
        }

        /// <summary>
        /// Gets the Items.
        /// </summary>
        public List<T> Items { get; }

        /// <summary>
        /// Gets the PageIndex.
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Gets the TotalPages.
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Gets the TotalCount.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Gets a value indicating whether there is a previous page.
        /// </summary>
        public bool HasPreviousPage => this.PageIndex > 1;

        /// <summary>
        /// Gets a value indicating whether there is a next page.
        /// </summary>
        public bool HasNextPage => this.PageIndex < this.TotalPages;

        /// <summary>
        /// Creates the paginated list.
        /// </summary>
        /// <param name="source">Source data.</param>
        /// <param name="pageIndex">Index of the current page.</param>
        /// <param name="pageSize">Size of the current page.</param>
        /// <returns>A paginated list.</returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
