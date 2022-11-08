﻿namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncWatchlistRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithShowAndSeasons_ITraktShow()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistRemovePost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithShowAndSeasons_ITraktShowIds()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistRemovePost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithShowAndSeasons_ShowAndSeasons()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithShowAndSeasons(new ShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1))
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistRemovePost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithShowAndSeasons_ShowIdsAndSeasons()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithShowAndSeasons(new ShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1))
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistRemovePost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithShowsAndSeasons_ShowAndSeasons()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithShowsAndSeasons(new List<ShowAndSeasons>
                {
                    new ShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                    new ShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
                })
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktSyncWatchlistPostShow postShow1 = syncWatchlistRemovePost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktSyncWatchlistPostShow postShow2 = syncWatchlistRemovePost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(2);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithShowsAndSeasons_ShowIdsAndSeasons()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithShowsAndSeasons(new List<ShowIdsAndSeasons>
                {
                    new ShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                    new ShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
                })
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktSyncWatchlistPostShow postShow1 = syncWatchlistRemovePost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktSyncWatchlistPostShow postShow2 = syncWatchlistRemovePost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(2);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }
    }
}
