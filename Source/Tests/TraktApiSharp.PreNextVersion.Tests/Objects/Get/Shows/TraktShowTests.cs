namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows;
    using Utils;

    [TestClass]
    public class TraktShowTests
    {
        [TestMethod]
        public void TestTraktShowDefaultConstructor()
        {
            var show = new TraktShow();

            show.Title.Should().BeNullOrEmpty();
            show.Year.Should().NotHaveValue();
            show.Airs.Should().BeNull();
            show.AvailableTranslationLanguageCodes.Should().BeNull();
            show.Ids.Should().BeNull();
            show.Genres.Should().BeNull();
            show.Seasons.Should().BeNull();
            show.Overview.Should().BeNullOrEmpty();
            show.FirstAired.Should().NotHaveValue();
            show.Runtime.Should().NotHaveValue();
            show.Certification.Should().BeNullOrEmpty();
            show.Network.Should().BeNullOrEmpty();
            show.CountryCode.Should().BeNullOrEmpty();
            show.UpdatedAt.Should().NotHaveValue();
            show.Trailer.Should().BeNullOrEmpty();
            show.Homepage.Should().BeNullOrEmpty();
            show.Status.Should().BeNull();
            show.Rating.Should().NotHaveValue();
            show.Votes.Should().NotHaveValue();
            show.LanguageCode.Should().BeNullOrEmpty();
            show.AiredEpisodes.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktShowReadFromJsonMinimal()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSummaryMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var show = JsonConvert.DeserializeObject<TraktShow>(jsonFile);

            show.Should().NotBeNull();
            show.Title.Should().Be("Game of Thrones");
            show.Year.Should().Be(2011);
            show.Airs.Should().BeNull();
            show.AvailableTranslationLanguageCodes.Should().BeNull();
            show.Ids.Should().NotBeNull();
            show.Ids.Trakt.Should().Be(1390U);
            show.Ids.Slug.Should().Be("game-of-thrones");
            show.Ids.Tvdb.Should().Be(121361U);
            show.Ids.Imdb.Should().Be("tt0944947");
            show.Ids.Tmdb.Should().Be(1399U);
            show.Ids.TvRage.Should().Be(24493U);
            show.Genres.Should().BeNull();
            show.Seasons.Should().BeNull();
            show.Overview.Should().BeNullOrEmpty();
            show.FirstAired.Should().NotHaveValue();
            show.Runtime.Should().NotHaveValue();
            show.Certification.Should().BeNullOrEmpty();
            show.Network.Should().BeNullOrEmpty();
            show.CountryCode.Should().BeNullOrEmpty();
            show.UpdatedAt.Should().NotHaveValue();
            show.Trailer.Should().BeNullOrEmpty();
            show.Homepage.Should().BeNullOrEmpty();
            show.Status.Should().BeNull();
            show.Rating.Should().NotHaveValue();
            show.Votes.Should().NotHaveValue();
            show.LanguageCode.Should().BeNullOrEmpty();
            show.AiredEpisodes.Should().NotHaveValue();
        }
        
        [TestMethod]
        public void TestTraktShowReadFromJsonFull()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSummaryFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var show = JsonConvert.DeserializeObject<TraktShow>(jsonFile);

            show.Should().NotBeNull();
            show.Title.Should().Be("Game of Thrones");
            show.Year.Should().Be(2011);
            show.Airs.Should().NotBeNull();
            show.Airs.Day.Should().Be("Sunday");
            show.Airs.Time.Should().Be("21:00");
            show.Airs.TimeZoneId.Should().Be("America/New_York");
            show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            show.Ids.Should().NotBeNull();
            show.Ids.Trakt.Should().Be(1390U);
            show.Ids.Slug.Should().Be("game-of-thrones");
            show.Ids.Tvdb.Should().Be(121361U);
            show.Ids.Imdb.Should().Be("tt0944947");
            show.Ids.Tmdb.Should().Be(1399U);
            show.Ids.TvRage.Should().Be(24493U);
            show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            show.Seasons.Should().BeNull();
            show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            show.Runtime.Should().Be(60);
            show.Certification.Should().Be("TV-MA");
            show.Network.Should().Be("HBO");
            show.CountryCode.Should().Be("us");
            show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            show.Rating.Should().Be(9.38327f);
            show.Votes.Should().Be(44773);
            show.LanguageCode.Should().Be("en");
            show.AiredEpisodes.Should().Be(50);
        }
    }
}
