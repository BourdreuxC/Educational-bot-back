// -----------------------------------------------------------------------
// <copyright file="IDomainEventService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Domain.Common;

    /// <summary>
    /// Interface domain event service.
    /// </summary>
    public interface IDomainEventService
    {
        /// <summary>
        /// Publish the event.
        /// </summary>
        /// <param name="domainEvent">Domain event.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task Publish(DomainEvent domainEvent);
    }
}
