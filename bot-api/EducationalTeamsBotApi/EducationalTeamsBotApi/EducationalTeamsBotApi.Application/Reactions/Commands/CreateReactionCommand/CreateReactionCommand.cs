// -----------------------------------------------------------------------
// <copyright file="CreateReactionCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Reactions.Commands.CreateReactionCommand
{
    using EducationalTeamsBotApi.Application.Dto;
    using MediatR;

    /// <summary>
    /// Command allowing to create a reaction.
    /// </summary>
    public class CreateReactionCommand : IRequest<ReactionDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReactionCommand"/> class.
        /// </summary>
        /// <param name="id">Database identifier.</param>
        /// <param name="reaction">Reaction identifier.</param>
        /// <param name="value">Reaction value.</param>
        public CreateReactionCommand(string id, string reaction, int value)
        {
            this.Id = id;
            this.Reaction = reaction;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the Reaction.
        /// </summary>
        public string Reaction { get; set; }

        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        public int Value { get; set; }
    }
}
