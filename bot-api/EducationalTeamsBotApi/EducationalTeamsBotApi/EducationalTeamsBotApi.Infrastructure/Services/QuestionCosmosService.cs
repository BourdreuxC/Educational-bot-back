// -----------------------------------------------------------------------
// <copyright file="QuestionCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml;
    using EducationalTeamsBotApi.Application.Common.Constants;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
    using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Linq;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Class that will interact with the CosmosDB.
    /// </summary>
    public class QuestionCosmosService : IQuestionCosmosService
    {
        /// <summary>
        /// Cosmos client used in this service.
        /// </summary>
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Qna Maker client used in this service.
        /// </summary>
        private readonly QnAMakerClient qnaClient;

        /// <summary>
        /// Database used in this service.
        /// </summary>
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionCosmosService"/> class.
        /// </summary>
        /// <param name="configuration">Configruation to use.</param>
        public QuestionCosmosService(IConfiguration configuration)
        {
            var authoringKey = configuration[QnaMakerConstants.AuthoringKey];
            var authoringURL = configuration[QnaMakerConstants.AuthoringUrl];

            this.qnaClient = new QnAMakerClient(new ApiKeyServiceClientCredentials(authoringKey))
            {
                Endpoint = authoringURL,
            };

            var cosmosConString = Environment.GetEnvironmentVariable(DatabaseConstants.ConnectionString);

            var options = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway };

            this.cosmosClient = new CosmosClient(cosmosConString, options);

            this.database = this.cosmosClient.GetDatabase(DatabaseConstants.Database);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosQuestion>> InsertCosmosQuestions(List<CosmosQuestion> questions)
        {
            var container = this.database.GetContainer(DatabaseConstants.QuestionContainer);

            var insertedQuestions = new List<CosmosQuestion>();

            questions.ForEach(async question =>
            {
                // If question already exists, ignore it
                var existingQuestion = this.GetQuestion(question.Id);
                if (existingQuestion == null)
                {
                    insertedQuestions.Add(await container.CreateItemAsync(question));
                }
            });

            return Task.FromResult(insertedQuestions.AsEnumerable());
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> AddAnswersToQuestion(List<string> answerIds)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> AddAnswerToQuestion(string answerId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> AddTagsToQuestion(List<string> tagIds)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> AddTagToQuestion(string tagId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CosmosQuestion>> GetCosmosQuestions()
        {
            var container = this.database.GetContainer(DatabaseConstants.QuestionContainer);
            var questions = container.GetItemLinqQueryable<CosmosQuestion>();
            var iterator = questions.ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return Tools.ToIEnumerable(results.GetEnumerator());
        }

        /// <inheritdoc/>
        public async Task<CosmosQuestion> GetQuestion(string id)
        {
            var container = this.database.GetContainer(DatabaseConstants.QuestionContainer);
            var q = container.GetItemLinqQueryable<CosmosQuestion>();
            var iterator = q.Where(x => x.Id == id).ToFeedIterator();
            var result = await iterator.ReadNextAsync();
            return Tools.ToIEnumerable(result.GetEnumerator()).First();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> GetQuestionFromAnswer(string answerId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<string> QuestionAsked(Activity question)
        {
            var mention = new Mention
            {
                Mentioned = question.From,
                Text = $"<at>{XmlConvert.EncodeName(question.From.Name)}</at>",
            };

            var replyActivity = MessageFactory.Text($"Hello {mention.Text}.");
            replyActivity.Entities = new List<Entity> { mention };
            var turnContext = question.GetConversationReference();
            turnContext.GetContinuationActivity().CreateReply();
            question.CreateReply($"Hello {mention.Text}.");

            var queryingURL = "https://qnadiibot.azurewebsites.net";
            var endpointKey = await this.qnaClient.EndpointKeys.GetKeysAsync();
            var qnaRuntimeCli = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(endpointKey.PrimaryEndpointKey)) { RuntimeEndpoint = queryingURL };

            var response = await qnaRuntimeCli.Runtime.GenerateAnswerAsync("770b2be2-e25f-4963-b502-93961da9f88f", new QueryDTO { Question = question.Text });
            var res = response.Answers[0].Answer;
            if (response.Answers[0].Answer == "No good match found in KB.")
            {
                res = "Pas de solution mais je reste à l'écoute";
            }

            Console.WriteLine("Endpoint Response: {0}.", response.Answers[0].Answer);

            return res;
        }
    }
}
