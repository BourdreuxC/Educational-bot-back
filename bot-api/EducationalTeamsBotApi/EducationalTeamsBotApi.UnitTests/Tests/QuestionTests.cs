// -----------------------------------------------------------------------
// <copyright file="QuestionTests.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.UnitTests.Tests
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Constants;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Questions.Commands.AskQuestion;
    using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
    using Microsoft.Extensions.Configuration;
    using Moq;

    /// <summary>
    /// Test class for question handlers.
    /// </summary>
    public class QuestionTests
    {
        /// <summary>
        /// Tests the <see cref="AskQuestionCommandHandler"/>.
        /// In this case, an answer corresponding to the question was found.
        /// </summary>
        /// <returns>Void.</returns>
        [Fact]
        public async Task AskQuestionCommandHandlerAnswerFound()
        {
            // Define the expected result
            var expectedSearchResult = new QnASearchResult
            {
                Answer = "Mock your service.",
                Id = 1,
            };

            // Mock the service
            var mockQuestionService = new Mock<IQuestionCosmosService>();

            // Set the input question
            var questionInput = new QuestionInputDto
            {
                Message = "My unit test throws this error : \"ArgumentOutOfRangeException : ToFeedIterator is only supported on Cosmos LINQ query operations\".",
                Tags = new List<string>
                {
                    "C#"
                }
            };

            // Setup the GetQuestionAnswer of the service
            mockQuestionService.Setup(x => x.GetQuestionAnswer(questionInput))
                .Returns(Task.FromResult(expectedSearchResult));

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

            // Instantiate the handler
            var handler = new AskQuestionCommandHandler(mockQuestionService.Object, config);

            // Handles the command
            var answerFoundResult = await handler.Handle(new AskQuestionCommand(questionInput), CancellationToken.None);

            // Check if result corresponds to the expectation
            Assert.Equal(expectedSearchResult.Answer, answerFoundResult.Answer);
        }

        /// <summary>
        /// Tests the <see cref="AskQuestionCommandHandler"/>.
        /// In this case, no answer corresponding to the question was found.
        /// Result must contain a mention to a speaker corresponding to the tag of the question.
        /// </summary>
        /// <returns>Void.</returns>
        [Fact]
        public async Task AskQuestionCommandHandlerNoAnswer()
        {
            // Define the expected search result
            var expectedSearchResult = new QnASearchResult
            {
                Answer = "",
                Id = -1,
            };

            // Define the expected speakers result
            var expectedSpeakersResult = new List<string>
            {
                "c193c120-8de1-48cd-8c04-dd691448c1b6"
            };

            // Mock the service
            var mockQuestionService = new Mock<IQuestionCosmosService>();

            // Set the input question
            var questionInput = new QuestionInputDto
            {
                Message = "My unit test throws this error : \"ArgumentOutOfRangeException : ToFeedIterator is only supported on Cosmos LINQ query operations\".",
                Tags = new List<string>
                {
                    "C#"
                }
            };

            // Setup the GetQuestionAnswer of the service
            mockQuestionService.Setup(x => x.GetQuestionAnswer(questionInput))
                .Returns(Task.FromResult(expectedSearchResult));

            // Setup the GetQuestionAnswer of the service
            mockQuestionService.Setup(x => x.GetQuestionSpeakers(questionInput))
                .Returns(Task.FromResult(expectedSpeakersResult.AsEnumerable()));

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

            // Instantiate the handler
            var handler = new AskQuestionCommandHandler(mockQuestionService.Object, config);

            // Handles the command
            var answerFoundResult = await handler.Handle(new AskQuestionCommand(questionInput), CancellationToken.None);

            // Check if result corresponds to the expectation
            Assert.Equal(QnaMakerConstants.NotFoundResult, answerFoundResult.Answer);
            Assert.NotEmpty(answerFoundResult.Mentions);
        }

        /// <summary>
        /// Tests the <see cref="AskQuestionCommandHandler"/>.
        /// In this case, no answer corresponding to the question was found an no tag was given.
        /// Result must contain a message telling that there is no result.
        /// </summary>
        /// <returns>Void.</returns>
        [Fact]
        public async Task AskQuestionCommandHandlerNoAnswerNoTag()
        {
            // Define the expected search result
            var expectedSearchResult = new QnASearchResult
            {
                Answer = "",
                Id = -1,
            };

            // Mock the service
            var mockQuestionService = new Mock<IQuestionCosmosService>();

            // Set the input question
            var questionInput = new QuestionInputDto
            {
                Message = "My unit test throws this error : \"ArgumentOutOfRangeException : ToFeedIterator is only supported on Cosmos LINQ query operations\".",
                Tags = new List<string>()
            };

            // Setup the service
            mockQuestionService.Setup(x => x.GetQuestionAnswer(questionInput))
                .Returns(Task.FromResult(expectedSearchResult));

            // Setup the GetQuestionAnswer of the service
            mockQuestionService.Setup(x => x.GetQuestionSpeakers(questionInput))
                .Returns(Task.FromResult(new List<string>().AsEnumerable()));

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

            // Instantiate the handler
            var handler = new AskQuestionCommandHandler(mockQuestionService.Object, config);

            // Handles the command
            var answerFoundResult = await handler.Handle(new AskQuestionCommand(questionInput), CancellationToken.None);

            // Check if result corresponds to the expectation
            Assert.Equal(QnaMakerConstants.NotFoundResult, answerFoundResult.Answer);
            Assert.Empty(answerFoundResult.Mentions);
        }

        /// <summary>
        /// Tests the <see cref="AskQuestionCommandHandler"/>.
        /// In this case, question is an empty string.
        /// Result must contain a message telling that there is no result and no mention.
        /// </summary>
        /// <returns>Void.</returns>
        [Fact]
        public async Task AskQuestionCommandHandlerNoQuestion()
        {
            // Mock the service
            var mockQuestionService = new Mock<IQuestionCosmosService>();

            // Set the input question
            var questionInput = new QuestionInputDto
            {
                Message = "",
                Tags = new List<string>()
            };

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

            // Instantiate the handler
            var handler = new AskQuestionCommandHandler(mockQuestionService.Object, config);

            // Handles the command
            var answerFoundResult = await handler.Handle(new AskQuestionCommand(questionInput), CancellationToken.None);

            // Check if result corresponds to the expectation
            Assert.Equal(QnaMakerConstants.NotFoundResult, answerFoundResult.Answer);
            Assert.Empty(answerFoundResult.Mentions);
        }
    }
}
