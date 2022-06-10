// -----------------------------------------------------------------------
// <copyright file="GetAllQuestionsQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Questions.Queries.GetAllQuestionsQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler for the query that will get speakers.
    /// </summary>
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, IEnumerable<CosmosQuestion>>
    {
        /// <summary>
        /// Question cosmos service to use.
        /// </summary>
        private readonly IQuestionCosmosService questionCosmosService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllQuestionsQueryHandler"/> class.
        /// </summary>
        /// <param name="questionCosmosService">Injection.</param>
        public GetAllQuestionsQueryHandler(IQuestionCosmosService questionCosmosService)
        {
            this.questionCosmosService = questionCosmosService;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosQuestion>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            return this.questionCosmosService.GetCosmosQuestions();
        }
    }
}
