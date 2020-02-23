namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.History.Json.Reader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Show_Read_Array_From_Stream_Complete()
        {
            var jsonReader = new HistoryItemArrayJsonReader();

            using (var stream = TYPE_SHOW_JSON_COMPLETE.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982348UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[0].Show.Should().NotBeNull();
                historyItems[0].Show.Title.Should().Be("Game of Thrones");
                historyItems[0].Show.Year.Should().Be(2011);
                historyItems[0].Show.Airs.Should().BeNull();
                historyItems[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Show.Ids.Should().NotBeNull();
                historyItems[0].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[0].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[0].Show.Genres.Should().BeNull();
                historyItems[0].Show.Seasons.Should().BeNull();
                historyItems[0].Show.Overview.Should().BeNullOrEmpty();
                historyItems[0].Show.FirstAired.Should().NotHaveValue();
                historyItems[0].Show.Runtime.Should().NotHaveValue();
                historyItems[0].Show.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Network.Should().BeNullOrEmpty();
                historyItems[0].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[0].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Show.Status.Should().BeNull();
                historyItems[0].Show.Rating.Should().NotHaveValue();
                historyItems[0].Show.Votes.Should().NotHaveValue();
                historyItems[0].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982348UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[1].Show.Should().NotBeNull();
                historyItems[1].Show.Title.Should().Be("Game of Thrones");
                historyItems[1].Show.Year.Should().Be(2011);
                historyItems[1].Show.Airs.Should().BeNull();
                historyItems[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Show.Ids.Should().NotBeNull();
                historyItems[1].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[1].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[1].Show.Genres.Should().BeNull();
                historyItems[1].Show.Seasons.Should().BeNull();
                historyItems[1].Show.Overview.Should().BeNullOrEmpty();
                historyItems[1].Show.FirstAired.Should().NotHaveValue();
                historyItems[1].Show.Runtime.Should().NotHaveValue();
                historyItems[1].Show.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Network.Should().BeNullOrEmpty();
                historyItems[1].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[1].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Show.Status.Should().BeNull();
                historyItems[1].Show.Rating.Should().NotHaveValue();
                historyItems[1].Show.Votes.Should().NotHaveValue();
                historyItems[1].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Show_Read_Array_From_Stream_Incomplete_1()
        {
            var jsonReader = new HistoryItemArrayJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_1.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982348UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[0].Show.Should().NotBeNull();
                historyItems[0].Show.Title.Should().Be("Game of Thrones");
                historyItems[0].Show.Year.Should().Be(2011);
                historyItems[0].Show.Airs.Should().BeNull();
                historyItems[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Show.Ids.Should().NotBeNull();
                historyItems[0].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[0].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[0].Show.Genres.Should().BeNull();
                historyItems[0].Show.Seasons.Should().BeNull();
                historyItems[0].Show.Overview.Should().BeNullOrEmpty();
                historyItems[0].Show.FirstAired.Should().NotHaveValue();
                historyItems[0].Show.Runtime.Should().NotHaveValue();
                historyItems[0].Show.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Network.Should().BeNullOrEmpty();
                historyItems[0].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[0].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Show.Status.Should().BeNull();
                historyItems[0].Show.Rating.Should().NotHaveValue();
                historyItems[0].Show.Votes.Should().NotHaveValue();
                historyItems[0].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[1].Show.Should().NotBeNull();
                historyItems[1].Show.Title.Should().Be("Game of Thrones");
                historyItems[1].Show.Year.Should().Be(2011);
                historyItems[1].Show.Airs.Should().BeNull();
                historyItems[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Show.Ids.Should().NotBeNull();
                historyItems[1].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[1].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[1].Show.Genres.Should().BeNull();
                historyItems[1].Show.Seasons.Should().BeNull();
                historyItems[1].Show.Overview.Should().BeNullOrEmpty();
                historyItems[1].Show.FirstAired.Should().NotHaveValue();
                historyItems[1].Show.Runtime.Should().NotHaveValue();
                historyItems[1].Show.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Network.Should().BeNullOrEmpty();
                historyItems[1].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[1].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Show.Status.Should().BeNull();
                historyItems[1].Show.Rating.Should().NotHaveValue();
                historyItems[1].Show.Votes.Should().NotHaveValue();
                historyItems[1].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Show_Read_Array_From_Stream_Incomplete_2()
        {
            var jsonReader = new HistoryItemArrayJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_2.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[0].Show.Should().NotBeNull();
                historyItems[0].Show.Title.Should().Be("Game of Thrones");
                historyItems[0].Show.Year.Should().Be(2011);
                historyItems[0].Show.Airs.Should().BeNull();
                historyItems[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Show.Ids.Should().NotBeNull();
                historyItems[0].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[0].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[0].Show.Genres.Should().BeNull();
                historyItems[0].Show.Seasons.Should().BeNull();
                historyItems[0].Show.Overview.Should().BeNullOrEmpty();
                historyItems[0].Show.FirstAired.Should().NotHaveValue();
                historyItems[0].Show.Runtime.Should().NotHaveValue();
                historyItems[0].Show.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Network.Should().BeNullOrEmpty();
                historyItems[0].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[0].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Show.Status.Should().BeNull();
                historyItems[0].Show.Rating.Should().NotHaveValue();
                historyItems[0].Show.Votes.Should().NotHaveValue();
                historyItems[0].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982348UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[1].Show.Should().NotBeNull();
                historyItems[1].Show.Title.Should().Be("Game of Thrones");
                historyItems[1].Show.Year.Should().Be(2011);
                historyItems[1].Show.Airs.Should().BeNull();
                historyItems[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Show.Ids.Should().NotBeNull();
                historyItems[1].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[1].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[1].Show.Genres.Should().BeNull();
                historyItems[1].Show.Seasons.Should().BeNull();
                historyItems[1].Show.Overview.Should().BeNullOrEmpty();
                historyItems[1].Show.FirstAired.Should().NotHaveValue();
                historyItems[1].Show.Runtime.Should().NotHaveValue();
                historyItems[1].Show.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Network.Should().BeNullOrEmpty();
                historyItems[1].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[1].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Show.Status.Should().BeNull();
                historyItems[1].Show.Rating.Should().NotHaveValue();
                historyItems[1].Show.Votes.Should().NotHaveValue();
                historyItems[1].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Show_Read_Array_From_Stream_Not_Valid_1()
        {
            var jsonReader = new HistoryItemArrayJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_1.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[0].Show.Should().NotBeNull();
                historyItems[0].Show.Title.Should().Be("Game of Thrones");
                historyItems[0].Show.Year.Should().Be(2011);
                historyItems[0].Show.Airs.Should().BeNull();
                historyItems[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Show.Ids.Should().NotBeNull();
                historyItems[0].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[0].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[0].Show.Genres.Should().BeNull();
                historyItems[0].Show.Seasons.Should().BeNull();
                historyItems[0].Show.Overview.Should().BeNullOrEmpty();
                historyItems[0].Show.FirstAired.Should().NotHaveValue();
                historyItems[0].Show.Runtime.Should().NotHaveValue();
                historyItems[0].Show.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Network.Should().BeNullOrEmpty();
                historyItems[0].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[0].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Show.Status.Should().BeNull();
                historyItems[0].Show.Rating.Should().NotHaveValue();
                historyItems[0].Show.Votes.Should().NotHaveValue();
                historyItems[0].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982348UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[1].Show.Should().NotBeNull();
                historyItems[1].Show.Title.Should().Be("Game of Thrones");
                historyItems[1].Show.Year.Should().Be(2011);
                historyItems[1].Show.Airs.Should().BeNull();
                historyItems[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Show.Ids.Should().NotBeNull();
                historyItems[1].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[1].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[1].Show.Genres.Should().BeNull();
                historyItems[1].Show.Seasons.Should().BeNull();
                historyItems[1].Show.Overview.Should().BeNullOrEmpty();
                historyItems[1].Show.FirstAired.Should().NotHaveValue();
                historyItems[1].Show.Runtime.Should().NotHaveValue();
                historyItems[1].Show.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Network.Should().BeNullOrEmpty();
                historyItems[1].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[1].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Show.Status.Should().BeNull();
                historyItems[1].Show.Rating.Should().NotHaveValue();
                historyItems[1].Show.Votes.Should().NotHaveValue();
                historyItems[1].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Show_Read_Array_From_Stream_Not_Valid_2()
        {
            var jsonReader = new HistoryItemArrayJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_2.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982348UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[0].Show.Should().NotBeNull();
                historyItems[0].Show.Title.Should().Be("Game of Thrones");
                historyItems[0].Show.Year.Should().Be(2011);
                historyItems[0].Show.Airs.Should().BeNull();
                historyItems[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Show.Ids.Should().NotBeNull();
                historyItems[0].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[0].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[0].Show.Genres.Should().BeNull();
                historyItems[0].Show.Seasons.Should().BeNull();
                historyItems[0].Show.Overview.Should().BeNullOrEmpty();
                historyItems[0].Show.FirstAired.Should().NotHaveValue();
                historyItems[0].Show.Runtime.Should().NotHaveValue();
                historyItems[0].Show.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Network.Should().BeNullOrEmpty();
                historyItems[0].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[0].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Show.Status.Should().BeNull();
                historyItems[0].Show.Rating.Should().NotHaveValue();
                historyItems[0].Show.Votes.Should().NotHaveValue();
                historyItems[0].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[1].Show.Should().NotBeNull();
                historyItems[1].Show.Title.Should().Be("Game of Thrones");
                historyItems[1].Show.Year.Should().Be(2011);
                historyItems[1].Show.Airs.Should().BeNull();
                historyItems[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Show.Ids.Should().NotBeNull();
                historyItems[1].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[1].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[1].Show.Genres.Should().BeNull();
                historyItems[1].Show.Seasons.Should().BeNull();
                historyItems[1].Show.Overview.Should().BeNullOrEmpty();
                historyItems[1].Show.FirstAired.Should().NotHaveValue();
                historyItems[1].Show.Runtime.Should().NotHaveValue();
                historyItems[1].Show.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Network.Should().BeNullOrEmpty();
                historyItems[1].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[1].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Show.Status.Should().BeNull();
                historyItems[1].Show.Rating.Should().NotHaveValue();
                historyItems[1].Show.Votes.Should().NotHaveValue();
                historyItems[1].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Show_Read_Array_From_Stream_Not_Valid_3()
        {
            var jsonReader = new HistoryItemArrayJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_3.ToStream())
            {
                var traktHistoryItems = await jsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[0].Show.Should().NotBeNull();
                historyItems[0].Show.Title.Should().Be("Game of Thrones");
                historyItems[0].Show.Year.Should().Be(2011);
                historyItems[0].Show.Airs.Should().BeNull();
                historyItems[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Show.Ids.Should().NotBeNull();
                historyItems[0].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[0].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[0].Show.Genres.Should().BeNull();
                historyItems[0].Show.Seasons.Should().BeNull();
                historyItems[0].Show.Overview.Should().BeNullOrEmpty();
                historyItems[0].Show.FirstAired.Should().NotHaveValue();
                historyItems[0].Show.Runtime.Should().NotHaveValue();
                historyItems[0].Show.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Network.Should().BeNullOrEmpty();
                historyItems[0].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[0].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Show.Status.Should().BeNull();
                historyItems[0].Show.Rating.Should().NotHaveValue();
                historyItems[0].Show.Votes.Should().NotHaveValue();
                historyItems[0].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Show);
                historyItems[1].Show.Should().NotBeNull();
                historyItems[1].Show.Title.Should().Be("Game of Thrones");
                historyItems[1].Show.Year.Should().Be(2011);
                historyItems[1].Show.Airs.Should().BeNull();
                historyItems[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Show.Ids.Should().NotBeNull();
                historyItems[1].Show.Ids.Trakt.Should().Be(1390U);
                historyItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                historyItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                historyItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                historyItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                historyItems[1].Show.Ids.TvRage.Should().Be(24493U);
                historyItems[1].Show.Genres.Should().BeNull();
                historyItems[1].Show.Seasons.Should().BeNull();
                historyItems[1].Show.Overview.Should().BeNullOrEmpty();
                historyItems[1].Show.FirstAired.Should().NotHaveValue();
                historyItems[1].Show.Runtime.Should().NotHaveValue();
                historyItems[1].Show.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Network.Should().BeNullOrEmpty();
                historyItems[1].Show.CountryCode.Should().BeNullOrEmpty();
                historyItems[1].Show.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Show.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Show.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Show.Status.Should().BeNull();
                historyItems[1].Show.Rating.Should().NotHaveValue();
                historyItems[1].Show.Votes.Should().NotHaveValue();
                historyItems[1].Show.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Show.AiredEpisodes.Should().NotHaveValue();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }
    }
}
