namespace TraktNet.Objects.Get.Tests.Seasons.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Complete()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_1()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_2()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_1()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_2()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_3()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Complete()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_1()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_2()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_3()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_4()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_5()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_6()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_7()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_8()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_9()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_10()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().BeNull();
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_11()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_11))
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
                traktSeason.Network.Should().Be("The CW");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_12()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_12))
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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_13()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_13))
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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_14()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_14))
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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_15()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_15))
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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_16()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_16))
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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_17()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.TotalEpisodesCount.Should().Be(23);
                traktSeason.AiredEpisodesCount.Should().BeNull();
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_18()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.AiredEpisodesCount.Should().Be(23);
                traktSeason.Overview.Should().BeNull();
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_19()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Overview.Should().Be("Text text text");
                traktSeason.FirstAired.Should().BeNull();
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_20()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_21()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_21))
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
                traktSeason.Network.Should().Be("The CW");
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_22()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_22))
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
                traktSeason.Network.Should().BeNull();
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_1()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_2()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_3()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_4()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_5()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_6()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_7()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_8()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_9()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().Be("The CW");
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_10()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

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
                traktSeason.Network.Should().BeNull();
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
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_11()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_11))
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
                traktSeason.Network.Should().Be("The CW");
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_12()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_12))
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
                traktSeason.Network.Should().BeNull();
                traktSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SeasonObjectJsonReader();
            Func<Task<ITraktSeason>> traktSeason = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktSeason.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SeasonObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeason = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktSeason.Should().BeNull();
            }
        }
    }
}
