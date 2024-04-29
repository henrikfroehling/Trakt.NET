namespace TraktNet.PostBuilder
{
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.People;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using Objects.Post.Users.PersonalListItems;
    using System;
    using System.Collections.Generic;

    public interface ITraktUserPersonalListItemsPostBuilder
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithMovie(ITraktMovieIds movieIds);

        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="movie"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes);

        /// <summary>Adds the given <paramref name="movieWithNotes"/> to the builder.</summary>
        /// <param name="movieWithNotes">The <see cref="MovieWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="movieWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithMovieWithNotes(MovieWithNotes movieWithNotes);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="movieIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithMovieWithNotes(ITraktMovieIds movieIds, string notes);

        /// <summary>Adds the given <paramref name="movieIdsWithNotes"/> to the builder.</summary>
        /// <param name="movieIdsWithNotes">The <see cref="MovieIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="movieIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithMovieWithNotes(MovieIdsWithNotes movieIdsWithNotes);

        /// <summary>Adds the given <paramref name="movies"/> collection to the builder.</summary>
        /// <param name="movies">A collection of <see cref="ITraktMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movies"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);

        /// <summary>Adds the given <paramref name="movieIds"/> collection to the builder.</summary>
        /// <param name="movieIds">A collection of <see cref="ITraktMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);

        /// <summary>Adds the given <paramref name="moviesWithNotes"/> collection to the builder.</summary>
        /// <param name="moviesWithNotes">A collection of <see cref="MovieWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="moviesWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="moviesWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="moviesWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithMoviesWithNotes(IEnumerable<MovieWithNotes> moviesWithNotes);

        /// <summary>Adds the given <paramref name="movieIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="movieIdsWithNotes">A collection of <see cref="MovieIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="movieIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="movieIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithMoviesWithNotes(IEnumerable<MovieIdsWithNotes> movieIdsWithNotes);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShow(ITraktShowIds showIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="show"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowWithNotes(ITraktShow show, string notes);

        /// <summary>Adds the given <paramref name="showWithNotes"/> to the builder.</summary>
        /// <param name="showWithNotes">The <see cref="ShowWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowWithNotes(ShowWithNotes showWithNotes);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="showIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowWithNotes(ITraktShowIds showIds, string notes);

        /// <summary>Adds the given <paramref name="showIdsWithNotes"/> to the builder.</summary>
        /// <param name="showIdsWithNotes">The <see cref="ShowIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowWithNotes(ShowIdsWithNotes showIdsWithNotes);

        /// <summary>Adds the given <paramref name="shows"/> collection to the builder.</summary>
        /// <param name="shows">A collection of <see cref="ITraktShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="shows"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows);

        /// <summary>Adds the given <paramref name="showIds"/> collection to the builder.</summary>
        /// <param name="showIds">A collection of <see cref="ITraktShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);

        /// <summary>Adds the given <paramref name="showsWithNotes"/> collection to the builder.</summary>
        /// <param name="showsWithNotes">A collection of <see cref="ShowWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithShowsWithNotes(IEnumerable<ShowWithNotes> showsWithNotes);

        /// <summary>Adds the given <paramref name="showIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="showIdsWithNotes">A collection of <see cref="ShowIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithShowsWithNotes(IEnumerable<ShowIdsWithNotes> showIdsWithNotes);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostSeasons"/> for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ITraktShow show, PostSeasons seasons);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The seasons for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ITraktShow show, IEnumerable<int> seasons);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="season">A season number for the <paramref name="show"/> which will be added.</param>
        /// <param name="seasons">An optional array of season numbers for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ITraktShow show, int season, params int[] seasons);

        /// <summary>Adds the given <paramref name="showAndSeasons"/> to the builder.</summary>
        /// <param name="showAndSeasons">The <see cref="ShowAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showAndSeasons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ShowAndSeasons showAndSeasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostSeasons"/> for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostSeasons seasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The seasons for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, IEnumerable<int> seasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="season">A season number for the <paramref name="showIds"/> which will be added.</param>
        /// <param name="seasons">An optional array of season numbers for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, int season, params int[] seasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> to the builder.</summary>
        /// <param name="showIdsAndSeasons">The <see cref="ShowIdsAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ShowIdsAndSeasons showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="showWithNotesAndSeasons"/> to the builder.</summary>
        /// <param name="showWithNotesAndSeasons">The <see cref="ShowWithNotesAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotesAndSeasons"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithNotesAndSeasons"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showWithNotesAndSeasons"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowWithNotesAndSeasons(ShowWithNotesAndSeasons showWithNotesAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsWithNotesAndSeasons"/> to the builder.</summary>
        /// <param name="showIdsWithNotesAndSeasons">The <see cref="ShowIdsWithNotesAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotesAndSeasons"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotesAndSeasons"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="showIdsWithNotesAndSeasons"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowWithNotesAndSeasons(ShowIdsWithNotesAndSeasons showIdsWithNotesAndSeasons);

        /// <summary>Adds the given <paramref name="showsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showsAndSeasons">A collection of <see cref="ShowAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsAndSeasons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowsAndSeasons(IEnumerable<ShowAndSeasons> showsAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsAndSeasons">A collection of <see cref="ShowIdsAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithShowsAndSeasons(IEnumerable<ShowIdsAndSeasons> showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="showsWithNotesAndSeasons"/> collection to the builder.</summary>
        /// <param name="showsWithNotesAndSeasons">A collection of <see cref="ShowIdsWithNotesAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithNotesAndSeasons"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showsWithNotesAndSeasons"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showsWithNotesAndSeasons"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowWithNotesAndSeasons> showsWithNotesAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsWithNotesAndSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsWithNotesAndSeasons">A collection of <see cref="ShowIdsWithNotesAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithNotesAndSeasons"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotesAndSeasons"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="showIdsWithNotesAndSeasons"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowIdsWithNotesAndSeasons> showIdsWithNotesAndSeasons);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithSeason(ITraktSeason season);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithSeason(ITraktSeasonIds seasonIds);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="season"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithSeasonWithNotes(ITraktSeason season, string notes);

        /// <summary>Adds the given <paramref name="seasonWithNotes"/> to the builder.</summary>
        /// <param name="seasonWithNotes">The <see cref="SeasonWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="seasonWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithSeasonWithNotes(SeasonWithNotes seasonWithNotes);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="seasonIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithSeasonWithNotes(ITraktSeasonIds seasonIds, string notes);

        /// <summary>Adds the given <paramref name="seasonIdsWithNotes"/> to the builder.</summary>
        /// <param name="seasonIdsWithNotes">The <see cref="SeasonIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="seasonIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithSeasonWithNotes(SeasonIdsWithNotes seasonIdsWithNotes);

        /// <summary>Adds the given <paramref name="seasons"/> collection to the builder.</summary>
        /// <param name="seasons">A collection of <see cref="ITraktSeason"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);

        /// <summary>Adds the given <paramref name="seasonIds"/> collection to the builder.</summary>
        /// <param name="seasonIds">A collection of <see cref="ITraktSeasonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds);

        /// <summary>Adds the given <paramref name="seasonsWithNotes"/> collection to the builder.</summary>
        /// <param name="seasonsWithNotes">A collection of <see cref="SeasonWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="seasonsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="seasonsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonWithNotes> seasonsWithNotes);

        /// <summary>Adds the given <paramref name="seasonIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="seasonIdsWithNotes">A collection of <see cref="SeasonIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="seasonIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="seasonIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonIdsWithNotes> seasonIdsWithNotes);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisode(ITraktEpisode episode);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisode(ITraktEpisodeIds episodeIds);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="episode"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisodeWithNotes(ITraktEpisode episode, string notes);

        /// <summary>Adds the given <paramref name="episodeWithNotes"/> to the builder.</summary>
        /// <param name="episodeWithNotes">The <see cref="EpisodeWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="episodeWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisodeWithNotes(EpisodeWithNotes episodeWithNotes);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="episodeIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisodeWithNotes(ITraktEpisodeIds episodeIds, string notes);

        /// <summary>Adds the given <paramref name="episodeIdsWithNotes"/> to the builder.</summary>
        /// <param name="episodeIdsWithNotes">The <see cref="EpisodeIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="episodeIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisodeWithNotes(EpisodeIdsWithNotes episodeIdsWithNotes);

        /// <summary>Adds the given <paramref name="episodes"/> collection to the builder.</summary>
        /// <param name="episodes">A collection of <see cref="ITraktEpisode"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodes"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);

        /// <summary>Adds the given <paramref name="episodeIds"/> collection to the builder.</summary>
        /// <param name="episodeIds">A collection of <see cref="ITraktEpisodeIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds);

        /// <summary>Adds the given <paramref name="episodesWithNotes"/> collection to the builder.</summary>
        /// <param name="episodesWithNotes">A collection of <see cref="EpisodeWithNotes"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodesWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="episodesWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="episodesWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeWithNotes> episodesWithNotes);

        /// <summary>Adds the given <paramref name="episodeIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="episodeIdsWithNotes">A collection of <see cref="EpisodeIdsWithNotes"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="episodeIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="episodeIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeIdsWithNotes> episodeIdsWithNotes);

        /// <summary>Adds the given <paramref name="person"/> to the builder.</summary>
        /// <param name="person">The <see cref="ITraktPerson"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="person"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithPerson(ITraktPerson person);

        /// <summary>Adds the given <paramref name="personIds"/> to the builder.</summary>
        /// <param name="personIds">The <see cref="ITraktPersonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithPerson(ITraktPersonIds personIds);

        /// <summary>Adds the given <paramref name="person"/> to the builder.</summary>
        /// <param name="person">The <see cref="ITraktPerson"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="person"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="person"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithPersonWithNotes(ITraktPerson person, string notes);

        /// <summary>Adds the given <paramref name="personWithNotes"/> to the builder.</summary>
        /// <param name="personWithNotes">The <see cref="PersonWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="personWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithPersonWithNotes(PersonWithNotes personWithNotes);

        /// <summary>Adds the given <paramref name="personIds"/> to the builder.</summary>
        /// <param name="personIds">The <see cref="ITraktPersonIds"/> which will be added.</param>
        /// <param name="notes">The notes for the given <paramref name="personIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="notes"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="notes"/> has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithPersonWithNotes(ITraktPersonIds personIds, string notes);

        /// <summary>Adds the given <paramref name="personIdsWithNotes"/> to the builder.</summary>
        /// <param name="personIdsWithNotes">The <see cref="PersonIdsWithNotes"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIdsWithNotes"/>.Notes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="personIdsWithNotes"/>.Notes has more than 255 characters.</exception>
        ITraktUserPersonalListItemsPostBuilder WithPersonWithNotes(PersonIdsWithNotes personIdsWithNotes);

        /// <summary>Adds the given <paramref name="persons"/> collection to the builder.</summary>
        /// <param name="persons">A collection of <see cref="ITraktPerson"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="persons"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithPersons(IEnumerable<ITraktPerson> persons);

        /// <summary>Adds the given <paramref name="personIds"/> collection to the builder.</summary>
        /// <param name="personIds">A collection of <see cref="ITraktPersonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        ITraktUserPersonalListItemsPostBuilder WithPersons(IEnumerable<ITraktPersonIds> personIds);

        /// <summary>Adds the given <paramref name="personsWithNotes"/> collection to the builder.</summary>
        /// <param name="personsWithNotes">A collection of <see cref="PersonWithNotes"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="personsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="personsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithPersonsWithNotes(IEnumerable<PersonWithNotes> personsWithNotes);

        /// <summary>Adds the given <paramref name="personIdsWithNotes"/> collection to the builder.</summary>
        /// <param name="personIdsWithNotes">A collection of <see cref="PersonIdsWithNotes"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIdsWithNotes"/> is null.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if one item of the given <paramref name="personIdsWithNotes"/> has notes which are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one item of the given <paramref name="personIdsWithNotes"/> has notes which have more than 255 characters.
        /// </exception>
        ITraktUserPersonalListItemsPostBuilder WithPersonsWithNotes(IEnumerable<PersonIdsWithNotes> personIdsWithNotes);

        /// <summary>Creates a new <see cref="ITraktUserPersonalListItemsPost" /> instance with the added movies, shows, seasons, episodes and people.</summary>
        /// <returns>A new <see cref="ITraktUserPersonalListItemsPost" /> instance with the added movies, shows, seasons, episodes and people.</returns>
        ITraktUserPersonalListItemsPost Build();
    }
}
