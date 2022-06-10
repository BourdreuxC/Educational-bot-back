// -----------------------------------------------------------------------
// <copyright file="Graph_SyncChannelMessagesCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Messages.Commands.Graph_SyncMessagesCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handles the <see cref="Graph_SyncChannelMessagesCommand"/>.
    /// </summary>
    public class Graph_SyncChannelMessagesCommandHandler : IRequestHandler<Graph_SyncChannelMessagesCommand, bool>
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
        /// Initializes a new instance of the <see cref="Graph_SyncChannelMessagesCommandHandler"/> class.
        /// </summary>
        /// <param name="graphService">Graph service.</param>
        /// <param name="questionCosmosService">Cosmos service.</param>
        public Graph_SyncChannelMessagesCommandHandler(IGraphService graphService, IQuestionCosmosService questionCosmosService)
        {
            this.graphService = graphService;
            this.questionCosmosService = questionCosmosService;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(Graph_SyncChannelMessagesCommand request, CancellationToken cancellationToken)
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
