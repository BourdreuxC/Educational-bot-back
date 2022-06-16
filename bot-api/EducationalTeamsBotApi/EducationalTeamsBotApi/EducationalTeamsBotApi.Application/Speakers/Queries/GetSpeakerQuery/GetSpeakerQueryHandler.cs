// -----------------------------------------------------------------------
// <copyright file="GetSpeakerQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakerQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.CrossCuting;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler for the query that will get a speaker.
    /// </summary>
    public class GetSpeakerQueryHandler : IRequestHandler<GetSpeakerQuery, SpeakerDto>
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
        /// Initializes a new instance of the <see cref="GetSpeakerQueryHandler"/> class.
        /// </summary>
        /// <param name="speakerCosmosService">Injection.</param>
        /// <param name="tagCosmosService">Injection of the tag service.</param>
        /// <param name="mapper">Mapper to use.</param>
        public GetSpeakerQueryHandler(ISpeakerCosmosService speakerCosmosService, ITagCosmosService tagCosmosService, IMapper mapper)
        {
            this.speakerCosmosService = speakerCosmosService;
            this.tagCosmosService = tagCosmosService;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public Task<SpeakerDto> Handle(GetSpeakerQuery request, CancellationToken cancellationToken)
        {
            var speaker = this.speakerCosmosService.GetSpeaker(request.SpeakerId).Result;
            var tags = new List<TagDto>();
            if (speaker == null)
            {
                throw new BusinessException("Speaker not found");
            }

            // Get the tag corresponding to each id.
            foreach (var item in speaker.Tags)
            {
                var tag = this.tagCosmosService.GetTag(item).Result;
                if (tag == null)
                {
                    throw new BusinessException("The tag with Identifier '" + item + "' in speaker '" + speaker.Name + "' does not exist ");
                }

                var tagToAdd = this.mapper.Map<TagDto>(tag);
                tags.Add(tagToAdd);
            }

            // Manual creation of the dto because automapper rely on list.
            var speakerDto = new SpeakerDto
            {
                Id = speaker.Id,
                AltIds = speaker.AltIds ?? new List<string>(),
                Enabled = speaker.Enabled,
                Name = speaker.Name,
                Nickname = speaker.Nickname,
                Tags = tags,
            };

            return Task.FromResult<SpeakerDto>(speakerDto);
        }
    }
}
