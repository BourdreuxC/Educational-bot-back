// -----------------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Infrastructure
{
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Infrastructure.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Graph;

    /// <summary>
    /// Static class providing an extension method to handle dependency injection for the infrastructure layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures and returns a service collection for the infrastructure layer.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>Returns a <see cref="ServiceCollection"/>.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<GraphServiceClient, GraphServiceClient>();
            services.AddScoped<IGraphService, GraphService>();
            services.AddScoped<ISpeakerCosmosService, SpeakerCosmosService>();
            services.AddScoped<IUserCosmosService, UserCosmosService>();
            services.AddScoped<IQuestionCosmosService, QuestionCosmosService>();
            services.AddScoped<IReactionCosmosService, ReactionCosmosService>();
            services.AddScoped<IAnswerCosmosService, AnswerCosmosService>();
            services.AddScoped<ITagCosmosService, TagCosmosService>();

            return services;
        }
    }
}