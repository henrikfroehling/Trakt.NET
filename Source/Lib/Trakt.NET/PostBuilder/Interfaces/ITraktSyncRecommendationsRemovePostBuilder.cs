namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;

    public interface ITraktSyncRecommendationsRemovePostBuilder
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncRecommendationsRemovePostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncRecommendationsRemovePostBuilder WithMovie(ITraktMovieIds movieIds);

        /// <summary>Adds the given <paramref name="movies"/> collection to the builder.</summary>
        /// <param name="movies">A collection of <see cref="ITraktMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movies"/> is null.</exception>
        ITraktSyncRecommendationsRemovePostBuilder WithMovies(IEnumerable<ITraktMovie> movies);

        /// <summary>Adds the given <paramref name="movieIds"/> collection to the builder.</summary>
        /// <param name="movieIds">A collection of <see cref="ITraktMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncRecommendationsRemovePostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncRecommendationsRemovePostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncRecommendationsRemovePostBuilder WithShow(ITraktShowIds showIds);

        /// <summary>Adds the given <paramref name="shows"/> collection to the builder.</summary>
        /// <param name="shows">A collection of <see cref="ITraktShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="shows"/> is null.</exception>
        ITraktSyncRecommendationsRemovePostBuilder WithShows(IEnumerable<ITraktShow> shows);

        /// <summary>Adds the given <paramref name="showIds"/> collection to the builder.</summary>
        /// <param name="showIds">A collection of <see cref="ITraktShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncRecommendationsRemovePostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);

        /// <summary>Creates a new <see cref="ITraktSyncRecommendationsRemovePost" /> instance with the added movies and shows.</summary>
        /// <returns>A new <see cref="ITraktSyncRecommendationsRemovePost" /> instance with the added movies and shows.</returns>
        ITraktSyncRecommendationsRemovePost Build();
    }
}
