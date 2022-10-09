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

    internal sealed class SyncHistoryRemovePostBuilder : ITraktSyncHistoryRemovePostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;
        private readonly Lazy<List<ShowAndSeasons>> _showsAndSeasons;
        private readonly Lazy<List<ShowIdsAndSeasons>> _showIdsAndSeasons;
        private readonly Lazy<List<ITraktSeason>> _seasons;
        private readonly Lazy<List<ITraktSeasonIds>> _seasonIds;
        private readonly Lazy<List<ITraktEpisode>> _episodes;
        private readonly Lazy<List<ITraktEpisodeIds>> _episodeIds;
        private readonly Lazy<List<ulong>> _historyIds;

        internal SyncHistoryRemovePostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>();
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
            _showsAndSeasons = new Lazy<List<ShowAndSeasons>>();
            _showIdsAndSeasons = new Lazy<List<ShowIdsAndSeasons>>();
            _seasons = new Lazy<List<ITraktSeason>>();
            _seasonIds = new Lazy<List<ITraktSeasonIds>>();
            _episodes = new Lazy<List<ITraktEpisode>>();
            _episodeIds = new Lazy<List<ITraktEpisodeIds>>();
            _historyIds = new Lazy<List<ulong>>();
        }

        public ITraktSyncHistoryRemovePostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (ITraktMovie movie in movies)
            {
                if (movie != null)
                    _movies.Value.Add(movie);
            }

            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            foreach (ITraktMovieIds movieId in movieIds)
            {
                if (movieId != null)
                    _movieIds.Value.Add(movieId);
            }

            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (ITraktShow show in shows)
            {
                if (show != null)
                    _shows.Value.Add(show);
            }

            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            foreach (ITraktShowIds showId in showIds)
            {
                if (showId != null)
                    _showIds.Value.Add(showId);
            }

            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShowAndSeasons(ITraktShow show, PostSeasons seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new ShowAndSeasons(show, seasons));
        }

        public ITraktSyncHistoryRemovePostBuilder WithShowAndSeasons(ShowAndSeasons showAndSeasons)
        {
            if (showAndSeasons == null)
                throw new ArgumentNullException(nameof(showAndSeasons));

            _showsAndSeasons.Value.Add(showAndSeasons);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostSeasons seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new ShowIdsAndSeasons(showIds, seasons));
        }

        public ITraktSyncHistoryRemovePostBuilder WithShowAndSeasons(ShowIdsAndSeasons showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            _showIdsAndSeasons.Value.Add(showIdsAndSeasons);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShowsAndSeasons(IEnumerable<ShowAndSeasons> showsAndSeasons)
        {
            if (showsAndSeasons == null)
                throw new ArgumentNullException(nameof(showsAndSeasons));

            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                if (showAndSeasons != null)
                    _showsAndSeasons.Value.Add(showAndSeasons);
            }

            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShowsAndSeasons(IEnumerable<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                if (showIdAndSeasons != null)
                    _showIdsAndSeasons.Value.Add(showIdAndSeasons);
            }

            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            _seasons.Value.Add(season);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithSeason(ITraktSeasonIds seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            _seasonIds.Value.Add(seasonIds);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            foreach (ITraktSeason season in seasons)
            {
                if (season != null)
                    _seasons.Value.Add(season);
            }

            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            foreach (ITraktSeasonIds seasonId in seasonIds)
            {
                if (seasonId != null)
                    _seasonIds.Value.Add(seasonId);
            }

            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Value.Add(episode);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithEpisode(ITraktEpisodeIds episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            _episodeIds.Value.Add(episodeIds);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            foreach (ITraktEpisode episode in episodes)
            {
                if (episode != null)
                    _episodes.Value.Add(episode);
            }

            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            foreach (ITraktEpisodeIds episodeId in episodeIds)
            {
                if (episodeId != null)
                    _episodeIds.Value.Add(episodeId);
            }

            return this;
        }

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

        public ITraktSyncHistoryRemovePost Build()
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
