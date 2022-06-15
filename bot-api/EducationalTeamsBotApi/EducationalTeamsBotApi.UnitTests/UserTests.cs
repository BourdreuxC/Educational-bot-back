// -----------------------------------------------------------------------
// <copyright file="UserTests.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.UnitTests
{
    using EducationalTeamsBotApi.Application.Users.Queries.GetUsersQuery;
    using EducationalTeamsBotApi.Infrastructure.Services;
    using Microsoft.Graph;
    using Moq;

    /// <summary>
    /// Test class for users handlers.
    /// </summary>
    public class UserTests
    {
        /// <summary>
        /// Tests the <see cref="GetUsersQueryHandler"/>.
        /// </summary>
        [Fact]
        public async Task GetUsersQueryHandlerTest()
        {
            // Create a collection of users
            IGraphServiceUsersCollectionPage users = new GraphServiceUsersCollectionPage
            {
                 new User
                 {
                    Id = "c193c120-8de1-48cd-8c04-dd691448c1b6",
                    DisplayName = "Benjamin Sorriaux",
                    GivenName = "Benjamin",
                    Surname = "Sorriaux",
                    Mail = "benjamin.sorriaux@grevord.onmicrosoft.com",
                 }
            };

            // Mock a GraphServiceClient
            var mockAuthProvider = new Mock<IAuthenticationProvider>();
            var mockHttpProvider = new Mock<IHttpProvider>();
            var mockGraphClient = new Mock<GraphServiceClient>(mockAuthProvider.Object, mockHttpProvider.Object);

            // Setup client to return the collection of users
            mockGraphClient.Setup(g => g.Users
                .Request()
                .GetAsync(CancellationToken.None))
                .ReturnsAsync(users);

            // Instanciate a GraphService
            var graphService = new GraphService(mockGraphClient.Object);

            // Instanciate a GetUsersQueryHandler
            var handler = new GetUsersQueryHandler(graphService);

            // Handle a GetUsersQuery
            var result = await handler.Handle(new GetUsersQuery(), CancellationToken.None);

            // Check if first value of the result corresponds to the first element of the users collection
            Assert.Equal(users.First().Id, result.First().Id);
        }
    }
}
