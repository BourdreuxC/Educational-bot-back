// -----------------------------------------------------------------------
// <copyright file="GetAllReactionsQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Reactions.Queries.GetAllReactionsQuery
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Common.Models;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Pagination.Queries;
    using global::Application.Common.Mappings;
    using MediatR;

    /// <summary>
    /// Handler for <see cref="GetWithPaginationQuery{ReactionDto}"/> query.
    /// </summary>
    public class GetAllReactionsQueryHandler : IRequestHandler<GetWithPaginationQuery<ReactionDto>, PaginatedList<ReactionDto>>
    {
        /// <summary>
        /// Cosmos service to use in this handler.
        /// </summary>
        private readonly IReactionCosmosService service;

        /// <summary>
        /// Mapper to use in this handler.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllReactionsQueryHandler"/> class.
        /// </summary>
        /// <param name="service">Cosmos service to use.</param>
        /// <param name="mapper">Mapper to use.</param>
        public GetAllReactionsQueryHandler(IReactionCosmosService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<PaginatedList<ReactionDto>> Handle(GetWithPaginationQuery<ReactionDto> request, CancellationToken cancellationToken)
        {
            var reactions = await this.service.GetCosmosReactions();

            return await reactions.ProjectTo<ReactionDto>(this.mapper.ConfigurationProvider).PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
