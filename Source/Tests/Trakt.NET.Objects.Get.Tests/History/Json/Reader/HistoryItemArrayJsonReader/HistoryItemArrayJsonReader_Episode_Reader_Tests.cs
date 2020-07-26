namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Episode_Read_Array_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982347UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[0].Movie.Should().BeNull();
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
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().NotBeNull();
                historyItems[0].Episode.SeasonNumber.Should().Be(1);
                historyItems[0].Episode.Number.Should().Be(1);
                historyItems[0].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[0].Episode.Ids.Should().NotBeNull();
                historyItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[0].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[0].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[0].Episode.Runtime.Should().NotHaveValue();
                historyItems[0].Episode.Rating.Should().NotHaveValue();
                historyItems[0].Episode.Votes.Should().NotHaveValue();
                historyItems[0].Episode.FirstAired.Should().NotHaveValue();
                historyItems[0].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Episode.Translations.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982347UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[1].Movie.Should().BeNull();
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
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().NotBeNull();
                historyItems[1].Episode.SeasonNumber.Should().Be(1);
                historyItems[1].Episode.Number.Should().Be(1);
                historyItems[1].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[1].Episode.Ids.Should().NotBeNull();
                historyItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[1].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[1].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[1].Episode.Runtime.Should().NotHaveValue();
                historyItems[1].Episode.Rating.Should().NotHaveValue();
                historyItems[1].Episode.Votes.Should().NotHaveValue();
                historyItems[1].Episode.FirstAired.Should().NotHaveValue();
                historyItems[1].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Episode.Translations.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Episode_Read_Array_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982347UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[0].Movie.Should().BeNull();
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
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().NotBeNull();
                historyItems[0].Episode.SeasonNumber.Should().Be(1);
                historyItems[0].Episode.Number.Should().Be(1);
                historyItems[0].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[0].Episode.Ids.Should().NotBeNull();
                historyItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[0].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[0].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[0].Episode.Runtime.Should().NotHaveValue();
                historyItems[0].Episode.Rating.Should().NotHaveValue();
                historyItems[0].Episode.Votes.Should().NotHaveValue();
                historyItems[0].Episode.FirstAired.Should().NotHaveValue();
                historyItems[0].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Episode.Translations.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[1].Movie.Should().BeNull();
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
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().NotBeNull();
                historyItems[1].Episode.SeasonNumber.Should().Be(1);
                historyItems[1].Episode.Number.Should().Be(1);
                historyItems[1].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[1].Episode.Ids.Should().NotBeNull();
                historyItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[1].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[1].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[1].Episode.Runtime.Should().NotHaveValue();
                historyItems[1].Episode.Rating.Should().NotHaveValue();
                historyItems[1].Episode.Votes.Should().NotHaveValue();
                historyItems[1].Episode.FirstAired.Should().NotHaveValue();
                historyItems[1].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Episode.Translations.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Episode_Read_Array_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[0].Movie.Should().BeNull();
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
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().NotBeNull();
                historyItems[0].Episode.SeasonNumber.Should().Be(1);
                historyItems[0].Episode.Number.Should().Be(1);
                historyItems[0].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[0].Episode.Ids.Should().NotBeNull();
                historyItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[0].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[0].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[0].Episode.Runtime.Should().NotHaveValue();
                historyItems[0].Episode.Rating.Should().NotHaveValue();
                historyItems[0].Episode.Votes.Should().NotHaveValue();
                historyItems[0].Episode.FirstAired.Should().NotHaveValue();
                historyItems[0].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Episode.Translations.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982347UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[1].Movie.Should().BeNull();
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
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().NotBeNull();
                historyItems[1].Episode.SeasonNumber.Should().Be(1);
                historyItems[1].Episode.Number.Should().Be(1);
                historyItems[1].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[1].Episode.Ids.Should().NotBeNull();
                historyItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[1].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[1].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[1].Episode.Runtime.Should().NotHaveValue();
                historyItems[1].Episode.Rating.Should().NotHaveValue();
                historyItems[1].Episode.Votes.Should().NotHaveValue();
                historyItems[1].Episode.FirstAired.Should().NotHaveValue();
                historyItems[1].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Episode.Translations.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Episode_Read_Array_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[0].Movie.Should().BeNull();
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
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().NotBeNull();
                historyItems[0].Episode.SeasonNumber.Should().Be(1);
                historyItems[0].Episode.Number.Should().Be(1);
                historyItems[0].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[0].Episode.Ids.Should().NotBeNull();
                historyItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[0].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[0].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[0].Episode.Runtime.Should().NotHaveValue();
                historyItems[0].Episode.Rating.Should().NotHaveValue();
                historyItems[0].Episode.Votes.Should().NotHaveValue();
                historyItems[0].Episode.FirstAired.Should().NotHaveValue();
                historyItems[0].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Episode.Translations.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982347UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[1].Movie.Should().BeNull();
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
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().NotBeNull();
                historyItems[1].Episode.SeasonNumber.Should().Be(1);
                historyItems[1].Episode.Number.Should().Be(1);
                historyItems[1].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[1].Episode.Ids.Should().NotBeNull();
                historyItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[1].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[1].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[1].Episode.Runtime.Should().NotHaveValue();
                historyItems[1].Episode.Rating.Should().NotHaveValue();
                historyItems[1].Episode.Votes.Should().NotHaveValue();
                historyItems[1].Episode.FirstAired.Should().NotHaveValue();
                historyItems[1].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Episode.Translations.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Episode_Read_Array_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982347UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[0].Movie.Should().BeNull();
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
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().NotBeNull();
                historyItems[0].Episode.SeasonNumber.Should().Be(1);
                historyItems[0].Episode.Number.Should().Be(1);
                historyItems[0].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[0].Episode.Ids.Should().NotBeNull();
                historyItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[0].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[0].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[0].Episode.Runtime.Should().NotHaveValue();
                historyItems[0].Episode.Rating.Should().NotHaveValue();
                historyItems[0].Episode.Votes.Should().NotHaveValue();
                historyItems[0].Episode.FirstAired.Should().NotHaveValue();
                historyItems[0].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Episode.Translations.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[1].Movie.Should().BeNull();
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
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().NotBeNull();
                historyItems[1].Episode.SeasonNumber.Should().Be(1);
                historyItems[1].Episode.Number.Should().Be(1);
                historyItems[1].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[1].Episode.Ids.Should().NotBeNull();
                historyItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[1].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[1].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[1].Episode.Runtime.Should().NotHaveValue();
                historyItems[1].Episode.Rating.Should().NotHaveValue();
                historyItems[1].Episode.Votes.Should().NotHaveValue();
                historyItems[1].Episode.FirstAired.Should().NotHaveValue();
                historyItems[1].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Episode.Translations.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Episode_Read_Array_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[0].Movie.Should().BeNull();
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
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().NotBeNull();
                historyItems[0].Episode.SeasonNumber.Should().Be(1);
                historyItems[0].Episode.Number.Should().Be(1);
                historyItems[0].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[0].Episode.Ids.Should().NotBeNull();
                historyItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[0].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[0].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[0].Episode.Runtime.Should().NotHaveValue();
                historyItems[0].Episode.Rating.Should().NotHaveValue();
                historyItems[0].Episode.Votes.Should().NotHaveValue();
                historyItems[0].Episode.FirstAired.Should().NotHaveValue();
                historyItems[0].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Episode.Translations.Should().BeNull();
                historyItems[0].Movie.Should().BeNull();
                historyItems[0].Season.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Checkin);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Episode);
                historyItems[1].Movie.Should().BeNull();
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
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().NotBeNull();
                historyItems[1].Episode.SeasonNumber.Should().Be(1);
                historyItems[1].Episode.Number.Should().Be(1);
                historyItems[1].Episode.Title.Should().Be("Winter Is Coming");
                historyItems[1].Episode.Ids.Should().NotBeNull();
                historyItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                historyItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                historyItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                historyItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                historyItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);
                historyItems[1].Episode.NumberAbsolute.Should().NotHaveValue();
                historyItems[1].Episode.Overview.Should().BeNullOrEmpty();
                historyItems[1].Episode.Runtime.Should().NotHaveValue();
                historyItems[1].Episode.Rating.Should().NotHaveValue();
                historyItems[1].Episode.Votes.Should().NotHaveValue();
                historyItems[1].Episode.FirstAired.Should().NotHaveValue();
                historyItems[1].Episode.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Episode.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Episode.Translations.Should().BeNull();
                historyItems[1].Movie.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
            }
        }
    }
}
