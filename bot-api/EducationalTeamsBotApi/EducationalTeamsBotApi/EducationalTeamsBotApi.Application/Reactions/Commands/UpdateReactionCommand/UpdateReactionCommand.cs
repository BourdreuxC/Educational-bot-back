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
        /// <param name="reactionId">Graph identifier.</param>
        /// <param name="value">Value.</param>
        public UpdateReactionCommand(string id, string reactionId, int value)
        {
            this.Id = id;
            this.ReactionId = reactionId;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the ReactionId.
        /// </summary>
        public string ReactionId { get; set; }

        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        public int Value { get; set; }
    }
}
