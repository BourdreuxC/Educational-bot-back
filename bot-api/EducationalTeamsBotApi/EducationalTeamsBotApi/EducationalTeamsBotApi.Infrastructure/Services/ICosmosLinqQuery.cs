// -----------------------------------------------------------------------
// <copyright file="ICosmosLinqQuery.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos;

    public interface ICosmosLinqQuery
    {
        FeedIterator<T> GetFeedIterator<T>(IQueryable<T> query);
    }
}