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
    using TraktNet.Objects.Post.Builder;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncRatingsPostBuilder_Tests
    {
        private readonly DateTime RATED_AT = DateTime.UtcNow;
        private const int RATING = 8;

        [Fact]
        public void Test_TraktPost_Get_SyncRatingsPostBuilder()
        {
            ITraktSyncRatingsPostBuilder syncCollectionPostBuilder = TraktPost.NewSyncRatingsPost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_Empty_Build()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost().Build();
            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovie()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovie(movie)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.Rating.Should().BeNull();
            postMovie.RatedAt.Should().BeNull();

            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovies()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovies(movies)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostMovie[] postMovies = syncRatingsPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].Rating.Should().BeNull();
            postMovies[0].RatedAt.Should().BeNull();

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].Rating.Should().BeNull();
            postMovies[1].RatedAt.Should().BeNull();

            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedMovie()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedMovie(movie).WithRating(RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.Rating.Should().Be(RATING);
            postMovie.RatedAt.Should().BeNull();

            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedMovie_And_RatedAt()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedMovie(movie).WithRating(RATING, RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.Rating.Should().Be(RATING);
            postMovie.RatedAt.Should().Be(RATED_AT);

            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShow(show)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.RatedAt.Should().BeNull();
            postShow.Seasons.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShows()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShows(shows)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShow[] postShows = syncRatingsPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].Rating.Should().BeNull();
            postShows[0].RatedAt.Should().BeNull();
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
            postShows[1].Rating.Should().BeNull();
            postShows[1].RatedAt.Should().BeNull();
            postShows[1].Seasons.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedShow()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedShow(show).WithRating(RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Rating.Should().Be(RATING);
            postShow.RatedAt.Should().BeNull();
            postShow.Seasons.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedShow_And_RatedAt()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedShow(show).WithRating(RATING, RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Rating.Should().Be(RATING);
            postShow.RatedAt.Should().Be(RATED_AT);
            postShow.Seasons.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedShowAndSeasons()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedShowAndSeasons(show).WithRating(RATING, 1, 2, 3)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Rating.Should().Be(RATING);
            postShow.RatedAt.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktSyncRatingsPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedShowAndSeasons_And_RatedAt()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedShowAndSeasons(show).WithRating(RATING, RATED_AT, 1, 2, 3)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Rating.Should().Be(RATING);
            postShow.RatedAt.Should().Be(RATED_AT);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktSyncRatingsPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedShowAndSeasonsCollection()
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

            var seasons = new PostRatingsSeasons
            {
                1,
                { 2, new PostRatingsEpisodes { 1, 2 } }
            };

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedShowAndSeasonsCollection(show).WithRating(RATING, seasons)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Rating.Should().Be(RATING);
            postShow.RatedAt.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedShowAndSeasonsCollection_And_RatedAt()
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

            var seasons = new PostRatingsSeasons
            {
                1,
                { 2, new PostRatingsEpisodes { 1, 2 } }
            };

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedShowAndSeasonsCollection(show).WithRating(RATING, RATED_AT, seasons)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Rating.Should().Be(RATING);
            postShow.RatedAt.Should().Be(RATED_AT);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddShowAndSeasons()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddShowAndSeasons(show).WithSeasons(1, 2, 3)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Rating.Should().BeNull();
            postShow.RatedAt.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktSyncRatingsPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddShowAndSeasonsCollection()
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

            var seasons = new PostRatingsSeasons
            {
                1,
                { 2, new PostRatingsEpisodes { 1, 2 } }
            };

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddShowAndSeasonsCollection(show).WithSeasons(seasons)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Rating.Should().BeNull();
            postShow.RatedAt.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisode()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisode(episode)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.Rating.Should().BeNull();
            postEpisode.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodes()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisodes(episodes)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostEpisode[] postEpisodes = syncRatingsPost.Episodes.ToArray();

            postEpisodes[0].Ids.Should().NotBeNull();
            postEpisodes[0].Ids.Trakt.Should().Be(1U);
            postEpisodes[0].Ids.Imdb.Should().Be("ttepisode1title");
            postEpisodes[0].Ids.Tmdb.Should().Be(1U);
            postEpisodes[0].Ids.Tvdb.Should().Be(1U);
            postEpisodes[0].Ids.TvRage.Should().Be(1U);
            postEpisodes[0].Rating.Should().BeNull();
            postEpisodes[0].RatedAt.Should().BeNull();

            postEpisodes[1].Ids.Should().NotBeNull();
            postEpisodes[1].Ids.Trakt.Should().Be(2U);
            postEpisodes[1].Ids.Imdb.Should().Be("ttepisode2title");
            postEpisodes[1].Ids.Tmdb.Should().Be(2U);
            postEpisodes[1].Ids.Tvdb.Should().Be(2U);
            postEpisodes[1].Ids.TvRage.Should().Be(2U);
            postEpisodes[1].Rating.Should().BeNull();
            postEpisodes[1].RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedEpisode()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedEpisode(episode).WithRating(RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.Rating.Should().Be(RATING);
            postEpisode.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_AddRatedEpisode_And_RatedAt()
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

            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .AddRatedEpisode(episode).WithRating(RATING, RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.Rating.Should().Be(RATING);
            postEpisode.RatedAt.Should().Be(RATED_AT);

            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }
    }
}
