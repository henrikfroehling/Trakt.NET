namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public class ITraktSeasonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktSeasonObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktSeasonObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktSeason>));
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Minimal_Complete()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(MINIMAL_JSON_COMPLETE);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().BeNullOrEmpty();
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().NotHaveValue();
            traktSeason.Votes.Should().NotHaveValue();
            traktSeason.TotalEpisodesCount.Should().NotHaveValue();
            traktSeason.AiredEpisodesCount.Should().NotHaveValue();
            traktSeason.Overview.Should().BeNullOrEmpty();
            traktSeason.FirstAired.Should().NotHaveValue();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_1()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(MINIMAL_JSON_INCOMPLETE_1);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().BeNullOrEmpty();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().NotHaveValue();
            traktSeason.Votes.Should().NotHaveValue();
            traktSeason.TotalEpisodesCount.Should().NotHaveValue();
            traktSeason.AiredEpisodesCount.Should().NotHaveValue();
            traktSeason.Overview.Should().BeNullOrEmpty();
            traktSeason.FirstAired.Should().NotHaveValue();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_2()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(MINIMAL_JSON_INCOMPLETE_2);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNullOrEmpty();
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().NotHaveValue();
            traktSeason.Votes.Should().NotHaveValue();
            traktSeason.TotalEpisodesCount.Should().NotHaveValue();
            traktSeason.AiredEpisodesCount.Should().NotHaveValue();
            traktSeason.Overview.Should().BeNullOrEmpty();
            traktSeason.FirstAired.Should().NotHaveValue();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_1()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(MINIMAL_JSON_NOT_VALID_1);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNullOrEmpty();
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().NotHaveValue();
            traktSeason.Votes.Should().NotHaveValue();
            traktSeason.TotalEpisodesCount.Should().NotHaveValue();
            traktSeason.AiredEpisodesCount.Should().NotHaveValue();
            traktSeason.Overview.Should().BeNullOrEmpty();
            traktSeason.FirstAired.Should().NotHaveValue();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_2()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(MINIMAL_JSON_NOT_VALID_2);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().BeNullOrEmpty();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().NotHaveValue();
            traktSeason.Votes.Should().NotHaveValue();
            traktSeason.TotalEpisodesCount.Should().NotHaveValue();
            traktSeason.AiredEpisodesCount.Should().NotHaveValue();
            traktSeason.Overview.Should().BeNullOrEmpty();
            traktSeason.FirstAired.Should().NotHaveValue();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_3()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(MINIMAL_JSON_NOT_VALID_3);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNullOrEmpty();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().NotHaveValue();
            traktSeason.Votes.Should().NotHaveValue();
            traktSeason.TotalEpisodesCount.Should().NotHaveValue();
            traktSeason.AiredEpisodesCount.Should().NotHaveValue();
            traktSeason.Overview.Should().BeNullOrEmpty();
            traktSeason.FirstAired.Should().NotHaveValue();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Complete()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_COMPLETE);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_1()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_1);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_2()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_2);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_3()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_3);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_4()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_4);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_5()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_5);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_6()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_6);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_7()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_7);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_8()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_8);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_9()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_9);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_10()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_10);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_11()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_11);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_12()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_12);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_13()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_13);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_14()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_14);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_15()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_15);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_16()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_16);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_17()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_17);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_18()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_18);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_19()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_19);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_20()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_20);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_1()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_1);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_2()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_2);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_3()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_3);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_4()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_4);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_5()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_5);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_6()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_6);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_7()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_7);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_8()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_8);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_9()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_9);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = traktSeason.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_10()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_10);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().Be(1);
            traktSeason.Title.Should().Be("Season 1");
            traktSeason.Ids.Should().NotBeNull();
            traktSeason.Ids.Trakt.Should().Be(61430U);
            traktSeason.Ids.Tvdb.Should().Be(279121U);
            traktSeason.Ids.Tmdb.Should().Be(60523U);
            traktSeason.Ids.TvRage.Should().Be(36939U);
            traktSeason.Rating.Should().Be(8.57053f);
            traktSeason.Votes.Should().Be(794);
            traktSeason.TotalEpisodesCount.Should().Be(23);
            traktSeason.AiredEpisodesCount.Should().Be(23);
            traktSeason.Overview.Should().Be("Text text text");
            traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_11()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_11);

            traktSeason.Should().NotBeNull();
            traktSeason.Number.Should().BeNull();
            traktSeason.Title.Should().BeNull();
            traktSeason.Ids.Should().BeNull();
            traktSeason.Rating.Should().BeNull();
            traktSeason.Votes.Should().BeNull();
            traktSeason.TotalEpisodesCount.Should().BeNull();
            traktSeason.AiredEpisodesCount.Should().BeNull();
            traktSeason.Overview.Should().BeNull();
            traktSeason.FirstAired.Should().BeNull();
            traktSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(default(string));
            traktSeason.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(string.Empty);
            traktSeason.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Complete()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().BeNullOrEmpty();
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().NotHaveValue();
                traktSeason.Votes.Should().NotHaveValue();
                traktSeason.TotalEpisodesCount.Should().NotHaveValue();
                traktSeason.AiredEpisodesCount.Should().NotHaveValue();
                traktSeason.Overview.Should().BeNullOrEmpty();
                traktSeason.FirstAired.Should().NotHaveValue();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_1()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().BeNullOrEmpty();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().NotHaveValue();
                traktSeason.Votes.Should().NotHaveValue();
                traktSeason.TotalEpisodesCount.Should().NotHaveValue();
                traktSeason.AiredEpisodesCount.Should().NotHaveValue();
                traktSeason.Overview.Should().BeNullOrEmpty();
                traktSeason.FirstAired.Should().NotHaveValue();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_2()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNullOrEmpty();
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().NotHaveValue();
                traktSeason.Votes.Should().NotHaveValue();
                traktSeason.TotalEpisodesCount.Should().NotHaveValue();
                traktSeason.AiredEpisodesCount.Should().NotHaveValue();
                traktSeason.Overview.Should().BeNullOrEmpty();
                traktSeason.FirstAired.Should().NotHaveValue();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_1()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNullOrEmpty();
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().NotHaveValue();
                traktSeason.Votes.Should().NotHaveValue();
                traktSeason.TotalEpisodesCount.Should().NotHaveValue();
                traktSeason.AiredEpisodesCount.Should().NotHaveValue();
                traktSeason.Overview.Should().BeNullOrEmpty();
                traktSeason.FirstAired.Should().NotHaveValue();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_2()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().BeNullOrEmpty();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().NotHaveValue();
                traktSeason.Votes.Should().NotHaveValue();
                traktSeason.TotalEpisodesCount.Should().NotHaveValue();
                traktSeason.AiredEpisodesCount.Should().NotHaveValue();
                traktSeason.Overview.Should().BeNullOrEmpty();
                traktSeason.FirstAired.Should().NotHaveValue();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_3()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNullOrEmpty();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().NotHaveValue();
                traktSeason.Votes.Should().NotHaveValue();
                traktSeason.TotalEpisodesCount.Should().NotHaveValue();
                traktSeason.AiredEpisodesCount.Should().NotHaveValue();
                traktSeason.Overview.Should().BeNullOrEmpty();
                traktSeason.FirstAired.Should().NotHaveValue();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Complete()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_1()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_2()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_3()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_4()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_5()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_6()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_7()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_8()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_9()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_10()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_11()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_12()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_13()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_14()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_15()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_16()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_17()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_18()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_19()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_20()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_1()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_2()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_3()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_4()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_5()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_6()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_7()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_8()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_9()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = traktSeason.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(74138U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63141U);
                episodes[1].Ids.TvRage.Should().Be(1325718577U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_10()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().Be(1);
                traktSeason.Title.Should().Be("Season 1");
                traktSeason.Ids.Should().NotBeNull();
                traktSeason.Ids.Trakt.Should().Be(61430U);
                traktSeason.Ids.Tvdb.Should().Be(279121U);
                traktSeason.Ids.Tmdb.Should().Be(60523U);
                traktSeason.Ids.TvRage.Should().Be(36939U);
                traktSeason.Rating.Should().Be(8.57053f);
                traktSeason.Votes.Should().Be(794);
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_11()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeason.Should().NotBeNull();
                traktSeason.Number.Should().BeNull();
                traktSeason.Title.Should().BeNull();
                traktSeason.Ids.Should().BeNull();
                traktSeason.Rating.Should().BeNull();
                traktSeason.Votes.Should().BeNull();
                traktSeason.TotalEpisodesCount.Should().BeNull();
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktSeasonObjectJsonReader();

            var traktSeason = await jsonReader.ReadObjectAsync(default(JsonTextReader));
            traktSeason.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktSeasonObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktSeason.Should().BeNull();
            }
        }

        private const string MINIMAL_JSON_COMPLETE =
            @"{
                ""number"": 1,
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_1 =
            @"{
                ""number"": 1
              }";

        private const string MINIMAL_JSON_INCOMPLETE_2 =
            @"{
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_1 =
            @"{
                ""nu"": 1,
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_2 =
            @"{
                ""number"": 1,
                ""id"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_3 =
            @"{
                ""nu"": 1,
                ""id"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string FULL_JSON_COMPLETE =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_1 =
            @"{
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_2 =
            @"{
                ""number"": 1,
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_3 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_4 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_5 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_6 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_7 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_8 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_9 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_10 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z""
              }";

        private const string FULL_JSON_INCOMPLETE_11 =
            @"{
                ""number"": 1
              }";

        private const string FULL_JSON_INCOMPLETE_12 =
            @"{
                ""title"": ""Season 1""
              }";

        private const string FULL_JSON_INCOMPLETE_13 =
            @"{
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string FULL_JSON_INCOMPLETE_14 =
            @"{
                ""rating"": 8.57053
              }";

        private const string FULL_JSON_INCOMPLETE_15 =
            @"{
                ""votes"": 794
              }";

        private const string FULL_JSON_INCOMPLETE_16 =
            @"{
                ""episode_count"": 23
              }";

        private const string FULL_JSON_INCOMPLETE_17 =
            @"{
                ""aired_episodes"": 23
              }";

        private const string FULL_JSON_INCOMPLETE_18 =
            @"{
                ""overview"": ""Text text text""
              }";

        private const string FULL_JSON_INCOMPLETE_19 =
            @"{
                ""first_aired"": ""2014-10-08T00:00:00.000Z""
              }";

        private const string FULL_JSON_INCOMPLETE_20 =
            @"{
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_1 =
            @"{
                ""nu"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_2 =
            @"{
                ""number"": 1,
                ""ti"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_3 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""id"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_4 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""ra"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_5 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""vo"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_6 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""epsc"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_7 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aireps"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_8 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""ov"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_9 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""fa"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_10 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""eps"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_11 =
            @"{
                ""nu"": 1,
                ""ti"": ""Season 1"",
                ""id"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""ra"": 8.57053,
                ""vo"": 794,
                ""epsc"": 23,
                ""aireps"": 23,
                ""ov"": ""Text text text"",
                ""fa"": ""2014-10-08T00:00:00.000Z"",
                ""eps"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";
    }
}
