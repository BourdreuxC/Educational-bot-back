// -----------------------------------------------------------------------
// <copyright file="GetTagByNameQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Queries.GetTagByNameQuery
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler for the query that will search.
    /// </summary>
    public class GetTagByNameQueryHandler : IRequestHandler<GetTagByNameQuery, CosmosTag?>
    {
        /// <summary>
        /// Tag service.
        /// </summary>
        private readonly ITagCosmosService tagService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTagByNameQueryHandler"/> class.
        /// </summary>
        /// <param name="tagService">Service of the tags.</param>
        public GetTagByNameQueryHandler(ITagCosmosService tagService)
        {
            this.tagService = tagService;
        }

        /// <inheritdoc/>
        public async Task<CosmosTag?> Handle(GetTagByNameQuery request, CancellationToken cancellationToken)
        {
            return await this.tagService.SearchTag(request.Name);
        }
    }
}
