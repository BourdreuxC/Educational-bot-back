// -----------------------------------------------------------------------
// <copyright file="DomainEventService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Common.Models;
    using EducationalTeamsBotApi.Domain.Common;
    using MediatR;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class service for the domain events.
    /// </summary>
    public class DomainEventService : IDomainEventService
    {
        /// <summary>
        /// Logger for the service.
        /// </summary>
        private readonly ILogger<DomainEventService> logger;

        /// <summary>
        /// Mediator.
        /// </summary>
        private readonly IPublisher mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="mediator">Mediator.</param>
        public DomainEventService(ILogger<DomainEventService> logger, IPublisher mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        /// Publish the event in mediator.
        /// </summary>
        /// <param name="domainEvent">Domain event to publish.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        public async Task Publish(DomainEvent domainEvent)
        {
            this.logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);

            await this.mediator.Publish(this.GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        /// <summary>
        /// Gets the notification for a domain event.
        /// </summary>
        /// <param name="domainEvent">Domain evetn.</param>
        /// <returns>Returns a <see cref="INotification"/>.</returns>
        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification)Activator.CreateInstance(typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
        }
    }
}