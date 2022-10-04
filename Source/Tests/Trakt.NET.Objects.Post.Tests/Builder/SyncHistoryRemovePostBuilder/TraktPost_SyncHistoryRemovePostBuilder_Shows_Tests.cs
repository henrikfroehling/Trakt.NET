namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShow_ITraktShow()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryRemovePostShow postShow = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShow_ITraktShowIds()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_IDS_1)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryRemovePostShow postShow = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShows_ITraktShow()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithShows(TraktPost_Tests_Common_Data.SHOWS)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryRemovePostShow postShow1 = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow1.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow1.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            ITraktSyncHistoryRemovePostShow postShow2 = syncHistoryRemovePost.Shows.ToArray()[1];
            postShow2.Title = TraktPost_Tests_Common_Data.SHOW_2.Title;
            postShow2.Year = TraktPost_Tests_Common_Data.SHOW_2.Year;
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShows_ITraktShowIds()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithShows(TraktPost_Tests_Common_Data.SHOW_IDS)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryRemovePostShow postShow1 = syncHistoryRemovePost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            ITraktSyncHistoryRemovePostShow postShow2 = syncHistoryRemovePost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }
    }
}
