namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.History;

    internal sealed class SyncHistoryRemovePostBuilder
        : ARemovePostBuilder<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktSyncHistoryRemovePostBuilder
    {
        private readonly Lazy<List<ulong>> _historyIds;

        internal SyncHistoryRemovePostBuilder() => _historyIds = new Lazy<List<ulong>>();

        public ITraktSyncHistoryRemovePostBuilder WithHistoryId(ulong historyId)
        {
            _historyIds.Value.Add(historyId);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithHistoryIds(IEnumerable<ulong> historyIds)
        {
            if (historyIds == null)
                throw new ArgumentNullException(nameof(historyIds));

            _historyIds.Value.AddRange(historyIds);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithHistoryIds(ulong historyId, params ulong[] historyIds)
        {
            _historyIds.Value.Add(historyId);

            if (historyIds?.Length > 0)
                _historyIds.Value.AddRange(historyIds);

            return this;
        }

        public override ITraktSyncHistoryRemovePost Build()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = new TraktSyncHistoryRemovePost();
            AddMovies(syncHistoryRemovePost);
            AddShows(syncHistoryRemovePost);
            AddSeasons(syncHistoryRemovePost);
            AddEpisodes(syncHistoryRemovePost);
            AddHistoryIds(syncHistoryRemovePost);
            syncHistoryRemovePost.Validate();
            return syncHistoryRemovePost;
        }

        protected override ITraktSyncHistoryRemovePostBuilder GetBuilder() => this;

        private void AddMovies(ITraktSyncHistoryRemovePost syncHistoryRemovePost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated)
                return;

            syncHistoryRemovePost.Movies ??= new List<ITraktSyncHistoryRemovePostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (syncHistoryRemovePost.Movies as List<ITraktSyncHistoryRemovePostMovie>)
                        .Add(CreateHistoryRemovePostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (syncHistoryRemovePost.Movies as List<ITraktSyncHistoryRemovePostMovie>)
                        .Add(CreateHistoryRemovePostMovie(movieIds));
                }
            }
        }

        private void AddShows(ITraktSyncHistoryRemovePost syncHistoryRemovePost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated)
                return;

            syncHistoryRemovePost.Shows ??= new List<ITraktSyncHistoryRemovePostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryRemovePostShow>)
                        .Add(CreateHistoryRemovePostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryRemovePostShow>)
                        .Add(CreateHistoryRemovePostShow(showIds));
                }
            }

            if (_showsAndSeasons.IsValueCreated && _showsAndSeasons.Value.Any())
                CreateHistoryRemovePostShowAndSeasons(syncHistoryRemovePost, _showsAndSeasons.Value);

            if (_showIdsAndSeasons.IsValueCreated && _showIdsAndSeasons.Value.Any())
                CreateHistoryRemovePostShowIdsAndSeasons(syncHistoryRemovePost, _showIdsAndSeasons.Value);
        }

        private void AddSeasons(ITraktSyncHistoryRemovePost syncHistoryRemovePost)
        {
            if (!_seasons.IsValueCreated && !_seasonIds.IsValueCreated)
                return;

            syncHistoryRemovePost.Seasons ??= new List<ITraktSyncHistoryRemovePostSeason>();

            if (_seasons.IsValueCreated && _seasons.Value.Any())
            {
                foreach (ITraktSeason season in _seasons.Value)
                {
                    (syncHistoryRemovePost.Seasons as List<ITraktSyncHistoryRemovePostSeason>)
                        .Add(CreateHistoryRemovePostSeason(season));
                }
            }

            if (_seasonIds.IsValueCreated && _seasonIds.Value.Any())
            {
                foreach (ITraktSeasonIds seasonIds in _seasonIds.Value)
                {
                    (syncHistoryRemovePost.Seasons as List<ITraktSyncHistoryRemovePostSeason>)
                        .Add(CreateHistoryRemovePostSeason(seasonIds));
                }
            }
        }

        private void AddEpisodes(ITraktSyncHistoryRemovePost syncHistoryRemovePost)
        {
            if (!_episodes.IsValueCreated && !_episodeIds.IsValueCreated)
                return;

            syncHistoryRemovePost.Episodes ??= new List<ITraktSyncHistoryRemovePostEpisode>();

            if (_episodes.IsValueCreated && _episodes.Value.Any())
            {
                foreach (ITraktEpisode episode in _episodes.Value)
                {
                    (syncHistoryRemovePost.Episodes as List<ITraktSyncHistoryRemovePostEpisode>)
                        .Add(CreateHistoryRemovePostEpisode(episode));
                }
            }

            if (_episodeIds.IsValueCreated && _episodeIds.Value.Any())
            {
                foreach (ITraktEpisodeIds episodeIds in _episodeIds.Value)
                {
                    (syncHistoryRemovePost.Episodes as List<ITraktSyncHistoryRemovePostEpisode>)
                        .Add(CreateHistoryRemovePostEpisode(episodeIds));
                }
            }
        }

        private void AddHistoryIds(ITraktSyncHistoryRemovePost syncHistoryRemovePost)
        {
            if (_historyIds.IsValueCreated && _historyIds.Value.Any())
                syncHistoryRemovePost.HistoryIds = _historyIds.Value;
        }

        private static ITraktSyncHistoryRemovePostMovie CreateHistoryRemovePostMovie(ITraktMovie movie)
            => new TraktSyncHistoryRemovePostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

        private static ITraktSyncHistoryRemovePostMovie CreateHistoryRemovePostMovie(ITraktMovieIds movieIds)
            => new TraktSyncHistoryRemovePostMovie { Ids = movieIds };

        private static ITraktSyncHistoryRemovePostShow CreateHistoryRemovePostShow(ITraktShow show)
            => new TraktSyncHistoryRemovePostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

        private static ITraktSyncHistoryRemovePostShow CreateHistoryRemovePostShow(ITraktShowIds showIds)
            => new TraktSyncHistoryRemovePostShow { Ids = showIds };

        private static void CreateHistoryRemovePostShowAndSeasons(ITraktSyncHistoryRemovePost syncHistoryRemovePost, List<ShowAndSeasons> showsAndSeasons)
        {
            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                ITraktSyncHistoryRemovePostShow syncHistoryRemovePostShow = CreateHistoryRemovePostShow(showAndSeasons.Object);
                CreateHistoryRemovePostShowSeasons(syncHistoryRemovePost, showAndSeasons.Seasons, syncHistoryRemovePostShow);
            }
        }

        private static void CreateHistoryRemovePostShowIdsAndSeasons(ITraktSyncHistoryRemovePost syncHistoryRemovePost, List<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                ITraktSyncHistoryRemovePostShow syncHistoryRemovePostShow = CreateHistoryRemovePostShow(showIdAndSeasons.Object);
                CreateHistoryRemovePostShowSeasons(syncHistoryRemovePost, showIdAndSeasons.Seasons, syncHistoryRemovePostShow);
            }
        }

        private static void CreateHistoryRemovePostShowSeasons(ITraktSyncHistoryRemovePost syncHistoryRemovePost, PostSeasons seasons, ITraktSyncHistoryRemovePostShow syncHistoryRemovePostShow)
        {
            if (seasons.Any())
            {
                syncHistoryRemovePostShow.Seasons = new List<ITraktSyncHistoryRemovePostShowSeason>();

                foreach (PostSeason season in seasons)
                {
                    ITraktSyncHistoryRemovePostShowSeason syncHistoryRemovePostShowSeason = CreateHistoryRemovePostShowSeason(season);

                    if (season.Episodes != null && season.Episodes.Any())
                    {
                        syncHistoryRemovePostShowSeason.Episodes = new List<ITraktSyncHistoryRemovePostShowEpisode>();

                        foreach (PostEpisode episode in season.Episodes)
                        {
                            (syncHistoryRemovePostShowSeason.Episodes as List<ITraktSyncHistoryRemovePostShowEpisode>)
                                .Add(CreateHistoryRemovePostShowEpisode(episode));
                        }
                    }

                    (syncHistoryRemovePostShow.Seasons as List<ITraktSyncHistoryRemovePostShowSeason>).Add(syncHistoryRemovePostShowSeason);
                }
            }

            (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryRemovePostShow>).Add(syncHistoryRemovePostShow);
        }

        private static ITraktSyncHistoryRemovePostShowSeason CreateHistoryRemovePostShowSeason(PostSeason season)
            => new TraktSyncHistoryRemovePostShowSeason { Number = season.Number };

        private static ITraktSyncHistoryRemovePostShowEpisode CreateHistoryRemovePostShowEpisode(PostEpisode episode)
            => new TraktSyncHistoryRemovePostShowEpisode { Number = episode.Number };

        private static ITraktSyncHistoryRemovePostSeason CreateHistoryRemovePostSeason(ITraktSeason season)
            => new TraktSyncHistoryRemovePostSeason { Ids = season.Ids };

        private static ITraktSyncHistoryRemovePostSeason CreateHistoryRemovePostSeason(ITraktSeasonIds seasonIds)
            => new TraktSyncHistoryRemovePostSeason { Ids = seasonIds };

        private static ITraktSyncHistoryRemovePostEpisode CreateHistoryRemovePostEpisode(ITraktEpisode episode)
            => new TraktSyncHistoryRemovePostEpisode { Ids = episode.Ids };

        private static ITraktSyncHistoryRemovePostEpisode CreateHistoryRemovePostEpisode(ITraktEpisodeIds episodeIds)
            => new TraktSyncHistoryRemovePostEpisode { Ids = episodeIds };
    }
}
