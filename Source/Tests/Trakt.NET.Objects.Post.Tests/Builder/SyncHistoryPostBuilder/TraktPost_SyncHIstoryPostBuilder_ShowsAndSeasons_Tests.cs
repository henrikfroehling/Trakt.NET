namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowAndSeasons_ITraktShow()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_1)
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

            postShow.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncHistoryPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].WatchedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].WatchedAt.Should().BeNull();
            postShowSeasons[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowEpisode[] episodes = postShowSeasons[2].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowAndSeasons_ITraktShowIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_1)
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

            postShow.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncHistoryPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].WatchedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].WatchedAt.Should().BeNull();
            postShowSeasons[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowEpisode[] episodes = postShowSeasons[2].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowAndSeasons_WatchedShowAndSeasons()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(new WatchedShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_1))
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

            postShow.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncHistoryPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].WatchedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].WatchedAt.Should().BeNull();
            postShowSeasons[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowEpisode[] episodes = postShowSeasons[2].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowAndSeasons_WatchedShowIdsAndSeasons()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(new WatchedShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_1))
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

            postShow.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncHistoryPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].WatchedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].WatchedAt.Should().BeNull();
            postShowSeasons[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowEpisode[] episodes = postShowSeasons[2].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowsAndSeasons_WatchedShowAndSeasons()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowsAndSeasons(new List<WatchedShowAndSeasons>
                {
                    new WatchedShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_1),
                    new WatchedShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_2)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktSyncHistoryPostShow postShow1 = syncHistoryPost.Shows.ToArray()[0];
            postShow1.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow1.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.WatchedAt.Should().BeNull();

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncHistoryPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].WatchedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].WatchedAt.Should().BeNull();
            postShowSeasons[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowEpisode[] episodes = postShowSeasons[2].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktSyncHistoryPostShow postShow2 = syncHistoryPost.Shows.ToArray()[1];
            postShow2.Title = TraktPost_Tests_Common_Data.SHOW_2.Title;
            postShow2.Year = TraktPost_Tests_Common_Data.SHOW_2.Year;
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.WatchedAt.Should().BeNull();

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(4);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].WatchedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].WatchedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].WatchedAt.Should().BeNull();
            postShowSeasons[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[2].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].WatchedAt.Should().BeNull();
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowsAndSeasons_WatchedShowIdsAndSeasons()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithShowsAndSeasons(new List<WatchedShowIdsAndSeasons>
                {
                    new WatchedShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_1),
                    new WatchedShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_2)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktSyncHistoryPostShow postShow1 = syncHistoryPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.WatchedAt.Should().BeNull();

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncHistoryPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].WatchedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].WatchedAt.Should().BeNull();
            postShowSeasons[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostShowEpisode[] episodes = postShowSeasons[2].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktSyncHistoryPostShow postShow2 = syncHistoryPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.WatchedAt.Should().BeNull();

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(4);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].WatchedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].WatchedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].WatchedAt.Should().BeNull();
            postShowSeasons[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[2].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].WatchedAt.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].WatchedAt.Should().BeNull();
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }
    }
}
