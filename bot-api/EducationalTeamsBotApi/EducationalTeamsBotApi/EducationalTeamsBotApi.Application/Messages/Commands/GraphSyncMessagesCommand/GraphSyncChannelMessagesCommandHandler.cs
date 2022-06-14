// -----------------------------------------------------------------------
// <copyright file="GraphSyncChannelMessagesCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Messages.Commands.GraphSyncMessagesCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handles the <see cref="GraphSyncChannelMessagesCommand"/>.
    /// </summary>
    public class GraphSyncChannelMessagesCommandHandler : IRequestHandler<GraphSyncChannelMessagesCommand, bool>
    {
        /// <summary>
        /// Graph service.
        /// </summary>
        private readonly IGraphService graphService;

        /// <summary>
        /// Cosmos service.
        /// </summary>
        private readonly IQuestionCosmosService questionCosmosService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphSyncChannelMessagesCommandHandler"/> class.
        /// </summary>
        /// <param name="graphService">Graph service.</param>
        /// <param name="questionCosmosService">Cosmos service.</param>
        public GraphSyncChannelMessagesCommandHandler(IGraphService graphService, IQuestionCosmosService questionCosmosService)
        {
            this.graphService = graphService;
            this.questionCosmosService = questionCosmosService;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(GraphSyncChannelMessagesCommand request, CancellationToken cancellationToken)
        {
            // Get graph channel messages.
            var messages = await this.graphService.GetChannelMessages(request.TeamId, request.ChannelId);

            // Format messages as a database object.
            var cosmosQuestions = messages.Select(x => new CosmosQuestion(x.Id, x.Body.Content, x.From.User.Id)).ToList();

            // Insert rows into database.
            var insertedQuestions = await this.questionCosmosService.InsertCosmosQuestions(cosmosQuestions);

            return insertedQuestions.Any();
        }
    }
}
