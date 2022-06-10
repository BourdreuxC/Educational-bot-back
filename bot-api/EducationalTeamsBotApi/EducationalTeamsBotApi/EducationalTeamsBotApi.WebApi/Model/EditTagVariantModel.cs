// -----------------------------------------------------------------------
// <copyright file="EditTagVariantModel.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Model
{
    /// <summary>
    /// Model for the edition of the tag variant.
    /// </summary>
    public class EditTagVariantModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditTagVariantModel"/> class.
        /// </summary>
        /// <param name="id">Identifier of the tag to edit.</param>
        /// <param name="variant">variant to edit.</param>
        public EditTagVariantModel(string id, string variant)
        {
            this.Id = id;
            this.Variant = variant;
        }

        /// <summary>
        /// Gets or Sets Identifier of the tag.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Variant to edit.
        /// </summary>
        public string Variant { get; set; }
    }
}
