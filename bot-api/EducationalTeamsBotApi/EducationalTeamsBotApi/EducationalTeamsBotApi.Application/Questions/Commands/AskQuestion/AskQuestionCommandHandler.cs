// -----------------------------------------------------------------------
// <copyright file="AskQuestionCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Questions.Commands.AskQuestion
{
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handler for the command that will interrogate te QnA service and insert in the Cosmos if no answer is provided.
    /// </summary>
    public class AskQuestionCommandHandler : IRequestHandler<AskQuestionCommand, string>
    {
        /// <summary>
        /// Question cosmos service to use.
        /// </summary>
        private readonly IQuestionCosmosService questionCosmosService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AskQuestionCommandHandler"/> class.
        /// </summary>
        /// <param name="questionCosmosService">injection.</param>
        public AskQuestionCommandHandler(IQuestionCosmosService questionCosmosService)
        {
            this.questionCosmosService = questionCosmosService;
        }

        /// <inheritdoc/>
        public Task<string> Handle(AskQuestionCommand request, CancellationToken cancellationToken)
        {
            return this.questionCosmosService.QuestionAsked(request.Activity);
        }
    }
}
