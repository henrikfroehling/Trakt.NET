namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt history post, containing all movies, shows and / or episodes,
    /// which should be added to the user's history.
    /// </summary>
    public class TraktSyncHistoryPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostMovie" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncHistoryPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostShow" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncHistoryPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncHistoryPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncHistoryPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        public static TraktSyncHistoryPostBuilder Builder() => new TraktSyncHistoryPostBuilder();
    }

    /// <summary>
    /// This is a helper class to build a <see cref="TraktSyncHistoryPost" />.
    /// <para>
    /// It is recommended to use this class to build a history post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncHistoryPost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncHistoryPostBuilder : TraktSyncHistoryRemovePostBuilder
    {
        /// <summary>Initializes a new instance of the <see cref="TraktSyncHistoryPostBuilder" /> class.</summary>
        public TraktSyncHistoryPostBuilder() : base() { }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the history post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public new TraktSyncHistoryPostBuilder AddMovie(TraktMovie movie)
        {
            base.AddMovie(movie);
            return this;
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the history post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given movie was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryPostBuilder AddMovie(TraktMovie movie, DateTime watchedAt)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, watchedAt) as TraktSyncHistoryPostBuilder;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public new TraktSyncHistoryPostBuilder AddShow(TraktShow show)
        {
            base.AddShow(show);
            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given show was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, DateTime watchedAt)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, watchedAt) as TraktSyncHistoryPostBuilder;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the history.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
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
        public new TraktSyncHistoryPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            base.AddShow(show, season, seasons);
            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given show was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the history.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
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
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, DateTime watchedAt, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, watchedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An <see cref="PostHistorySeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
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
        public new TraktSyncHistoryPostBuilder AddShow(TraktShow show, PostHistorySeasons seasons)
        {
            base.AddShow(show, seasons);
            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given show was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="seasons">
        /// An <see cref="PostHistorySeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
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
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, DateTime watchedAt, PostHistorySeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, watchedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the history post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public new TraktSyncHistoryPostBuilder AddEpisode(TraktEpisode episode)
        {
            base.AddEpisode(episode);
            return this;
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the history post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given episode was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncHistoryPostBuilder AddEpisode(TraktEpisode episode, DateTime watchedAt)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, watchedAt) as TraktSyncHistoryPostBuilder;
        }

        /// <summary>
        /// Returns an <see cref="TraktSyncHistoryPost" /> instance, which contains all
        /// added movies, shows, seasons and episodes, including watched at UTC datetimes.
        /// </summary>
        /// <returns>An <see cref="TraktSyncHistoryPost" /> instance.</returns>
        public new TraktSyncHistoryPost Build() => _historyPost;
    }
}
