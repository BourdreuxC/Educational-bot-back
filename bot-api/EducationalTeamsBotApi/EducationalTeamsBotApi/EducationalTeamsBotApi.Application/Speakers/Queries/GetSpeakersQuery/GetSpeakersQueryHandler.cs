// -----------------------------------------------------------------------
// <copyright file="GetSpeakersQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakersQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Common.Models;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Pagination.Queries;
    using EducationalTeamsBotApi.CrossCuting;
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
        /// Tag cosmos service used in this class.
        /// </summary>
        private readonly ITagCosmosService tagCosmosService;

        /// <summary>
        /// IMapper instance.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSpeakersQueryHandler"/> class.
        /// </summary>
        /// <param name="speakerCosmosService">Injection of the speaker service.</param>
        /// <param name="tagCosmosService">Injection of the tag service.</param>
        /// <param name="mapper">Mapper to use.</param>
        public GetSpeakersQueryHandler(ISpeakerCosmosService speakerCosmosService, ITagCosmosService tagCosmosService, IMapper mapper)
        {
            this.speakerCosmosService = speakerCosmosService;
            this.tagCosmosService = tagCosmosService;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<PaginatedList<SpeakerDto>> Handle(GetWithPaginationQuery<SpeakerDto> request, CancellationToken cancellationToken)
        {
            var speakers = await this.speakerCosmosService.GetCosmosSpeakers();
            var speakersDto = speakers
                .Where(s => request.Search == string.Empty || (s.Nickname != null && s.Nickname.ToLower().Contains(request.Search.ToLower())) || (s.Name != null && s.Name.ToLower().Contains(request.Search.ToLower())))
                .ProjectTo<SpeakerDto>(this.mapper.ConfigurationProvider).ToList();

            // Get the tags item of the speakers.
            foreach (var speaker in speakersDto)
            {
                var tags = new List<TagDto>();
                var tagsSpeaker = speaker.TagsIds.ToList();

                // Get the tag corresponding to each id.
                foreach (var item in tagsSpeaker)
                {
                    var tag = this.tagCosmosService.GetTag(item).Result;
                    if (tag == null)
                    {
                        throw new BusinessException("The tag with Identifier '" + item + "' in speaker '" + speaker.Name + "' does not exist ");
                    }

                    var tagToAdd = this.mapper.Map<TagDto>(tag);
                    tags.Add(tagToAdd);
                }

                speaker.Tags = tags;
            }

            return await speakersDto
                .AsQueryable()
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
