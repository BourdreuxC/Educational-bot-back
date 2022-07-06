// -----------------------------------------------------------------------
// <copyright file="LogicAppHttpBody.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Dto
{
    /// <summary>
    /// Content to use as request body for Logic App HTTP trigger.
    /// </summary>
    public class LogicAppHttpBody
    {
        /// <summary>
        /// Gets or sets the MessageId.
        /// </summary>
        public string MessageId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ChannelId.
        /// </summary>
        public string ChannelId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the TeamId.
        /// </summary>
        public string TeamId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Delay.
        /// </summary>
        public int Delay { get; set; } = 3;
    }
}
