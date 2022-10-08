namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncRecommendationsPostBuilder_Tests
    {
        private const string TEST_NOTES = "test-notes";

        [Fact]
        public void Test_TraktPost_Get_SyncRatingsPostBuilder()
        {
            ITraktSyncRecommendationsPostBuilder syncRecommendationsPostBuilder = TraktPost.NewSyncRecommendationsPost();
            syncRecommendationsPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_Empty_Build()
        {
            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost().Build();
            act.Should().Throw<ArgumentException>();
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

            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithMovie(movie)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostMovie postMovie = syncRecommendationsPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.Notes.Should().BeNull();

            syncRecommendationsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovieWithNotes()
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

            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(movie, TEST_NOTES)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostMovie postMovie = syncRecommendationsPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.Notes.Should().Be(TEST_NOTES);

            syncRecommendationsPost.Shows.Should().NotBeNull().And.BeEmpty();
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

            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithMovies(movies)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostMovie[] postMovies = syncRecommendationsPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].Notes.Should().BeNull();

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].Notes.Should().BeNull();

            syncRecommendationsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMoviesWithNotes()
        {
            var movies = new List<Tuple<ITraktMovie, string>>
            {
                new Tuple<ITraktMovie, string>
                (
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
                    TEST_NOTES
                ),
                new Tuple<ITraktMovie, string>
                (
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
                    },
                    TEST_NOTES
                )
            };

            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithMoviesWithNotes(movies)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostMovie[] postMovies = syncRecommendationsPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].Notes.Should().Be(TEST_NOTES);

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].Notes.Should().Be(TEST_NOTES);

            syncRecommendationsPost.Shows.Should().NotBeNull().And.BeEmpty();
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

            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShow(show)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow postShow = syncRecommendationsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Notes.Should().BeNull();

            syncRecommendationsPost.Movies.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowWithNotes()
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

            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(show, TEST_NOTES)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow postShow = syncRecommendationsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Notes.Should().Be(TEST_NOTES);

            syncRecommendationsPost.Movies.Should().NotBeNull().And.BeEmpty();
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

            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShows(shows)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostShow[] postShows = syncRecommendationsPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].Notes.Should().BeNull();

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].Notes.Should().BeNull();

            syncRecommendationsPost.Movies.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowsWithNotes()
        {
            var shows = new List<Tuple<ITraktShow, string>>
            {
                new Tuple<ITraktShow, string>
                (
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
                    TEST_NOTES
                ),
                new Tuple<ITraktShow, string>
                (
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
                    },
                    TEST_NOTES
                )
            };

            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShowsWithNotes(shows)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostShow[] postShows = syncRecommendationsPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].Notes.Should().Be(TEST_NOTES);

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].Notes.Should().Be(TEST_NOTES);

            syncRecommendationsPost.Movies.Should().NotBeNull().And.BeEmpty();
        }
    }
}
