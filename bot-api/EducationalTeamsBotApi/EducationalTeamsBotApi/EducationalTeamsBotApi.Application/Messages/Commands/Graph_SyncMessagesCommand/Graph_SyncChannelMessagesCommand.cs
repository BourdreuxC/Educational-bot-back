// -----------------------------------------------------------------------
// <copyright file="Graph_SyncChannelMessagesCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Messages.Commands.Graph_SyncMessagesCommand
{
    using MediatR;

    /// <summary>
    /// Command used to sync graph messages from a channel with the database.
    /// </summary>
    public class Graph_SyncChannelMessagesCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        public string? TeamId { get; set; }

        /// <summary>
        /// Gets or sets the channel identifier.
        /// </summary>
        public string? ChannelId { get; set; }
    }
}
