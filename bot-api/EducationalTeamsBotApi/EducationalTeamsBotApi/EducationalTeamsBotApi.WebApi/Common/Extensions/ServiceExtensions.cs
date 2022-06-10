// -----------------------------------------------------------------------
// <copyright file="ServiceExtensions.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Common.Extensions
{
    using EducationalTeamsBotApi.WebApi.Common.Extensions.Options;

    /// <summary>
    /// Extension class for the services.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add the service for the support of the versioning of the web api for Swagger.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>Returns the <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSwaggerVersioningSupport(this IServiceCollection services)
        {
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }
    }
}
