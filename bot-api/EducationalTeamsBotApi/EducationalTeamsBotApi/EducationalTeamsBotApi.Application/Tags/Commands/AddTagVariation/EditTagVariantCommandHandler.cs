// -----------------------------------------------------------------------
// <copyright file="EditTagVariantCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Commands.AddTagVariant
{
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Command handler for the tag variant edition.
    /// </summary>
    public class EditTagVariantCommandHandler : IRequestHandler<EditTagVariantCommand, CosmosTag?>
    {
        /// <summary>
        /// Tag service.
        /// </summary>
        private readonly ITagCosmosService tagService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditTagVariantCommandHandler"/> class.
        /// </summary>
        /// <param name="tagService">Service of the tags.</param>
        public EditTagVariantCommandHandler(ITagCosmosService tagService)
        {
            this.tagService = tagService;
        }

        /// <inheritdoc/>
        public async Task<CosmosTag?> Handle(EditTagVariantCommand request, CancellationToken cancellationToken)
        {
            return await this.tagService.EditTagVariant(request.Id, request.Variant);
        }
    }
}
