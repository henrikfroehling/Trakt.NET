namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Season_Read_Array_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var stream = TYPE_SEASON_JSON_COMPLETE.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982344UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[0].Season.Should().NotBeNull();
                historyItems[0].Season.Number.Should().Be(1);
                historyItems[0].Season.Ids.Should().NotBeNull();
                historyItems[0].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[0].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[0].Season.Rating.Should().NotHaveValue();
                historyItems[0].Season.Votes.Should().NotHaveValue();
                historyItems[0].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.Overview.Should().BeNullOrEmpty();
                historyItems[0].Season.FirstAired.Should().NotHaveValue();
                historyItems[0].Season.Episodes.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982344UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[1].Season.Should().NotBeNull();
                historyItems[1].Season.Number.Should().Be(1);
                historyItems[1].Season.Ids.Should().NotBeNull();
                historyItems[1].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[1].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[1].Season.Rating.Should().NotHaveValue();
                historyItems[1].Season.Votes.Should().NotHaveValue();
                historyItems[1].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.Overview.Should().BeNullOrEmpty();
                historyItems[1].Season.FirstAired.Should().NotHaveValue();
                historyItems[1].Season.Episodes.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Season_Read_Array_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_1.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982344UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[0].Season.Should().NotBeNull();
                historyItems[0].Season.Number.Should().Be(1);
                historyItems[0].Season.Ids.Should().NotBeNull();
                historyItems[0].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[0].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[0].Season.Rating.Should().NotHaveValue();
                historyItems[0].Season.Votes.Should().NotHaveValue();
                historyItems[0].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.Overview.Should().BeNullOrEmpty();
                historyItems[0].Season.FirstAired.Should().NotHaveValue();
                historyItems[0].Season.Episodes.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[1].Season.Should().NotBeNull();
                historyItems[1].Season.Number.Should().Be(1);
                historyItems[1].Season.Ids.Should().NotBeNull();
                historyItems[1].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[1].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[1].Season.Rating.Should().NotHaveValue();
                historyItems[1].Season.Votes.Should().NotHaveValue();
                historyItems[1].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.Overview.Should().BeNullOrEmpty();
                historyItems[1].Season.FirstAired.Should().NotHaveValue();
                historyItems[1].Season.Episodes.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Season_Read_Array_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_2.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[0].Season.Should().NotBeNull();
                historyItems[0].Season.Number.Should().Be(1);
                historyItems[0].Season.Ids.Should().NotBeNull();
                historyItems[0].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[0].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[0].Season.Rating.Should().NotHaveValue();
                historyItems[0].Season.Votes.Should().NotHaveValue();
                historyItems[0].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.Overview.Should().BeNullOrEmpty();
                historyItems[0].Season.FirstAired.Should().NotHaveValue();
                historyItems[0].Season.Episodes.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982344UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[1].Season.Should().NotBeNull();
                historyItems[1].Season.Number.Should().Be(1);
                historyItems[1].Season.Ids.Should().NotBeNull();
                historyItems[1].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[1].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[1].Season.Rating.Should().NotHaveValue();
                historyItems[1].Season.Votes.Should().NotHaveValue();
                historyItems[1].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.Overview.Should().BeNullOrEmpty();
                historyItems[1].Season.FirstAired.Should().NotHaveValue();
                historyItems[1].Season.Episodes.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Season_Read_Array_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_1.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[0].Season.Should().NotBeNull();
                historyItems[0].Season.Number.Should().Be(1);
                historyItems[0].Season.Ids.Should().NotBeNull();
                historyItems[0].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[0].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[0].Season.Rating.Should().NotHaveValue();
                historyItems[0].Season.Votes.Should().NotHaveValue();
                historyItems[0].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.Overview.Should().BeNullOrEmpty();
                historyItems[0].Season.FirstAired.Should().NotHaveValue();
                historyItems[0].Season.Episodes.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982344UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[1].Season.Should().NotBeNull();
                historyItems[1].Season.Number.Should().Be(1);
                historyItems[1].Season.Ids.Should().NotBeNull();
                historyItems[1].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[1].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[1].Season.Rating.Should().NotHaveValue();
                historyItems[1].Season.Votes.Should().NotHaveValue();
                historyItems[1].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.Overview.Should().BeNullOrEmpty();
                historyItems[1].Season.FirstAired.Should().NotHaveValue();
                historyItems[1].Season.Episodes.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Season_Read_Array_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_2.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982344UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[0].Season.Should().NotBeNull();
                historyItems[0].Season.Number.Should().Be(1);
                historyItems[0].Season.Ids.Should().NotBeNull();
                historyItems[0].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[0].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[0].Season.Rating.Should().NotHaveValue();
                historyItems[0].Season.Votes.Should().NotHaveValue();
                historyItems[0].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.Overview.Should().BeNullOrEmpty();
                historyItems[0].Season.FirstAired.Should().NotHaveValue();
                historyItems[0].Season.Episodes.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[1].Season.Should().NotBeNull();
                historyItems[1].Season.Number.Should().Be(1);
                historyItems[1].Season.Ids.Should().NotBeNull();
                historyItems[1].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[1].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[1].Season.Rating.Should().NotHaveValue();
                historyItems[1].Season.Votes.Should().NotHaveValue();
                historyItems[1].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.Overview.Should().BeNullOrEmpty();
                historyItems[1].Season.FirstAired.Should().NotHaveValue();
                historyItems[1].Season.Episodes.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Season_Read_Array_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_3.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[0].Season.Should().NotBeNull();
                historyItems[0].Season.Number.Should().Be(1);
                historyItems[0].Season.Ids.Should().NotBeNull();
                historyItems[0].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[0].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[0].Season.Rating.Should().NotHaveValue();
                historyItems[0].Season.Votes.Should().NotHaveValue();
                historyItems[0].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[0].Season.Overview.Should().BeNullOrEmpty();
                historyItems[0].Season.FirstAired.Should().NotHaveValue();
                historyItems[0].Season.Episodes.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Watch);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Season);
                historyItems[1].Season.Should().NotBeNull();
                historyItems[1].Season.Number.Should().Be(1);
                historyItems[1].Season.Ids.Should().NotBeNull();
                historyItems[1].Season.Ids.Trakt.Should().Be(61430U);
                historyItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                historyItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                historyItems[1].Season.Ids.TvRage.Should().Be(36939U);
                historyItems[1].Season.Rating.Should().NotHaveValue();
                historyItems[1].Season.Votes.Should().NotHaveValue();
                historyItems[1].Season.TotalEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.AiredEpisodesCount.Should().NotHaveValue();
                historyItems[1].Season.Overview.Should().BeNullOrEmpty();
                historyItems[1].Season.FirstAired.Should().NotHaveValue();
                historyItems[1].Season.Episodes.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }
    }
}
