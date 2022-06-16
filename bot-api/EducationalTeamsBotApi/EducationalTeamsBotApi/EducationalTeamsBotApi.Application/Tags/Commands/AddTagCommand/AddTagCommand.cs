// -----------------------------------------------------------------------
// <copyright file="AddTagModel.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Commands.AddTagCommand
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;
    using Newtonsoft.Json;

    /// <summary>
    /// Model to add a tag.
    /// </summary>
    public class AddTagCommand : IRequest<CosmosTag?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTagCommand"/> class.
        /// </summary>
        /// <param name="variants"> Variants of the tags.</param>
        /// <param name="id"> Identifier of the tag (edition only).</param>
        public AddTagCommand(string id,List<string> variants)
        {
            this.Variants = variants;
            this.Id = id;
        }

        /// <summary>
        /// Gets or Sets the variants of the tag.
        /// </summary>
        [JsonProperty("variants")]
        public List<string> Variants { get; set; }

        /// <summary>
        /// Gets or Sets the identifier of the tag (for edition only).
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
