// -----------------------------------------------------------------------
// <copyright file="SpeakersController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Speakers.Commands.AddSpeakerCommand;
    using EducationalTeamsBotApi.Application.Speakers.Commands.DeleteSpeakerCommand;
    using EducationalTeamsBotApi.Application.Speakers.Commands.EditSpeakerCommand;
    using EducationalTeamsBotApi.Application.Speakers.Commands.EnableSpeakerCommand;
    using EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakerQuery;
    using EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakersQuery;
    using EducationalTeamsBotApi.WebApi.Model;
    using Microsoft.AspNetCore.Authorization;
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
        /// <returns>A list of speakers.</returns>
        [HttpGet]
        public async Task<IActionResult> GetSpeakers()
        {
            try
            {
                var speakers = await this.Mediator.Send(new GetSpeakersQuery());
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

                var speakers = await this.Mediator.Send(new GetSpeakerQuery { SpeakerId = id });
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
                var speakers = await this.Mediator.Send(new EnableSpeakerCommand { Id = id });
                return this.Ok(speakers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Edit a speaker.
        /// </summary>
        /// <param name="model">model containting the speaker to update.</param>
        /// <returns>A speaker.</returns>
        [HttpPut]
        public async Task<IActionResult> EditSpeaker(EditSpeakerModel model)
        {
            try
            {
                var speakers = await this.Mediator.Send(new EditSpeakerCommand
                {
                    Speaker = new Domain.Entities.CosmosSpeaker(model.Id)
                    {
                        AltIds = model.AltIds,
                        Enabled = model.Enabled,
                        Nickname = model.Nickname,
                        Name = model.Name,
                        Tags = model.Tags,
                    },
                });
                return this.Ok(speakers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Add a speaker.
        /// </summary>
        /// <param name="model">model containting the speaker to update.</param>
        /// <returns>A speaker.</returns>
        [HttpPost]
        public async Task<IActionResult> Speaker(AddSpeakerModel model)
        {
            try
            {
                var speakers = await this.Mediator.Send(new AddSpeakerCommand
                {
                    Speaker = new Domain.Entities.CosmosSpeaker(string.Empty)
                    {
                        AltIds = model.AltIds,
                        Enabled = model.Enabled,
                        Nickname = model.Nickname,
                        Name = model.Name,
                        Tags = model.Tags,
                    },
                });
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
                var speakers = await this.Mediator.Send(new DeleteSpeakerCommand { Id = id });
                return this.Ok(speakers);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
