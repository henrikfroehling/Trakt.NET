namespace TraktNet.PostBuilder
{
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktRemovePostBuilder<TPostBuilder, TPostObject> where TPostBuilder : ITraktRemovePostBuilder<TPostBuilder, TPostObject>
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        TPostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        TPostBuilder WithMovie(ITraktMovieIds movieIds);

        /// <summary>Adds the given <paramref name="movies"/> collection to the builder.</summary>
        /// <param name="movies">A collection of <see cref="ITraktMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movies"/> is null.</exception>
        TPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);

        /// <summary>Adds the given <paramref name="movieIds"/> collection to the builder.</summary>
        /// <param name="movieIds">A collection of <see cref="ITraktMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        TPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        TPostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        TPostBuilder WithShow(ITraktShowIds showIds);

        /// <summary>Adds the given <paramref name="shows"/> collection to the builder.</summary>
        /// <param name="shows">A collection of <see cref="ITraktShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="shows"/> is null.</exception>
        TPostBuilder WithShows(IEnumerable<ITraktShow> shows);

        /// <summary>Adds the given <paramref name="showIds"/> collection to the builder.</summary>
        /// <param name="showIds">A collection of <see cref="ITraktShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        TPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostSeasons"/> for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        TPostBuilder WithShowAndSeasons(ITraktShow show, PostSeasons seasons);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The seasons for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        TPostBuilder WithShowAndSeasons(ITraktShow show, IEnumerable<int> seasons);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="season">A season number for the <paramref name="show"/> which will be added.</param>
        /// <param name="seasons">An optional array of season numbers for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        TPostBuilder WithShowAndSeasons(ITraktShow show, int season, params int[] seasons);

        /// <summary>Adds the given <paramref name="showAndSeasons"/> to the builder.</summary>
        /// <param name="showAndSeasons">The <see cref="ShowAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showAndSeasons"/> is null.</exception>
        TPostBuilder WithShowAndSeasons(ShowAndSeasons showAndSeasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostSeasons"/> for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        TPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostSeasons seasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The seasons for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        TPostBuilder WithShowAndSeasons(ITraktShowIds showIds, IEnumerable<int> seasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="season">A season number for the <paramref name="showIds"/> which will be added.</param>
        /// <param name="seasons">An optional array of season numbers for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        TPostBuilder WithShowAndSeasons(ITraktShowIds showIds, int season, params int[] seasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> to the builder.</summary>
        /// <param name="showIdsAndSeasons">The <see cref="ShowIdsAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        TPostBuilder WithShowAndSeasons(ShowIdsAndSeasons showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="showsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showsAndSeasons">A collection of <see cref="ShowAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsAndSeasons"/> is null.</exception>
        TPostBuilder WithShowsAndSeasons(IEnumerable<ShowAndSeasons> showsAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsAndSeasons">A collection of <see cref="ShowIdsAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        TPostBuilder WithShowsAndSeasons(IEnumerable<ShowIdsAndSeasons> showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        TPostBuilder WithSeason(ITraktSeason season);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        TPostBuilder WithSeason(ITraktSeasonIds seasonIds);

        /// <summary>Adds the given <paramref name="seasons"/> collection to the builder.</summary>
        /// <param name="seasons">A collection of <see cref="ITraktSeason"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        TPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);

        /// <summary>Adds the given <paramref name="seasonIds"/> collection to the builder.</summary>
        /// <param name="seasonIds">A collection of <see cref="ITraktSeasonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        TPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        TPostBuilder WithEpisode(ITraktEpisode episode);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        TPostBuilder WithEpisode(ITraktEpisodeIds episodeIds);

        /// <summary>Adds the given <paramref name="episodes"/> collection to the builder.</summary>
        /// <param name="episodes">A collection of <see cref="ITraktEpisode"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodes"/> is null.</exception>
        TPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);

        /// <summary>Adds the given <paramref name="episodeIds"/> collection to the builder.</summary>
        /// <param name="episodeIds">A collection of <see cref="ITraktEpisodeIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        TPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds);

        /// <summary>Creates a new <typeparamref name="TPostObject"/> instance with the added movies, shows, seasons and episodes.</summary>
        /// <returns>A new <typeparamref name="TPostObject"/> instance with the added movies, shows, seasons and episodes.</returns>
        TPostObject Build();
    }
}
