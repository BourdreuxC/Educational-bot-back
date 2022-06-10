// -----------------------------------------------------------------------
// <copyright file="ConflictException.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Exceptions
{
    using System;

    /// <summary>
    /// Class exception for the conflict exception.
    /// </summary>
    public class ConflictException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictException"/> class.
        /// </summary>
        public ConflictException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictException"/> class.
        /// </summary>
        /// <param name="message">Message to print.</param>
        public ConflictException(string message)
            : base(message)
        {
        }
    }
}
