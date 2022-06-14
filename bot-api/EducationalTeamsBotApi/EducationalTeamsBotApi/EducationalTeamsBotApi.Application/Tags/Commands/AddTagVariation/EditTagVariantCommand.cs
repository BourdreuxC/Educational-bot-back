// -----------------------------------------------------------------------
// <copyright file="EditTagVariantCommand.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Commands.AddTagVariant
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Command for the tag variant edition.
    /// </summary>
    public class EditTagVariantCommand : IRequest<CosmosTag?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditTagVariantCommand"/> class.
        /// </summary>
        /// <param name="id">Tag identifier.</param>
        /// <param name="variant">Variant.</param>
        public EditTagVariantCommand(string id, string variant)
        {
            this.Id = id;
            this.Variant = variant;
        }

        /// <summary>
        /// Gets or Sets the identifier of the tag.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets the variant ti edit.
        /// </summary>
        public string Variant { get; set; }
    }
}
