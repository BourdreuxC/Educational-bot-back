using EducationalTeamsBotApi.Infrastructure.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

public class CosmosLinqQuery : ICosmosLinqQuery
{
    public FeedIterator<T> GetFeedIterator<T>(IQueryable<T> query)
    {
        return query.ToFeedIterator();
    }
}