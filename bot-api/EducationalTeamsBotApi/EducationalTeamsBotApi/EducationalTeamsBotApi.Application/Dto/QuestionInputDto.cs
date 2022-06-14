// -----------------------------------------------------------------------
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
        /// Initializes a new instance of the <see cref="QuestionInputDto"/> class.
        /// </summary>
        public QuestionInputDto()
        {
            this.Message = string.Empty;
            this.Tags = new List<string>();
        }

        /// <summary>
        /// Gets or sets the content of the request.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a list of tags provided in the message.
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
