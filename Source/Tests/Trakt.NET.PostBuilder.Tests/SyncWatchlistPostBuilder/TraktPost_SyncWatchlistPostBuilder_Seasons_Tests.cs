namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncWatchlistPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeason_ITraktSeason()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostSeason postSeason = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostSeason postSeason = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonWithNotes_ITraktSeason()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostSeason postSeason = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonWithNotes_ITraktSeasonIds()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostSeason postSeason = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonWithNotes_SeasonWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1,
                                                           TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostSeason postSeason = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonWithNotes_SeasonIdsWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1,
                                                              TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostSeason postSeason = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASONS)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostSeason postSeason1 = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason1.Notes.Should().BeNull();

            ITraktSyncWatchlistPostSeason postSeason2 = syncWatchlistPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);
            postSeason2.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASON_IDS)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostSeason postSeason1 = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason1.Notes.Should().BeNull();

            ITraktSyncWatchlistPostSeason postSeason2 = syncWatchlistPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);
            postSeason2.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonsWithNotes_SeasonWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeasonsWithNotes(new List<SeasonWithNotes>
                {
                    new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES),
                    new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostSeason postSeason1 = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncWatchlistPostSeason postSeason2 = syncWatchlistPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);
            postSeason2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonsWithNotes_SeasonIdsWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithSeasonsWithNotes(new List<SeasonIdsWithNotes>
                {
                    new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostSeason postSeason1 = syncWatchlistPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncWatchlistPostSeason postSeason2 = syncWatchlistPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);
            postSeason2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }
    }
}
