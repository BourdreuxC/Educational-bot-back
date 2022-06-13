// -----------------------------------------------------------------------
// <copyright file="DomainEventNotification.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Models
{
    using EducationalTeamsBotApi.Domain.Common;
    using MediatR;

    /// <summary>
    /// Class event domain notification.
    /// </summary>
    /// <typeparam name="TDomainEvent">Type of the Domain Event.</typeparam>
    public class DomainEventNotification<TDomainEvent> : INotification
        where TDomainEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventNotification{TDomainEvent}"/> class.
        /// </summary>
        /// <param name="domainEvent">Domain event.</param>
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            this.DomainEvent = domainEvent;
        }

        /// <summary>
        /// Gets the domain event.
        /// </summary>
        public TDomainEvent DomainEvent { get; }
    }
}
