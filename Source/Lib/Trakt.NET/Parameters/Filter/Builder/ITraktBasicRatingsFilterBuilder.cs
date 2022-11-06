namespace TraktNet.Parameters
{
    using System;

    public interface ITraktBasicRatingsFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        /// <summary>Adds the given Trakt rating range, with <paramref name="start"/> and <paramref name="end"/>, to the builder.</summary>
        /// <param name="start">The start value of the Trakt rating range. Maximum value should be 100.</param>
        /// <param name="end">The end value of the Trakt rating range. Maximum value should be 100.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> is greater than 100.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="end"/> is greater than 100.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> value is greater than the given <paramref name="end"/> value.</exception>
        TFilterBuilder WithRatings(uint start, uint end);

        /// <summary>Adds the given Trakt vote count range, with <paramref name="start"/> and <paramref name="end"/>, to the builder.</summary>
        /// <param name="start">The start value of the Trakt vote count. Maximum value should be 100000.</param>
        /// <param name="end">The end value of the Trakt vote count. Maximum value should be 100000.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> is greater than 100000.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="end"/> is greater than 100000.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> value is greater than the given <paramref name="end"/> value.</exception>
        TFilterBuilder WithVotes(uint start, uint end);
    }
}
