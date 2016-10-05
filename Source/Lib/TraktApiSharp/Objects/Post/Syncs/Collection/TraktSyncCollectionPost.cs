namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Trakt collection post, containing all movies, shows and / or episodes,
    /// which should be added to the user's collection.
    /// </summary>
    public class TraktSyncCollectionPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostMovie" />s.
        /// <para>Each <see cref="TraktSyncCollectionPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncCollectionPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostShow" />s.
        /// <para>Each <see cref="TraktSyncCollectionPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncCollectionPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncCollectionPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncCollectionPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncCollectionPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        public static TraktSyncCollectionPostBuilder Builder() => new TraktSyncCollectionPostBuilder();
    }

    /// <summary>
    /// This is a helper class to build a <see cref="TraktSyncCollectionPost" />.
    /// <para>
    /// It is recommended to use this class to build a collection post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncCollectionPost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncCollectionPostBuilder
    {
        private TraktSyncCollectionPost _collectionPost;

        /// <summary>Initializes a new instance of the <see cref="TraktSyncCollectionPostBuilder" /> class.</summary>
        public TraktSyncCollectionPostBuilder()
        {
            _collectionPost = new TraktSyncCollectionPost();
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the collection post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddMovie(TraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the collection post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <param name="collectedAt">The datetime, when the given movie was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddMovie(TraktMovie movie, DateTime collectedAt)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, null, collectedAt);
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the collection post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given movie.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddMovie(TraktMovie movie, TraktMetadata metadata)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, metadata);
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the collection post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given movie.</param>
        /// <param name="collectedAt">The datetime, when the given movie was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddMovie(TraktMovie movie, TraktMetadata metadata, DateTime collectedAt)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, metadata, collectedAt);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="collectedAt">The datetime, when the given show was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, DateTime collectedAt)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, null, collectedAt);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given show.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, metadata);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given show.</param>
        /// <param name="collectedAt">The datetime, when the given show was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, DateTime collectedAt)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, metadata, collectedAt);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the collection.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="collectedAt">The datetime, when the given show was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the collection.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, DateTime collectedAt, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, null, collectedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given show.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the collection.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, metadata);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given show.</param>
        /// <param name="collectedAt">The datetime, when the given show was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the collection.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, DateTime collectedAt, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, metadata, collectedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An <see cref="PostSeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="collectedAt">The datetime, when the given show was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="seasons">
        /// An <see cref="PostSeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, DateTime collectedAt, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, null, collectedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given show.</param>
        /// <param name="seasons">
        /// An <see cref="PostSeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, metadata);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given show.</param>
        /// <param name="collectedAt">The datetime, when the given show was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="seasons">
        /// An <see cref="PostSeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, DateTime collectedAt, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, metadata, collectedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the collection post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncCollectionPostBuilder AddEpisode(TraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode);
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the collection post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="collectedAt">The datetime, when the given episode was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncCollectionPostBuilder AddEpisode(TraktEpisode episode, DateTime collectedAt)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, null, collectedAt);
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the collection post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given episode.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncCollectionPostBuilder AddEpisode(TraktEpisode episode, TraktMetadata metadata)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, metadata);
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the collection post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given episode.</param>
        /// <param name="collectedAt">The datetime, when the given episode was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncCollectionPostBuilder AddEpisode(TraktEpisode episode, TraktMetadata metadata, DateTime collectedAt)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, metadata, collectedAt);
        }

        /// <summary>Removes all already added movies, shows, seasons and episodes.</summary>
        public void Reset()
        {
            if (_collectionPost.Movies != null)
            {
                (_collectionPost.Movies as List<TraktSyncCollectionPostMovie>).Clear();
                _collectionPost.Movies = null;
            }

            if (_collectionPost.Shows != null)
            {
                (_collectionPost.Shows as List<TraktSyncCollectionPostShow>).Clear();
                _collectionPost.Shows = null;
            }

            if (_collectionPost.Episodes != null)
            {
                (_collectionPost.Episodes as List<TraktSyncCollectionPostEpisode>).Clear();
                _collectionPost.Episodes = null;
            }
        }

        /// <summary>
        /// Returns an <see cref="TraktSyncCollectionPost" /> instance, which contains all
        /// added movies, shows, seasons and episodes, including metadata and collected at UTC datetimes.
        /// </summary>
        /// <returns>An <see cref="TraktSyncCollectionPost" /> instance.</returns>
        public TraktSyncCollectionPost Build() => _collectionPost;

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

        private bool ContainsMovie(TraktMovie movie)
            => _collectionPost.Movies.Where(m => m.Ids == movie.Ids).FirstOrDefault() != null;

        private void EnsureMoviesListExists()
        {
            if (_collectionPost.Movies == null)
                _collectionPost.Movies = new List<TraktSyncCollectionPostMovie>();
        }

        private bool ContainsShow(TraktShow show)
            => _collectionPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault() != null;

        private void EnsureShowsListExists()
        {
            if (_collectionPost.Shows == null)
                _collectionPost.Shows = new List<TraktSyncCollectionPostShow>();
        }

        private bool ContainsEpisode(TraktEpisode episode)
            => _collectionPost.Episodes.Where(e => e.Ids == episode.Ids).FirstOrDefault() != null;

        private void EnsureEpisodesListExists()
        {
            if (_collectionPost.Episodes == null)
                _collectionPost.Episodes = new List<TraktSyncCollectionPostEpisode>();
        }

        private TraktSyncCollectionPostBuilder AddMovieOrIgnore(TraktMovie movie, TraktMetadata metadata = null,
                                                                DateTime? collectedAt = null)
        {
            if (ContainsMovie(movie))
                return this;

            var collectionMovie = new TraktSyncCollectionPostMovie();
            collectionMovie.Ids = movie.Ids;
            collectionMovie.Title = movie.Title;
            collectionMovie.Year = movie.Year;

            if (metadata != null)
                collectionMovie.Metadata = metadata;

            if (collectedAt.HasValue)
                collectionMovie.CollectedAt = collectedAt.Value.ToUniversalTime();

            (_collectionPost.Movies as List<TraktSyncCollectionPostMovie>).Add(collectionMovie);

            return this;
        }

        private TraktSyncCollectionPostBuilder AddShowOrIgnore(TraktShow show, TraktMetadata metadata = null,
                                                               DateTime? collectedAt = null)
        {
            if (ContainsShow(show))
                return this;

            var collectionShow = new TraktSyncCollectionPostShow();
            collectionShow.Ids = show.Ids;
            collectionShow.Title = show.Title;
            collectionShow.Year = show.Year;

            if (metadata != null)
                collectionShow.Metadata = metadata;

            if (collectedAt.HasValue)
                collectionShow.CollectedAt = collectedAt.Value.ToUniversalTime();

            (_collectionPost.Shows as List<TraktSyncCollectionPostShow>).Add(collectionShow);

            return this;
        }

        private TraktSyncCollectionPostBuilder AddEpisodeOrIgnore(TraktEpisode episode, TraktMetadata metadata = null,
                                                                  DateTime? collectedAt = null)
        {
            if (ContainsEpisode(episode))
                return this;

            var collectionEpisode = new TraktSyncCollectionPostEpisode();
            collectionEpisode.Ids = episode.Ids;

            if (metadata != null)
                collectionEpisode.Metadata = metadata;

            if (collectedAt.HasValue)
                collectionEpisode.CollectedAt = collectedAt.Value.ToUniversalTime();

            (_collectionPost.Episodes as List<TraktSyncCollectionPostEpisode>).Add(collectionEpisode);

            return this;
        }

        private void CreateOrSetShow(TraktShow show, IEnumerable<TraktSyncCollectionPostShowSeason> showSeasons,
                                     TraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            var existingShow = _collectionPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var collectionShow = new TraktSyncCollectionPostShow();
                collectionShow.Ids = show.Ids;
                collectionShow.Title = show.Title;
                collectionShow.Year = show.Year;

                if (metadata != null)
                    collectionShow.Metadata = metadata;

                if (collectedAt.HasValue)
                    collectionShow.CollectedAt = collectedAt.Value.ToUniversalTime();

                collectionShow.Seasons = showSeasons;
                (_collectionPost.Shows as List<TraktSyncCollectionPostShow>).Add(collectionShow);
            }
        }

        private IEnumerable<TraktSyncCollectionPostShowSeason> CreateShowSeasons(int season, params int[] seasons)
        {
            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktSyncCollectionPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncCollectionPostShowSeason { Number = seasonsToAdd[i] });
            }

            return showSeasons;
        }

        private IEnumerable<TraktSyncCollectionPostShowSeason> CreateShowSeasons(PostSeasons seasons)
        {
            var showSeasons = new List<TraktSyncCollectionPostShowSeason>();

            foreach (var season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktSyncCollectionPostShowSeason { Number = season.Number };

                if (season.Episodes != null && season.Episodes.Count() > 0)
                {
                    var showEpisodes = new List<TraktSyncCollectionPostShowEpisode>();

                    foreach (var episode in season.Episodes)
                    {
                        if (episode < 0)
                            throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                        showEpisodes.Add(new TraktSyncCollectionPostShowEpisode { Number = episode });
                    }

                    showSingleSeason.Episodes = showEpisodes;
                }

                showSeasons.Add(showSingleSeason);
            }

            return showSeasons;
        }
    }
}
