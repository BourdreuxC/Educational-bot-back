// -----------------------------------------------------------------------
// <copyright file="ApplicationDbContextFactory.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Factory
{
    using EducationalTeamsBotApi.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// Class Factory for the <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// Creates a <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>Returns a <see cref="ApplicationDbContext"/>.</returns>
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            return new ApplicationDbContext(optionsBuilder.Options, null, null);
        }
    }
}
