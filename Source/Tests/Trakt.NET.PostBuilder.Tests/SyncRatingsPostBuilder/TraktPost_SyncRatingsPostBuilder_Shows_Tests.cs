namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_ITraktShow()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_ITraktShowIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_RatingsShow()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShow(new RatingsShow(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.RATING))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_RatingsShowIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShow(new RatingsShowIds(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.RATING))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_ITraktShow()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.RATING,
                                 TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_ITraktShowIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.RATING,
                                 TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_RatingsShowRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(new RatingsShowRatedAt(TraktPost_Tests_Common_Data.SHOW_1,
                                                        TraktPost_Tests_Common_Data.RATING,
                                                        TraktPost_Tests_Common_Data.RATED_AT))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_RatingsShowIdsRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(new RatingsShowIdsRatedAt(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                                           TraktPost_Tests_Common_Data.RATING,
                                                           TraktPost_Tests_Common_Data.RATED_AT))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShows_RatingsShow()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShows(new List<RatingsShow>
                {
                    new RatingsShow(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.RATING),
                    new RatingsShow(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.RATING)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShow postShow1 = syncRatingsPost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow1.RatedAt.Should().BeNull();

            ITraktSyncRatingsPostShow postShow2 = syncRatingsPost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow2.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShows_RatingsShowIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShows(new List<RatingsShowIds>
                {
                    new RatingsShowIds(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.RATING),
                    new RatingsShowIds(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.RATING)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShow postShow1 = syncRatingsPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow1.RatedAt.Should().BeNull();

            ITraktSyncRatingsPostShow postShow2 = syncRatingsPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow2.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowsRatedAt_RatingsShowRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowsRatedAt(new List<RatingsShowRatedAt>
                {
                    new RatingsShowRatedAt(TraktPost_Tests_Common_Data.SHOW_1,
                                           TraktPost_Tests_Common_Data.RATING,
                                           TraktPost_Tests_Common_Data.RATED_AT),
                    new RatingsShowRatedAt(TraktPost_Tests_Common_Data.SHOW_2,
                                           TraktPost_Tests_Common_Data.RATING,
                                           TraktPost_Tests_Common_Data.RATED_AT)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShow postShow1 = syncRatingsPost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow1.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            ITraktSyncRatingsPostShow postShow2 = syncRatingsPost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow2.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowsRatedAt_RatingsShowIdsRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowsRatedAt(new List<RatingsShowIdsRatedAt>
                {
                    new RatingsShowIdsRatedAt(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                              TraktPost_Tests_Common_Data.RATING,
                                              TraktPost_Tests_Common_Data.RATED_AT),
                    new RatingsShowIdsRatedAt(TraktPost_Tests_Common_Data.SHOW_IDS_2,
                                              TraktPost_Tests_Common_Data.RATING,
                                              TraktPost_Tests_Common_Data.RATED_AT)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShow postShow1 = syncRatingsPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow1.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            ITraktSyncRatingsPostShow postShow2 = syncRatingsPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShow2.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }
    }
}
