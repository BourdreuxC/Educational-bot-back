// -----------------------------------------------------------------------
// <copyright file="IApplicationDbContext.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface context for the application.
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Persists the data.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Returns a <see cref="Task{int}"/>.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
