namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Trakt ratings post, containing all movies, shows and / or episodes,
    /// which should be added to the user's ratings.
    /// </summary>
    public class TraktSyncRatingsPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostMovie" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncRatingsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostShow" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncRatingsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncRatingsPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncRatingsPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        public static TraktSyncRatingsPostBuilder Builder() => new TraktSyncRatingsPostBuilder();
    }

    /// <summary>
    /// This is a helper class to build a <see cref="TraktSyncRatingsPost" />.
    /// <para>
    /// It is recommended to use this class to build a ratings post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncRatingsPost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncRatingsPostBuilder
    {
        private TraktSyncRatingsPost _ratingsPost;

        /// <summary>Initializes a new instance of the <see cref="TraktSyncRatingsPostBuilder" /> class.</summary>
        public TraktSyncRatingsPostBuilder()
        {
            _ratingsPost = new TraktSyncRatingsPost();
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddMovie(TraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddMovie(TraktMovie movie, int rating)
        {
            ValidateMovie(movie);
            ValidateRating(rating);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, rating);
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddMovie(TraktMovie movie, int rating, DateTime ratedAt)
        {
            ValidateMovie(movie);
            ValidateRating(rating);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, rating, ratedAt);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddShow(TraktShow show, PostRatingsSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, rating);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, int season, params int[] seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, rating);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, PostRatingsSeasons seasons)
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

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, DateTime ratedAt)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, rating, ratedAt);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, DateTime ratedAt,
                                                             int season, params int[] seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, rating, ratedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, DateTime ratedAt,
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

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the ratings post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncRatingsPostBuilder AddEpisode(TraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode);
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the ratings post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="rating">A rating from 1 to 10 for the given episode.</param>
        /// <returns>The current <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given rating is not between 1 and 10.</exception>
        public TraktSyncRatingsPostBuilder AddEpisode(TraktEpisode episode, int rating)
        {
            ValidateEpisode(episode);
            ValidateRating(rating);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, rating);
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the ratings post.</summary>
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
        public TraktSyncRatingsPostBuilder AddEpisode(TraktEpisode episode, int rating, DateTime ratedAt)
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
                (_ratingsPost.Movies as List<TraktSyncRatingsPostMovie>).Clear();
                _ratingsPost.Movies = null;
            }

            if (_ratingsPost.Shows != null)
            {
                (_ratingsPost.Shows as List<TraktSyncRatingsPostShow>).Clear();
                _ratingsPost.Shows = null;
            }

            if (_ratingsPost.Episodes != null)
            {
                (_ratingsPost.Episodes as List<TraktSyncRatingsPostEpisode>).Clear();
                _ratingsPost.Episodes = null;
            }
        }

        /// <summary>
        /// Returns an <see cref="TraktSyncRatingsPost" /> instance, which contains all
        /// added movies, shows, seasons and episodes, including ratings and rated at UTC datetimes.
        /// </summary>
        /// <returns>An <see cref="TraktSyncRatingsPost" /> instance.</returns>
        public TraktSyncRatingsPost Build()
        {
            return _ratingsPost;
        }

        private void ValidateMovie(TraktMovie movie)
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

        private void ValidateShow(TraktShow show)
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

        private void ValidateEpisode(TraktEpisode episode)
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

        private bool ContainsMovie(TraktMovie movie)
        {
            return _ratingsPost.Movies.Where(m => m.Ids == movie.Ids).FirstOrDefault() != null;
        }

        private void EnsureMoviesListExists()
        {
            if (_ratingsPost.Movies == null)
                _ratingsPost.Movies = new List<TraktSyncRatingsPostMovie>();
        }

        private bool ContainsShow(TraktShow show)
        {
            return _ratingsPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault() != null;
        }

        private void EnsureShowsListExists()
        {
            if (_ratingsPost.Shows == null)
                _ratingsPost.Shows = new List<TraktSyncRatingsPostShow>();
        }

        private bool ContainsEpisode(TraktEpisode episode)
        {
            return _ratingsPost.Episodes.Where(e => e.Ids == episode.Ids).FirstOrDefault() != null;
        }

        private void EnsureEpisodesListExists()
        {
            if (_ratingsPost.Episodes == null)
                _ratingsPost.Episodes = new List<TraktSyncRatingsPostEpisode>();
        }

        private TraktSyncRatingsPostBuilder AddMovieOrIgnore(TraktMovie movie, int? rating = null, DateTime? ratedAt = null)
        {
            if (ContainsMovie(movie))
                return this;

            var ratingsMovie = new TraktSyncRatingsPostMovie();
            ratingsMovie.Ids = movie.Ids;
            ratingsMovie.Title = movie.Title;
            ratingsMovie.Year = movie.Year;

            if (rating.HasValue)
                ratingsMovie.Rating = rating;

            if (ratedAt.HasValue)
                ratingsMovie.RatedAt = ratedAt.Value.ToUniversalTime();

            (_ratingsPost.Movies as List<TraktSyncRatingsPostMovie>).Add(ratingsMovie);

            return this;
        }

        private TraktSyncRatingsPostBuilder AddShowOrIgnore(TraktShow show, int? rating = null, DateTime? ratedAt = null)
        {
            if (ContainsShow(show))
                return this;

            var ratingsShow = new TraktSyncRatingsPostShow();
            ratingsShow.Ids = show.Ids;
            ratingsShow.Title = show.Title;
            ratingsShow.Year = show.Year;

            if (rating.HasValue)
                ratingsShow.Rating = rating;

            if (ratedAt.HasValue)
                ratingsShow.RatedAt = ratedAt.Value.ToUniversalTime();

            (_ratingsPost.Shows as List<TraktSyncRatingsPostShow>).Add(ratingsShow);

            return this;
        }

        private TraktSyncRatingsPostBuilder AddEpisodeOrIgnore(TraktEpisode episode, int? rating = null, DateTime? ratedAt = null)
        {
            if (ContainsEpisode(episode))
                return this;

            var ratingsEpisode = new TraktSyncRatingsPostEpisode();
            ratingsEpisode.Ids = episode.Ids;

            if (rating.HasValue)
                ratingsEpisode.Rating = rating;

            if (ratedAt.HasValue)
                ratingsEpisode.RatedAt = ratedAt.Value.ToUniversalTime();

            (_ratingsPost.Episodes as List<TraktSyncRatingsPostEpisode>).Add(ratingsEpisode);

            return this;
        }

        private void CreateOrSetShow(TraktShow show, IEnumerable<TraktSyncRatingsPostShowSeason> showSeasons,
                                     int? rating = null, DateTime? ratedAt = null)
        {
            var existingShow = _ratingsPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var ratingsShow = new TraktSyncRatingsPostShow();
                ratingsShow.Ids = show.Ids;
                ratingsShow.Title = show.Title;
                ratingsShow.Year = show.Year;

                if (rating.HasValue)
                    ratingsShow.Rating = rating;

                if (ratedAt.HasValue)
                    ratingsShow.RatedAt = ratedAt.Value.ToUniversalTime();

                ratingsShow.Seasons = showSeasons;
                (_ratingsPost.Shows as List<TraktSyncRatingsPostShow>).Add(ratingsShow);
            }
        }

        private IEnumerable<TraktSyncRatingsPostShowSeason> CreateShowSeasons(int season, params int[] seasons)
        {
            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktSyncRatingsPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncRatingsPostShowSeason { Number = seasonsToAdd[i] });
            }

            return showSeasons;
        }

        private IEnumerable<TraktSyncRatingsPostShowSeason> CreateShowSeasons(PostRatingsSeasons seasons)
        {
            var showSeasons = new List<TraktSyncRatingsPostShowSeason>();

            foreach (var season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktSyncRatingsPostShowSeason { Number = season.Number };

                if (season.Rating.HasValue)
                    showSingleSeason.Rating = season.Rating;

                if (season.RatedAt.HasValue)
                    showSingleSeason.RatedAt = season.RatedAt.Value.ToUniversalTime();

                if (season.Episodes != null && season.Episodes.Count() > 0)
                {
                    var showEpisodes = new List<TraktSyncRatingsPostShowEpisode>();

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
