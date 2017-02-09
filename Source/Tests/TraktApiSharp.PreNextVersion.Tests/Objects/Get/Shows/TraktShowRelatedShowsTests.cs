namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows;
    using Utils;

    [TestClass]
    public class TraktShowRelatedShowsTests
    {
        [TestMethod]
        public void TestTraktShowRelatedShowsReadFromJsonMinimal()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var relatedShows = JsonConvert.DeserializeObject<IEnumerable<TraktShow>>(jsonFile);

            relatedShows.Should().NotBeNull();
            relatedShows.Should().HaveCount(2);

            var shows = relatedShows.ToArray();

            shows[0].Title.Should().Be("Sherlock");
            shows[0].Year.Should().Be(2010);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(19792U);
            shows[0].Ids.Slug.Should().Be("sherlock");
            shows[0].Ids.Tvdb.Should().Be(176941U);
            shows[0].Ids.Imdb.Should().Be("tt1475582");
            shows[0].Ids.Tmdb.Should().Be(19885U);
            shows[0].Ids.TvRage.Should().Be(23433U);

            shows[1].Title.Should().Be("11.22.63");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(102771U);
            shows[1].Ids.Slug.Should().Be("11-22-63");
            shows[1].Ids.Tvdb.Should().Be(301824U);
            shows[1].Ids.Imdb.Should().Be("tt2879552");
            shows[1].Ids.Tmdb.Should().Be(64464U);
            shows[1].Ids.TvRage.Should().Be(45210U);
        }

        [TestMethod]
        public void TestTraktShowRelatedShowsReadFromJsonFull()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var relatedShows = JsonConvert.DeserializeObject<IEnumerable<TraktShow>>(jsonFile);

            relatedShows.Should().NotBeNull();
            relatedShows.Should().HaveCount(2);

            var shows = relatedShows.ToArray();

            shows[0].Title.Should().Be("Sherlock");
            shows[0].Year.Should().Be(2010);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(19792U);
            shows[0].Ids.Slug.Should().Be("sherlock");
            shows[0].Ids.Tvdb.Should().Be(176941U);
            shows[0].Ids.Imdb.Should().Be("tt1475582");
            shows[0].Ids.Tmdb.Should().Be(19885U);
            shows[0].Ids.TvRage.Should().Be(23433U);
            shows[0].Overview.Should().Be("Sherlock is a British television crime drama that presents a contemporary adaptation of Sir Arthur Conan Doyle's Sherlock Holmes detective stories. Created by Steven Moffat and Mark Gatiss, it stars Benedict Cumberbatch as Sherlock Holmes and Martin Freeman as Doctor John Watson.");
            shows[0].FirstAired.Should().Be(DateTime.Parse("2010-07-25T07:00:00Z").ToUniversalTime());
            shows[0].Airs.Should().NotBeNull();
            shows[0].Airs.Day.Should().Be("Sunday");
            shows[0].Airs.Time.Should().Be("20:30");
            shows[0].Airs.TimeZoneId.Should().Be("Europe/London");
            shows[0].Runtime.Should().Be(90);
            shows[0].Certification.Should().Be("TV-14");
            shows[0].Network.Should().Be("BBC One");
            shows[0].CountryCode.Should().Be("gb");
            shows[0].Trailer.Should().Be("http://youtube.com/watch?v=JP5Dr63TbSU");
            shows[0].Homepage.Should().Be("http://www.bbc.co.uk/programmes/b018ttws");
            shows[0].Status.Should().Be(TraktShowStatus.ReturningSeries);
            shows[0].Rating.Should().Be(9.26159f);
            shows[0].Votes.Should().Be(22268);
            shows[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-07T19:31:38Z").ToUniversalTime());
            shows[0].LanguageCode.Should().Be("en");
            shows[0].AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "ru", "zh", "hu");
            shows[0].Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "crime", "mystery", "adventure", "thriller");
            shows[0].AiredEpisodes.Should().Be(9);

            shows[1].Title.Should().Be("11.22.63");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(102771U);
            shows[1].Ids.Slug.Should().Be("11-22-63");
            shows[1].Ids.Tvdb.Should().Be(301824U);
            shows[1].Ids.Imdb.Should().Be("tt2879552");
            shows[1].Ids.Tmdb.Should().Be(64464U);
            shows[1].Ids.TvRage.Should().Be(45210U);
            shows[1].Overview.Should().Be("Imagine having the power to change history. Would you journey down the \"rabbit hole\"? This event series follows Jake Epping, an ordinary high school teacher, presented with the unthinkable mission of traveling back in time to prevent the assassination of John F. Kennedy on November 22, 1963. Jake travels to the past in order to solve the most enduring mystery of the 20th century: who killed JFK, and could it have been stopped? But as Jake will learn, the past does not want to be changed. And trying to divert the course of history may prove fatal.");
            shows[1].FirstAired.Should().Be(DateTime.Parse("2016-02-15T08:00:00Z").ToUniversalTime());
            shows[1].Airs.Should().NotBeNull();
            shows[1].Airs.Day.Should().Be("Monday");
            shows[1].Airs.Time.Should().Be("00:01");
            shows[1].Airs.TimeZoneId.Should().Be("America/New_York");
            shows[1].Runtime.Should().Be(60);
            shows[1].Certification.Should().Be("TV-MA");
            shows[1].Network.Should().Be("Hulu");
            shows[1].CountryCode.Should().Be("us");
            shows[1].Trailer.Should().Be("http://youtube.com/watch?v=NXUx__qQGew");
            shows[1].Homepage.Should().Be("http://www.hulu.com/112263");
            shows[1].Status.Should().Be(TraktShowStatus.Unspecified);
            shows[1].Rating.Should().Be(8.26689f);
            shows[1].Votes.Should().Be(607);
            shows[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-07T19:47:40Z").ToUniversalTime());
            shows[1].LanguageCode.Should().Be("en");
            shows[1].AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "bs", "he");
            shows[1].Genres.Should().NotBeNull().And.HaveCount(3).And.Contain("science-fiction", "drama", "fantasy");
            shows[1].AiredEpisodes.Should().Be(8);
        }
    }
}
