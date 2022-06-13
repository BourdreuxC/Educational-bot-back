// -----------------------------------------------------------------------
// <copyright file="GraphConstants.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Constants
{
    /// <summary>
    /// Define Graph API constants.
    /// </summary>
    public static class GraphConstants
    {
        /// <summary>
        /// Key of configuration corresponding to the tenant ID of the application using Graph.
        /// </summary>
        public const string TenantId = "AzureAd:TenantId";

        /// <summary>
        /// Key of configuration corresponding to the client ID of the application using Graph.
        /// </summary>
        public const string ClientId = "AzureAd:ClientId";

        /// <summary>
        /// Key of configuration corresponding to the client secret of application using Graph.
        /// </summary>
        public const string ClientSecret = "AzureAd:ClientSecret";

        /// <summary>
        /// Token scheme used to request Graph API.
        /// </summary>
        public const string TokenScheme = "Bearer";

        /// <summary>
        /// Key of configuration corresponding to the authorized scopes of the application using Graph.
        /// </summary>
        public static readonly string[] Scopes = { "User.Read" };
    }
}
