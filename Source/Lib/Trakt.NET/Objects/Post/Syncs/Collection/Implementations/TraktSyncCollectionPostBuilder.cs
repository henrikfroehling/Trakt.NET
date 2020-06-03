namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Episodes;
    using Get.Movies;
    using Get.Shows;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This is a helper class to build a <see cref="ITraktSyncCollectionPost" />.
    /// <para>
    /// It is recommended to use this class to build a collection post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncCollectionPost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncCollectionPostBuilder
    {
        private readonly ITraktSyncCollectionPost _collectionPost;

        /// <summary>Initializes a new instance of the <see cref="TraktSyncCollectionPostBuilder" /> class.</summary>
        public TraktSyncCollectionPostBuilder() => _collectionPost = new TraktSyncCollectionPost();

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the collection post.</summary>
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
        public TraktSyncCollectionPostBuilder AddMovie(ITraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();
            return AddMovieOrIgnore(movie);
        }

        /// <summary>Adds a collection of <see cref="ITraktMovie" />s, which will be added to the collection post.</summary>
        /// <param name="movies">A collection of Trakt movies, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movies collection is null.
        /// Thrown, if one of the given movies is null.
        /// Thrown, if one of the given movies' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given movies has no valid ids set.
        /// Thrown, if one of the given movies has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            if (!movies.Any())
                return this;

            foreach (ITraktMovie movie in movies)
                AddMovie(movie);

            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktMovie" />s, which will be added to the collection post.</summary>
        /// <param name="movies">
        /// A collection of Trakt movie tuples - each containing a movie, metadata and a collectedAt datetime -, which will be added.
        /// The given metadata and collectedAt datetime can be null.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movies collection is null.
        /// Thrown, if one of the given movies is null.
        /// Thrown, if one of the given movies' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given movies has no valid ids set.
        /// Thrown, if one of the given movies has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddMovies(IEnumerable<Tuple<ITraktMovie, ITraktMetadata, DateTime?>> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            if (!movies.Any())
                return this;

            foreach (Tuple<ITraktMovie, ITraktMetadata, DateTime?> movieValues in movies)
                AddMovieOrIgnore(movieValues.Item1, movieValues.Item2, movieValues.Item3);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the collection post.</summary>
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
        public TraktSyncCollectionPostBuilder AddMovie(ITraktMovie movie, DateTime collectedAt)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();
            return AddMovieOrIgnore(movie, null, collectedAt);
        }

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the collection post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given movie.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddMovie(ITraktMovie movie, ITraktMetadata metadata)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();
            return AddMovieOrIgnore(movie, metadata);
        }

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the collection post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given movie.</param>
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
        public TraktSyncCollectionPostBuilder AddMovie(ITraktMovie movie, ITraktMetadata metadata, DateTime collectedAt)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();
            return AddMovieOrIgnore(movie, metadata, collectedAt);
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            return AddShowOrIgnore(show);
        }

        /// <summary>Adds a collection of <see cref="ITraktShow" />s, which will be added to the collection post.</summary>
        /// <param name="shows">A collection of Trakt shows, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given shows collection is null.
        /// Thrown, if one of the given shows is null.
        /// Thrown, if one of the given shows' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given shows has no valid ids set.
        /// Thrown, if one of the given shows has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            if (!shows.Any())
                return this;

            foreach (ITraktShow show in shows)
                AddShow(show);

            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktShow" />s, which will be added to the collection post.</summary>
        /// <param name="shows">
        /// A collection of Trakt show tuples - each containing a show, metadata and a collectedAt datetime -, which will be added.
        /// The given metadata and collectedAt datetime can be null.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given shows collection is null.
        /// Thrown, if one of the given shows is null.
        /// Thrown, if one of the given shows' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given shows has no valid ids set.
        /// Thrown, if one of the given shows has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddShows(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            if (!shows.Any())
                return this;

            foreach (Tuple<ITraktShow, ITraktMetadata, DateTime?> showValues in shows)
                AddShowOrIgnore(showValues.Item1, showValues.Item2, showValues.Item3);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, DateTime collectedAt)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            return AddShowOrIgnore(show, null, collectedAt);
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given show.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, ITraktMetadata metadata)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            return AddShowOrIgnore(show, metadata);
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given show.</param>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, ITraktMetadata metadata, DateTime collectedAt)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            return AddShowOrIgnore(show, metadata, collectedAt);
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, DateTime collectedAt, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, null, collectedAt);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="collectedAt">The datetime, when the given show was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, DateTime collectedAt, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, null, collectedAt);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given show.</param>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, ITraktMetadata metadata, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, metadata);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given show.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, ITraktMetadata metadata, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, metadata);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given show.</param>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, ITraktMetadata metadata, DateTime collectedAt, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, metadata, collectedAt);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given show.</param>
        /// <param name="collectedAt">The datetime, when the given show was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be added to the collection.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, ITraktMetadata metadata, DateTime collectedAt, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, metadata, collectedAt);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, DateTime collectedAt, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, null, collectedAt);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given show.</param>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, ITraktMetadata metadata, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, metadata);
            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the collection post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given show.</param>
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
        public TraktSyncCollectionPostBuilder AddShow(ITraktShow show, ITraktMetadata metadata, DateTime collectedAt, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();
            IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, metadata, collectedAt);
            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktShow" />s, which will be added to the collection post.</summary>
        /// <param name="shows">
        /// A collection of Trakt show tuples - each containing a show, metadata, a collectedAt datetime and a collection of seasons and episodes -, which will be added.
        /// The given metadata and collectedAt datetime can be null.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given shows collection is null.
        /// Thrown, if one of the given shows is null.
        /// Thrown, if one of the given shows' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given shows has no valid ids set.
        /// Thrown, if one of the given shows has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddShows(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            if (!shows.Any())
                return this;

            EnsureShowsListExists();

            foreach (Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons> showValues in shows)
            {
                IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons = CreateShowSeasons(showValues.Item4);
                CreateOrSetShow(showValues.Item1, showSeasons, showValues.Item2, showValues.Item3);
            }

            return this;
        }

        /// <summary>Adds a <see cref="ITraktEpisode" />, which will be added to the collection post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncCollectionPostBuilder AddEpisode(ITraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();
            return AddEpisodeOrIgnore(episode);
        }

        /// <summary>Adds a collection of <see cref="ITraktEpisode" />s, which will be added to the collection post.</summary>
        /// <param name="episodes">A collection of Trakt episodes, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episodes collection is null.
        /// Thrown, if one of the given episodes is null.
        /// Thrown, if one of the given episodes' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given episodes has no valid ids set.</exception>
        public TraktSyncCollectionPostBuilder AddEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            if (!episodes.Any())
                return this;

            foreach (ITraktEpisode episode in episodes)
                AddEpisode(episode);

            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktEpisode" />s, which will be added to the collection post.</summary>
        /// <param name="episodes">
        /// A collection of Trakt episode tuples - each containing a episode, metadata and a collectedAt datetime -, which will be added.
        /// The given metadata and collectedAt datetime can be null.
        /// </param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movies collection is null.
        /// Thrown, if one of the given movies is null.
        /// Thrown, if one of the given movies' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given movies has no valid ids set.
        /// Thrown, if one of the given movies has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncCollectionPostBuilder AddEpisodes(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            if (!episodes.Any())
                return this;

            foreach (Tuple<ITraktEpisode, ITraktMetadata, DateTime?> episodeValues in episodes)
                AddEpisodeOrIgnore(episodeValues.Item1, episodeValues.Item2, episodeValues.Item3);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktEpisode" />, which will be added to the collection post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="collectedAt">The datetime, when the given episode was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncCollectionPostBuilder AddEpisode(ITraktEpisode episode, DateTime collectedAt)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();
            return AddEpisodeOrIgnore(episode, null, collectedAt);
        }

        /// <summary>Adds a <see cref="ITraktEpisode" />, which will be added to the collection post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="metadata">An <see cref="TraktMetadata" /> instance, containing metadata about the given episode.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncCollectionPostBuilder AddEpisode(ITraktEpisode episode, TraktMetadata metadata)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();
            return AddEpisodeOrIgnore(episode, metadata);
        }

        /// <summary>Adds a <see cref="ITraktEpisode" />, which will be added to the collection post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="metadata">An <see cref="ITraktMetadata" /> instance, containing metadata about the given episode.</param>
        /// <param name="collectedAt">The datetime, when the given episode was collected. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncCollectionPostBuilder AddEpisode(ITraktEpisode episode, ITraktMetadata metadata, DateTime collectedAt)
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
                (_collectionPost.Movies as List<ITraktSyncCollectionPostMovie>)?.Clear();
                _collectionPost.Movies = null;
            }

            if (_collectionPost.Shows != null)
            {
                (_collectionPost.Shows as List<ITraktSyncCollectionPostShow>)?.Clear();
                _collectionPost.Shows = null;
            }

            if (_collectionPost.Episodes != null)
            {
                (_collectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)?.Clear();
                _collectionPost.Episodes = null;
            }
        }

        /// <summary>
        /// Returns an <see cref="ITraktSyncCollectionPost" /> instance, which contains all
        /// added movies, shows, seasons and episodes, including metadata and collected at UTC datetimes.
        /// </summary>
        /// <returns>An <see cref="TraktSyncCollectionPost" /> instance.</returns>
        public ITraktSyncCollectionPost Build() => _collectionPost;

        private void ValidateMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (!movie.Year.HasValue)
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

            if (!show.Year.HasValue)
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

        private bool ContainsMovie(ITraktMovie movie)
            => _collectionPost.Movies.Any(m => m.Ids == movie.Ids);

        private void EnsureMoviesListExists()
        {
            if (_collectionPost.Movies == null)
                _collectionPost.Movies = new List<ITraktSyncCollectionPostMovie>();
        }

        private bool ContainsShow(ITraktShow show)
            => _collectionPost.Shows.Any(s => s.Ids == show.Ids);

        private void EnsureShowsListExists()
        {
            if (_collectionPost.Shows == null)
                _collectionPost.Shows = new List<ITraktSyncCollectionPostShow>();
        }

        private bool ContainsEpisode(ITraktEpisode episode)
            => _collectionPost.Episodes.Any(e => e.Ids == episode.Ids);

        private void EnsureEpisodesListExists()
        {
            if (_collectionPost.Episodes == null)
                _collectionPost.Episodes = new List<ITraktSyncCollectionPostEpisode>();
        }

        private TraktSyncCollectionPostBuilder AddMovieOrIgnore(ITraktMovie movie, ITraktMetadata metadata = null,
                                                                DateTime? collectedAt = null)
        {
            if (ContainsMovie(movie))
                return this;

            var collectionMovie = new TraktSyncCollectionPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional
            };

            if (collectedAt.HasValue)
                collectionMovie.CollectedAt = collectedAt.Value.ToUniversalTime();

            (_collectionPost.Movies as List<ITraktSyncCollectionPostMovie>)?.Add(collectionMovie);
            return this;
        }

        private TraktSyncCollectionPostBuilder AddShowOrIgnore(ITraktShow show, ITraktMetadata metadata = null,
                                                               DateTime? collectedAt = null)
        {
            if (ContainsShow(show))
                return this;

            var collectionShow = new TraktSyncCollectionPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional
            };

            if (collectedAt.HasValue)
                collectionShow.CollectedAt = collectedAt.Value.ToUniversalTime();

            (_collectionPost.Shows as List<ITraktSyncCollectionPostShow>)?.Add(collectionShow);
            return this;
        }

        private TraktSyncCollectionPostBuilder AddEpisodeOrIgnore(ITraktEpisode episode, ITraktMetadata metadata = null,
                                                                  DateTime? collectedAt = null)
        {
            if (ContainsEpisode(episode))
                return this;

            var collectionEpisode = new TraktSyncCollectionPostEpisode
            {
                Ids = episode.Ids,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional
            };

            if (collectedAt.HasValue)
                collectionEpisode.CollectedAt = collectedAt.Value.ToUniversalTime();

            (_collectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)?.Add(collectionEpisode);
            return this;
        }

        private void CreateOrSetShow(ITraktShow show, IEnumerable<ITraktSyncCollectionPostShowSeason> showSeasons,
                                     ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            ITraktSyncCollectionPostShow existingShow = _collectionPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                var collectionShow = new TraktSyncCollectionPostShow
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year,
                    MediaType = metadata?.MediaType,
                    MediaResolution = metadata?.MediaResolution,
                    Audio = metadata?.Audio,
                    AudioChannels = metadata?.AudioChannels,
                    ThreeDimensional = metadata?.ThreeDimensional
                };

                if (collectedAt.HasValue)
                    collectionShow.CollectedAt = collectedAt.Value.ToUniversalTime();

                collectionShow.Seasons = showSeasons;
                (_collectionPost.Shows as List<ITraktSyncCollectionPostShow>)?.Add(collectionShow);
            }
        }

        private IEnumerable<ITraktSyncCollectionPostShowSeason> CreateShowSeasons(int season, params int[] seasons)
        {
            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);
            var showSeasons = new List<ITraktSyncCollectionPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncCollectionPostShowSeason
                {
                    Number = seasonsToAdd[i]
                });
            }

            return showSeasons;
        }

        private IEnumerable<ITraktSyncCollectionPostShowSeason> CreateShowSeasons(int[] seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            var showSeasons = new List<ITraktSyncCollectionPostShowSeason>();

            for (int i = 0; i < seasons.Length; i++)
            {
                if (seasons[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncCollectionPostShowSeason
                {
                    Number = seasons[i]
                });
            }

            return showSeasons;
        }

        private IEnumerable<ITraktSyncCollectionPostShowSeason> CreateShowSeasons(PostSeasons seasons)
        {
            var showSeasons = new List<ITraktSyncCollectionPostShowSeason>();

            foreach (PostSeason season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktSyncCollectionPostShowSeason
                {
                    Number = season.Number
                };

                if (season.Episodes?.Count() > 0)
                {
                    var showEpisodes = new List<ITraktSyncCollectionPostShowEpisode>();

                    foreach (PostEpisode episode in season.Episodes)
                    {
                        if (episode.Number < 0)
                            throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                        showEpisodes.Add(new TraktSyncCollectionPostShowEpisode
                        {
                            Number = episode.Number,
                            MediaType = episode.Metadata?.MediaType,
                            MediaResolution = episode.Metadata?.MediaResolution,
                            Audio = episode.Metadata?.Audio,
                            AudioChannels = episode.Metadata?.AudioChannels,
                            ThreeDimensional = episode.Metadata?.ThreeDimensional,
                            CollectedAt = episode.At
                        });
                    }

                    showSingleSeason.Episodes = showEpisodes;
                }

                showSeasons.Add(showSingleSeason);
            }

            return showSeasons;
        }
    }
}
