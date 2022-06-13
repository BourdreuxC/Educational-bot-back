// -----------------------------------------------------------------------
// <copyright file="DeleteQuestionCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Questions.Commands.DeleteQuestionCommand
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handler for <see cref="DeleteQuestionCommand"/> command.
    /// </summary>
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
    {
        /// <summary>
        /// Cosmos service to use.
        /// </summary>
        private readonly IQuestionCosmosService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteQuestionCommandHandler"/> class.
        /// </summary>
        /// <param name="service">Cosmos service.</param>
        public DeleteQuestionCommandHandler(IQuestionCosmosService service)
        {
            this.service = service;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await this.service.DeleteQuestion(request.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
