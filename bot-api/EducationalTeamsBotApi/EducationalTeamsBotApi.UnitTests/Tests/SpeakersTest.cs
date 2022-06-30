

namespace EducationalTeamsBotApi.UnitTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using EducationalTeamsBotApi.Application.Dto;
    using EducationalTeamsBotApi.Application.Speakers.Commands.EditSpeakerCommand;
    using EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakersQuery;
    using EducationalTeamsBotApi.Domain.Entities;
    using EducationalTeamsBotApi.UnitTests.MockServices;

    public class SpeakersTest
    {
        [Fact]
        public async Task GetSpeakersTest()
        {
            // Create the mock speakers.
            var speakers = new List<CosmosSpeaker>
            {
             new CosmosSpeaker("guid1") { Tags = new List<string>{ "1","2"} },
             new CosmosSpeaker("guid2") { Tags = new List<string>{ "2"} }
            };

            var speakerService = new SpeakerMockService(speakers);

            // Create the mock tags.
            var tags = new List<CosmosTag>
            {
             new CosmosTag { Variants = new List<string>{ "php","PHP","Php"}, Id="1" },
             new CosmosTag { Variants = new List<string>{ "c#","C#","CSharp"}, Id="2" },
            };

            var tagService = new TagsMockService(tags);

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CosmosSpeaker, SpeakerDto>()
                             .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                             .ForMember(p => p.Name, opt => opt.MapFrom(s => s.Name))
                             .ForMember(p => p.Nickname, opt => opt.MapFrom(s => s.Nickname))
                             .ForMember(p => p.Enabled, opt => opt.MapFrom(s =>   s.Enabled))
                             .ForMember(p => p.TagsIds, opt => opt.MapFrom(s => s.Tags))
                             .ForMember(p => p.AltIds, opt => opt.MapFrom(s => s.AltIds))
                             .ForMember(p => p.Tags, opt => opt.Ignore());

                cfg.CreateMap<CosmosTag, TagDto>()
                             .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                             .ForMember(p => p.Variants, opt => opt.MapFrom(s => s.Variants));
            });
            var mapper = mockMapper.CreateMapper();

            var queryHandler = new GetSpeakersQueryHandler(speakerService, tagService, mapper);
            var result = await queryHandler.Handle(new Application.Pagination.Queries.GetWithPaginationQuery<SpeakerDto>(), CancellationToken.None);

            Assert.True(speakers.Count == result.Items.Count);
            Assert.True(speakers.First().Tags.First() == result.Items.First().Tags.First().Id);
        }

        [Fact]
        public async Task GetSpeakersTestNoSpeaker()
        {
            // Create the mock speakers.
            var speakers = new List<CosmosSpeaker>
            {
            };

            var speakerService = new SpeakerMockService(speakers);


            var tagService = new TagsMockService(new List<CosmosTag>());

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CosmosSpeaker, SpeakerDto>()
                             .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                             .ForMember(p => p.Name, opt => opt.MapFrom(s => s.Name))
                             .ForMember(p => p.Nickname, opt => opt.MapFrom(s => s.Nickname))
                             .ForMember(p => p.Enabled, opt => opt.MapFrom(s => s.Enabled))
                             .ForMember(p => p.TagsIds, opt => opt.MapFrom(s => s.Tags))
                             .ForMember(p => p.AltIds, opt => opt.MapFrom(s => s.AltIds))
                             .ForMember(p => p.Tags, opt => opt.Ignore());

                cfg.CreateMap<CosmosTag, TagDto>()
                             .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                             .ForMember(p => p.Variants, opt => opt.MapFrom(s => s.Variants));
            });
            var mapper = mockMapper.CreateMapper();

            var queryHandler = new GetSpeakersQueryHandler(speakerService, tagService, mapper);
            var result = await queryHandler.Handle(new Application.Pagination.Queries.GetWithPaginationQuery<SpeakerDto>(), CancellationToken.None);

            Assert.Empty(result.Items);
        }
    }
}
