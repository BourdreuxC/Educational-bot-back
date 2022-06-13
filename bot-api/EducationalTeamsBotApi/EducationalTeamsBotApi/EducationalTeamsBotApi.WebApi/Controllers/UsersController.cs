// -----------------------------------------------------------------------
// <copyright file="UsersController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Users.Queries.GetUsersQuery;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller allowing to interact with users.
    /// </summary>
    [ApiController]
    public class UsersController : ApiBaseController
    {
        /// <summary>
        /// Gets the list of all users.
        /// </summary>
        /// <returns>A list of users.</returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var test = await this.Mediator.Send(new GetUsersQuery());
            return this.Ok(test);
        }
    }
}
