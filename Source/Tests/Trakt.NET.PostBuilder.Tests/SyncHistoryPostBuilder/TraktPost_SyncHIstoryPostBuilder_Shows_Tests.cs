namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShow_ITraktShow()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryPost.Shows.ToArray()[0];
            postShow.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShow_ITraktShowIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_IDS_1)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowWatchedAt_ITraktShow()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowWatchedAt(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryPost.Shows.ToArray()[0];
            postShow.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowWatchedAt_ITraktShowIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowWatchedAt(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowWatchedAt_WatchedShow()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowWatchedAt(new WatchedShow(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.WATCHED_AT))
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryPost.Shows.ToArray()[0];
            postShow.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowWatchedAt_WatchedShowIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowWatchedAt(new WatchedShowIds(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT))
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostShow postShow = syncHistoryPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShows_ITraktShow()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShows(TraktPost_Tests_Common_Data.SHOWS)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShow postShow1 = syncHistoryPost.Shows.ToArray()[0];
            postShow1.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow1.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.WatchedAt.Should().BeNull();

            ITraktSyncHistoryPostShow postShow2 = syncHistoryPost.Shows.ToArray()[1];
            postShow2.Title = TraktPost_Tests_Common_Data.SHOW_2.Title;
            postShow2.Year = TraktPost_Tests_Common_Data.SHOW_2.Year;
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShows_ITraktShowIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShows(TraktPost_Tests_Common_Data.SHOW_IDS)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShow postShow1 = syncHistoryPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.WatchedAt.Should().BeNull();

            ITraktSyncHistoryPostShow postShow2 = syncHistoryPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowsWatchedAt_WatchedShow()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowsWatchedAt(new List<WatchedShow>
                {
                    new WatchedShow(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.WATCHED_AT),
                    new WatchedShow(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.WATCHED_AT)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShow postShow1 = syncHistoryPost.Shows.ToArray()[0];
            postShow1.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow1.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            ITraktSyncHistoryPostShow postShow2 = syncHistoryPost.Shows.ToArray()[1];
            postShow2.Title = TraktPost_Tests_Common_Data.SHOW_2.Title;
            postShow2.Year = TraktPost_Tests_Common_Data.SHOW_2.Year;
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowsWatchedAt_WatchedShowIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowsWatchedAt(new List<WatchedShowIds>
                {
                    new WatchedShowIds(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT),
                    new WatchedShowIds(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.WATCHED_AT)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShow postShow1 = syncHistoryPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            ITraktSyncHistoryPostShow postShow2 = syncHistoryPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }
    }
}
