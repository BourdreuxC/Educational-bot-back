// -----------------------------------------------------------------------
// <copyright file="MessagesController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Common.Constants;
    using EducationalTeamsBotApi.Application.Messages.Commands.Graph_SyncMessagesCommand;
    using EducationalTeamsBotApi.Application.Messages.Queries.GetMessagesQuery;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller allowing to interact with messages.
    /// </summary>
    [ApiController]
    public class MessagesController : ApiBaseController
    {
        /// <summary>
        /// Gets the list of all messages.
        /// </summary>
        /// <returns>A list of messages.</returns>
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await this.Mediator.Send(new GetMessagesQuery());
            return this.Ok(messages);
        }

        /// <summary>
        /// Get the list of messages for a team channel from Graph and update database.
        /// </summary>
        /// <param name="teamId">Graph team identifier.</param>
        /// <param name="channelId">Graph channel identifier.</param>
        /// <returns>A <see cref="CreatedResult"/>.</returns>
        [HttpGet("sync")]
        public async Task<IActionResult> SyncGraphMessages(string teamId, string channelId)
        {
            var result = await this.Mediator.Send(new Graph_SyncChannelMessagesCommand { TeamId = teamId, ChannelId = channelId });

            if (result)
            {
                return this.StatusCode(201);
            }
            else
            {
                return this.StatusCode(409);
            }
        }
    }
}
