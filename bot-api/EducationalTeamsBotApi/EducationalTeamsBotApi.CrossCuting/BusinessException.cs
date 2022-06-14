// -----------------------------------------------------------------------
// <copyright file="BusinessException.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.CrossCuting
{
    using System;

    /// <summary>
    /// Exception used for the business case.
    /// </summary>
    [Serializable]
    public class BusinessException : Exception
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
