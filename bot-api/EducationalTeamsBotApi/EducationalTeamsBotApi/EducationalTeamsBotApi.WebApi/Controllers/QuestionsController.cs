﻿// -----------------------------------------------------------------------
// <copyright file="QuestionsController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Questions.Commands.AskQuestion;
    using EducationalTeamsBotApi.Application.Questions.Queries.GetAllQuestionsQuery;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;
    using Microsoft.Bot.Connector.Teams;
    using System.Xml;
    using EducationalTeamsBotApi.Application.Common.DTOs;

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
        /// <returns>All Questions.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetQuestions()
        {
            try
            {
                var questions = await this.Mediator.Send(new GetAllQuestionsQuery());
                return this.Ok(questions);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Answer a given question.
        /// </summary>
        /// <param name="question">the question asked.</param>
        /// <returns>the answer.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> QuestionAsked([FromBody] string question)
        {
            try
            {
               var res = await this.Mediator.Send(new AskQuestionCommand { Activity = question });
               return this.Ok(res);
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}
