// -----------------------------------------------------------------------
// <copyright file="AskQuestionCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Questions.Commands.AskQuestion
{
    using MediatR;
    using Microsoft.Bot.Schema;

    /// <summary>
    /// Post a new question to be answered.
    /// </summary>
    public class AskQuestionCommand : IRequest<string>
    {
        /// <summary>
        /// Gets or sets The content of the question.
        /// </summary>
        public Activity? Activity { get; set; }
    }
}
