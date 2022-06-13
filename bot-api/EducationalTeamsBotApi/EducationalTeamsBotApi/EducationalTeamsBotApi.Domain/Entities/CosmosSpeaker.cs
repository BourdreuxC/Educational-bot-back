// -----------------------------------------------------------------------
// <copyright file="CosmosSpeaker.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Domain.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// Speaker in the CosmosDB format.
    /// </summary>
    public class CosmosSpeaker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosmosSpeaker"/> class.
        /// </summary>
        /// <param name="id">identifier of a user.</param>
        public CosmosSpeaker(string id)
        {
            this.Id = id;
            this.AltIds = new List<string>();
            this.Tags = new List<string>();
        }

        /// <summary>
        /// Gets or sets the identifier of a user.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the alternatives Identifiers of the same user.
        /// </summary>
        [JsonProperty("altIds")]
        public IEnumerable<string> AltIds { get; set; }

        /// <summary>
        /// Gets or sets the tags associated to a speaker.
        /// </summary>
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the name of the speaker | not required.
        /// </summary>
        [JsonProperty("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the nickname of a speaker | not required.
        /// </summary>
        [JsonProperty("Nickname")]
        public string? Nickname { get; set; }

        /// <summary>
        /// Gets or sets the status of the speaker | not required.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; } = true;
    }
}
