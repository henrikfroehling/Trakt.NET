namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class TraktSyncHistoryPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncHistoryPostMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncHistoryPostShow> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncHistoryPostEpisode> Episodes { get; set; }

        public static TraktSyncHistoryPostBuilder Builder() => new TraktSyncHistoryPostBuilder();
    }

    public class TraktSyncHistoryPostBuilder : TraktSyncHistoryRemovePostBuilder
    {
        public TraktSyncHistoryPostBuilder() : base() { }

        public new TraktSyncHistoryPostBuilder AddMovie(TraktMovie movie)
        {
            base.AddMovie(movie);
            return this;
        }

        public TraktSyncHistoryPostBuilder AddMovie(TraktMovie movie, DateTime watchedAt)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, watchedAt) as TraktSyncHistoryPostBuilder;
        }

        public new TraktSyncHistoryPostBuilder AddShow(TraktShow show)
        {
            base.AddShow(show);
            return this;
        }

        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, DateTime watchedAt)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, watchedAt) as TraktSyncHistoryPostBuilder;
        }

        public new TraktSyncHistoryPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            base.AddShow(show, season, seasons);
            return this;
        }

        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, DateTime watchedAt, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, watchedAt);

            return this;
        }

        public new TraktSyncHistoryPostBuilder AddShow(TraktShow show, PostHistorySeasons seasons)
        {
            base.AddShow(show, seasons);
            return this;
        }

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

        public new TraktSyncHistoryPostBuilder AddEpisode(TraktEpisode episode)
        {
            base.AddEpisode(episode);
            return this;
        }

        public TraktSyncHistoryPostBuilder AddEpisode(TraktEpisode episode, DateTime watchedAt)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, watchedAt) as TraktSyncHistoryPostBuilder;
        }

        public new TraktSyncHistoryPost Build()
        {
            return _historyPost;
        }
    }
}
