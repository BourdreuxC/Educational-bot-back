// -----------------------------------------------------------------------
// <copyright file="SpeakersController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Pagination.Queries;
    using EducationalTeamsBotApi.Application.Speakers.Commands.DeleteSpeakerCommand;
    using EducationalTeamsBotApi.Application.Speakers.Commands.EditSpeakerCommand;
    using EducationalTeamsBotApi.Application.Speakers.Commands.EnableSpeakerCommand;
    using EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakerQuery;
    using EducationalTeamsBotApi.Domain.Entities;
    using EducationalTeamsBotApi.WebApi.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller allowing to interact with speakers.
    /// </summary>
    [ApiController]
    public class SpeakersController : ApiBaseController
    {
        /// <summary>
        /// Gets the list of all speakers.
        /// </summary>
        /// <param name="query">Query with pagination.</param>
        /// <returns>A list of speakers.</returns>
        [HttpGet]
        public async Task<IActionResult> GetSpeakers([FromQuery] GetWithPaginationQuery<SpeakerDto> query)
        {
            try
            {
                var speakers = await this.Mediator.Send(query);
                return this.Ok(speakers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the list of all speakers.
        /// </summary>
        /// <param name="id">Identifier of the speaker.</param>
        /// <returns>A list of speakers.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpeaker(string id)
        {
            try
            {
                var speakers = await this.Mediator.Send(new GetSpeakerQuery(id));
                return this.Ok(speakers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Enable or disable a speaker.
        /// </summary>
        /// <param name="id">Identifier of the speaker.</param>
        /// <returns>A speaker.</returns>
        [HttpPut("Enable/{id}")]
        public async Task<IActionResult> EnableSpeaker(string id)
        {
            try
            {
                var speakers = await this.Mediator.Send(new EnableSpeakerCommand(id));
                return this.Ok(speakers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Insert and update a speaker.
        /// </summary>
        /// <param name="model">model containting the speaker to upsert.</param>
        /// <returns>A speaker.</returns>
        [HttpPost]
        public async Task<IActionResult> UpsertSpeaker(UpsertSpeakerModel model)
        {
            try
            {
                var speakers = await this.Mediator.Send(new UpsertSpeakerCommand(new CosmosSpeaker(model.Id)
                {
                    AltIds = model.AltIds,
                    Enabled = model.Enabled,
                    Nickname = model.Nickname,
                    Name = model.Name,
                    Tags = model.Tags ?? new List<string>(),
                }));
                return this.Ok(speakers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete a speaker.
        /// </summary>
        /// <param name="id">Identifier of the speaker to delete.</param>
        /// <returns>A speaker.</returns>
        [HttpDelete]
        public async Task<IActionResult> Speaker(string id)
        {
            try
            {
                var speakers = await this.Mediator.Send(new DeleteSpeakerCommand(id));
                return this.Ok(speakers);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
