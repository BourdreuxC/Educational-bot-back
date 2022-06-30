// -----------------------------------------------------------------------
// <copyright file="IQuestionCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Domain.Entities;
    using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
    using Microsoft.Bot.Schema;

    /// <summary>
    /// Interface containing methods that call cosmosDB.
    /// </summary>
    public interface IQuestionCosmosService
    {
        /// <summary>
        /// Get all questions.
        /// </summary>
        /// <returns>List of all questions objects.</returns>
        Task<IQueryable<CosmosQuestion>> GetCosmosQuestions();

        /// <summary>
        /// Inserts a list of <see cref="CosmosQuestion"/> in database.
        /// </summary>
        /// <param name="questions">Questions to insert.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<CosmosQuestion>> InsertCosmosQuestions(List<CosmosQuestion> questions);

        /// <summary>
        /// Get a specific question.
        /// </summary>
        /// <param name="id">the identifier of a question.</param>
        /// <returns>The question Object.</returns>
        Task<CosmosQuestion> GetQuestion(string id);

        /// <summary>
        /// Add an answer to the question.
        /// </summary>
        /// <param name="answerId">The id of the answer.</param>
        /// <returns>The updated question.</returns>
        Task<CosmosQuestion> AddAnswerToQuestion(string answerId);

        /// <summary>
        /// Add multiple answers to a question.
        /// </summary>
        /// <param name="answerIds">List of answers ids.</param>
        /// <returns>The newly updated question.</returns>
        Task<CosmosQuestion> AddAnswersToQuestion(List<string> answerIds);

        /// <summary>
        /// Add a new tag to a question.
        /// </summary>
        /// <param name="tagId">The id of the tag.</param>
        /// <returns>The updated question.</returns>
        Task<CosmosQuestion> AddTagToQuestion(string tagId);

        /// <summary>
        /// Add multiple new tags to a question.
        /// </summary>
        /// <param name="tagIds">A list of Ids for the tags.</param>
        /// <returns>The updated question.</returns>
        Task<CosmosQuestion> AddTagsToQuestion(List<string> tagIds);

        /// <summary>
        /// Get the question that has the answer provided.
        /// </summary>
        /// <param name="answerId">The id of the answer associated with the question.</param>
        /// <returns>The question object.</returns>
        Task<CosmosQuestion> GetQuestionFromAnswer(string answerId);

        /// <summary>
        /// Get the answer corresponding to the question asked.
        /// </summary>
        /// <param name="question">A <see cref="QuestionInputDto"/> containing the asked question.</param>
        /// <returns>A <see cref="QnASearchResult"/>.</returns>
        Task<QnASearchResult> GetQuestionAnswer(QuestionInputDto question);

        /// <summary>
        /// Get the speakers corresponding to the tags of the question asked.
        /// </summary>
        /// <param name="question">A <see cref="QuestionInputDto"/> containing the asked question and its tags.</param>
        /// <returns>A <see cref="IEnumerable{string}"/> containing speakers identifiers.</returns>
        Task<IEnumerable<string>> GetQuestionSpeakers(QuestionInputDto question);

        /// <summary>
        /// Return the best answer for a question.
        /// </summary>
        /// <param name="questionId">The identifier of the question.</param>
        /// <returns>A <see cref="CosmosAnswer"/>.</returns>
        Task<CosmosAnswer?> GetBestAnswerFromQuestion(string questionId);

        /// <summary>
        /// Deletes a question.
        /// </summary>
        /// <param name="id">Question identifier.</param>
        /// <returns>Void.</returns>
        Task DeleteQuestion(string id);
    }
}
