// -----------------------------------------------------------------------
// <copyright file="TokenService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Services
{
    using EducationalTeamsBotApi.Application.Common.Interfaces;

    /// <summary>
    /// Class <see cref="TokenService"/> providing the current user in the http context.
    /// </summary>
    public class TokenService : ITokenService
    {
        /// <summary>
        /// Http context accessor.
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">Accessor of the http context.</param>
        public TokenService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        public string? Token => this.httpContextAccessor.HttpContext?.Request.Headers?.Authorization.ToString().Split(" ")[1];
    }
}
