// -----------------------------------------------------------------------
// <copyright file="GetAllQuestionsQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Questions.Queries.GetAllQuestionsQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Common.Models;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Pagination.Queries;
    using EducationalTeamsBotApi.CrossCuting;
    using global::Application.Common.Mappings;
    using MediatR;

    /// <summary>
    /// Handler for the query that will get speakers.
    /// </summary>
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetWithPaginationQuery<QuestionDto>, PaginatedList<QuestionDto>>
    {
        /// <summary>
        /// Question cosmos service to use.
        /// </summary>
        private readonly IQuestionCosmosService questionCosmosService;

        /// <summary>
        /// IMapper instance.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllQuestionsQueryHandler"/> class.
        /// </summary>
        /// <param name="questionCosmosService">Injection.</param>
        /// <param name="mapper">Mapper to use.</param>
        public GetAllQuestionsQueryHandler(IQuestionCosmosService questionCosmosService, IMapper mapper)
        {
            this.questionCosmosService = questionCosmosService;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<PaginatedList<QuestionDto>> Handle(GetWithPaginationQuery<QuestionDto> request, CancellationToken cancellationToken)
        {
            var questions = await this.questionCosmosService.GetCosmosQuestions();

            var projectedQuestions = questions
                .Where(q => request.Search == string.Empty || q.Content.ToLower().Contains(request.Search.ToLower()))
                .ProjectTo<QuestionDto>(this.mapper.ConfigurationProvider);

            var result = new List<QuestionDto>();
            foreach (var question in projectedQuestions)
            {
                if (question.Id == null)
                {
                    throw new BusinessException("The questions identifier are corrupted");
                }

                var answer = "No response available yet.";
                var bestAnswer = this.questionCosmosService.GetBestAnswerFromQuestion(question.Id).Result;

                if (bestAnswer != null)
                {
                    answer = bestAnswer.Content;
                }

                question.BestAnswer = answer;
                result.Add(question);
            }

            var paginatedQuestions = await result.AsQueryable().PaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedQuestions;
        }
    }
}
