namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Watchlist;

    internal sealed class SyncWatchlistRemovePostBuilder
        : ARemovePostBuilder<ITraktSyncWatchlistRemovePostBuilder, ITraktSyncWatchlistRemovePost>,
          ITraktSyncWatchlistRemovePostBuilder
    {
        public override ITraktSyncWatchlistRemovePost Build()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = new TraktSyncWatchlistRemovePost();
            AddMovies(syncWatchlistRemovePost);
            AddShows(syncWatchlistRemovePost);
            AddSeasons(syncWatchlistRemovePost);
            AddEpisodes(syncWatchlistRemovePost);
            syncWatchlistRemovePost.Validate();
            return syncWatchlistRemovePost;
        }

        protected override ITraktSyncWatchlistRemovePostBuilder GetBuilder() => this;

        private void AddMovies(ITraktSyncWatchlistRemovePost syncWatchlistRemovePost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated)
                return;

            syncWatchlistRemovePost.Movies ??= new List<ITraktSyncWatchlistPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                    syncWatchlistRemovePost.Movies.Add(CreateWatchlistPostMovie(movie));
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                    syncWatchlistRemovePost.Movies.Add(CreateWatchlistPostMovie(movieIds));
            }
        }

        private void AddShows(ITraktSyncWatchlistRemovePost syncWatchlistRemovePost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated)
                return;

            syncWatchlistRemovePost.Shows ??= new List<ITraktSyncWatchlistPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                    syncWatchlistRemovePost.Shows.Add(CreateWatchlistPostShow(show));
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                    syncWatchlistRemovePost.Shows.Add(CreateWatchlistRemovePostShow(showIds));
            }

            if (_showsAndSeasons.IsValueCreated && _showsAndSeasons.Value.Any())
                CreateWatchlistPostShowAndSeasons(syncWatchlistRemovePost, _showsAndSeasons.Value);

            if (_showIdsAndSeasons.IsValueCreated && _showIdsAndSeasons.Value.Any())
                CreateWatchlistPostShowIdsAndSeasons(syncWatchlistRemovePost, _showIdsAndSeasons.Value);
        }

        private void AddSeasons(ITraktSyncWatchlistRemovePost syncWatchlistRemovePost)
        {
            if (!_seasons.IsValueCreated && !_seasonIds.IsValueCreated)
                return;

            syncWatchlistRemovePost.Seasons ??= new List<ITraktSyncWatchlistPostSeason>();

            if (_seasons.IsValueCreated && _seasons.Value.Any())
            {
                foreach (ITraktSeason season in _seasons.Value)
                    syncWatchlistRemovePost.Seasons.Add(CreateWatchlistPostSeason(season));
            }

            if (_seasonIds.IsValueCreated && _seasonIds.Value.Any())
            {
                foreach (ITraktSeasonIds seasonIds in _seasonIds.Value)
                    syncWatchlistRemovePost.Seasons.Add(CreateWatchlistPostSeason(seasonIds));
            }
        }

        private void AddEpisodes(ITraktSyncWatchlistRemovePost syncWatchlistRemovePost)
        {
            if (!_episodes.IsValueCreated && !_episodeIds.IsValueCreated)
                return;

            syncWatchlistRemovePost.Episodes ??= new List<ITraktSyncWatchlistPostEpisode>();

            if (_episodes.IsValueCreated && _episodes.Value.Any())
            {
                foreach (ITraktEpisode episode in _episodes.Value)
                    syncWatchlistRemovePost.Episodes.Add(CreateWatchlistPostEpisode(episode));
            }

            if (_episodeIds.IsValueCreated && _episodeIds.Value.Any())
            {
                foreach (ITraktEpisodeIds episodeIds in _episodeIds.Value)
                    syncWatchlistRemovePost.Episodes.Add(CreateWatchlistPostEpisode(episodeIds));
            }
        }

        private static ITraktSyncWatchlistPostMovie CreateWatchlistPostMovie(ITraktMovie movie)
            => new TraktSyncWatchlistPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

        private static ITraktSyncWatchlistPostMovie CreateWatchlistPostMovie(ITraktMovieIds movieIds)
            => new TraktSyncWatchlistPostMovie { Ids = movieIds };

        private static ITraktSyncWatchlistPostShow CreateWatchlistPostShow(ITraktShow show)
            => new TraktSyncWatchlistPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

        private static ITraktSyncWatchlistPostShow CreateWatchlistRemovePostShow(ITraktShowIds showIds)
            => new TraktSyncWatchlistPostShow { Ids = showIds };

        private static void CreateWatchlistPostShowAndSeasons(ITraktSyncWatchlistRemovePost syncWatchlistRemovePost, List<ShowAndSeasons> showsAndSeasons)
        {
            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                ITraktSyncWatchlistPostShow syncWatchlistRemovePostShow = CreateWatchlistPostShow(showAndSeasons.Object);
                CreateWatchlistPostShowSeasons(syncWatchlistRemovePost, showAndSeasons.Seasons, syncWatchlistRemovePostShow);
            }
        }

        private static void CreateWatchlistPostShowIdsAndSeasons(ITraktSyncWatchlistRemovePost syncWatchlistRemovePost, List<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                ITraktSyncWatchlistPostShow syncWatchlistRemovePostShow = CreateWatchlistRemovePostShow(showIdAndSeasons.Object);
                CreateWatchlistPostShowSeasons(syncWatchlistRemovePost, showIdAndSeasons.Seasons, syncWatchlistRemovePostShow);
            }
        }

        private static void CreateWatchlistPostShowSeasons(ITraktSyncWatchlistRemovePost syncWatchlistRemovePost, PostSeasons seasons, ITraktSyncWatchlistPostShow syncWatchlistRemovePostShow)
        {
            if (seasons.Any())
            {
                syncWatchlistRemovePostShow.Seasons = new List<ITraktSyncWatchlistPostShowSeason>();

                foreach (PostSeason season in seasons)
                {
                    ITraktSyncWatchlistPostShowSeason syncWatchlistRemovePostShowSeason = CreateWatchlistPostShowSeason(season);

                    if (season.Episodes != null && season.Episodes.Any())
                    {
                        syncWatchlistRemovePostShowSeason.Episodes = new List<ITraktSyncWatchlistPostShowEpisode>();

                        foreach (PostEpisode episode in season.Episodes)
                            syncWatchlistRemovePostShowSeason.Episodes.Add(CreateWatchlistPostShowEpisode(episode));
                    }

                    syncWatchlistRemovePostShow.Seasons.Add(syncWatchlistRemovePostShowSeason);
                }
            }

            syncWatchlistRemovePost.Shows.Add(syncWatchlistRemovePostShow);
        }

        private static ITraktSyncWatchlistPostShowSeason CreateWatchlistPostShowSeason(PostSeason season)
            => new TraktSyncWatchlistPostShowSeason { Number = season.Number };

        private static ITraktSyncWatchlistPostShowEpisode CreateWatchlistPostShowEpisode(PostEpisode episode)
            => new TraktSyncWatchlistPostShowEpisode { Number = episode.Number };

        private static ITraktSyncWatchlistPostSeason CreateWatchlistPostSeason(ITraktSeason season)
            => new TraktSyncWatchlistPostSeason { Ids = season.Ids };

        private static ITraktSyncWatchlistPostSeason CreateWatchlistPostSeason(ITraktSeasonIds seasonIds)
            => new TraktSyncWatchlistPostSeason { Ids = seasonIds };

        private static ITraktSyncWatchlistPostEpisode CreateWatchlistPostEpisode(ITraktEpisode episode)
            => new TraktSyncWatchlistPostEpisode { Ids = episode.Ids };

        private static ITraktSyncWatchlistPostEpisode CreateWatchlistPostEpisode(ITraktEpisodeIds episodeIds)
            => new TraktSyncWatchlistPostEpisode { Ids = episodeIds };
    }
}
