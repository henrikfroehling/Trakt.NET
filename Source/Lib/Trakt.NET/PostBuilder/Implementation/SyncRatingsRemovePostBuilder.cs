namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Ratings;

    internal sealed class SyncRatingsRemovePostBuilder
        : ATraktRemovePostBuilder<ITraktSyncRatingsRemovePostBuilder, ITraktSyncRatingsRemovePost>,
          ITraktSyncRatingsRemovePostBuilder
    {
        public override ITraktSyncRatingsRemovePost Build()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = new TraktSyncRatingsRemovePost();
            AddMovies(syncRatingsRemovePost);
            AddShows(syncRatingsRemovePost);
            AddSeasons(syncRatingsRemovePost);
            AddEpisodes(syncRatingsRemovePost);
            syncRatingsRemovePost.Validate();
            return syncRatingsRemovePost;
        }

        protected override ITraktSyncRatingsRemovePostBuilder GetBuilder() => this;

        private void AddMovies(ITraktSyncRatingsRemovePost syncRatingsRemovePost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated)
                return;

            syncRatingsRemovePost.Movies ??= new List<ITraktSyncRatingsPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (syncRatingsRemovePost.Movies as List<ITraktSyncRatingsPostMovie>)
                        .Add(CreateRatingsPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (syncRatingsRemovePost.Movies as List<ITraktSyncRatingsPostMovie>)
                        .Add(CreateRatingsPostMovie(movieIds));
                }
            }
        }

        private void AddShows(ITraktSyncRatingsRemovePost syncRatingsRemovePost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated)
                return;

            syncRatingsRemovePost.Shows ??= new List<ITraktSyncRatingsPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (syncRatingsRemovePost.Shows as List<ITraktSyncRatingsPostShow>)
                        .Add(CreateRatingsPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (syncRatingsRemovePost.Shows as List<ITraktSyncRatingsPostShow>)
                        .Add(CreateRatingsRemovePostShow(showIds));
                }
            }

            if (_showsAndSeasons.IsValueCreated && _showsAndSeasons.Value.Any())
                CreateRatingsPostShowAndSeasons(syncRatingsRemovePost, _showsAndSeasons.Value);

            if (_showIdsAndSeasons.IsValueCreated && _showIdsAndSeasons.Value.Any())
                CreateRatingsPostShowIdsAndSeasons(syncRatingsRemovePost, _showIdsAndSeasons.Value);
        }

        private void AddSeasons(ITraktSyncRatingsRemovePost syncRatingsRemovePost)
        {
            if (!_seasons.IsValueCreated && !_seasonIds.IsValueCreated)
                return;

            syncRatingsRemovePost.Seasons ??= new List<ITraktSyncRatingsPostSeason>();

            if (_seasons.IsValueCreated && _seasons.Value.Any())
            {
                foreach (ITraktSeason season in _seasons.Value)
                {
                    (syncRatingsRemovePost.Seasons as List<ITraktSyncRatingsPostSeason>)
                        .Add(CreateRatingsPostSeason(season));
                }
            }

            if (_seasonIds.IsValueCreated && _seasonIds.Value.Any())
            {
                foreach (ITraktSeasonIds seasonIds in _seasonIds.Value)
                {
                    (syncRatingsRemovePost.Seasons as List<ITraktSyncRatingsPostSeason>)
                        .Add(CreateRatingsPostSeason(seasonIds));
                }
            }
        }

        private void AddEpisodes(ITraktSyncRatingsRemovePost syncRatingsRemovePost)
        {
            if (!_episodes.IsValueCreated && !_episodeIds.IsValueCreated)
                return;

            syncRatingsRemovePost.Episodes ??= new List<ITraktSyncRatingsPostEpisode>();

            if (_episodes.IsValueCreated && _episodes.Value.Any())
            {
                foreach (ITraktEpisode episode in _episodes.Value)
                {
                    (syncRatingsRemovePost.Episodes as List<ITraktSyncRatingsPostEpisode>)
                        .Add(CreateRatingsPostEpisode(episode));
                }
            }

            if (_episodeIds.IsValueCreated && _episodeIds.Value.Any())
            {
                foreach (ITraktEpisodeIds episodeIds in _episodeIds.Value)
                {
                    (syncRatingsRemovePost.Episodes as List<ITraktSyncRatingsPostEpisode>)
                        .Add(CreateRatingsPostEpisode(episodeIds));
                }
            }
        }

        private static ITraktSyncRatingsPostMovie CreateRatingsPostMovie(ITraktMovie movie)
            => new TraktSyncRatingsPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

        private static ITraktSyncRatingsPostMovie CreateRatingsPostMovie(ITraktMovieIds movieIds)
            => new TraktSyncRatingsPostMovie { Ids = movieIds };

        private static ITraktSyncRatingsPostShow CreateRatingsPostShow(ITraktShow show)
            => new TraktSyncRatingsPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

        private static ITraktSyncRatingsPostShow CreateRatingsRemovePostShow(ITraktShowIds showIds)
            => new TraktSyncRatingsPostShow { Ids = showIds };

        private static void CreateRatingsPostShowAndSeasons(ITraktSyncRatingsRemovePost syncRatingsRemovePost, List<ShowAndSeasons> showsAndSeasons)
        {
            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                ITraktSyncRatingsPostShow syncRatingsRemovePostShow = CreateRatingsPostShow(showAndSeasons.Object);
                CreateRatingsPostShowSeasons(syncRatingsRemovePost, showAndSeasons.Seasons, syncRatingsRemovePostShow);
            }
        }

        private static void CreateRatingsPostShowIdsAndSeasons(ITraktSyncRatingsRemovePost syncRatingsRemovePost, List<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                ITraktSyncRatingsPostShow syncRatingsRemovePostShow = CreateRatingsRemovePostShow(showIdAndSeasons.Object);
                CreateRatingsPostShowSeasons(syncRatingsRemovePost, showIdAndSeasons.Seasons, syncRatingsRemovePostShow);
            }
        }

        private static void CreateRatingsPostShowSeasons(ITraktSyncRatingsRemovePost syncRatingsRemovePost, PostSeasons seasons, ITraktSyncRatingsPostShow syncRatingsRemovePostShow)
        {
            if (seasons.Any())
            {
                syncRatingsRemovePostShow.Seasons = new List<ITraktSyncRatingsPostShowSeason>();

                foreach (PostSeason season in seasons)
                {
                    ITraktSyncRatingsPostShowSeason syncRatingsRemovePostShowSeason = CreateRatingsPostShowSeason(season);

                    if (season.Episodes != null && season.Episodes.Any())
                    {
                        syncRatingsRemovePostShowSeason.Episodes = new List<ITraktSyncRatingsPostShowEpisode>();

                        foreach (PostEpisode episode in season.Episodes)
                        {
                            (syncRatingsRemovePostShowSeason.Episodes as List<ITraktSyncRatingsPostShowEpisode>)
                                .Add(CreateRatingsPostShowEpisode(episode));
                        }
                    }

                    (syncRatingsRemovePostShow.Seasons as List<ITraktSyncRatingsPostShowSeason>).Add(syncRatingsRemovePostShowSeason);
                }
            }

            (syncRatingsRemovePost.Shows as List<ITraktSyncRatingsPostShow>).Add(syncRatingsRemovePostShow);
        }

        private static ITraktSyncRatingsPostShowSeason CreateRatingsPostShowSeason(PostSeason season)
            => new TraktSyncRatingsPostShowSeason { Number = season.Number };

        private static ITraktSyncRatingsPostShowEpisode CreateRatingsPostShowEpisode(PostEpisode episode)
            => new TraktSyncRatingsPostShowEpisode { Number = episode.Number };

        private static ITraktSyncRatingsPostSeason CreateRatingsPostSeason(ITraktSeason season)
            => new TraktSyncRatingsPostSeason { Ids = season.Ids };

        private static ITraktSyncRatingsPostSeason CreateRatingsPostSeason(ITraktSeasonIds seasonIds)
            => new TraktSyncRatingsPostSeason { Ids = seasonIds };

        private static ITraktSyncRatingsPostEpisode CreateRatingsPostEpisode(ITraktEpisode episode)
            => new TraktSyncRatingsPostEpisode { Ids = episode.Ids };

        private static ITraktSyncRatingsPostEpisode CreateRatingsPostEpisode(ITraktEpisodeIds episodeIds)
            => new TraktSyncRatingsPostEpisode { Ids = episodeIds };
    }
}
