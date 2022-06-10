// -----------------------------------------------------------------------
// <copyright file="AuditableEntity.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Domain.Common
{
    using System;

    /// <summary>
    /// Abstract class providing the properties allowing the tracking the modification of an entity.
    /// </summary>
    public abstract class AuditableEntity
    {
        /// <summary>
        /// Gets or sets the creation date of the <see cref="AuditableEntity"/>.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the user who create the <see cref="AuditableEntity"/>.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date of last modification of the <see cref="AuditableEntity"/>.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Gets or sets the user who made the last modification on the <see cref="AuditableEntity"/>.
        /// </summary>
        public string? LastModifiedBy { get; set; }
    }
}
