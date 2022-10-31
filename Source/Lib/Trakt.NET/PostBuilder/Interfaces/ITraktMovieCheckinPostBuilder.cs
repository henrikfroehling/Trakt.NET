namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Checkins;

    public interface ITraktMovieCheckinPostBuilder : ITraktCheckinPostBuilder<ITraktMovieCheckinPostBuilder, ITraktMovieCheckinPost>
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktMovieCheckinPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="movie"/>s ids are not valid.</exception>
        ITraktMovieCheckinPostBuilder WithMovie(ITraktMovie movie);
    }
}
