// -----------------------------------------------------------------------
// <copyright file="DeleteQuestionCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Questions.Commands.DeleteQuestionCommand
{
    using MediatR;

    /// <summary>
    /// Command allowing to delete a question.
    /// </summary>
    public class DeleteQuestionCommand : IRequest<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteQuestionCommand"/> class.
        /// </summary>
        /// <param name="id">Id of the question.</param>
        public DeleteQuestionCommand(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }
    }
}
