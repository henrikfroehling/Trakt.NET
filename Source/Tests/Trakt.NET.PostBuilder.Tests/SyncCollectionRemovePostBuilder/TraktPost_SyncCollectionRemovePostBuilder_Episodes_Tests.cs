namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncCollectionRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithEpisode_ITraktEpisode()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = TraktPost.NewSyncCollectionRemovePost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .Build();

            syncCollectionRemovePost.Should().NotBeNull();
            syncCollectionRemovePost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionRemovePost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);

            syncCollectionRemovePost.Movies.Should().BeNull();
            syncCollectionRemovePost.Shows.Should().BeNull();
            syncCollectionRemovePost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithEpisode_ITraktEpisodeIds()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = TraktPost.NewSyncCollectionRemovePost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_IDS_1)
                .Build();

            syncCollectionRemovePost.Should().NotBeNull();
            syncCollectionRemovePost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionRemovePost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);

            syncCollectionRemovePost.Movies.Should().BeNull();
            syncCollectionRemovePost.Shows.Should().BeNull();
            syncCollectionRemovePost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithEpisodes_ITraktEpisode()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = TraktPost.NewSyncCollectionRemovePost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODES)
                .Build();

            syncCollectionRemovePost.Should().NotBeNull();
            syncCollectionRemovePost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionRemovePost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionRemovePost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);

            syncCollectionRemovePost.Movies.Should().BeNull();
            syncCollectionRemovePost.Shows.Should().BeNull();
            syncCollectionRemovePost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithEpisodes_ITraktEpisodeIds()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = TraktPost.NewSyncCollectionRemovePost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODE_IDS)
                .Build();

            syncCollectionRemovePost.Should().NotBeNull();
            syncCollectionRemovePost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionRemovePost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionRemovePost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);

            syncCollectionRemovePost.Movies.Should().BeNull();
            syncCollectionRemovePost.Shows.Should().BeNull();
            syncCollectionRemovePost.Seasons.Should().BeNull();
        }
    }
}
