// -----------------------------------------------------------------------
// <copyright file="CosmosUser.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Domain.Entities
{
    /// <summary>
    /// Users (admins) contained in a cosmosDb format.
    /// </summary>
    public class CosmosUser
    {
        /// <summary>
        /// Gets or sets a user's identifier.
        /// </summary>
        public string? Id { get; set; }
    }
}
