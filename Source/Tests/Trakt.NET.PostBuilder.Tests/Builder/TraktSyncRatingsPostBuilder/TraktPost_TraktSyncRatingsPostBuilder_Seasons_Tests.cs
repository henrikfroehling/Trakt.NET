namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeason_ITraktSeason()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeason_RatingsSeason()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeason(new RatingsSeason(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.RATING))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeason_RatingsSeasonIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeason(new RatingsSeasonIds(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.RATING))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonRatedAt_ITraktSeason()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeasonRatedAt(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.RATING,
                                   TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonRatedAt_ITraktSeasonIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeasonRatedAt(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.RATING,
                                   TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonRatedAt_RatingsSeasonRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeasonRatedAt(new RatingsSeasonRatedAt(TraktPost_Tests_Common_Data.SEASON_1,
                                                            TraktPost_Tests_Common_Data.RATING,
                                                            TraktPost_Tests_Common_Data.RATED_AT))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonRatedAt_RatingsSeasonIdsRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeasonRatedAt(new RatingsSeasonIdsRatedAt(TraktPost_Tests_Common_Data.SEASON_IDS_1,
                                                               TraktPost_Tests_Common_Data.RATING,
                                                               TraktPost_Tests_Common_Data.RATED_AT))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasons_RatingsSeason()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeasons(new List<RatingsSeason>
                {
                    new RatingsSeason(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.RATING),
                    new RatingsSeason(TraktPost_Tests_Common_Data.SEASON_2, TraktPost_Tests_Common_Data.RATING)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostSeason postSeason1 = syncRatingsPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason1.RatedAt.Should().BeNull();

            ITraktSyncRatingsPostSeason postSeason2 = syncRatingsPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);
            postSeason2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason2.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasons_RatingsSeasonIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeasons(new List<RatingsSeasonIds>
                {
                    new RatingsSeasonIds(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.RATING),
                    new RatingsSeasonIds(TraktPost_Tests_Common_Data.SEASON_IDS_2, TraktPost_Tests_Common_Data.RATING)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostSeason postSeason1 = syncRatingsPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason1.RatedAt.Should().BeNull();

            ITraktSyncRatingsPostSeason postSeason2 = syncRatingsPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);
            postSeason2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason2.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonsRatedAt_RatingsSeasonRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeasonsRatedAt(new List<RatingsSeasonRatedAt>
                {
                    new RatingsSeasonRatedAt(TraktPost_Tests_Common_Data.SEASON_1,
                                             TraktPost_Tests_Common_Data.RATING,
                                             TraktPost_Tests_Common_Data.RATED_AT),
                    new RatingsSeasonRatedAt(TraktPost_Tests_Common_Data.SEASON_2,
                                             TraktPost_Tests_Common_Data.RATING,
                                             TraktPost_Tests_Common_Data.RATED_AT)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostSeason postSeason1 = syncRatingsPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason1.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            ITraktSyncRatingsPostSeason postSeason2 = syncRatingsPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);
            postSeason2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason2.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonsRatedAt_RatingsSeasonIdsRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithSeasonsRatedAt(new List<RatingsSeasonIdsRatedAt>
                {
                    new RatingsSeasonIdsRatedAt(TraktPost_Tests_Common_Data.SEASON_IDS_1,
                                                TraktPost_Tests_Common_Data.RATING,
                                                TraktPost_Tests_Common_Data.RATED_AT),
                    new RatingsSeasonIdsRatedAt(TraktPost_Tests_Common_Data.SEASON_IDS_2,
                                                TraktPost_Tests_Common_Data.RATING,
                                                TraktPost_Tests_Common_Data.RATED_AT)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostSeason postSeason1 = syncRatingsPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason1.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            ITraktSyncRatingsPostSeason postSeason2 = syncRatingsPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);
            postSeason2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postSeason2.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }
    }
}
