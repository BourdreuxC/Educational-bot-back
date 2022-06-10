// -----------------------------------------------------------------------
// <copyright file="AddTagCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Commands.AddTagCommand
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Command handler for the tag creation.
    /// </summary>
    public class AddTagCommandHandler : IRequestHandler<AddTagCommand, CosmosTag?>
    {
        /// <summary>
        /// Tag service.
        /// </summary>
        private readonly ITagCosmosService tagService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTagCommandHandler"/> class.
        /// </summary>
        /// <param name="tagService"> service of the tags.</param>
        public AddTagCommandHandler(ITagCosmosService tagService)
        {
            this.tagService = tagService;
        }

        /// <inheritdoc/>
        public async Task<CosmosTag?> Handle(AddTagCommand request, CancellationToken cancellationToken)
        {
            return await this.tagService.AddTag(request.Variants);
        }
    }
}
