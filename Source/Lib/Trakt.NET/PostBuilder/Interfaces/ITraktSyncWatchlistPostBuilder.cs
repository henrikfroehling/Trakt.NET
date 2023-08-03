namespace TraktNet.PostBuilder
{
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using Objects.Post.Syncs.Watchlist;
    using System;
    using System.Collections.Generic;

    public interface ITraktSyncWatchlistPostBuilder
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithMovie(ITraktMovieIds movieIds);

        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="movie"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes);

        /// <summary>Adds the given <paramref name="movieWithNotes"/> to the builder.</summary>
        /// <param name="movieWithNotes">The <see cref="MovieWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="movieWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithMovieWithNotes(MovieWithNotes movieWithNotes);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="movieIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithMovieWithNotes(ITraktMovieIds movieIds, string notes);

        /// <summary>Adds the given <paramref name="movieIdsWithNotes"/> to the builder.</summary>
        /// <param name="movieIdsWithNotes">The <see cref="MovieIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="movieIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithMovieWithNotes(MovieIdsWithNotes movieIdsWithNotes);

        /// <summary>Adds the given <paramref name="movies"/> collection to the builder.</summary>
        /// <param name="movies">A collection of <see cref="ITraktMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movies"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);

        /// <summary>Adds the given <paramref name="movieIds"/> collection to the builder.</summary>
        /// <param name="movieIds">A collection of <see cref="ITraktMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);

        /// <summary>Adds the given <paramref name="moviesWithNotes"/> collection to the builder.</summary>
        /// <param name="moviesWithNotes">A collection of <see cref="MovieWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="moviesWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="moviesWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="moviesWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithMoviesWithNotes(IEnumerable<MovieWithNotes> moviesWithNotes);

        /// <summary>Adds the given <paramref name="movieIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="movieIdsWithNotes">A collection of <see cref="MovieIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="movieIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="movieIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithMoviesWithNotes(IEnumerable<MovieIdsWithNotes> movieIdsWithNotes);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShow(ITraktShowIds showIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="show"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithShowWithNotes(ITraktShow show, string notes);

        /// <summary>Adds the given <paramref name="showWithNotes"/> to the builder.</summary>
        /// <param name="showWithNotes">The <see cref="ShowWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithShowWithNotes(ShowWithNotes showWithNotes);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="showIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithShowWithNotes(ITraktShowIds showIds, string notes);

        /// <summary>Adds the given <paramref name="showIdsWithNotes"/> to the builder.</summary>
        /// <param name="showIdsWithNotes">The <see cref="ShowIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithShowWithNotes(ShowIdsWithNotes showIdsWithNotes);

        /// <summary>Adds the given <paramref name="shows"/> collection to the builder.</summary>
        /// <param name="shows">A collection of <see cref="ITraktShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="shows"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShows(IEnumerable<ITraktShow> shows);

        /// <summary>Adds the given <paramref name="showIds"/> collection to the builder.</summary>
        /// <param name="showIds">A collection of <see cref="ITraktShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);

        /// <summary>Adds the given <paramref name="showsWithNotes"/> collection to the builder.</summary>
        /// <param name="showsWithNotes">A collection of <see cref="ShowWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithShowsWithNotes(IEnumerable<ShowWithNotes> showsWithNotes);

        /// <summary>Adds the given <paramref name="showIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="showIdsWithNotes">A collection of <see cref="ShowIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithShowsWithNotes(IEnumerable<ShowIdsWithNotes> showIdsWithNotes);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostSeasons"/> for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShow show, PostSeasons seasons);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The seasons for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShow show, IEnumerable<int> seasons);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="season">A season number for the <paramref name="show"/> which will be added.</param>
        /// <param name="seasons">An optional array of season numbers for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShow show, int season, params int[] seasons);

        /// <summary>Adds the given <paramref name="showAndSeasons"/> to the builder.</summary>
        /// <param name="showAndSeasons">The <see cref="ShowAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showAndSeasons"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ShowAndSeasons showAndSeasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostSeasons"/> for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostSeasons seasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The seasons for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShowIds showIds, IEnumerable<int> seasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="season">A season number for the <paramref name="showIds"/> which will be added.</param>
        /// <param name="seasons">An optional array of season numbers for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShowIds showIds, int season, params int[] seasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> to the builder.</summary>
        /// <param name="showIdsAndSeasons">The <see cref="ShowIdsAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ShowIdsAndSeasons showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="showWithNotesAndSeasons"/> to the builder.</summary>
        /// <param name="showWithNotesAndSeasons">The <see cref="ShowWithNotesAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotesAndSeasons"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotesAndSeasons"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showWithNotesAndSeasons"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithShowWithNotesAndSeasons(ShowWithNotesAndSeasons showWithNotesAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsWithNotesAndSeasons"/> to the builder.</summary>
        /// <param name="showIdsWithNotesAndSeasons">The <see cref="ShowIdsWithNotesAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotesAndSeasons"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotesAndSeasons"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showIdsWithNotesAndSeasons"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithShowWithNotesAndSeasons(ShowIdsWithNotesAndSeasons showIdsWithNotesAndSeasons);

        /// <summary>Adds the given <paramref name="showsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showsAndSeasons">A collection of <see cref="ShowAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsAndSeasons"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowsAndSeasons(IEnumerable<ShowAndSeasons> showsAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsAndSeasons">A collection of <see cref="ShowIdsAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithShowsAndSeasons(IEnumerable<ShowIdsAndSeasons> showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="showsWithNotesAndSeasons"/> collection to the builder.</summary>
        /// <param name="showsWithNotesAndSeasons">A collection of <see cref="ShowIdsWithNotesAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithNotesAndSeasons"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showsWithNotesAndSeasons"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showsWithNotesAndSeasons"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowWithNotesAndSeasons> showsWithNotesAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsWithNotesAndSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsWithNotesAndSeasons">A collection of <see cref="ShowIdsWithNotesAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotesAndSeasons"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotesAndSeasons"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotesAndSeasons"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowIdsWithNotesAndSeasons> showIdsWithNotesAndSeasons);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithSeason(ITraktSeason season);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithSeason(ITraktSeasonIds seasonIds);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="season"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(ITraktSeason season, string notes);

        /// <summary>Adds the given <paramref name="seasonWithNotes"/> to the builder.</summary>
        /// <param name="seasonWithNotes">The <see cref="SeasonWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="seasonWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(SeasonWithNotes seasonWithNotes);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="seasonIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(ITraktSeasonIds seasonIds, string notes);

        /// <summary>Adds the given <paramref name="seasonIdsWithNotes"/> to the builder.</summary>
        /// <param name="seasonIdsWithNotes">The <see cref="SeasonIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="seasonIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(SeasonIdsWithNotes seasonIdsWithNotes);

        /// <summary>Adds the given <paramref name="seasons"/> collection to the builder.</summary>
        /// <param name="seasons">A collection of <see cref="ITraktSeason"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);

        /// <summary>Adds the given <paramref name="seasonIds"/> collection to the builder.</summary>
        /// <param name="seasonIds">A collection of <see cref="ITraktSeasonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds);

        /// <summary>Adds the given <paramref name="seasonsWithNotes"/> collection to the builder.</summary>
        /// <param name="seasonsWithNotes">A collection of <see cref="SeasonWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="seasonsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="seasonsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonWithNotes> seasonsWithNotes);

        /// <summary>Adds the given <paramref name="seasonIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="seasonIdsWithNotes">A collection of <see cref="SeasonIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="seasonIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="seasonIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonIdsWithNotes> seasonIdsWithNotes);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithEpisode(ITraktEpisode episode);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithEpisode(ITraktEpisodeIds episodeIds);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="episode"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(ITraktEpisode episode, string notes);

        /// <summary>Adds the given <paramref name="episodeWithNotes"/> to the builder.</summary>
        /// <param name="episodeWithNotes">The <see cref="EpisodeWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="episodeWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(EpisodeWithNotes episodeWithNotes);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="episodeIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(ITraktEpisodeIds episodeIds, string notes);

        /// <summary>Adds the given <paramref name="episodeIdsWithNotes"/> to the builder.</summary>
        /// <param name="episodeIdsWithNotes">The <see cref="EpisodeIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="episodeIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(EpisodeIdsWithNotes episodeIdsWithNotes);

        /// <summary>Adds the given <paramref name="episodes"/> collection to the builder.</summary>
        /// <param name="episodes">A collection of <see cref="ITraktEpisode"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodes"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);

        /// <summary>Adds the given <paramref name="episodeIds"/> collection to the builder.</summary>
        /// <param name="episodeIds">A collection of <see cref="ITraktEpisodeIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncWatchlistPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds);

        /// <summary>Adds the given <paramref name="episodesWithNotes"/> collection to the builder.</summary>
        /// <param name="episodesWithNotes">A collection of <see cref="EpisodeWithNotes"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodesWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="episodesWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="episodesWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeWithNotes> episodesWithNotes);

        /// <summary>Adds the given <paramref name="episodeIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="episodeIdsWithNotes">A collection of <see cref="EpisodeIdsWithNotes"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncWatchlistPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="episodeIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="episodeIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktSyncWatchlistPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeIdsWithNotes> episodeIdsWithNotes);

        /// <summary>Creates a new <see cref="ITraktSyncWatchlistPost" /> instance with the added movies, shows, seasons and episodes.</summary>
        /// <returns>A new <see cref="ITraktSyncWatchlistPost" /> instance with the added movies, shows, seasons and episodes.</returns>
        ITraktSyncWatchlistPost Build();
    }
}
