// -----------------------------------------------------------------------
// <copyright file="UpdateReactionCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Reactions.Commands.UpdateReactionCommand
{
    using EducationalTeamsBotApi.Application.Dto;
    using MediatR;

    /// <summary>
    /// Command allowing to update a reaction.
    /// </summary>
    public class UpdateReactionCommand : IRequest<ReactionDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateReactionCommand"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="reaction">Graph identifier.</param>
        /// <param name="value">Value.</param>
        public UpdateReactionCommand(string id, string reaction, int value)
        {
            this.Id = id;
            this.Reaction = reaction;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }

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
