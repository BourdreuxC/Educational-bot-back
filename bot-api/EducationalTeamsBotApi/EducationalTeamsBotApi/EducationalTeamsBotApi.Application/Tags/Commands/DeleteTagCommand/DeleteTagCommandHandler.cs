// -----------------------------------------------------------------------
// <copyright file="DeleteTagCommandHandler.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Tags.Commands.DeleteTagCommand
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Command handler for tag deletion.
    /// </summary>
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Unit>
    {
        /// <summary>
        /// Tag service.
        /// </summary>
        private readonly ITagCosmosService tagService;

        /// <summary>
        /// speaker service.
        /// </summary>
        private readonly ISpeakerCosmosService speakerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTagCommandHandler"/> class.
        /// </summary>
        /// <param name="tagService">Service of the tags.</param>
        /// <param name="tagService">Service of the speakers.</param>
        public DeleteTagCommandHandler(ITagCosmosService tagService, ISpeakerCosmosService speakerService)
        {
            this.tagService = tagService;
            this.speakerService = speakerService;
        }

        /// <summary>
        /// Handler of the tag deletion.
        /// </summary>
        /// <param name="request">Delete request.</param>
        /// <param name="cancellationToken">Token of cancellation.</param>
        /// <returns>A Unit.</returns>
        Task<Unit> IRequestHandler<DeleteTagCommand, Unit>.Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            this.speakerService.RemoveTagFromSpeakers(request.Id);
            return this.tagService.DeleteTag(request.Id);
        }
    }
}
