// -----------------------------------------------------------------------
// <copyright file="QuestionDto.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Dto
{
    using AutoMapper;
    using EducationalTeamsBotApi.Application.Common.Mappings;
    using EducationalTeamsBotApi.Domain.Entities;

    /// <summary>
    /// The DTO for a question.
    /// </summary>
    public class QuestionDto : IMapFrom<CosmosQuestion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionDto"/> class.
        /// </summary>
        public QuestionDto()
        {
            this.Tags = new List<string>();
            this.Answers = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionDto"/> class.
        /// </summary>
        /// <param name="id">Question Id.</param>
        /// <param name="content">Question content.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="tags">Question associated tags.</param>
        /// <param name="answers">Questions answers.</param>
        public QuestionDto(string id, string content, string userId, IEnumerable<string> tags, IEnumerable<string> answers)
        {
            this.Id = id;
            this.Content = content;
            this.UserId = userId;
            this.Tags = tags;
            this.Answers = answers;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        public IEnumerable<string> Answers { get; set; }

        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// Method to map an entity to a DTO.
        /// </summary>
        /// <param name="profile">The profile for the mapping.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CosmosQuestion, QuestionDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.Content, opt => opt.MapFrom(s => s.Content))
                .ForMember(p => p.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(p => p.Tags, opt => opt.MapFrom(s => s.AssociatedTags))
                .ForMember(p => p.Answers, opt => opt.MapFrom(s => s.Answers));
        }
    }
}
