// -----------------------------------------------------------------------
// <copyright file="DeleteReactionCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Reactions.Commands.DeleteReactionCommand
{
    using MediatR;

    /// <summary>
    /// Command allowing to delete a reaction.
    /// </summary>
    public class DeleteReactionCommand : IRequest<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteReactionCommand"/> class.
        /// </summary>
        /// <param name="id">Reaction identifier.</param>
        public DeleteReactionCommand(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }
    }
}
