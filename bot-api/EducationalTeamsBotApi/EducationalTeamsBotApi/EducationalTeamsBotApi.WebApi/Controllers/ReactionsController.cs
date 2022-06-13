// -----------------------------------------------------------------------
// <copyright file="ReactionsController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Pagination.Queries;
    using EducationalTeamsBotApi.Application.Reactions.Commands.CreateReactionCommand;
    using EducationalTeamsBotApi.Application.Reactions.Commands.DeleteReactionCommand;
    using EducationalTeamsBotApi.Application.Reactions.Commands.UpdateReactionCommand;
    using EducationalTeamsBotApi.Application.Reactions.Queries.GetReactionQuery;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller allowing to interact with reactions.
    /// </summary>
    [ApiController]
    public class ReactionsController : ApiBaseController
    {
        /// <summary>
        /// Gets the list of all reactions.
        /// </summary>
        /// <param name="query">Query with pagination.</param>
        /// <returns>A <see cref="PaginatedList{ReactionDto}"/>.</returns>
        [HttpGet]
        public async Task<IActionResult> GetReactions([FromQuery] GetWithPaginationQuery<ReactionDto> query)
        {
            try
            {
                var reactions = await this.Mediator.Send(query);
                return this.Ok(reactions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a reaction by id.
        /// </summary>
        /// <param name="id">Reaction identifier.</param>
        /// <returns>A <see cref="ReactionDto"/>.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReaction(string id)
        {
            var reaction = await this.Mediator.Send(new GetReactionQuery(id));
            return this.Ok(reaction);
        }

        /// <summary>
        /// Creates a reaction.
        /// </summary>
        /// <param name="command">Reaction creation command.</param>
        /// <returns>A <see cref="ReactionDto"/>.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateReaction([FromBody] CreateReactionCommand command)
        {
            var reaction = await this.Mediator.Send(command);
            return this.Ok(reaction);
        }

        /// <summary>
        /// Updates a reaction.
        /// </summary>
        /// <param name="command">Reaction update command.</param>
        /// <returns>A <see cref="ReactionDto"/>.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateReaction([FromBody] UpdateReactionCommand command)
        {
            var reaction = await this.Mediator.Send(command);
            return this.Ok(reaction);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReaction(string id)
        {
            var result = await this.Mediator.Send(new DeleteReactionCommand(id));

            if (result)
            {
                return this.Ok();
            }

            return this.Forbid();
        }
    }
}
