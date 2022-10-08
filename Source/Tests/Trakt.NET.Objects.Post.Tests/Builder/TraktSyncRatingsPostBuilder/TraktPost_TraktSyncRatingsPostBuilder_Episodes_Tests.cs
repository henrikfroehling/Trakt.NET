namespace TraktNet.Objects.Post.Tests.Builder
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
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisode_ITraktEpisode()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisode_ITraktEpisodeIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.RATING)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisode_RatingsEpisode()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisode(new RatingsEpisode(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.RATING))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisode_RatingsEpisodeIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisode(new RatingsEpisodeIds(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.RATING))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodeRatedAt_ITraktEpisode()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisodeRatedAt(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.RATING,
                                    TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodeRatedAt_ITraktEpisodeIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisodeRatedAt(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.RATING,
                                    TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodeRatedAt_RatingsEpisodeRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisodeRatedAt(new RatingsEpisodeRatedAt(TraktPost_Tests_Common_Data.EPISODE_1,
                                                              TraktPost_Tests_Common_Data.RATING,
                                                              TraktPost_Tests_Common_Data.RATED_AT))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodeRatedAt_RatingsEpisodeIdsRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisodeRatedAt(new RatingsEpisodeIdsRatedAt(TraktPost_Tests_Common_Data.EPISODE_IDS_1,
                                                                 TraktPost_Tests_Common_Data.RATING,
                                                                 TraktPost_Tests_Common_Data.RATED_AT))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostEpisode postEpisode = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodes_RatingsEpisode()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisodes(new List<RatingsEpisode>
                {
                    new RatingsEpisode(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.RATING),
                    new RatingsEpisode(TraktPost_Tests_Common_Data.EPISODE_2, TraktPost_Tests_Common_Data.RATING)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostEpisode postEpisode1 = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode1.RatedAt.Should().BeNull();

            ITraktSyncRatingsPostEpisode postEpisode2 = syncRatingsPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);
            postEpisode2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode2.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodes_RatingsEpisodeIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisodes(new List<RatingsEpisodeIds>
                {
                    new RatingsEpisodeIds(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.RATING),
                    new RatingsEpisodeIds(TraktPost_Tests_Common_Data.EPISODE_IDS_2, TraktPost_Tests_Common_Data.RATING)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostEpisode postEpisode1 = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode1.RatedAt.Should().BeNull();

            ITraktSyncRatingsPostEpisode postEpisode2 = syncRatingsPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);
            postEpisode2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode2.RatedAt.Should().BeNull();

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodesRatedAt_RatingsEpisodeRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisodesRatedAt(new List<RatingsEpisodeRatedAt>
                {
                    new RatingsEpisodeRatedAt(TraktPost_Tests_Common_Data.EPISODE_1,
                                              TraktPost_Tests_Common_Data.RATING,
                                              TraktPost_Tests_Common_Data.RATED_AT),
                    new RatingsEpisodeRatedAt(TraktPost_Tests_Common_Data.EPISODE_2,
                                              TraktPost_Tests_Common_Data.RATING,
                                              TraktPost_Tests_Common_Data.RATED_AT)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostEpisode postEpisode1 = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode1.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            ITraktSyncRatingsPostEpisode postEpisode2 = syncRatingsPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);
            postEpisode2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode2.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodesRatedAt_RatingsEpisodeIdsRatedAt()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithEpisodesRatedAt(new List<RatingsEpisodeIdsRatedAt>
                {
                    new RatingsEpisodeIdsRatedAt(TraktPost_Tests_Common_Data.EPISODE_IDS_1,
                                                 TraktPost_Tests_Common_Data.RATING,
                                                 TraktPost_Tests_Common_Data.RATED_AT),
                    new RatingsEpisodeIdsRatedAt(TraktPost_Tests_Common_Data.EPISODE_IDS_2,
                                                 TraktPost_Tests_Common_Data.RATING,
                                                 TraktPost_Tests_Common_Data.RATED_AT)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostEpisode postEpisode1 = syncRatingsPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode1.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode1.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            ITraktSyncRatingsPostEpisode postEpisode2 = syncRatingsPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);
            postEpisode2.Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postEpisode2.RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Shows.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
        }
    }
}
