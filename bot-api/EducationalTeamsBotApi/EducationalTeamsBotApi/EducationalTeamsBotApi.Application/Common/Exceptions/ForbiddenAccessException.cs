// -----------------------------------------------------------------------
// <copyright file="ForbiddenAccessException.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Exceptions
{
    using System;

    /// <summary>
    /// Class exception for the forbidden exception.
    /// </summary>
    public class ForbiddenAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        public ForbiddenAccessException()
            : base()
        {
        }
    }
}
