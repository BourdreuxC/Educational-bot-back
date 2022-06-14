using EducationalTeamsBotApi.Application.Tags.Queries.GetTagByNameQuery;
using EducationalTeamsBotApi.Application.Tags.Queries.GetTagsQuery;
using EducationalTeamsBotApi.Domain.Entities;
using EducationalTeamsBotApi.Infrastructure.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Moq;

namespace EducationalTeamsBotApi.UnitTests
{
    public class TagTest
    {
        [Fact]
        public async Task Test1()
        {
            // Create the mock data.
            var tags = new[]
            {
             new CosmosTag { Variants = new List<string>{ "php","PHP","Php"}, Id="1" },
             new CosmosTag { Variants = new List<string>{ "c#","C#","CSharp"}, Id="2" },
            }.AsQueryable();

            // Set the mock data as IOrderedQueryable
            var queryable = Enumerable.Empty<CosmosTag>().AsQueryable().OrderBy(a => a.Id);
            queryable.AsEnumerable().Concat(tags);

            //set the mock expected behavior
            var containerMock = new Mock<Container>();
            containerMock.Setup<IOrderedQueryable>(x => x.GetItemLinqQueryable<CosmosTag>(false, null, null, null)).Returns(queryable);

            var tagservice = new TagCosmosService(null, containerMock.Object);
            var queryHandler = new GetTagsQueryHandler(tagservice,null);
            var tagAmount = await queryHandler.Handle(new Application.Pagination.Queries.GetWithPaginationQuery<Application.Dto.TagDto>(), CancellationToken.None);
            Assert.Equal(2, tagAmount.TotalCount);
        }
    }
}