// -----------------------------------------------------------------------
// <copyright file="PerformanceBehaviour.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Behaviours
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class Behaviour for the performances.
    /// </summary>
    /// <typeparam name="TRequest">Type of the request.</typeparam>
    /// <typeparam name="TResponse">Type of the response.</typeparam>
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;
        private readonly ICurrentUserService currentUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceBehaviour{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="currentUserService">Current user service.</param>
        /// <param name="identityService">Identity service.</param>
        public PerformanceBehaviour(
            ILogger<TRequest> logger,
            ICurrentUserService currentUserService)
        {
            this.timer = new Stopwatch();

            this.logger = logger;
            this.currentUserService = currentUserService;
        }

        /// <summary>
        /// Handle the Behaviour.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="next">Request handler delegate.</param>
        /// <returns>Returns a <see cref="Task{TResponse}"/>.</returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            this.timer.Start();

            var response = await next();

            this.timer.Stop();

            var elapsedMilliseconds = this.timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = this.currentUserService.UserId ?? string.Empty;

                this.logger.LogWarning(
                    "Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                    requestName,
                    elapsedMilliseconds,
                    userId,
                    request);
            }

            return response;
        }
    }
}
