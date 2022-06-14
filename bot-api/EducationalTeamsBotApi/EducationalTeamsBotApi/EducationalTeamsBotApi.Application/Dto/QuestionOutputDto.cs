// -----------------------------------------------------------------------
// <copyright file="QuestionOutputDto.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Application.Dto
{
    /// <summary>
    /// The question answer DTO
    /// </summary>
    public class QuestionOutputDto
    {
        /// <summary>
        /// Gets or sets the answer of the question if exist.
        /// </summary>
        public string? Answer { get; set; }

        /// <summary>
        /// Gets or sets the user to mention if needed.
        /// </summary>
        public List<string>? Mentions { get; set; }
    }
}
