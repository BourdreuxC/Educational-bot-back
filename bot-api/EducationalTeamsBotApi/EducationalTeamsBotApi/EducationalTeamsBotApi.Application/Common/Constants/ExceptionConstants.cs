// --------------------------------------------------------------------
// <copyright file="ExceptionConstants.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Constants
{
    /// <summary>
    /// Define exception constants.
    /// </summary>
    public static class ExceptionConstants
    {
        /// <summary>
        /// Validation exception type.
        /// </summary>
        public const string ValidationExceptionType = "https://tools.ietf.org/html/rfc7231#section-6.5.1";

        /// <summary>
        /// Not found exception type.
        /// </summary>
        public const string NotFoundExceptionType = "https://tools.ietf.org/html/rfc7231#section-6.5.4";

        /// <summary>
        /// Not found exception title.
        /// </summary>
        public const string NotFoundExceptionTitle = "The specified resource was not found.";

        /// <summary>
        /// Unauthorized exception type.
        /// </summary>
        public const string UnauthorizedExceptionType = "https://tools.ietf.org/html/rfc7235#section-3.1";

        /// <summary>
        /// Unauthorized exception title.
        /// </summary>
        public const string UnauthorizedExceptionTitle = "Unauthorized";

        /// <summary>
        /// Forbidden exception type.
        /// </summary>
        public const string ForbiddenExceptionType = "https://tools.ietf.org/html/rfc7231#section-6.5.3";

        /// <summary>
        /// Forbidden exception title.
        /// </summary>
        public const string ForbiddenExceptionTitle = "Forbidden";

        /// <summary>
        /// Unknown exception type.
        /// </summary>
        public const string UnknownExceptionType = "https://tools.ietf.org/html/rfc7231#section-6.5.3";

        /// <summary>
        /// Unknown exception title.
        /// </summary>
        public const string UnknownExceptionTitle = "An error occurred while processing your request.";

        /// <summary>
        /// Conflict exception type.
        /// </summary>
        public const string ConflictExceptionType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";

        /// <summary>
        /// Exception to show if there is a conflict.
        /// </summary>
        public const string ConflictExceptionTitle = "A conflict occured while trying to update database.";
    }
}
