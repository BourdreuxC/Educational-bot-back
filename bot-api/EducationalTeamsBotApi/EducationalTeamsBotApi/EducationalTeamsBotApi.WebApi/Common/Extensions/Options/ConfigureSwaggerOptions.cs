// -----------------------------------------------------------------------
// <copyright file="ConfigureSwaggerOptions.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Common.Extensions.Options
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// Configuration class for Swagger.
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">Api version description provider.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        /// <inheritdoc/>
        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in this.provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, this.CreateInfoForApiVersion(description));
            }
        }

        /// <inheritdoc/>
        public void Configure(string name, SwaggerGenOptions options)
        {
            this.Configure(options);
        }

        /// <summary>
        /// Create the informations for the web api version.
        /// </summary>
        /// <param name="description">Version description of the api.</param>
        /// <returns>Returns a <see cref="OpenApiInfo"/>.</returns>
        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "EducationalTeamsBotApi.WebApi API",
                Version = description.ApiVersion.ToString(),
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
