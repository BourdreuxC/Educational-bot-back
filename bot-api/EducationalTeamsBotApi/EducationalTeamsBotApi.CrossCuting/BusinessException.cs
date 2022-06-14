// -----------------------------------------------------------------------
// <copyright file="BusinessException.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.CrossCuting
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception used for the business case.
    /// </summary>
    public class BusinessException : Exception, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        /// <param name="message">Message de l'exception.</param>
        public BusinessException(string message)
            : base(message)
        {
        }
    }
}
