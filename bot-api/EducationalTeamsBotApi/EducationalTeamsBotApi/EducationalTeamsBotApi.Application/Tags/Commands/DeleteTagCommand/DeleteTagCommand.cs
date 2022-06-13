// -----------------------------------------------------------------------
// <copyright file="DeleteTagCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Commands.DeleteTagCommand
{
    using MediatR;

    /// <summary>
    /// Command to delete the tag.
    /// </summary>
    public class DeleteTagCommand : IRequest<Unit>
    {
        /// <summary>
        /// Gets or Sets the identifier of the tag.
        /// </summary>
        public string? Id { get; set; }
    }
}
