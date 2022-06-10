// -----------------------------------------------------------------------
// <copyright file="SpeakerDto.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Dto
{
    using AutoMapper;
    using EducationalTeamsBotApi.Application.Common.Mappings;
    using EducationalTeamsBotApi.Domain.Entities;

    /// <summary>
    /// The DTO for a speaker.
    /// </summary>
    public class SpeakerDto : IMapFrom<CosmosSpeaker>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpeakerDto"/> class.
        /// </summary>
        public SpeakerDto()
        {
            this.AltIds = new HashSet<string>();
            this.Tags = new HashSet<string>();
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the nickname.
        /// </summary>
        public string? Nickname { get; set; }

        /// <summary>
        /// Gets or sets the status of the speaker | not required.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the alternative identifiers.
        /// </summary>
        public IEnumerable<string> AltIds { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Method to map an entity to a DTO.
        /// </summary>
        /// <param name="profile">The profile for the mapping.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CosmosSpeaker, SpeakerDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(p => p.Nickname, opt => opt.MapFrom(s => s.Nickname))
                .ForMember(p => p.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(p => p.Tags, opt => opt.MapFrom(s => s.Tags))
                .ForMember(p => p.AltIds, opt => opt.MapFrom(s => s.AltIds));
        }
    }
}
