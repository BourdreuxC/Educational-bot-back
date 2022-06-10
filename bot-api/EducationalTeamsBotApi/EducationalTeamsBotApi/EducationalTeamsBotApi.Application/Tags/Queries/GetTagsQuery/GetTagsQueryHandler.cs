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
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Common.Models;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Pagination.Queries;
    using EducationalTeamsBotApi.Domain.Entities;
    using global::Application.Common.Mappings;
    using MediatR;

    /// <summary>
    /// Handler for the query that will get tags.
    /// </summary>
    public class GetTagsQueryHandler : IRequestHandler<GetWithPaginationQuery<TagDto>, PaginatedList<TagDto>>
    {
        /// <summary>
        /// Tag service.
        /// </summary>
        private readonly ITagCosmosService tagService;

        /// <summary>
        /// IMapper instance.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTagsQueryHandler"/> class.
        /// </summary>
        /// <param name="tagService"> Service of the tag.</param>
        /// <param name="mapper">Mapper to use.</param>
        public GetTagsQueryHandler(ITagCosmosService tagService, IMapper mapper)
        {
            this.tagService = tagService;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<PaginatedList<TagDto>> Handle(GetWithPaginationQuery<TagDto> request, CancellationToken cancellationToken)
        {
            var tags = await this.tagService.GetTags();
            return await tags.ToList().AsQueryable()
                .ProjectTo<TagDto>(this.mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
