// -----------------------------------------------------------------------
// <copyright file="CurrentUserService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Services
{
    using System.Security.Claims;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Class <see cref="CurrentUserService"/> providing the current user in the http context.
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        /// <summary>
        /// Http context accessor.
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentUserService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">Accessor of the http context.</param>
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Gets the current user id.
        /// </summary>
        public string UserId => this.httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
