namespace TraktNet.Parameters
{
    using System;

    public interface ITraktMovieRatingsFilterBuilder : ITraktCommonRatingsFilterBuilder<ITraktMovieFilter, ITraktMovieFilterBuilder>
    {
        /// <summary>Adds the given Rotten Tomatoes meter range, with <paramref name="start"/> and <paramref name="end"/>, to the builder.</summary>
        /// <param name="start">The start value of the Rotten Tomatoes meter range. Maximum value should be 100.0.</param>
        /// <param name="end">The end value of the Rotten Tomatoes meter range. Maximum value should be 100.0.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktMovieFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> is greater than 100.0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="end"/> is greater than 100.0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> value is greater than the given <paramref name="end"/> value.</exception>
        ITraktMovieFilterBuilder WithRottenTomatoesMeter(float start, float end);

        /// <summary>Adds the given Metacritic score range, with <paramref name="start"/> and <paramref name="end"/>, to the builder.</summary>
        /// <param name="start">The start value of the Metacritic score range. Maximum value should be 100.0.</param>
        /// <param name="end">The end value of the Metacritic score range. Maximum value should be 100.0.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktMovieFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> is greater than 100.0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="end"/> is greater than 100.0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> value is greater than the given <paramref name="end"/> value.</exception>
        ITraktMovieFilterBuilder WithMetascores(float start, float end);
    }
}
