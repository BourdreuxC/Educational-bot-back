// -----------------------------------------------------------------------
// <copyright file="AddTagCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Commands.AddTagCommand
{
    using System.Collections.Generic;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Add tag command.
    /// </summary>
    public class AddTagCommand : IRequest<CosmosTag?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTagCommand"/> class.
        /// </summary>
        /// <param name="variants">Variants of the tag.</param>
        public AddTagCommand(List<string> variants)
        {
            this.Variants = variants;
        }

        /// <summary>
        /// Gets or Sets the list of variants of a new tag.
        /// </summary>
        public List<string> Variants { get; set; }
    }
}
