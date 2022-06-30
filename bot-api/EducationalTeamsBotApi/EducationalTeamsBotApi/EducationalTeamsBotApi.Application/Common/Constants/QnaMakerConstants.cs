// -----------------------------------------------------------------------
// <copyright file="QnaMakerConstants.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Constants
{
    /// <summary>
    /// Define QNA maker constants.
    /// </summary>
    public static class QnaMakerConstants
    {
        /// <summary>
        /// Key to get in configuration to get authoring key.
        /// </summary>
        public const string AuthoringKey = "QnaMaker:AuthoringKey";

        /// <summary>
        /// Key to get in configuration to get authoring URL.
        /// </summary>
        public const string AuthoringUrl = "QnaMaker:AuthoringUrl";

        /// <summary>
        /// Key to get the default message when there is no answer and speaker corresponding to the question.
        /// </summary>
        public const string NotFoundResult = "Pas de solution mais je reste à l'écoute.";
    }
}
