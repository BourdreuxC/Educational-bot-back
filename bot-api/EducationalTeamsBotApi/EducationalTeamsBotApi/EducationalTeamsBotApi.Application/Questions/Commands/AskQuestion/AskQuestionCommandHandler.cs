// -----------------------------------------------------------------------
// <copyright file="AskQuestionCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Questions.Commands.AskQuestion
{
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Constants;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using RestSharp;

    /// <summary>
    /// Handler for the command that will interrogate te QnA service and insert in the Cosmos if no answer is provided.
    /// </summary>
    public class AskQuestionCommandHandler : IRequestHandler<AskQuestionCommand, QuestionOutputDto>
    {
        /// <summary>
        /// Question cosmos service to use.
        /// </summary>
        private readonly IQuestionCosmosService questionCosmosService;

        /// <summary>
        /// Configuration.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AskQuestionCommandHandler"/> class.
        /// </summary>
        /// <param name="questionCosmosService">injection.</param>
        /// <param name="configuration">Configuration.</param>
        public AskQuestionCommandHandler(IQuestionCosmosService questionCosmosService, IConfiguration configuration)
        {
            this.questionCosmosService = questionCosmosService;
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<QuestionOutputDto> Handle(AskQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = request.Message;

            // Insert question in database
            await this.questionCosmosService.InsertCosmosQuestions(new List<CosmosQuestion>
            {
                new CosmosQuestion(request.Message.MessageId, request.Message.Message, request.Message.UserId),
            });

            var result = new QuestionOutputDto
            {
                Answer = QnaMakerConstants.NotFoundResult,
                Mentions = new List<string>(),
            };

            if (question.Message != string.Empty)
            {
                // Get answer
                var answer = await this.questionCosmosService.GetQuestionAnswer(question);

                // If there is no answer, try to get speakers corresponding to tags
                if (answer.Id == -1)
                {
                    if (question.Tags.Any())
                    {
                        var speakers = await this.questionCosmosService.GetQuestionSpeakers(question);
                        if (speakers.Any())
                        {
                            result.Mentions = speakers.ToList();
                        }
                    }
                }
                else
                {
                    result.Answer = answer.Answer;
                }
            }

            if (Environment.GetEnvironmentVariable("LOGIC_APP_HTTP_TRIGGER") != null)
            {
                // Instantiate rest client
                var restClient = new RestClient(Environment.GetEnvironmentVariable("LOGIC_APP_HTTP_TRIGGER") ?? string.Empty);

                // Prepare request
                var restRequest = new RestRequest().AddBody(new LogicAppHttpBody { ChannelId = request.Message.ChannelId, MessageId = request.Message.MessageId, TeamId = request.Message.TeamId });

                // Trigger logic app
                await restClient.PostAsync(restRequest, CancellationToken.None);
            }

            return result;
        }
    }
}
