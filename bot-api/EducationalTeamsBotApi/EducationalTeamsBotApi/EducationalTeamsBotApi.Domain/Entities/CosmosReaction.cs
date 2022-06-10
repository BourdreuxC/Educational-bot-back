// -----------------------------------------------------------------------
// <copyright file="CosmosReaction.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Domain.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// Reaction in the CosmosDB format.
    /// </summary>
    public class CosmosReaction
    {
        /// <summary>
        /// Gets or sets the identifier of a reaction.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the id of a specific teams reaction.
        /// </summary>
        [JsonProperty("reactionId")]
        public string ReactionId { get; set; }

        /// <summary>
        /// Gets or sets the points value of a reaction.
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CosmosReaction"/> class.
        /// </summary>
        /// <param name="id">identifier of a reaction.</param>
        /// <param name="reactionId"> the id of a specific teams reaction.</param>
        /// <param name="val">points value of a reaction.</param>
        public CosmosReaction(string id, string reactionId, int val)
        {
            this.Id = id;
            this.ReactionId = reactionId;
            this.Value = val;
        }
    }
}
