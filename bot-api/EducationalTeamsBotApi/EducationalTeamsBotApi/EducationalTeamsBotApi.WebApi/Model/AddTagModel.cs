// -----------------------------------------------------------------------
// <copyright file="AddTagModel.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace EducationalTeamsBotApi.WebApi.Model
{
    /// <summary>
    /// Model to add a tag.
    /// </summary>
    public class AddTagModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTagModel"/> class.
        /// </summary>
        /// <param name="variants"> Variants of the tags.</param>
        public AddTagModel(List<string> variants)
        {
            this.Variants = variants;
        }

        /// <summary>
        /// Gets or Sets the variants of the tag.
        /// </summary>
        [JsonProperty("variants")]
        public List<string> Variants { get; set; }
    }
}
