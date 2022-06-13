// -----------------------------------------------------------------------
// <copyright file="TagDto.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Dto
{
    using AutoMapper;
    using EducationalTeamsBotApi.Application.Common.Mappings;
    using EducationalTeamsBotApi.Domain.Entities;

    /// <summary>
    /// The DTO for a tag.
    /// </summary>
    public class TagDto : IMapFrom<CosmosTag>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagDto"/> class.
        /// </summary>
        public TagDto()
        {
            this.Variants = new List<string>();
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the variants.
        /// </summary>
        public IEnumerable<string> Variants { get; set; }

        /// <summary>
        /// Method to map an entity to a DTO.
        /// </summary>
        /// <param name="profile">The profile for the mapping.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CosmosTag, TagDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.Variants, opt => opt.MapFrom(s => s.Variants));
        }
    }
}
