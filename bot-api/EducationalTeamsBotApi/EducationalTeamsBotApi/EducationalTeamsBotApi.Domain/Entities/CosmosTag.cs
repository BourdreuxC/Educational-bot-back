// -----------------------------------------------------------------------
// <copyright file="CosmosTag.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Domain.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// Tag in the CosmosDB format.
    /// </summary>
    public class CosmosTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosmosTag"/> class.
        /// </summary>
        /// <param name="id">identifier of a tag.</param>
        public CosmosTag()
        {

            this.Variants = new List<string>();
        }

        /// <summary>
        /// Gets or sets the identifier of a tag.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets every variants of a tag.
        /// </summary>
        [JsonProperty("variants")]
        public IEnumerable<string> Variants { get; set; }
    }
}
