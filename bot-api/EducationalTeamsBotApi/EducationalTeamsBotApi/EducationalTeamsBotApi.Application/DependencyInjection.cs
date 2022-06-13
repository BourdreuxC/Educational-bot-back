// -----------------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application
{
    using System.Reflection;
    using EducationalTeamsBotApi.Application.Common.Behaviours;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Static class providing an extension method to handle dependency injection for the application layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures and returns a service collection for the infrastructure layer.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>Returns a <see cref="ServiceCollection"/>.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            return services;
        }
    }
}
