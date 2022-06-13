// -----------------------------------------------------------------------
// <copyright file="DatabaseConstants.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Constants
{
    /// <summary>
    /// Define database constants.
    /// </summary>
    public static class DatabaseConstants
    {
        /// <summary>
        /// Database connection string environment variable name.
        /// </summary>
        public const string ConnectionString = "COSMOS_CON_STRING";

        /// <summary>
        /// Database name constant.
        /// </summary>
        public const string Database = "DiiageBotDatabase";

        /// <summary>
        /// Answer container name constant.
        /// </summary>
        public const string AnswerContainer = "Answers";

        /// <summary>
        /// Question container name constant.
        /// </summary>
        public const string QuestionContainer = "Questions";

        /// <summary>
        /// Reaction container name constant.
        /// </summary>
        public const string ReactionContainer = "Reactions";

        /// <summary>
        /// Speaker container name constant.
        /// </summary>
        public const string SpeakerContainer = "Speakers";

        /// <summary>
        /// Tag container name constant.
        /// </summary>
        public const string TagContainer = "Tags";

        /// <summary>
        /// User container name constant.
        /// </summary>
        public const string UserContainer = "Users";
    }
}
