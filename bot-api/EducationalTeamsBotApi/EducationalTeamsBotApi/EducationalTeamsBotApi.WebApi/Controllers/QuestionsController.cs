// -----------------------------------------------------------------------
// <copyright file="QuestionsController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Pagination.Queries;
    using EducationalTeamsBotApi.Application.Questions.Commands.AskQuestion;
    using EducationalTeamsBotApi.Application.Questions.Commands.DeleteQuestionCommand;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Bot.Schema;

    /// <summary>
    /// Controller allowing to interact with questions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ApiBaseController
    {
        /// <summary>
        /// Get the list of questions.
        /// </summary>
        /// <param name="query">Query with pagination.</param>
        /// <returns>All Questions.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetQuestions([FromQuery] GetWithPaginationQuery<QuestionDto> query)
        {
            try
            {
                var questions = await this.Mediator.Send(query);
                return this.Ok(questions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Answer a given question.
        /// </summary>
        /// <param name="question">The question asked.</param>
        /// <returns>The answer.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> QuestionAsked(QuestionInputDto activity)
        {
            try
            {
               var res = await this.Mediator.Send(new AskQuestionCommand(activity));
               return this.Ok(res);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes a question.
        /// </summary>
        /// <param name="id">Question identifier.</param>
        /// <returns>A HTTP status code.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(string id)
        {
            var result = await this.Mediator.Send(new DeleteQuestionCommand(id));

            if (result)
            {
                return this.Ok();
            }

            return this.Forbid();
        }
    }
}
