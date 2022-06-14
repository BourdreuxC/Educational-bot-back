// -----------------------------------------------------------------------
// <copyright file="GraphSyncChannelMessagesCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Messages.Commands.GraphSyncMessagesCommand
{
    using MediatR;

    /// <summary>
    /// Command used to sync graph messages from a channel with the database.
    /// </summary>
    public class GraphSyncChannelMessagesCommand : IRequest<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphSyncChannelMessagesCommand"/> class.
        /// </summary>
        /// <param name="teamId">Team Graph identifier.</param>
        /// <param name="channelId">Channel Graph identifier.</param>
        public GraphSyncChannelMessagesCommand(string teamId, string channelId)
        {
            this.TeamId = teamId;
            this.ChannelId = channelId;
        }

        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        public string TeamId { get; set; }

        /// <summary>
        /// Gets or sets the channel identifier.
        /// </summary>
        public string ChannelId { get; set; }
    }
}
