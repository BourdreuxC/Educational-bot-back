// -----------------------------------------------------------------------
// <copyright file="IMapFrom.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Mappings
{
    using AutoMapper;

    /// <summary>
    /// Interface mapper.
    /// </summary>
    /// <typeparam name="T">Type to map.</typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Creates a Map.
        /// </summary>
        /// <param name="profile">Profile of mapping.</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), this.GetType());
    }
}
