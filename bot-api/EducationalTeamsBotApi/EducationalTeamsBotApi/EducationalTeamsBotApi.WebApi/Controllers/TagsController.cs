// -----------------------------------------------------------------------
// <copyright file="TagsController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Tags.Commands.AddTagCommand;
    using EducationalTeamsBotApi.Application.Tags.Commands.AddTagVariant;
    using EducationalTeamsBotApi.Application.Tags.Commands.DeleteTagCommand;
    using EducationalTeamsBotApi.Application.Tags.Queries.GetTagByNameQuery;
    using EducationalTeamsBotApi.Application.Tags.Queries.GetTagQuery;
    using EducationalTeamsBotApi.Application.Tags.Queries.GetTagsQuery;
    using EducationalTeamsBotApi.WebApi.Model;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller allowing to interact with tags.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ApiBaseController
    {
        /// <summary>
        /// Gets the list of all tags.
        /// </summary>
        /// <returns>A list of tags.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetTags()
        {
            var tags = await this.Mediator.Send(new GetTagsQuery());
            return this.Ok(tags);
        }

        /// <summary>
        /// Get a tag by it's name.
        /// </summary>
        /// <param name="name">Name of the tag to search.</param>
        /// <returns>A tag.</returns>
        [HttpGet]
        [Route("GetTagByName/{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTagByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            var tag = await this.Mediator.Send(new GetTagByNameQuery { Name = name });
            if (tag == null)
            {
                return this.NoContent();
            }

            return this.Ok(tag);
        }

        /// <summary>
        /// Gets a tag by it's identifier.
        /// </summary>
        /// <param name="id">Identifier of the tag to search.</param>
        /// <returns>A tag.</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTag(string id)
        {
            var tag = await this.Mediator.Send(new GetTagQuery { Id = id });
            if (tag == null)
            {
                return this.NoContent();
            }

            return this.Ok(tag);
        }

        /// <summary>
        /// Add or remove the tag variant.
        /// </summary>
        /// <param name="model">model containing the tag identifier and the variant.</param>
        /// <returns>The updated tag.</returns>
        [HttpPut]
        [Route("EditTagVariant")]
        [AllowAnonymous]
        public async Task<IActionResult> EditTagVariant(EditTagVariantModel model)
        {
            var tag = await this.Mediator.Send(new EditTagVariantCommand
            {
                Variant = model.Variant,
                Id = model.Id,
            });

            if (tag == null)
            {
                return this.BadRequest("tag not found");
            }

            return this.Ok(tag);
        }

        /// <summary>
        /// Create  a tag.
        /// </summary>
        /// <param name="model">model containing the tag to create.</param>
        /// <returns>The created tag.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddTag(AddTagModel model)
        {
            if (!model.Variants.Any())
            {
                throw new Exception("The list of variant is empty.");
            }

            var tags = await this.Mediator.Send(new AddTagCommand
                {
                 Variants = model.Variants,
                });

            return this.Ok(tags);
        }

        /// <summary>
        /// Delete a tag.
        /// </summary>
        /// <param name="id">Identifier of the tag to delete.</param>
        /// <returns> An Http code 200.</returns>
        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(string id)
        {
            var tags = await this.Mediator.Send(new DeleteTagCommand { Id = id });
            return this.Ok(tags);
        }
    }
}
