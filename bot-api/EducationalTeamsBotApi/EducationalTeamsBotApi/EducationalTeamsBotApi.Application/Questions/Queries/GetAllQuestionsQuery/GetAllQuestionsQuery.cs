// -----------------------------------------------------------------------
// <copyright file="GetAllQuestionsQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Questions.Queries.GetAllQuestionsQuery
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Get the list of questions.
    /// </summary>
    public class GetAllQuestionsQuery : IRequest<IEnumerable<CosmosQuestion>>
    {
    }
}
