namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Complete()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_1()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_2()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_3()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_4()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_5()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_6()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_1()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_2()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_3()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_4()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Complete()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_1()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_2()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_3()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_4()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_5()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_6()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_7()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_8()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_9()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_10()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_11()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_12()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_13()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_14()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_15()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_16()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_17()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_18()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_19()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_20()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_21()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_22()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_23()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_23))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_24()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_24))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_25()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_25))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_26()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_26))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_27()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_27))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_28()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_28))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_29()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_29))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_30()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_30))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_31()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_31))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_32()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_32))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_33()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_33))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_34()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_34))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_35()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_35))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_36()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_36))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_37()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_37))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_38()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_38))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_39()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_39))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_40()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_40))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_41()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_41))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_42()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_42))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_1()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_2()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_3()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_4()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_5()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_6()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_7()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_8()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_9()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_10()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_11()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_12()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_13()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_14()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_15()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_16()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_17()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_18()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_19()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_20()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = traktShow.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);
                seasons[0].Rating.Should().BeNull();
                seasons[0].Votes.Should().BeNull();
                seasons[0].TotalEpisodesCount.Should().BeNull();
                seasons[0].AiredEpisodesCount.Should().BeNull();
                seasons[0].Overview.Should().BeNull();
                seasons[0].FirstAired.Should().BeNull();
                seasons[0].Episodes.Should().BeNull();

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(3964U);
                seasons[1].Ids.Tvdb.Should().Be(473271U);
                seasons[1].Ids.Tmdb.Should().Be(3625U);
                seasons[1].Ids.TvRage.Should().Be(36940U);
                seasons[1].Rating.Should().BeNull();
                seasons[1].Votes.Should().BeNull();
                seasons[1].TotalEpisodesCount.Should().BeNull();
                seasons[1].AiredEpisodesCount.Should().BeNull();
                seasons[1].Overview.Should().BeNull();
                seasons[1].FirstAired.Should().BeNull();
                seasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_21()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().Be("Game of Thrones");
                traktShow.Year.Should().Be(2011);
                traktShow.Ids.Should().NotBeNull();
                traktShow.Ids.Trakt.Should().Be(1390U);
                traktShow.Ids.Slug.Should().Be("game-of-thrones");
                traktShow.Ids.Tvdb.Should().Be(121361U);
                traktShow.Ids.Imdb.Should().Be("tt0944947");
                traktShow.Ids.Tmdb.Should().Be(1399U);
                traktShow.Ids.TvRage.Should().Be(24493U);
                traktShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
                traktShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
                traktShow.Airs.Should().NotBeNull();
                traktShow.Airs.Day.Should().Be("Sunday");
                traktShow.Airs.Time.Should().Be("21:00");
                traktShow.Airs.TimeZoneId.Should().Be("America/New_York");
                traktShow.Runtime.Should().Be(60);
                traktShow.Certification.Should().Be("TV-MA");
                traktShow.Network.Should().Be("HBO");
                traktShow.CountryCode.Should().Be("us");
                traktShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
                traktShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
                traktShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
                traktShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
                traktShow.Rating.Should().Be(9.38327f);
                traktShow.Votes.Should().Be(44773);
                traktShow.LanguageCode.Should().Be("en");
                traktShow.AiredEpisodes.Should().Be(50);
                traktShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
                traktShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_22()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShow.Should().NotBeNull();
                traktShow.Title.Should().BeNull();
                traktShow.Year.Should().BeNull();
                traktShow.Ids.Should().BeNull();
                traktShow.Overview.Should().BeNull();
                traktShow.FirstAired.Should().BeNull();
                traktShow.Airs.Should().BeNull();
                traktShow.Runtime.Should().BeNull();
                traktShow.Certification.Should().BeNull();
                traktShow.Network.Should().BeNull();
                traktShow.CountryCode.Should().BeNull();
                traktShow.UpdatedAt.Should().BeNull();
                traktShow.Trailer.Should().BeNull();
                traktShow.Homepage.Should().BeNull();
                traktShow.Status.Should().BeNull();
                traktShow.Rating.Should().BeNull();
                traktShow.Votes.Should().BeNull();
                traktShow.LanguageCode.Should().BeNull();
                traktShow.AiredEpisodes.Should().BeNull();
                traktShow.AvailableTranslationLanguageCodes.Should().BeNull();
                traktShow.Genres.Should().BeNull();
                traktShow.Seasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            var traktShow = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktShow.Should().BeNull();
            }
        }
    }
}
