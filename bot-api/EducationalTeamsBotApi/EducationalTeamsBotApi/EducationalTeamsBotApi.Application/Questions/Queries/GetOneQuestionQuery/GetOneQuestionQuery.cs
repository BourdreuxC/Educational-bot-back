// -----------------------------------------------------------------------
// <copyright file="GetOneQuestionQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Questions.Queries.GetOneQuestionQuery
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    public class GetOneQuestionQuery : IRequest<CosmosQuestion>
    {
    }
}
