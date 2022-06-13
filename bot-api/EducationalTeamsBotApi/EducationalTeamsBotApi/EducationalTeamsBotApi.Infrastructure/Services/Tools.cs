// -----------------------------------------------------------------------
// <copyright file="Tools.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    /// <summary>
    /// Tools class allowing to convert data to <see cref="IEnumerable"/>.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Converts a <see cref="IEnumerator{T}"/> to a <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of elements of the list.</typeparam>
        /// <param name="enumerator">Enumerator to transform.</param>
        /// <returns>A <see cref="IEnumerable{T}"/>.</returns>
        public static IEnumerable<T> ToIEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}
