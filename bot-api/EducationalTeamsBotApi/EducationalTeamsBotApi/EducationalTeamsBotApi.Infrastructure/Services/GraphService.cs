// -----------------------------------------------------------------------
// <copyright file="GraphService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Azure.Identity;
    using EducationalTeamsBotApi.Application.Common.Constants;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Graph;
    using Microsoft.Identity.Client;

    /// <summary>
    /// Class that will interact with Graph API.
    /// </summary>
    public class GraphService : IGraphService
    {
        /// <summary>
        /// Graph service client.
        /// </summary>
        private readonly GraphServiceClient graphServiceClient;

        /// <summary>
        /// Configuration.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphService"/> class.
        /// </summary>
        /// <param name="configuration">Configuration to use.</param>
        /// <param name="tokenService">Token.</param>
        public GraphService(IConfiguration configuration, ITokenService tokenService)
        {
            this.configuration = configuration;
            var scopes = GraphConstants.Scopes;
            var tenantId = this.configuration[GraphConstants.TenantId];
            var clientId = this.configuration[GraphConstants.ClientId];
            var clientSecret = this.configuration[GraphConstants.ClientSecret];

            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            };

            var cca = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithTenantId(tenantId)
                .WithClientSecret(clientSecret)
                .Build();

            var authProvider = new DelegateAuthenticationProvider((request) =>
            {
                request.Headers.Authorization =
                  new System.Net.Http.Headers.AuthenticationHeaderValue(GraphConstants.TokenScheme, tokenService.Token);

                return Task.CompletedTask;
            });

            this.graphServiceClient = new GraphServiceClient(authProvider);
        }

        /// <inheritdoc/>
        public bool AddUserToTeam(string teamId, string userId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<object> GetMessageAnswers(string teamId, string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Team>> GetJoinedTeams()
        {
            var teams = new List<Team>();

            var requestResult = await this.graphServiceClient.Me.JoinedTeams
                .Request()
                .GetAsync();

            teams.AddRange(requestResult);

            return teams;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Channel>> GetTeamChannels(string teamId)
        {
            var channels = new List<Channel>();

            var requestResult = await this.graphServiceClient.Teams[teamId].Channels
                .Request()
                .GetAsync();

            channels.AddRange(requestResult);

            return channels;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ChatMessage>> GetChannelMessages(string teamId, string channelId)
        {
            var messages = new List<ChatMessage>();

            var requestResult = await this.graphServiceClient.Teams[teamId].Channels[channelId].Messages
                .Request()
                .GetAsync();

            messages.AddRange(requestResult);

            return messages;
        }

        /// <inheritdoc/>
        public List<Message> GetUnansweredMessages(string teamId, string channelId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = new List<User>();

            var requestResult = await this.graphServiceClient.Users
                .Request()
                .GetAsync();

            users.AddRange(requestResult);

            return users;
        }

        /// <inheritdoc/>
        public bool RemoveUserFromTeam(string teamId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
