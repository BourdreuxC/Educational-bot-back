// -----------------------------------------------------------------------
// <copyright file="AddSpeakerModel.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Model
{
    /// <summary>
    /// Model useed for the addition of a speaker.
    /// </summary>
    public class AddSpeakerModel
    {
        /// <summary>
        /// Gets or sets the alternatives Identifiers of the same a speaker.
        /// </summary>
        public IEnumerable<string> AltIds { get; set; }

        /// <summary>
        /// Gets or sets the tags associated to a speaker.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the name of the speaker.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the nickname of a speaker.
        /// </summary>
        public string? Nickname { get; set; }

        /// <summary>
        /// Gets or sets the status of the speaker.
        /// </summary>
        public bool? Enabled { get; set; } = true;
    }
}
