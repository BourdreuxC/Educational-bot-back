// -----------------------------------------------------------------------
// <copyright file="ForbiddenAccessException.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class exception for the forbidden exception.
    /// </summary>
    [Serializable]
    public class ForbiddenAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        public ForbiddenAccessException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected ForbiddenAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
