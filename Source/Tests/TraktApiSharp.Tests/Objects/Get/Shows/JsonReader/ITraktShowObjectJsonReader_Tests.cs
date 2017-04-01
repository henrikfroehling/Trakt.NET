namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public class IITraktShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktShowObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktShow>));
        }

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Complete()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_COMPLETE);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_1()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_1);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_2()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_2);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_3()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_3);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_4()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_4);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_5()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_5);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_6()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_6);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_1()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_1);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_2()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_2);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_3()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_3);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_4()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_4);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Complete()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_COMPLETE);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_1()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_1);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_2()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_2);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_3()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_3);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_4()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_4);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_5()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_5);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_6()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_6);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_7()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_7);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_8()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_8);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_9()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_9);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_10()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_10);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_11()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_11);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_12()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_12);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_13()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_13);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_14()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_14);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_15()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_15);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_16()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_16);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_17()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_17);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_18()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_18);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_19()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_19);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_20()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_20);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_21()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_21);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_22()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_22);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_23()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_23);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_24()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_24);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_25()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_25);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_26()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_26);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_27()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_27);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_28()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_28);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_29()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_29);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_30()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_30);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_31()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_31);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_32()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_32);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_33()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_33);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_34()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_34);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_35()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_35);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_36()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_36);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_37()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_37);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_38()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_38);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_39()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_39);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_40()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_40);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_41()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_41);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_42()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_42);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_1()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_1);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_2()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_2);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_3()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_3);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_4()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_4);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_5()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_5);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_6()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_6);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_7()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_7);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_8()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_8);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_9()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_9);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_10()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_10);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_11()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_11);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_12()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_12);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_13()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_13);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_14()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_14);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_15()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_15);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_16()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_16);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_17()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_17);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_18()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_18);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_19()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_19);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_20()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_20);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_21()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_21);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_22()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(FULL_JSON_NOT_VALID_22);

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

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(default(string));
            traktShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(string.Empty);
            traktShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Complete()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_1()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_2()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_3()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_4()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_5()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_6()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_1()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_2()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_3()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_4()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Complete()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_1()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_2()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_3()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_4()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_5()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_6()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_7()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_8()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_9()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_10()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_11()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_12()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_13()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_14()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_15()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_16()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_17()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_18()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_19()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_20()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_21()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_22()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_23()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_23))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_24()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_24))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_25()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_25))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_26()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_26))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_27()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_27))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_28()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_28))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_29()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_29))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_30()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_30))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_31()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_31))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_32()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_32))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_33()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_33))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_34()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_34))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_35()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_35))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_36()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_36))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_37()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_37))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_38()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_38))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_39()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_39))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_40()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_40))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_41()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_41))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_42()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_42))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_1()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_2()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_3()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_4()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_5()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_6()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_7()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_8()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_9()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_10()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_11()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_12()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_13()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_14()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_15()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_16()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_17()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_18()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_19()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_20()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_21()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_22()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktShowObjectJsonReader();

            var traktShow = jsonReader.ReadObject(default(JsonTextReader));
            traktShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShow = traktJsonReader.ReadObject(jsonReader);
                traktShow.Should().BeNull();
            }
        }

        private const string MINIMAL_JSON_COMPLETE =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_1 =
            @"{
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011
              }";

        private const string MINIMAL_JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Game of Thrones""
              }";

        private const string MINIMAL_JSON_INCOMPLETE_5 =
            @"{
                ""year"": 2011
              }";

        private const string MINIMAL_JSON_INCOMPLETE_6 =
            @"{
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""ye"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""id"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_4 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""ye"": 2011,
                ""id"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string FULL_JSON_COMPLETE =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_1 =
            @"{
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_5 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_6 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_7 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_8 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_9 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_10 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_11 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_12 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_13 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_14 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_15 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_16 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_17 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_18 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_19 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_20 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_21 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50
              }";

        private const string FULL_JSON_INCOMPLETE_22 =
            @"{
                ""title"": ""Game of Thrones""
              }";

        private const string FULL_JSON_INCOMPLETE_23 =
            @"{
                ""year"": 2011
              }";

        private const string FULL_JSON_INCOMPLETE_24 =
            @"{
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string FULL_JSON_INCOMPLETE_25 =
            @"{
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.""
              }";

        private const string FULL_JSON_INCOMPLETE_26 =
            @"{
                ""first_aired"": ""2011-04-17T07:00:00Z""
              }";

        private const string FULL_JSON_INCOMPLETE_27 =
            @"{
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                }
              }";

        private const string FULL_JSON_INCOMPLETE_28 =
            @"{
                ""runtime"": 60
              }";

        private const string FULL_JSON_INCOMPLETE_29 =
            @"{
                ""certification"": ""TV-MA""
              }";

        private const string FULL_JSON_INCOMPLETE_30 =
            @"{
                ""network"": ""HBO""
              }";

        private const string FULL_JSON_INCOMPLETE_31 =
            @"{
                ""country"": ""us""
              }";

        private const string FULL_JSON_INCOMPLETE_32 =
            @"{
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g""
              }";

        private const string FULL_JSON_INCOMPLETE_33 =
            @"{
                ""homepage"": ""http://www.hbo.com/game-of-thrones""
              }";

        private const string FULL_JSON_INCOMPLETE_34 =
            @"{
                ""status"": ""returning series""
              }";

        private const string FULL_JSON_INCOMPLETE_35 =
            @"{
                ""rating"": 9.38327
              }";

        private const string FULL_JSON_INCOMPLETE_36 =
            @"{
                ""votes"": 44773
              }";

        private const string FULL_JSON_INCOMPLETE_37 =
            @"{
                ""updated_at"": ""2016-04-06T10:39:11Z""
              }";

        private const string FULL_JSON_INCOMPLETE_38 =
            @"{
                ""language"": ""en""
              }";

        private const string FULL_JSON_INCOMPLETE_39 =
            @"{
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_40 =
            @"{
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_41 =
            @"{
                ""aired_episodes"": 50
              }";

        private const string FULL_JSON_INCOMPLETE_42 =
            @"{
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""ye"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""id"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""ov"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_5 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""fa"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_6 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""ai"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_7 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""ru"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_8 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""cert"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_9 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""net"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_10 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""co"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_11 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""tr"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_12 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""hp"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_13 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""st"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_14 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""ra"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_15 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""vo"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_16 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""ua"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_17 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""la"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_18 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""availtr"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_19 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""ge"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_20 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aireps"": 50,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_21 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""sea"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string FULL_JSON_NOT_VALID_22 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""ye"": 2011,
                ""id"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""ov"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""fa"": ""2011-04-17T07:00:00Z"",
                ""ai"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""ru"": 60,
                ""cert"": ""TV-MA"",
                ""net"": ""HBO"",
                ""co"": ""us"",
                ""tr"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""hp"": ""http://www.hbo.com/game-of-thrones"",
                ""st"": ""returning series"",
                ""ra"": 9.38327,
                ""vo"": 44773,
                ""ua"": ""2016-04-06T10:39:11Z"",
                ""la"": ""en"",
                ""availtr"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""ge"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aireps"": 50,
                ""sea"": [
                  {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3964,
                      ""tvdb"": 473271,
                      ""tmdb"": 3625,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";
    }
}
