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
        /// Initializes a new instance of the <see cref="AskQuestionCommandHandler"/> class.
        /// </summary>
        /// <param name="questionCosmosService">injection.</param>
        public AskQuestionCommandHandler(IQuestionCosmosService questionCosmosService)
        {
            this.questionCosmosService = questionCosmosService;
        }

        /// <inheritdoc/>
        public async Task<QuestionOutputDto> Handle(AskQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = request.Message;

            // Insert question in database
            await this.questionCosmosService.InsertCosmosQuestions(new List<CosmosQuestion>
            {
                new CosmosQuestion(Guid.NewGuid().ToString(), request.Message.Message, request.Message.UserId),
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

            return result;
        }
    }
}
