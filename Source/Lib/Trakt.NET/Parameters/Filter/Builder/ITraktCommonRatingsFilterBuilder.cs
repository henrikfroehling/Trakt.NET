namespace TraktNet.Parameters
{
    using System;

    public interface ITraktCommonRatingsFilterBuilder<TFilter, TFilterBuilder> : ITraktBasicRatingsFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        /// <summary>Adds the given TMDB rating range, with <paramref name="start"/> and <paramref name="end"/>, to the builder.</summary>
        /// <param name="start">The start value of the TMDB rating range. Maximum value should be 10.0.</param>
        /// <param name="end">The end value of the TMDB rating range. Maximum value should be 10.0.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> is greater than 10.0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="end"/> is greater than 10.0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> value is greater than the given <paramref name="end"/> value.</exception>
        TFilterBuilder WithTMDBRatings(float start, float end);

        /// <summary>Adds the given TMDB vote count range, with <paramref name="start"/> and <paramref name="end"/>, to the builder.</summary>
        /// <param name="start">The start value of the TMDB vote count. Maximum value should be 100000.</param>
        /// <param name="end">The end value of the TMDB vote count. Maximum value should be 100000.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> is greater than 100000.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="end"/> is greater than 100000.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> value is greater than the given <paramref name="end"/> value.</exception>
        TFilterBuilder WithTMDBVotes(uint start, uint end);

        /// <summary>Adds the given IMDB rating range, with <paramref name="start"/> and <paramref name="end"/>, to the builder.</summary>
        /// <param name="start">The start value of the IMDB rating range. Maximum value should be 10.0.</param>
        /// <param name="end">The end value of the IMDB rating range. Maximum value should be 10.0.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> is greater than 10.0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="end"/> is greater than 10.0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> value is greater than the given <paramref name="end"/> value.</exception>
        TFilterBuilder WithIMDBRatings(float start, float end);

        /// <summary>Adds the given IMDB vote count range, with <paramref name="start"/> and <paramref name="end"/>, to the builder.</summary>
        /// <param name="start">The start value of the IMDB vote count. Maximum value should be 3000000.</param>
        /// <param name="end">The end value of the IMDB vote count. Maximum value should be 3000000.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> is greater than 3000000.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="end"/> is greater than 3000000.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> value is greater than the given <paramref name="end"/> value.</exception>
        TFilterBuilder WithIMDBVotes(uint start, uint end);
    }
}
