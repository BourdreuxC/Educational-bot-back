﻿// -----------------------------------------------------------------------
// <copyright file="QuestionInputDto.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Dto
{
    /// <summary>
    /// A query DTO.
    /// </summary>
    public class QuestionInputDto
    {
        /// <summary>
        /// Gets or sets the content of the request.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// List of tags provided in the message.
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
