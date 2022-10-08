namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;

    public interface ITraktSyncRecommendationsPostBuilder
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncRecommendationsPostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncRecommendationsPostBuilder WithMovie(ITraktMovieIds movieIds);

        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="movie"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncRecommendationsPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes);

        /// <summary>Adds the given <paramref name="movieWithNotes"/> to the builder.</summary>
        /// <param name="movieWithNotes">The <see cref="MovieWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="movieWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncRecommendationsPostBuilder WithMovieWithNotes(MovieWithNotes movieWithNotes);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="movieIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncRecommendationsPostBuilder WithMovieWithNotes(ITraktMovieIds movieIds, string notes);

        /// <summary>Adds the given <paramref name="movieIdsWithNotes"/> to the builder.</summary>
        /// <param name="movieIdsWithNotes">The <see cref="MovieIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="movieIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncRecommendationsPostBuilder WithMovieWithNotes(MovieIdsWithNotes movieIdsWithNotes);

        /// <summary>Adds the given <paramref name="movies"/> collection to the builder.</summary>
        /// <param name="movies">A collection of <see cref="ITraktMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movies"/> is null.</exception>
        ITraktSyncRecommendationsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);

        /// <summary>Adds the given <paramref name="movieIds"/> collection to the builder.</summary>
        /// <param name="movieIds">A collection of <see cref="ITraktMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncRecommendationsPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);

        /// <summary>Adds the given <paramref name="moviesWithNotes"/> collection to the builder.</summary>
        /// <param name="moviesWithNotes">A collection of <see cref="MovieWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="moviesWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="moviesWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="moviesWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncRecommendationsPostBuilder WithMoviesWithNotes(IEnumerable<MovieWithNotes> moviesWithNotes);

        /// <summary>Adds the given <paramref name="movieIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="movieIdsWithNotes">A collection of <see cref="MovieIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="movieIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="movieIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncRecommendationsPostBuilder WithMoviesWithNotes(IEnumerable<MovieIdsWithNotes> movieIdsWithNotes);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncRecommendationsPostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncRecommendationsPostBuilder WithShow(ITraktShowIds showIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="show"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncRecommendationsPostBuilder WithShowWithNotes(ITraktShow show, string notes);

        /// <summary>Adds the given <paramref name="showWithNotes"/> to the builder.</summary>
        /// <param name="showWithNotes">The <see cref="ShowWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncRecommendationsPostBuilder WithShowWithNotes(ShowWithNotes showWithNotes);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="showIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncRecommendationsPostBuilder WithShowWithNotes(ITraktShowIds showIds, string notes);

        /// <summary>Adds the given <paramref name="showIdsWithNotes"/> to the builder.</summary>
        /// <param name="showIdsWithNotes">The <see cref="ShowIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncRecommendationsPostBuilder WithShowWithNotes(ShowIdsWithNotes showIdsWithNotes);

        /// <summary>Adds the given <paramref name="shows"/> collection to the builder.</summary>
        /// <param name="shows">A collection of <see cref="ITraktShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="shows"/> is null.</exception>
        ITraktSyncRecommendationsPostBuilder WithShows(IEnumerable<ITraktShow> shows);

        /// <summary>Adds the given <paramref name="showIds"/> collection to the builder.</summary>
        /// <param name="showIds">A collection of <see cref="ITraktShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncRecommendationsPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);

        /// <summary>Adds the given <paramref name="showsWithNotes"/> collection to the builder.</summary>
        /// <param name="showsWithNotes">A collection of <see cref="ShowWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncRecommendationsPostBuilder WithShowsWithNotes(IEnumerable<ShowWithNotes> showsWithNotes);

        /// <summary>Adds the given <paramref name="showIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="showIdsWithNotes">A collection of <see cref="ShowIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRecommendationsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncRecommendationsPostBuilder WithShowsWithNotes(IEnumerable<ShowIdsWithNotes> showIdsWithNotes);

        /// <summary>Creates a new <see cref="ITraktSyncRecommendationsPost" /> instance with the added movies and shows.</summary>
        /// <returns>A new <see cref="ITraktSyncRecommendationsPost" /> instance with the added movies and shows.</returns>
        ITraktSyncRecommendationsPost Build();
    }
}
