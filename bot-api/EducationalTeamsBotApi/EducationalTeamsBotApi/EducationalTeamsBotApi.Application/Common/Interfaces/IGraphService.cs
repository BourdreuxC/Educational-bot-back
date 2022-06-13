// -----------------------------------------------------------------------
// <copyright file="IGraphService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using System.Collections.Generic;
    using Microsoft.Graph;

    /// <summary>
    /// Interface containing methods that call microsoft graph API.
    /// </summary>
    public interface IGraphService
    {
        /// <summary>
        /// Gets the list of users of the organization.
        /// </summary>
        /// <returns>A list of objects.</returns>
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Gets the list of joined teams of the connected user.
        /// </summary>
        /// <returns>A list of <see cref="Team"/>.</returns>
        Task<IEnumerable<Team>> GetJoinedTeams();

        /// <summary>
        /// Gets the list of channels of a specific team.
        /// </summary>
        /// <param name="teamId">Graph team identifier.</param>
        /// <returns>A list of <see cref="Channel"/>.</returns>
        Task<IEnumerable<Channel>> GetTeamChannels(string teamId);

        /// <summary>
        /// Gets the list of messages of a channel.
        /// </summary>
        /// <param name="teamId">Graph team identifier.</param>
        /// <param name="channelId">Graph channel identifier.</param>
        /// <returns>A list of <see cref="ChatMessage"/>.</returns>
        Task<IEnumerable<ChatMessage>> GetChannelMessages(string teamId, string channelId);

        /// <summary>
        /// Gets the list of unanswered messages in a channel.
        /// </summary>
        /// <param name="teamId">Team (group) identifier.</param>
        /// <param name="channelId">Channel identifier.</param>
        /// <returns>A list of objects.</returns>
        List<Message> GetUnansweredMessages(string teamId, string channelId);

        /// <summary>
        /// Gets the list of answers of a message.
        /// </summary>
        /// <param name="teamId">Team (group) identifier.</param>
        /// <param name="channelId">Channel identifier.</param>
        /// <param name="messageId">Message identifier.</param>
        /// <returns>A list of objects.</returns>
        List<object> GetMessageAnswers(string teamId, string channelId, string messageId);

        /// <summary>
        /// Adds a user to a team.
        /// </summary>
        /// <param name="teamId">Team identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>True if success, false if failed.</returns>
        bool AddUserToTeam(string teamId, string userId);

        /// <summary>
        /// Removes a user from a team.
        /// </summary>
        /// <param name="teamId">Team identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>True if success, false if failed.</returns>
        bool RemoveUserFromTeam(string teamId, string userId);
    }
}
