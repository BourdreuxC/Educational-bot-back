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
        /// <param name="activity">the question asked.</param>
        /// <returns>the answer.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task QuestionAsked([FromBody] Activity activity)
        {
            try
            {
               await this.Mediator.Send(new AskQuestionCommand { Activity = activity });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
