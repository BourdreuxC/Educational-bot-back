// -----------------------------------------------------------------------
// <copyright file="TagsController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Pagination.Queries;
    using EducationalTeamsBotApi.Application.Tags.Commands.AddTagCommand;
    using EducationalTeamsBotApi.Application.Tags.Commands.AddTagVariant;
    using EducationalTeamsBotApi.Application.Tags.Commands.DeleteTagCommand;
    using EducationalTeamsBotApi.Application.Tags.Queries.GetTagByNameQuery;
    using EducationalTeamsBotApi.Application.Tags.Queries.GetTagQuery;
    using EducationalTeamsBotApi.Application.Tags.Queries.GetTagsQuery;
    using EducationalTeamsBotApi.CrossCuting;
    using EducationalTeamsBotApi.WebApi.Filters;
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
        /// <param name="query">Query with pagination.</param>
        /// <returns>A list of tags.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetTags([FromQuery] GetWithPaginationQuery<TagDto> query)
        {
            var tags = await this.Mediator.Send(query);
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
                throw new BusinessException("The parameter name is null");
            }

            var tag = await this.Mediator.Send(new GetTagByNameQuery(name));
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
            var tag = await this.Mediator.Send(new GetTagQuery(id));
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
            var tag = await this.Mediator.Send(new EditTagVariantCommand(model.Id, model.Variant));

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
                throw new BusinessException("The list of variant is empty.");
            }

            var tags = await this.Mediator.Send(new AddTagCommand(model.Id ?? string.Empty, model.Variants));

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
            var tags = await this.Mediator.Send(new DeleteTagCommand(id));
            return this.Ok(tags);
        }
    }
}
