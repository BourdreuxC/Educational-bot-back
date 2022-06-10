// -----------------------------------------------------------------------
// <copyright file="CosmosAnswerReaction.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Domain.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// The association between an answer and reactions.
    /// </summary>
    public class CosmosAnswerReaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosmosAnswerReaction"/> class.
        /// </summary>
        /// <param name="userId">Id of the user that user a reaction.</param>
        /// <param name="reactionId">Id of the cosmos reation.</param>
        public CosmosAnswerReaction(string userId, string reactionId)
        {
            this.UserId = userId;
            this.ReactionId = reactionId;
        }

        /// <summary>
        /// Gets or sets the id of the user.
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the id of the cosmos reaction.
        /// </summary>
        [JsonProperty("reaction")]
        public string ReactionId { get; set; }
    }
}
