// -----------------------------------------------------------------------
// <copyright file="GetSpeakersQueryHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakersQuery
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler for the query that will get speakers.
    /// </summary>
    public class GetSpeakersQueryHandler : IRequestHandler<GetSpeakersQuery, IEnumerable<CosmosSpeaker>>
    {
        /// <summary>
        /// Speaker cosmos service used in this class.
        /// </summary>
        private readonly ISpeakerCosmosService speakerCosmosService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSpeakersQueryHandler"/> class.
        /// </summary>
        /// <param name="speakerCosmosService">Injection.</param>
        public GetSpeakersQueryHandler(ISpeakerCosmosService speakerCosmosService)
        {
            this.speakerCosmosService = speakerCosmosService;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosSpeaker>> Handle(GetSpeakersQuery request, CancellationToken cancellationToken)
        {
            return this.speakerCosmosService.GetCosmosSpeakers();
        }
    }
}
