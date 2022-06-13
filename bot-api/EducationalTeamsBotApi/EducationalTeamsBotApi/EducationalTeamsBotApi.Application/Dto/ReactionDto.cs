// -----------------------------------------------------------------------
// <copyright file="ReactionDto.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Dto
{
    using AutoMapper;
    using EducationalTeamsBotApi.Application.Common.Mappings;
    using EducationalTeamsBotApi.Domain.Entities;

    /// <summary>
    /// The DTO for a reaction.
    /// </summary>
    public class ReactionDto : IMapFrom<CosmosReaction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReactionDto"/> class.
        /// </summary>
        public ReactionDto()
        {
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the ReactionId.
        /// </summary>
        public string? ReactionId { get; set; }

        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        public int? Value { get; set; }

        /// <summary>
        /// Method to map an entity to a DTO.
        /// </summary>
        /// <param name="profile">The profile for the mapping.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CosmosReaction, ReactionDto>()
                .ForMember(r => r.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(r => r.Value, opt => opt.MapFrom(e => e.Value))
                .ForMember(r => r.ReactionId, opt => opt.MapFrom(e => e.ReactionId));
        }
    }
}
