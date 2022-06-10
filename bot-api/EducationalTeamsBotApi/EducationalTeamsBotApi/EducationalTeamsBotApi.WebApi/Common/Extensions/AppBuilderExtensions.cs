// -----------------------------------------------------------------------
// <copyright file="AppBuilderExtensions.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Common.Extensions
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;

    /// <summary>
    /// Extension class providing methods for the app builder.
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Add support of the versioning of the web api for Swagger.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <returns>Returns the <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseSwaggerWithVersioning(this IApplicationBuilder app)
        {
            IServiceProvider services = app.ApplicationServices;
            var provider = services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                for (int i = 0; i < provider.ApiVersionDescriptions.Count; i++)
                {
                    ApiVersionDescription? description = provider.ApiVersionDescriptions[i];
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }
    }
}
