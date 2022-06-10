// -----------------------------------------------------------------------
// <copyright file="GetTagsQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Application.Tags.Queries.GetTagsQuery
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Common.Models;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler for the query that will get tags.
    /// </summary>
    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, IEnumerable<CosmosTag>>
    {
        /// <summary>
        /// Tag service.
        /// </summary>
        private readonly ITagCosmosService tagService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTagsQueryHandler"/> class.
        /// </summary>
        /// <param name="tagService"> Service of the tag.</param>
        public GetTagsQueryHandler(ITagCosmosService tagService)
        {
            this.tagService = tagService;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CosmosTag>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            return await this.tagService.GetTags();
        }
    }
}
