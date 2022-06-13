// -----------------------------------------------------------------------
// <copyright file="GetSpeakersQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakersQuery
{
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
    /// Handler for the query that will get speakers.
    /// </summary>
    public class GetSpeakersQueryHandler : IRequestHandler<GetWithPaginationQuery<SpeakerDto>, PaginatedList<SpeakerDto>>
    {
        /// <summary>
        /// Speaker cosmos service used in this class.
        /// </summary>
        private readonly ISpeakerCosmosService speakerCosmosService;

        /// <summary>
        /// IMapper instance.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSpeakersQueryHandler"/> class.
        /// </summary>
        /// <param name="speakerCosmosService">Injection.</param>
        /// <param name="mapper">Mapper to use.</param>
        public GetSpeakersQueryHandler(ISpeakerCosmosService speakerCosmosService, IMapper mapper)
        {
            this.speakerCosmosService = speakerCosmosService;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<PaginatedList<SpeakerDto>> Handle(GetWithPaginationQuery<SpeakerDto> request, CancellationToken cancellationToken)
        {
            var speakers = await this.speakerCosmosService.GetCosmosSpeakers();
            return await speakers.ToList().AsQueryable().ProjectTo<SpeakerDto>(this.mapper.ConfigurationProvider).PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
