namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovie_ITraktMovie()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie.RatedAt.Should().BeNull();

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovie_ITraktMovieIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie.RatedAt.Should().BeNull();

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovie_RatingsMovie()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovie(new RatingsMovie(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.RATING))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie.RatedAt.Should().BeNull();

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovie_RatingsMovieIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovie(new RatingsMovieIds(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.RATING))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie.RatedAt.Should().BeNull();

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovieRatedAt_ITraktMovie()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovieRatedAt(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.RATING,
                                  TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovieRatedAt_ITraktMovieIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovieRatedAt(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.RATING,
                                  TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovieRatedAt_RatingsMovieRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovieRatedAt(new RatingsMovieRatedAt(TraktPost_Tests_Common_Data.MOVIE_1,
                                                          TraktPost_Tests_Common_Data.RATING,
                                                          TraktPost_Tests_Common_Data.RATED_AT))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovieRatedAt_RatingsMovieIdsRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovieRatedAt(new RatingsMovieIdsRatedAt(TraktPost_Tests_Common_Data.MOVIE_IDS_1,
                                                             TraktPost_Tests_Common_Data.RATING,
                                                             TraktPost_Tests_Common_Data.RATED_AT))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovies_RatingsMovie()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovies(new List<RatingsMovie>
                {
                    new RatingsMovie(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.RATING),
                    new RatingsMovie(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.RATING)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostMovie postMovie1 = syncRatingsPost.Movies.ToArray()[0];
            postMovie1.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie1.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie1.RatedAt.Should().BeNull();

            ITraktSyncRatingsPostMovie postMovie2 = syncRatingsPost.Movies.ToArray()[1];
            postMovie2.Title = TraktPost_Tests_Common_Data.MOVIE_2.Title;
            postMovie2.Year = TraktPost_Tests_Common_Data.MOVIE_2.Year;
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie2.RatedAt.Should().BeNull();

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovies_RatingsMovieIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMovies(new List<RatingsMovieIds>
                {
                    new RatingsMovieIds(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.RATING),
                    new RatingsMovieIds(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.RATING)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostMovie postMovie1 = syncRatingsPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie1.RatedAt.Should().BeNull();

            ITraktSyncRatingsPostMovie postMovie2 = syncRatingsPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie2.RatedAt.Should().BeNull();

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMoviesRatedAt_RatingsMovieRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMoviesRatedAt(new List<RatingsMovieRatedAt>
                {
                    new RatingsMovieRatedAt(TraktPost_Tests_Common_Data.MOVIE_1,
                                            TraktPost_Tests_Common_Data.RATING,
                                            TraktPost_Tests_Common_Data.RATED_AT),
                    new RatingsMovieRatedAt(TraktPost_Tests_Common_Data.MOVIE_2,
                                            TraktPost_Tests_Common_Data.RATING,
                                            TraktPost_Tests_Common_Data.RATED_AT)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostMovie postMovie1 = syncRatingsPost.Movies.ToArray()[0];
            postMovie1.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie1.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie1.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            ITraktSyncRatingsPostMovie postMovie2 = syncRatingsPost.Movies.ToArray()[1];
            postMovie2.Title = TraktPost_Tests_Common_Data.MOVIE_2.Title;
            postMovie2.Year = TraktPost_Tests_Common_Data.MOVIE_2.Year;
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie2.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMoviesRatedAt_RatingsMovieIdsRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithMoviesRatedAt(new List<RatingsMovieIdsRatedAt>
                {
                    new RatingsMovieIdsRatedAt(TraktPost_Tests_Common_Data.MOVIE_IDS_1,
                                               TraktPost_Tests_Common_Data.RATING,
                                               TraktPost_Tests_Common_Data.RATED_AT),
                    new RatingsMovieIdsRatedAt(TraktPost_Tests_Common_Data.MOVIE_IDS_2,
                                               TraktPost_Tests_Common_Data.RATING,
                                               TraktPost_Tests_Common_Data.RATED_AT)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostMovie postMovie1 = syncRatingsPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie1.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            ITraktSyncRatingsPostMovie postMovie2 = syncRatingsPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postMovie2.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }
    }
}
