// -----------------------------------------------------------------------
// <copyright file="Result.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Models
{
    /// <summary>
    /// Class <see cref="Result"/>.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="succeeded">Succeeded.</param>
        /// <param name="errors">Errors.</param>
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            this.Succeeded = succeeded;
            this.Errors = errors.ToArray();
        }

        /// <summary>
        /// Gets or sets a value indicating whether it succeeded.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        public string[] Errors { get; set; }

        /// <summary>
        /// Returns a success Result.
        /// </summary>
        /// <returns>Returns a <see cref="Result"/>.</returns>
        public static Result Success()
        {
            return new Result(true, Array.Empty<string>());
        }

        /// <summary>
        /// Returns a failure Result.
        /// </summary>
        /// <param name="errors">Errors.</param>
        /// <returns>Returns a <see cref="Result"/>.</returns>
        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
}
