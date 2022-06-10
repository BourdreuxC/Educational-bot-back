// -----------------------------------------------------------------------
// <copyright file="DomainEvent.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Domain.Common
{
    using System;

    /// <summary>
    /// Abstract class for a domain event.
    /// </summary>
    public abstract class DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEvent"/> class.
        /// </summary>
        protected DomainEvent()
        {
            this.DateOccurred = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets a value indicating if the event is published.
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Gets or sets the occured date of the event.
        /// </summary>
        public DateTimeOffset DateOccurred { get; protected set; }
    }
}
