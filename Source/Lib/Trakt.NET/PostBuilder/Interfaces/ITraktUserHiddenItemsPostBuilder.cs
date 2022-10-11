namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Post.Users.HiddenItems;

    public interface ITraktUserHiddenItemsPostBuilder
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithMovie(ITraktMovieIds movieIds);

        /// <summary>Adds the given <paramref name="movies"/> collection to the builder.</summary>
        /// <param name="movies">A collection of <see cref="ITraktMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movies"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);

        /// <summary>Adds the given <paramref name="movieIds"/> collection to the builder.</summary>
        /// <param name="movieIds">A collection of <see cref="ITraktMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShow(ITraktShowIds showIds);

        /// <summary>Adds the given <paramref name="shows"/> collection to the builder.</summary>
        /// <param name="shows">A collection of <see cref="ITraktShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="shows"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows);

        /// <summary>Adds the given <paramref name="showIds"/> collection to the builder.</summary>
        /// <param name="showIds">A collection of <see cref="ITraktShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The season numbers for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(ITraktShow show, IEnumerable<int> seasons);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="season">The season number for the <paramref name="show"/> which will be added.</param>
        /// <param name="seasons">The optional season numbers for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(ITraktShow show, int season, params int[] seasons);

        /// <summary>Adds the given <paramref name="showWithSeasons"/> to the builder.</summary>
        /// <param name="showWithSeasons">The <see cref="HiddenShowWithSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithSeasons"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(HiddenShowWithSeasons showWithSeasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The season numbers for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, IEnumerable<int> seasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="season">The season number for the <paramref name="showIds"/> which will be added.</param>
        /// <param name="seasons">The optional season numbers for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, int season, params int[] seasons);

        /// <summary>Adds the given <paramref name="showIdsWithSeasons"/> to the builder.</summary>
        /// <param name="showIdsWithSeasons">The <see cref="HiddenShowIdsWithSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithSeasons"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(HiddenShowIdsWithSeasons showIdsWithSeasons);

        /// <summary>Adds the given <paramref name="showsWithSeasons"/> collection to the builder.</summary>
        /// <param name="showsWithSeasons">A collection of <see cref="HiddenShowWithSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithSeasons"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShowsAndSeasons(IEnumerable<HiddenShowWithSeasons> showsWithSeasons);

        /// <summary>Adds the given <paramref name="showIdsWithSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsWithSeasons">A collection of <see cref="HiddenShowIdsWithSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithSeasons"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithShowsAndSeasons(IEnumerable<HiddenShowIdsWithSeasons> showIdsWithSeasons);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithSeason(ITraktSeason season);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithSeason(ITraktSeasonIds seasonIds);

        /// <summary>Adds the given <paramref name="seasons"/> collection to the builder.</summary>
        /// <param name="seasons">A collection of <see cref="ITraktSeason"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);

        /// <summary>Adds the given <paramref name="seasonIds"/> collection to the builder.</summary>
        /// <param name="seasonIds">A collection of <see cref="ITraktSeasonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds);

        /// <summary>Adds the given <paramref name="user"/> to the builder.</summary>
        /// <param name="user">The <see cref="ITraktUser"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="user"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithUser(ITraktUser user);

        /// <summary>Adds the given <paramref name="userIds"/> to the builder.</summary>
        /// <param name="userIds">The <see cref="ITraktUserIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="userIds"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithUser(ITraktUserIds userIds);

        /// <summary>Adds the given <paramref name="users"/> collection to the builder.</summary>
        /// <param name="users">A collection of <see cref="ITraktUser"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="users"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithUsers(IEnumerable<ITraktUser> users);

        /// <summary>Adds the given <paramref name="userIds"/> collection to the builder.</summary>
        /// <param name="userIds">A collection of <see cref="ITraktUserIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserHiddenItemsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="userIds"/> is null.</exception>
        ITraktUserHiddenItemsPostBuilder WithUsers(IEnumerable<ITraktUserIds> userIds);

        /// <summary>Creates a new <see cref="ITraktUserHiddenItemsPost" /> instance with the added movies, shows, seasons and users.</summary>
        /// <returns>A new <see cref="ITraktUserHiddenItemsPost" /> instance with the added movies, shows, seasons and users.</returns>
        ITraktUserHiddenItemsPost Build();
    }
}
