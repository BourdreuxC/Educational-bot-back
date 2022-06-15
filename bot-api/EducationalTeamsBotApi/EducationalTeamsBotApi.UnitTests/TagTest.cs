

namespace EducationalTeamsBotApi.UnitTests
{
    using EducationalTeamsBotApi.Application.Tags.Commands.DeleteTagCommand;
    using EducationalTeamsBotApi.CrossCuting;
    using EducationalTeamsBotApi.Domain.Entities;
    using EducationalTeamsBotApi.UnitTests.MockServices;

    public class TagTest
    {
        [Fact]
        public async Task DeleteTagTest()
        {
            // Create the mock tags.
            var tags = new List<CosmosTag>
            {
             new CosmosTag { Variants = new List<string>{ "php","PHP","Php"}, Id="1" },
             new CosmosTag { Variants = new List<string>{ "c#","C#","CSharp"}, Id="2" },
            };

            const string idTagToDelete = "2";
            var tagService = new TagsMockService(tags);

            // Create the mock speakers.
            var speakers = new List<CosmosSpeaker>
            {
             new CosmosSpeaker("1") { Tags = new List<string>{ "1","2"} },
             new CosmosSpeaker("2") { Tags = new List<string>{ "2"} }
            };
            var amountOfSpeakerWithTag2 = speakers.Where(s => s.Tags.Contains(idTagToDelete));
            var speakerService = new SpeakerMockService(speakers);

            var deletedTag = tags.FirstOrDefault(tags => tags.Id == idTagToDelete);
            Assert.True(deletedTag != null);

            var commandHandler = new DeleteTagCommandHandler(tagService, speakerService);
            var result = await commandHandler.Handle(new DeleteTagCommand(idTagToDelete),CancellationToken.None);

            deletedTag = tags.FirstOrDefault(tags => tags.Id == idTagToDelete);
            Assert.True(deletedTag == null);

            amountOfSpeakerWithTag2 = speakers.Where(s => s.Tags.Contains(idTagToDelete));
            Assert.Empty(amountOfSpeakerWithTag2);
        }

        [Fact]
        public async Task DeleteTagTestTagDontExist()
        {
            // Create the mock tags.
            var tags = new List<CosmosTag>
            {
             new CosmosTag { Variants = new List<string>{ "php","PHP","Php"}, Id="1" },
             new CosmosTag { Variants = new List<string>{ "c#","C#","CSharp"}, Id="2" },
            };

            const string idTagToDelete = "3";
            var tagService = new TagsMockService(tags);

            // Create the mock speakers.
            var speakers = new List<CosmosSpeaker>
            {
             new CosmosSpeaker("1") { Tags = new List<string>{ "1","2"} },
             new CosmosSpeaker("2") { Tags = new List<string>{ "2"} }
            };
            var amountOfSpeakerWithTag2 = speakers.Where(s => s.Tags.Contains(idTagToDelete));
            var speakerService = new SpeakerMockService(speakers);



            var commandHandler = new DeleteTagCommandHandler(tagService, speakerService);
            try
            { 
                // The handler should trigger an exception.
                var result = await commandHandler.Handle(new DeleteTagCommand(idTagToDelete), CancellationToken.None);
                Assert.True(false);
            }
            catch (BusinessException e)
            {
                Assert.Equal("Tag id '" + idTagToDelete + "' was not found for deletion", e.Message);
            }

        }

        [Fact]
        public async Task DeleteTagTestNoSpeakers()
        {
            // Create the mock tags.
            var tags = new List<CosmosTag>
            {
             new CosmosTag { Variants = new List<string>{ "php","PHP","Php"}, Id="1" },
             new CosmosTag { Variants = new List<string>{ "c#","C#","CSharp"}, Id="2" },
            };

            const string idTagToDelete = "1";
            var tagService = new TagsMockService(tags);

            // Create the mock speakers.
            var speakers = new List<CosmosSpeaker>
            {
             new CosmosSpeaker("1") { Tags = new List<string>{ "2"} },
             new CosmosSpeaker("2") { Tags = new List<string>{ "2"} }
            };
            var amountOfSpeakerWithTag2 = speakers.Where(s => s.Tags.Contains(idTagToDelete));
            var speakerService = new SpeakerMockService(speakers);


            var deletedTag = tags.FirstOrDefault(tags => tags.Id == idTagToDelete);
            Assert.True(deletedTag != null);

            var commandHandler = new DeleteTagCommandHandler(tagService, speakerService);
            var result = await commandHandler.Handle(new DeleteTagCommand(idTagToDelete), CancellationToken.None);

            deletedTag = tags.FirstOrDefault(tags => tags.Id == idTagToDelete);
            Assert.True(deletedTag == null);

            amountOfSpeakerWithTag2 = speakers.Where(s => s.Tags.Contains(idTagToDelete));
            Assert.Empty(amountOfSpeakerWithTag2);
        }
    }
}