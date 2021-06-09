namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncHistoryRemoveRemovePostBuilder_Tests
    {
        private readonly DateTime WATCHED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_TraktPost_Get_SyncHistoryRemovePostBuilder()
        {
            ITraktSyncHistoryRemovePostBuilder syncCollectionPostBuilder = TraktPost.NewSyncHistoryRemovePost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_Empty_Build()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost().Build();
            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithMovie()
        {
            ITraktMovie movie = new TraktMovie
            {
                Title = "movie title",
                Year = 2020,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie-title",
                    Imdb = "ttmovietitle",
                    Tmdb = 1
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithMovie(movie)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostMovie postMovie = syncHistoryRemovePost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.WatchedAt.Should().BeNull();

            syncHistoryRemovePost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithMovies()
        {
            var movies = new List<ITraktMovie>
            {
                new TraktMovie
                {
                    Title = "movie 1 title",
                    Year = 2020,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 1,
                        Slug = "movie-1-title",
                        Imdb = "ttmovie1title",
                        Tmdb = 1
                    }
                },
                new TraktMovie
                {
                    Title = "movie 2 title",
                    Year = 2020,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 2,
                        Slug = "movie-2-title",
                        Imdb = "ttmovie2title",
                        Tmdb = 2
                    }
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithMovies(movies)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostMovie[] postMovies = syncHistoryRemovePost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].WatchedAt.Should().BeNull();

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].WatchedAt.Should().BeNull();

            syncHistoryRemovePost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_AddWatchedMovie()
        {
            ITraktMovie movie = new TraktMovie
            {
                Title = "movie title",
                Year = 2020,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie-title",
                    Imdb = "ttmovietitle",
                    Tmdb = 1
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .AddWatchedMovie(movie).WatchedAt(WATCHED_AT)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostMovie postMovie = syncHistoryRemovePost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.WatchedAt.Should().Be(WATCHED_AT);

            syncHistoryRemovePost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShow()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithShow(show)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.WatchedAt.Should().BeNull();
            postShow.Seasons.Should().BeNull();

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShows()
        {
            var shows = new List<ITraktShow>
            {
                new TraktShow
                {
                    Title = "show 1 title",
                    Year = 2020,
                    Ids = new TraktShowIds
                    {
                        Trakt = 1,
                        Slug = "show-1-title",
                        Imdb = "ttshow1title",
                        Tmdb = 1,
                        Tvdb = 1,
                        TvRage = 1
                    }
                },
                new TraktShow
                {
                    Title = "show 2 title",
                    Year = 2020,
                    Ids = new TraktShowIds
                    {
                        Trakt = 2,
                        Slug = "show-2-title",
                        Imdb = "ttshow2title",
                        Tmdb = 2,
                        Tvdb = 2,
                        TvRage = 2
                    }
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithShows(shows)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShow[] postShows = syncHistoryRemovePost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].WatchedAt.Should().BeNull();
            postShows[0].Seasons.Should().BeNull();

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].WatchedAt.Should().BeNull();
            postShows[1].Seasons.Should().BeNull();

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_AddWatchedShow()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .AddWatchedShow(show).WatchedAt(WATCHED_AT)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.WatchedAt.Should().Be(WATCHED_AT);
            postShow.Seasons.Should().BeNull();

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_AddWatchedShowAndSeasons()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .AddWatchedShowAndSeasons(show).WatchedAt(WATCHED_AT, 1, 2, 3)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.WatchedAt.Should().Be(WATCHED_AT);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktSyncHistoryPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_AddWatchedShowAndSeasonsCollection()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            var seasons = new PostHistorySeasons
            {
                1,
                { 2, new PostHistoryEpisodes { 1, 2 } }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .AddWatchedShowAndSeasonsCollection(show).WatchedAt(WATCHED_AT, seasons)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.WatchedAt.Should().Be(WATCHED_AT);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_AddShowAndSeasons()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .AddShowAndSeasons(show).WithSeasons(1, 2, 3)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.WatchedAt.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktSyncHistoryPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_AddShowAndSeasonsCollection()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            var seasons = new PostHistorySeasons
            {
                1,
                { 2, new PostHistoryEpisodes { 1, 2 } }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .AddShowAndSeasonsCollection(show).WithSeasons(seasons)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.WatchedAt.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithEpisode()
        {
            ITraktEpisode episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 1,
                    Imdb = "ttepisodetitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithEpisode(episode)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostEpisode postEpisode = syncHistoryRemovePost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.WatchedAt.Should().BeNull();

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithEpisodes()
        {
            var episodes = new List<ITraktEpisode>
            {
                new TraktEpisode
                {
                    Ids = new TraktEpisodeIds
                    {
                        Trakt = 1,
                        Imdb = "ttepisode1title",
                        Tmdb = 1,
                        Tvdb = 1,
                        TvRage = 1
                    }
                },
                new TraktEpisode
                {
                    Ids = new TraktEpisodeIds
                    {
                        Trakt = 2,
                        Imdb = "ttepisode2title",
                        Tmdb = 2,
                        Tvdb = 2,
                        TvRage = 2
                    }
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithEpisodes(episodes)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostEpisode[] postEpisodes = syncHistoryRemovePost.Episodes.ToArray();

            postEpisodes[0].Ids.Should().NotBeNull();
            postEpisodes[0].Ids.Trakt.Should().Be(1U);
            postEpisodes[0].Ids.Imdb.Should().Be("ttepisode1title");
            postEpisodes[0].Ids.Tmdb.Should().Be(1U);
            postEpisodes[0].Ids.Tvdb.Should().Be(1U);
            postEpisodes[0].Ids.TvRage.Should().Be(1U);
            postEpisodes[0].WatchedAt.Should().BeNull();

            postEpisodes[1].Ids.Should().NotBeNull();
            postEpisodes[1].Ids.Trakt.Should().Be(2U);
            postEpisodes[1].Ids.Imdb.Should().Be("ttepisode2title");
            postEpisodes[1].Ids.Tmdb.Should().Be(2U);
            postEpisodes[1].Ids.Tvdb.Should().Be(2U);
            postEpisodes[1].Ids.TvRage.Should().Be(2U);
            postEpisodes[1].WatchedAt.Should().BeNull();

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_AddWatchedEpisode()
        {
            ITraktEpisode episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 1,
                    Imdb = "ttepisodetitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .AddWatchedEpisode(episode).WatchedAt(WATCHED_AT)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostEpisode postEpisode = syncHistoryRemovePost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.WatchedAt.Should().Be(WATCHED_AT);

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_AddHistoryIds()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .AddHistoryIds(1, 2, 3)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.HaveCount(3).And.Contain(new List<ulong> { 1UL, 2UL, 3UL });

            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
