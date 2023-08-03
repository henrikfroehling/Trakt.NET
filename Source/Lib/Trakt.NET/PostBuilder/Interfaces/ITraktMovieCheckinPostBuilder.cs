namespace TraktNet.PostBuilder
{
    using Objects.Get.Movies;
    using Objects.Post.Checkins;
    using System;

    public interface ITraktMovieCheckinPostBuilder : ITraktCheckinPostBuilder<ITraktMovieCheckinPostBuilder, ITraktMovieCheckinPost>
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktMovieCheckinPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="movie"/>s ids are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithMovie(ITraktMovieIds)"/>.</remarks>
        ITraktMovieCheckinPostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktMovieCheckinPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="movieIds"/>s are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithMovie(ITraktMovie)"/>.</remarks>
        ITraktMovieCheckinPostBuilder WithMovie(ITraktMovieIds movieIds);
    }
}
