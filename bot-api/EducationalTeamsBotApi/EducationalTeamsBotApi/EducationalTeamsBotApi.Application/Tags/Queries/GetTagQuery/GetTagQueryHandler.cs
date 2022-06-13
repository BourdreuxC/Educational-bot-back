// -----------------------------------------------------------------------
// <copyright file="GetTagQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Queries.GetTagQuery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Query handler for the tag research.
    /// </summary>
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, CosmosTag?>
    {
        /// <summary>
        /// Tag service.
        /// </summary>
        private readonly ITagCosmosService tagService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTagQueryHandler"/> class.
        /// </summary>
        /// <param name="tagService">Service of the tag.</param>
        public GetTagQueryHandler(ITagCosmosService tagService)
        {
            this.tagService = tagService;
        }

        /// <inheritdoc/>
        public async Task<CosmosTag?> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            return await this.tagService.GetTag(request.Id);
        }
    }
}
