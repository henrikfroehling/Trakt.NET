namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.History;

    internal sealed class SyncHistoryPostBuilder : ITraktSyncHistoryPostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<WatchedMovie>> _moviesWatchedAt;
        private readonly Lazy<List<WatchedMovieIds>> _movieIdsWatchedAt;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;
        private readonly Lazy<List<WatchedShow>> _showsWatchedAt;
        private readonly Lazy<List<WatchedShowIds>> _showIdsWatchedAt;
        private readonly Lazy<List<WatchedShowAndSeasons>> _showsAndSeasons;
        private readonly Lazy<List<WatchedShowIdsAndSeasons>> _showIdsAndSeasons;
        private readonly Lazy<List<ITraktSeason>> _seasons;
        private readonly Lazy<List<ITraktSeasonIds>> _seasonIds;
        private readonly Lazy<List<WatchedSeason>> _seasonsWatchedAt;
        private readonly Lazy<List<WatchedSeasonIds>> _seasonIdsWatchedAt;
        private readonly Lazy<List<ITraktEpisode>> _episodes;
        private readonly Lazy<List<ITraktEpisodeIds>> _episodeIds;
        private readonly Lazy<List<WatchedEpisode>> _episodesWatchedAt;
        private readonly Lazy<List<WatchedEpisodeIds>> _episodeIdsWatchedAt;

        internal SyncHistoryPostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>(() => new List<ITraktMovie>());
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _moviesWatchedAt = new Lazy<List<WatchedMovie>>();
            _movieIdsWatchedAt = new Lazy<List<WatchedMovieIds>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
            _showsWatchedAt = new Lazy<List<WatchedShow>>();
            _showIdsWatchedAt = new Lazy<List<WatchedShowIds>>();
            _showsAndSeasons = new Lazy<List<WatchedShowAndSeasons>>();
            _showIdsAndSeasons = new Lazy<List<WatchedShowIdsAndSeasons>>();
            _seasons = new Lazy<List<ITraktSeason>>();
            _seasonIds = new Lazy<List<ITraktSeasonIds>>();
            _seasonsWatchedAt = new Lazy<List<WatchedSeason>>();
            _seasonIdsWatchedAt = new Lazy<List<WatchedSeasonIds>>();
            _episodes = new Lazy<List<ITraktEpisode>>();
            _episodeIds = new Lazy<List<ITraktEpisodeIds>>();
            _episodesWatchedAt = new Lazy<List<WatchedEpisode>>();
            _episodeIdsWatchedAt = new Lazy<List<WatchedEpisodeIds>>();
        }

        public ITraktSyncHistoryPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithMovieWatchedAt(ITraktMovie movie, DateTime watchedAt)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            return WithMovieWatchedAt(new WatchedMovie(movie, watchedAt));
        }

        public ITraktSyncHistoryPostBuilder WithMovieWatchedAt(WatchedMovie movieWatchedAt)
        {
            if (movieWatchedAt == null)
                throw new ArgumentNullException(nameof(movieWatchedAt));

            _moviesWatchedAt.Value.Add(movieWatchedAt);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithMovieWatchedAt(ITraktMovieIds movieIds, DateTime watchedAt)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            return WithMovieWatchedAt(new WatchedMovieIds(movieIds, watchedAt));
        }

        public ITraktSyncHistoryPostBuilder WithMovieWatchedAt(WatchedMovieIds movieIdsWatchedAt)
        {
            if (movieIdsWatchedAt == null)
                throw new ArgumentNullException(nameof(movieIdsWatchedAt));

            _movieIdsWatchedAt.Value.Add(movieIdsWatchedAt);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
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

        public ITraktSyncHistoryPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
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

        public ITraktSyncHistoryPostBuilder WithMoviesWatchedAt(IEnumerable<WatchedMovie> moviesWatchedAt)
        {
            if (moviesWatchedAt == null)
                throw new ArgumentNullException(nameof(moviesWatchedAt));

            foreach (WatchedMovie movieWatchedAt in moviesWatchedAt)
            {
                if (movieWatchedAt != null)
                    _moviesWatchedAt.Value.Add(movieWatchedAt);
            }

            return this;
        }

        public ITraktSyncHistoryPostBuilder WithMoviesWatchedAt(IEnumerable<WatchedMovieIds> movieIdsWatchedAt)
        {
            if (movieIdsWatchedAt == null)
                throw new ArgumentNullException(nameof(movieIdsWatchedAt));

            foreach (WatchedMovieIds movieIdWatchedAt in movieIdsWatchedAt)
            {
                if (movieIdWatchedAt != null)
                    _movieIdsWatchedAt.Value.Add(movieIdWatchedAt);
            }

            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShowWatchedAt(ITraktShow show, DateTime watchedAt)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return WithShowWatchedAt(new WatchedShow(show, watchedAt));
        }

        public ITraktSyncHistoryPostBuilder WithShowWatchedAt(WatchedShow showWatchedAt)
        {
            if (showWatchedAt == null)
                throw new ArgumentNullException(nameof(showWatchedAt));

            _showsWatchedAt.Value.Add(showWatchedAt);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShowWatchedAt(ITraktShowIds showIds, DateTime watchedAt)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            return WithShowWatchedAt(new WatchedShowIds(showIds, watchedAt));
        }

        public ITraktSyncHistoryPostBuilder WithShowWatchedAt(WatchedShowIds showIdsWatchedAt)
        {
            if (showIdsWatchedAt == null)
                throw new ArgumentNullException(nameof(showIdsWatchedAt));

            _showIdsWatchedAt.Value.Add(showIdsWatchedAt);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShows(IEnumerable<ITraktShow> shows)
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

        public ITraktSyncHistoryPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
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

        public ITraktSyncHistoryPostBuilder WithShowsWatchedAt(IEnumerable<WatchedShow> showsWatchedAt)
        {
            if (showsWatchedAt == null)
                throw new ArgumentNullException(nameof(showsWatchedAt));

            foreach (WatchedShow showWatchedAt in showsWatchedAt)
            {
                if (showWatchedAt != null)
                    _showsWatchedAt.Value.Add(showWatchedAt);
            }

            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShowsWatchedAt(IEnumerable<WatchedShowIds> showIdsWatchedAt)
        {
            if (showIdsWatchedAt == null)
                throw new ArgumentNullException(nameof(showIdsWatchedAt));

            foreach (WatchedShowIds showIdWatchedAt in showIdsWatchedAt)
            {
                if (showIdWatchedAt != null)
                    _showIdsWatchedAt.Value.Add(showIdWatchedAt);
            }

            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShowAndSeasons(ITraktShow show, PostHistorySeasons seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new WatchedShowAndSeasons(show, seasons));
        }

        public ITraktSyncHistoryPostBuilder WithShowAndSeasons(WatchedShowAndSeasons showAndSeasons)
        {
            if (showAndSeasons == null)
                throw new ArgumentNullException(nameof(showAndSeasons));

            _showsAndSeasons.Value.Add(showAndSeasons);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostHistorySeasons seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new WatchedShowIdsAndSeasons(showIds, seasons));
        }

        public ITraktSyncHistoryPostBuilder WithShowAndSeasons(WatchedShowIdsAndSeasons showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            _showIdsAndSeasons.Value.Add(showIdsAndSeasons);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShowsAndSeasons(IEnumerable<WatchedShowAndSeasons> showsAndSeasons)
        {
            if (showsAndSeasons == null)
                throw new ArgumentNullException(nameof(showsAndSeasons));

            foreach (WatchedShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                if (showAndSeasons != null)
                    _showsAndSeasons.Value.Add(showAndSeasons);
            }

            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShowsAndSeasons(IEnumerable<WatchedShowIdsAndSeasons> showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            foreach (WatchedShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                if (showIdAndSeasons != null)
                    _showIdsAndSeasons.Value.Add(showIdAndSeasons);
            }

            return this;
        }

        public ITraktSyncHistoryPostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            _seasons.Value.Add(season);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithSeason(ITraktSeasonIds seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            _seasonIds.Value.Add(seasonIds);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(ITraktSeason season, DateTime watchedAt)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            return WithSeasonWatchedAt(new WatchedSeason(season, watchedAt));
        }

        public ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(WatchedSeason seasonWatchedAt)
        {
            if (seasonWatchedAt == null)
                throw new ArgumentNullException(nameof(seasonWatchedAt));

            _seasonsWatchedAt.Value.Add(seasonWatchedAt);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(ITraktSeasonIds seasonIds, DateTime watchedAt)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            return WithSeasonWatchedAt(new WatchedSeasonIds(seasonIds, watchedAt));
        }

        public ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(WatchedSeasonIds seasonIdsWatchedAt)
        {
            if (seasonIdsWatchedAt == null)
                throw new ArgumentNullException(nameof(seasonIdsWatchedAt));

            _seasonIdsWatchedAt.Value.Add(seasonIdsWatchedAt);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
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

        public ITraktSyncHistoryPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds)
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

        public ITraktSyncHistoryPostBuilder WithSeasonsWatchedAt(IEnumerable<WatchedSeason> seasonsWatchedAt)
        {
            if (seasonsWatchedAt == null)
                throw new ArgumentNullException(nameof(seasonsWatchedAt));

            foreach (WatchedSeason seasonWatchedAt in seasonsWatchedAt)
            {
                if (seasonWatchedAt != null)
                    _seasonsWatchedAt.Value.Add(seasonWatchedAt);
            }

            return this;
        }

        public ITraktSyncHistoryPostBuilder WithSeasonsWatchedAt(IEnumerable<WatchedSeasonIds> seasonIdsWatchedAt)
        {
            if (seasonIdsWatchedAt == null)
                throw new ArgumentNullException(nameof(seasonIdsWatchedAt));

            foreach (WatchedSeasonIds seasonIdWatchedAt in seasonIdsWatchedAt)
            {
                if (seasonIdWatchedAt != null)
                    _seasonIdsWatchedAt.Value.Add(seasonIdWatchedAt);
            }

            return this;
        }

        public ITraktSyncHistoryPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Value.Add(episode);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithEpisode(ITraktEpisodeIds episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            _episodeIds.Value.Add(episodeIds);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(ITraktEpisode episode, DateTime watchedAt)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            return WithEpisodeWatchedAt(new WatchedEpisode(episode, watchedAt));
        }

        public ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(WatchedEpisode episodeWatchedAt)
        {
            if (episodeWatchedAt == null)
                throw new ArgumentNullException(nameof(episodeWatchedAt));

            _episodesWatchedAt.Value.Add(episodeWatchedAt);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(ITraktEpisodeIds episodeIds, DateTime watchedAt)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            return WithEpisodeWatchedAt(new WatchedEpisodeIds(episodeIds, watchedAt));
        }

        public ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(WatchedEpisodeIds episodeIdsWatchedAt)
        {
            if (episodeIdsWatchedAt == null)
                throw new ArgumentNullException(nameof(episodeIdsWatchedAt));

            _episodeIdsWatchedAt.Value.Add(episodeIdsWatchedAt);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
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

        public ITraktSyncHistoryPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds)
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

        public ITraktSyncHistoryPostBuilder WithEpisodesWatchedAt(IEnumerable<WatchedEpisode> episodesWatchedAt)
        {
            if (episodesWatchedAt == null)
                throw new ArgumentNullException(nameof(episodesWatchedAt));

            foreach (WatchedEpisode episodeWatchedAt in episodesWatchedAt)
            {
                if (episodeWatchedAt != null)
                    _episodesWatchedAt.Value.Add(episodeWatchedAt);
            }

            return this;
        }

        public ITraktSyncHistoryPostBuilder WithEpisodesWatchedAt(IEnumerable<WatchedEpisodeIds> episodeIdsWatchedAt)
        {
            if (episodeIdsWatchedAt == null)
                throw new ArgumentNullException(nameof(episodeIdsWatchedAt));

            foreach (WatchedEpisodeIds episodeIdWatchedAt in episodeIdsWatchedAt)
            {
                if (episodeIdWatchedAt != null)
                    _episodeIdsWatchedAt.Value.Add(episodeIdWatchedAt);
            }

            return this;
        }

        public ITraktSyncHistoryPost Build()
        {
            ITraktSyncHistoryPost syncHistoryPost = new TraktSyncHistoryPost();
            AddMovies(syncHistoryPost);
            AddShows(syncHistoryPost);
            AddSeasons(syncHistoryPost);
            AddEpisodes(syncHistoryPost);
            syncHistoryPost.Validate();
            return syncHistoryPost;
        }

        private void AddMovies(ITraktSyncHistoryPost syncHistoryPost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated && !_moviesWatchedAt.IsValueCreated && !_movieIdsWatchedAt.IsValueCreated)
                return;

            syncHistoryPost.Movies ??= new List<ITraktSyncHistoryPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (syncHistoryPost.Movies as List<ITraktSyncHistoryPostMovie>)
                        .Add(CreateHistoryPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (syncHistoryPost.Movies as List<ITraktSyncHistoryPostMovie>)
                        .Add(CreateHistoryPostMovie(movieIds));
                }
            }

            if (_moviesWatchedAt.IsValueCreated && _moviesWatchedAt.Value.Any())
            {
                foreach (WatchedMovie movieWatchedAt in _moviesWatchedAt.Value)
                {
                    (syncHistoryPost.Movies as List<ITraktSyncHistoryPostMovie>)
                        .Add(CreateHistoryPostMovie(movieWatchedAt.Object, movieWatchedAt.WatchedAt));
                }
            }

            if (_movieIdsWatchedAt.IsValueCreated && _movieIdsWatchedAt.Value.Any())
            {
                foreach (WatchedMovieIds movieIdWatchedAt in _movieIdsWatchedAt.Value)
                {
                    (syncHistoryPost.Movies as List<ITraktSyncHistoryPostMovie>)
                        .Add(CreateHistoryPostMovie(movieIdWatchedAt.Object, movieIdWatchedAt.WatchedAt));
                }
            }
        }

        private void AddShows(ITraktSyncHistoryPost syncHistoryPost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated && !_showsWatchedAt.IsValueCreated
               && !_showIdsWatchedAt.IsValueCreated && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated)
            {
                return;
            }

            syncHistoryPost.Shows ??= new List<ITraktSyncHistoryPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>)
                        .Add(CreateHistoryPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>)
                        .Add(CreateHistoryPostShow(showIds));
                }
            }

            if (_showsWatchedAt.IsValueCreated && _showsWatchedAt.Value.Any())
            {
                foreach (WatchedShow showWatchedAt in _showsWatchedAt.Value)
                {
                    (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>)
                        .Add(CreateHistoryPostShow(showWatchedAt.Object, showWatchedAt.WatchedAt));
                }
            }

            if (_showIdsWatchedAt.IsValueCreated && _showIdsWatchedAt.Value.Any())
            {
                foreach (WatchedShowIds showIdWatchedAt in _showIdsWatchedAt.Value)
                {
                    (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>)
                        .Add(CreateHistoryPostShow(showIdWatchedAt.Object, showIdWatchedAt.WatchedAt));
                }
            }

            // TODO show and seasons
        }

        private void AddSeasons(ITraktSyncHistoryPost syncHistoryPost)
        {
            if (!_seasons.IsValueCreated && !_seasonIds.IsValueCreated && !_seasonsWatchedAt.IsValueCreated && !_seasonIdsWatchedAt.IsValueCreated)
                return;

            // TODO
        }

        private void AddEpisodes(ITraktSyncHistoryPost syncHistoryPost)
        {
            if (!_episodes.IsValueCreated && !_episodeIds.IsValueCreated && !_episodesWatchedAt.IsValueCreated && !_episodeIdsWatchedAt.IsValueCreated)
                return;

            syncHistoryPost.Episodes ??= new List<ITraktSyncHistoryPostEpisode>();

            if (_episodes.IsValueCreated && _episodes.Value.Any())
            {
                foreach (ITraktEpisode episode in _episodes.Value)
                {
                    (syncHistoryPost.Episodes as List<ITraktSyncHistoryPostEpisode>)
                        .Add(CreateHistoryPostEpisode(episode));
                }
            }

            if (_episodeIds.IsValueCreated && _episodeIds.Value.Any())
            {
                foreach (ITraktEpisodeIds episodeIds in _episodeIds.Value)
                {
                    (syncHistoryPost.Episodes as List<ITraktSyncHistoryPostEpisode>)
                        .Add(CreateHistoryPostEpisode(episodeIds));
                }
            }

            if (_episodesWatchedAt.IsValueCreated && _episodesWatchedAt.Value.Any())
            {
                foreach (WatchedEpisode episodeWatchedAt in _episodesWatchedAt.Value)
                {
                    (syncHistoryPost.Episodes as List<ITraktSyncHistoryPostEpisode>)
                        .Add(CreateHistoryPostEpisode(episodeWatchedAt.Object, episodeWatchedAt.WatchedAt));
                }
            }

            if (_episodeIdsWatchedAt.IsValueCreated && _episodeIdsWatchedAt.Value.Any())
            {
                foreach (WatchedEpisodeIds episodeIdWatchedAt in _episodeIdsWatchedAt.Value)
                {
                    (syncHistoryPost.Episodes as List<ITraktSyncHistoryPostEpisode>)
                        .Add(CreateHistoryPostEpisode(episodeIdWatchedAt.Object, episodeIdWatchedAt.WatchedAt));
                }
            }

        }

        private static ITraktSyncHistoryPostMovie CreateHistoryPostMovie(ITraktMovie movie, DateTime? watchedAt = null)
        {
            ITraktSyncHistoryPostMovie syncHistoryPostMovie = new TraktSyncHistoryPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            if (watchedAt.HasValue)
                syncHistoryPostMovie.WatchedAt = watchedAt.Value;

            return syncHistoryPostMovie;
        }

        private static ITraktSyncHistoryPostMovie CreateHistoryPostMovie(ITraktMovieIds movieIds, DateTime? watchedAt = null)
        {
            ITraktSyncHistoryPostMovie syncHistoryPostMovie = new TraktSyncHistoryPostMovie
            {
                Ids = movieIds
            };

            if (watchedAt.HasValue)
                syncHistoryPostMovie.WatchedAt = watchedAt.Value;

            return syncHistoryPostMovie;
        }

        private static ITraktSyncHistoryPostShow CreateHistoryPostShow(ITraktShow show, DateTime? watchedAt = null)
        {
            ITraktSyncHistoryPostShow syncHistoryPostShow = new TraktSyncHistoryPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (watchedAt.HasValue)
                syncHistoryPostShow.WatchedAt = watchedAt.Value;

            return syncHistoryPostShow;
        }

        private static ITraktSyncHistoryPostShow CreateHistoryPostShow(ITraktShowIds showIds, DateTime? watchedAt = null)
        {
            ITraktSyncHistoryPostShow syncHistoryPostShow = new TraktSyncHistoryPostShow
            {
                Ids = showIds
            };

            if (watchedAt.HasValue)
                syncHistoryPostShow.WatchedAt = watchedAt.Value;

            return syncHistoryPostShow;
        }

        private static ITraktSyncHistoryPostEpisode CreateHistoryPostEpisode(ITraktEpisode episode, DateTime? watchedAt = null)
        {
            ITraktSyncHistoryPostEpisode syncHistoryPostEpisode = new TraktSyncHistoryPostEpisode
            {
                Ids = episode.Ids
            };

            if (watchedAt.HasValue)
                syncHistoryPostEpisode.WatchedAt = watchedAt.Value;

            return syncHistoryPostEpisode;
        }

        private static ITraktSyncHistoryPostEpisode CreateHistoryPostEpisode(ITraktEpisodeIds episodeIds, DateTime? watchedAt = null)
        {
            ITraktSyncHistoryPostEpisode syncHistoryPostEpisode = new TraktSyncHistoryPostEpisode
            {
                Ids = episodeIds
            };

            if (watchedAt.HasValue)
                syncHistoryPostEpisode.WatchedAt = watchedAt.Value;

            return syncHistoryPostEpisode;
        }
    }
}
