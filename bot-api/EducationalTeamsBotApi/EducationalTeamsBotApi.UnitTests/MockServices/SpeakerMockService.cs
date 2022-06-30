

namespace EducationalTeamsBotApi.UnitTests.MockServices
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.CrossCuting;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    public class SpeakerMockService : ISpeakerCosmosService
    {

        public List<CosmosSpeaker> Speakers { get; set; }

        public SpeakerMockService(List<CosmosSpeaker> speakers)
        {
            this.Speakers = speakers;
        }


        public Task<CosmosSpeaker?> AddSpeaker(CosmosSpeaker speaker)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> DeleteSpeaker(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CosmosSpeaker?> EditSpeaker(CosmosSpeaker speaker)
        {
             var existingSpeaker = this.GetSpeaker(speaker.Id).Result;

            if (existingSpeaker == null)
            {
                throw new BusinessException("Speaker not found");
            }

            existingSpeaker = speaker;

            return Task.FromResult((CosmosSpeaker?) existingSpeaker);

        }

        public Task<CosmosSpeaker?> EnableSpeaker(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<CosmosSpeaker>> GetCosmosSpeakers()
        {

            return Task.FromResult(Speakers.AsQueryable());
        }

        public Task<CosmosSpeaker?> GetSpeaker(string id)
        {
            var speaker = Speakers.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(speaker);
        }

        public async Task<Unit> RemoveTagFromSpeakers(string id)
        {
            var speakersWithTag = Speakers.Where(s => s.Tags.Contains(id));

            IEnumerable<string> tagList;
            CosmosSpeaker? speaker;
            foreach (var item in speakersWithTag)
            {
                speaker = await this.GetSpeaker(item.Id);
                if (speaker == null)
                {
                    continue;
                }

                tagList = item.Tags.Where(t => t != id);
                speaker.Tags = tagList;
                await this.EditSpeaker(speaker);
            }

            return default;
        }
    }
}
