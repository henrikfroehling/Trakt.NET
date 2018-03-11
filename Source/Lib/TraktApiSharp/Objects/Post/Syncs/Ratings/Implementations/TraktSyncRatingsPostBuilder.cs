namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Implementations
{
    using Get.Episodes;
    using Get.Movies;
    using Get.Shows;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This is a helper class to build a <see cref="ITraktSyncRatingsPost" />.
    /// <para>
    /// It is recommended to use this class to build a ratings post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncRatingsPost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncRatingsPostBuilder
    {
        private readonly ITraktSyncRatingsPost _ratingsPost;

        /// <summary>Initializes a new instance of the <see cref="TraktSyncRatingsPostBuilder" /> class.</summary>
        public TraktSyncRatingsPostBuilder()
        {
            _ratingsPost = new TraktSyncRatingsPost();
        }

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the ratings post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddMovie(ITraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        /// <summary>Adds a collection of <see cref="ITraktMovie" />s, which will be added to the ratings post.</summary>
        /// <param name="movies">A collection of Trakt movies, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movies collection is null.
        /// Thrown, if one of the given movies is null.
        /// Thrown, if one of the given movies' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given movies has no valid ids set.
        /// Thrown, if one of the given movies has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            if (!movies.Any())
                return this;

            foreach (var movie in movies)
                AddMovie(movie);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the ratings post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given movie.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given rating is not between 1 and 10.</exception>
        public TraktSyncRatingsPostBuilder AddMovie(ITraktMovie movie, int rating)
        {
            ValidateMovie(movie);
            ValidateRating(rating);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, rating);
        }

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the ratings post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given movie.</param>
        /// <param name="ratedAt">The datetime, when the given movie was rated. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given rating is not between 1 and 10.</exception>
        public TraktSyncRatingsPostBuilder AddMovie(ITraktMovie movie, int rating, DateTime ratedAt)
        {
            ValidateMovie(movie);
            ValidateRating(rating);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, rating, ratedAt);
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShow(ITraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        /// <summary>Adds a collection of <see cref="ITraktShow" />s, which will be added to the ratings post.</summary>
        /// <param name="shows">A collection of Trakt shows, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given shows collection is null.
        /// Thrown, if one of the given shows is null.
        /// Thrown, if one of the given shows' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given shows has no valid ids set.
        /// Thrown, if one of the given shows has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            if (!shows.Any())
                return this;

            foreach (var show in shows)
                AddShow(show);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the ratings.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShow(ITraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// Thrown, if the given seasons array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShow(ITraktShow show, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An <see cref="PostRatingsSeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers in <paramref name="seasons" /> is below zero.
        /// Thrown, if at least one of the given episode numbers in <paramref name="seasons" /> is below zero.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShow(ITraktShow show, PostRatingsSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given show.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given rating is not between 1 and 10.</exception>
        public TraktSyncRatingsPostBuilder AddShowWithRating(ITraktShow show, int rating)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, rating);
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given show.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the ratings.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// Thrown, if the given rating is not between 1 and 10.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShowWithRating(ITraktShow show, int rating, int season, params int[] seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, rating);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given show.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// Thrown, if the given seasons array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// Thrown, if the given rating is not between 1 and 10.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShowWithRating(ITraktShow show, int rating, int[] seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, rating);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given show.</param>
        /// <param name="seasons">
        /// An <see cref="PostRatingsSeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers in <paramref name="seasons" /> is below zero.
        /// Thrown, if at least one of the given episode numbers in <paramref name="seasons" /> is below zero.
        /// Thrown, if the given rating is not between 1 and 10.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShowWithRating(ITraktShow show, int rating, PostRatingsSeasons seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, rating);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given show.</param>
        /// <param name="ratedAt">The datetime, when the given show was rated. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given rating is not between 1 and 10.</exception>
        public TraktSyncRatingsPostBuilder AddShowWithRating(ITraktShow show, int rating, DateTime ratedAt)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, rating, ratedAt);
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given show.</param>
        /// <param name="ratedAt">The datetime, when the given show was rated. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the ratings.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// Thrown, if the given rating is not between 1 and 10.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShowWithRating(ITraktShow show, int rating, DateTime ratedAt,
                                                             int season, params int[] seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, rating, ratedAt);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given show.</param>
        /// <param name="ratedAt">The datetime, when the given show was rated. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// Thrown, if the given seasons array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// Thrown, if the given rating is not between 1 and 10.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShowWithRating(ITraktShow show, int rating, DateTime ratedAt, int[] seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, rating, ratedAt);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the ratings post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given show.</param>
        /// <param name="ratedAt">The datetime, when the given show was rated. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="seasons">
        /// An <see cref="PostRatingsSeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers in <paramref name="seasons" /> is below zero.
        /// Thrown, if at least one of the given episode numbers in <paramref name="seasons" /> is below zero.
        /// Thrown, if the given rating is not between 1 and 10.
        /// </exception>
        public TraktSyncRatingsPostBuilder AddShowWithRating(ITraktShow show, int rating, DateTime ratedAt,
                                                             PostRatingsSeasons seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, rating, ratedAt);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktEpisode" />, which will be added to the ratings post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncRatingsPostBuilder AddEpisode(ITraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode);
        }

        /// <summary>Adds a collection of <see cref="ITraktEpisode" />s, which will be added to the ratings post.</summary>
        /// <param name="episodes">A collection of Trakt episodes, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episodes collection is null.
        /// Thrown, if one of the given episodes is null.
        /// Thrown, if one of the given episodes' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given episodes has no valid ids set.</exception>
        public TraktSyncRatingsPostBuilder AddEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            if (!episodes.Any())
                return this;

            foreach (var episode in episodes)
                AddEpisode(episode);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktEpisode" />, which will be added to the ratings post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given episode.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given rating is not between 1 and 10.</exception>
        public TraktSyncRatingsPostBuilder AddEpisode(ITraktEpisode episode, int rating)
        {
            ValidateEpisode(episode);
            ValidateRating(rating);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, rating);
        }

        /// <summary>Adds a <see cref="ITraktEpisode" />, which will be added to the ratings post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given episode.</param>
        /// <param name="ratedAt">The datetime, when the given episode was rated. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given rating is not between 1 and 10.</exception>
        public TraktSyncRatingsPostBuilder AddEpisode(ITraktEpisode episode, int rating, DateTime ratedAt)
        {
            ValidateEpisode(episode);
            ValidateRating(rating);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, rating, ratedAt);
        }

        /// <summary>Removes all already added movies, shows, seasons and episodes.</summary>
        public void Reset()
        {
            if (_ratingsPost.Movies != null)
            {
                (_ratingsPost.Movies as List<ITraktSyncRatingsPostMovie>)?.Clear();
                _ratingsPost.Movies = null;
            }

            if (_ratingsPost.Shows != null)
            {
                (_ratingsPost.Shows as List<ITraktSyncRatingsPostShow>)?.Clear();
                _ratingsPost.Shows = null;
            }

            if (_ratingsPost.Episodes != null)
            {
                (_ratingsPost.Episodes as List<ITraktSyncRatingsPostEpisode>)?.Clear();
                _ratingsPost.Episodes = null;
            }
        }

        /// <summary>
        /// Returns an <see cref="ITraktSyncRatingsPost" /> instance, which contains all
        /// added movies, shows, seasons and episodes, including ratings and rated at UTC datetimes.
        /// </summary>
        /// <returns>An <see cref="TraktSyncRatingsPost" /> instance.</returns>
        public ITraktSyncRatingsPost Build() => _ratingsPost;

        private void ValidateMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (movie.Year.HasValue && movie.Year.Value.ToString().Length != 4)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));
        }

        private void ValidateShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException(nameof(show.Ids));

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("no show ids set or valid", nameof(show.Ids));

            if (show.Year.HasValue && show.Year.Value.ToString().Length != 4)
                throw new ArgumentException("show year not valid", nameof(show.Year));
        }

        private void ValidateEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids));

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("no episode ids set or valid", nameof(episode.Ids));
        }

        private void ValidateRating(int rating)
        {
            if (rating < 1 || rating > 10)
                throw new ArgumentOutOfRangeException(nameof(rating));
        }

        private bool ContainsMovie(ITraktMovie movie) => _ratingsPost.Movies.FirstOrDefault(m => m.Ids == movie.Ids) != null;

        private void EnsureMoviesListExists()
        {
            if (_ratingsPost.Movies == null)
                _ratingsPost.Movies = new List<ITraktSyncRatingsPostMovie>();
        }

        private bool ContainsShow(ITraktShow show) => _ratingsPost.Shows.FirstOrDefault(s => s.Ids == show.Ids) != null;

        private void EnsureShowsListExists()
        {
            if (_ratingsPost.Shows == null)
                _ratingsPost.Shows = new List<ITraktSyncRatingsPostShow>();
        }

        private bool ContainsEpisode(ITraktEpisode episode) => _ratingsPost.Episodes.FirstOrDefault(e => e.Ids == episode.Ids) != null;

        private void EnsureEpisodesListExists()
        {
            if (_ratingsPost.Episodes == null)
                _ratingsPost.Episodes = new List<ITraktSyncRatingsPostEpisode>();
        }

        private TraktSyncRatingsPostBuilder AddMovieOrIgnore(ITraktMovie movie, int? rating = null, DateTime? ratedAt = null)
        {
            if (ContainsMovie(movie))
                return this;

            var ratingsMovie = new TraktSyncRatingsPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            if (rating.HasValue)
                ratingsMovie.Rating = rating;

            if (ratedAt.HasValue)
                ratingsMovie.RatedAt = ratedAt.Value.ToUniversalTime();

            (_ratingsPost.Movies as List<ITraktSyncRatingsPostMovie>)?.Add(ratingsMovie);

            return this;
        }

        private TraktSyncRatingsPostBuilder AddShowOrIgnore(ITraktShow show, int? rating = null, DateTime? ratedAt = null)
        {
            if (ContainsShow(show))
                return this;

            var ratingsShow = new TraktSyncRatingsPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (rating.HasValue)
                ratingsShow.Rating = rating;

            if (ratedAt.HasValue)
                ratingsShow.RatedAt = ratedAt.Value.ToUniversalTime();

            (_ratingsPost.Shows as List<ITraktSyncRatingsPostShow>)?.Add(ratingsShow);

            return this;
        }

        private TraktSyncRatingsPostBuilder AddEpisodeOrIgnore(ITraktEpisode episode, int? rating = null, DateTime? ratedAt = null)
        {
            if (ContainsEpisode(episode))
                return this;

            var ratingsEpisode = new TraktSyncRatingsPostEpisode
            {
                Ids = episode.Ids
            };

            if (rating.HasValue)
                ratingsEpisode.Rating = rating;

            if (ratedAt.HasValue)
                ratingsEpisode.RatedAt = ratedAt.Value.ToUniversalTime();

            (_ratingsPost.Episodes as List<ITraktSyncRatingsPostEpisode>)?.Add(ratingsEpisode);

            return this;
        }

        private void CreateOrSetShow(ITraktShow show, IEnumerable<ITraktSyncRatingsPostShowSeason> showSeasons,
                                     int? rating = null, DateTime? ratedAt = null)
        {
            var existingShow = _ratingsPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                var ratingsShow = new TraktSyncRatingsPostShow
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year
                };

                if (rating.HasValue)
                    ratingsShow.Rating = rating;

                if (ratedAt.HasValue)
                    ratingsShow.RatedAt = ratedAt.Value.ToUniversalTime();

                ratingsShow.Seasons = showSeasons;
                (_ratingsPost.Shows as List<ITraktSyncRatingsPostShow>)?.Add(ratingsShow);
            }
        }

        private IEnumerable<ITraktSyncRatingsPostShowSeason> CreateShowSeasons(int season, params int[] seasons)
        {
            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<ITraktSyncRatingsPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncRatingsPostShowSeason { Number = seasonsToAdd[i] });
            }

            return showSeasons;
        }

        private IEnumerable<ITraktSyncRatingsPostShowSeason> CreateShowSeasons(int[] seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            var showSeasons = new List<ITraktSyncRatingsPostShowSeason>();

            for (int i = 0; i < seasons.Length; i++)
            {
                if (seasons[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncRatingsPostShowSeason { Number = seasons[i] });
            }

            return showSeasons;
        }

        private IEnumerable<ITraktSyncRatingsPostShowSeason> CreateShowSeasons(PostRatingsSeasons seasons)
        {
            var showSeasons = new List<ITraktSyncRatingsPostShowSeason>();

            foreach (var season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktSyncRatingsPostShowSeason { Number = season.Number };

                if (season.Rating.HasValue)
                    showSingleSeason.Rating = season.Rating;

                if (season.RatedAt.HasValue)
                    showSingleSeason.RatedAt = season.RatedAt.Value.ToUniversalTime();

                if (season.Episodes?.Count() > 0)
                {
                    var showEpisodes = new List<ITraktSyncRatingsPostShowEpisode>();

                    foreach (var episode in season.Episodes)
                    {
                        if (episode.Number < 0)
                            throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                        var showEpisode = new TraktSyncRatingsPostShowEpisode { Number = episode.Number };

                        if (episode.Rating.HasValue)
                            showEpisode.Rating = episode.Rating;

                        if (episode.RatedAt.HasValue)
                            showEpisode.RatedAt = episode.RatedAt.Value.ToUniversalTime();

                        showEpisodes.Add(showEpisode);
                    }

                    showSingleSeason.Episodes = showEpisodes;
                }

                showSeasons.Add(showSingleSeason);
            }

            return showSeasons;
        }
    }
}
