namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Collection;

    internal sealed class SyncCollectionRemovePostBuilder
        : ATraktRemovePostBuilder<ITraktSyncCollectionRemovePostBuilder, ITraktSyncCollectionRemovePost>,
          ITraktSyncCollectionRemovePostBuilder
    {
        public override ITraktSyncCollectionRemovePost Build()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = new TraktSyncCollectionRemovePost();
            AddMovies(syncCollectionRemovePost);
            AddShows(syncCollectionRemovePost);
            AddSeasons(syncCollectionRemovePost);
            AddEpisodes(syncCollectionRemovePost);
            syncCollectionRemovePost.Validate();
            return syncCollectionRemovePost;
        }

        protected override ITraktSyncCollectionRemovePostBuilder GetBuilder() => this;

        private void AddMovies(ITraktSyncCollectionRemovePost syncCollectionRemovePost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated)
                return;

            syncCollectionRemovePost.Movies ??= new List<ITraktSyncCollectionPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (syncCollectionRemovePost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (syncCollectionRemovePost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movieIds));
                }
            }
        }

        private void AddShows(ITraktSyncCollectionRemovePost syncCollectionRemovePost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated)
                return;

            syncCollectionRemovePost.Shows ??= new List<ITraktSyncCollectionPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (syncCollectionRemovePost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (syncCollectionRemovePost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionRemovePostShow(showIds));
                }
            }

            if (_showsAndSeasons.IsValueCreated && _showsAndSeasons.Value.Any())
                CreateCollectionPostShowAndSeasons(syncCollectionRemovePost, _showsAndSeasons.Value);

            if (_showIdsAndSeasons.IsValueCreated && _showIdsAndSeasons.Value.Any())
                CreateCollectionPostShowIdsAndSeasons(syncCollectionRemovePost, _showIdsAndSeasons.Value);
        }

        private void AddSeasons(ITraktSyncCollectionRemovePost syncCollectionRemovePost)
        {
            if (!_seasons.IsValueCreated && !_seasonIds.IsValueCreated)
                return;

            syncCollectionRemovePost.Seasons ??= new List<ITraktSyncCollectionPostSeason>();

            if (_seasons.IsValueCreated && _seasons.Value.Any())
            {
                foreach (ITraktSeason season in _seasons.Value)
                {
                    (syncCollectionRemovePost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(season));
                }
            }

            if (_seasonIds.IsValueCreated && _seasonIds.Value.Any())
            {
                foreach (ITraktSeasonIds seasonIds in _seasonIds.Value)
                {
                    (syncCollectionRemovePost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(seasonIds));
                }
            }
        }

        private void AddEpisodes(ITraktSyncCollectionRemovePost syncCollectionRemovePost)
        {
            if (!_episodes.IsValueCreated && !_episodeIds.IsValueCreated)
                return;

            syncCollectionRemovePost.Episodes ??= new List<ITraktSyncCollectionPostEpisode>();

            if (_episodes.IsValueCreated && _episodes.Value.Any())
            {
                foreach (ITraktEpisode episode in _episodes.Value)
                {
                    (syncCollectionRemovePost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episode));
                }
            }

            if (_episodeIds.IsValueCreated && _episodeIds.Value.Any())
            {
                foreach (ITraktEpisodeIds episodeIds in _episodeIds.Value)
                {
                    (syncCollectionRemovePost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episodeIds));
                }
            }
        }

        private static ITraktSyncCollectionPostMovie CreateCollectionPostMovie(ITraktMovie movie)
            => new TraktSyncCollectionPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

        private static ITraktSyncCollectionPostMovie CreateCollectionPostMovie(ITraktMovieIds movieIds)
            => new TraktSyncCollectionPostMovie { Ids = movieIds };

        private static ITraktSyncCollectionPostShow CreateCollectionPostShow(ITraktShow show)
            => new TraktSyncCollectionPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

        private static ITraktSyncCollectionPostShow CreateCollectionRemovePostShow(ITraktShowIds showIds)
            => new TraktSyncCollectionPostShow { Ids = showIds };

        private static void CreateCollectionPostShowAndSeasons(ITraktSyncCollectionRemovePost syncCollectionRemovePost, List<ShowAndSeasons> showsAndSeasons)
        {
            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                ITraktSyncCollectionPostShow syncCollectionRemovePostShow = CreateCollectionPostShow(showAndSeasons.Object);
                CreateCollectionPostShowSeasons(syncCollectionRemovePost, showAndSeasons.Seasons, syncCollectionRemovePostShow);
            }
        }

        private static void CreateCollectionPostShowIdsAndSeasons(ITraktSyncCollectionRemovePost syncCollectionRemovePost, List<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                ITraktSyncCollectionPostShow syncCollectionRemovePostShow = CreateCollectionRemovePostShow(showIdAndSeasons.Object);
                CreateCollectionPostShowSeasons(syncCollectionRemovePost, showIdAndSeasons.Seasons, syncCollectionRemovePostShow);
            }
        }

        private static void CreateCollectionPostShowSeasons(ITraktSyncCollectionRemovePost syncCollectionRemovePost, PostSeasons seasons, ITraktSyncCollectionPostShow syncCollectionRemovePostShow)
        {
            if (seasons.Any())
            {
                syncCollectionRemovePostShow.Seasons = new List<ITraktSyncCollectionPostShowSeason>();

                foreach (PostSeason season in seasons)
                {
                    ITraktSyncCollectionPostShowSeason syncCollectionRemovePostShowSeason = CreateCollectionPostShowSeason(season);

                    if (season.Episodes != null && season.Episodes.Any())
                    {
                        syncCollectionRemovePostShowSeason.Episodes = new List<ITraktSyncCollectionPostShowEpisode>();

                        foreach (PostEpisode episode in season.Episodes)
                        {
                            (syncCollectionRemovePostShowSeason.Episodes as List<ITraktSyncCollectionPostShowEpisode>)
                                .Add(CreateCollectionPostShowEpisode(episode));
                        }
                    }

                    (syncCollectionRemovePostShow.Seasons as List<ITraktSyncCollectionPostShowSeason>).Add(syncCollectionRemovePostShowSeason);
                }
            }

            (syncCollectionRemovePost.Shows as List<ITraktSyncCollectionPostShow>).Add(syncCollectionRemovePostShow);
        }

        private static ITraktSyncCollectionPostShowSeason CreateCollectionPostShowSeason(PostSeason season)
            => new TraktSyncCollectionPostShowSeason { Number = season.Number };

        private static ITraktSyncCollectionPostShowEpisode CreateCollectionPostShowEpisode(PostEpisode episode)
            => new TraktSyncCollectionPostShowEpisode { Number = episode.Number };

        private static ITraktSyncCollectionPostSeason CreateCollectionPostSeason(ITraktSeason season)
            => new TraktSyncCollectionPostSeason { Ids = season.Ids };

        private static ITraktSyncCollectionPostSeason CreateCollectionPostSeason(ITraktSeasonIds seasonIds)
            => new TraktSyncCollectionPostSeason { Ids = seasonIds };

        private static ITraktSyncCollectionPostEpisode CreateCollectionPostEpisode(ITraktEpisode episode)
            => new TraktSyncCollectionPostEpisode { Ids = episode.Ids };

        private static ITraktSyncCollectionPostEpisode CreateCollectionPostEpisode(ITraktEpisodeIds episodeIds)
            => new TraktSyncCollectionPostEpisode { Ids = episodeIds };
    }
}
