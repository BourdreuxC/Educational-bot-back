// -----------------------------------------------------------------------
// <copyright file="ApiBaseController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Common.Security;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Abstract class controller to define <see cref="ISender"/>.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        /// <summary>
        /// Send interface to use.
        /// </summary>
        private ISender? mediator;

        /// <summary>
        /// Gets the <see cref="ISender"/>.
        /// </summary>
        protected ISender Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<ISender>();
    }
}
