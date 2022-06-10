// -----------------------------------------------------------------------
// <copyright file="ValueObject.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Domain.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Abstract class value object.
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// Determine if the value object is equal to the object.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>Returns a <see cref="bool"/>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// Gets the hash code of the value object.
        /// </summary>
        /// <returns>Returns a <see cref="int"/>.</returns>
        public override int GetHashCode()
        {
            return this.GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Check if the value objects are equals.
        /// </summary>
        /// <param name="left">First value object.</param>
        /// <param name="right">Second value object.</param>
        /// <returns>Returns a <see cref="bool"/>.</returns>
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return left?.Equals(right) != false;
        }

        /// <summary>
        /// Check if the value objects are not equals.
        /// </summary>
        /// <param name="left">First value object.</param>
        /// <param name="right">Second value object.</param>
        /// <returns>Returns a <see cref="bool"/>.</returns>
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        /// <summary>
        /// Returns the equality components.
        /// </summary>
        /// <returns>Returns <see cref="IEnumerable{object}"/>.</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();
    }
}
