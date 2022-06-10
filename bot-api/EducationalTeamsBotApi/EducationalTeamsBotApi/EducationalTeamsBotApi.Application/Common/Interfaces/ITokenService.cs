// -----------------------------------------------------------------------
// <copyright file="ITokenService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    /// <summary>
    /// Interface auth token.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        string? Token { get; }
    }
}
