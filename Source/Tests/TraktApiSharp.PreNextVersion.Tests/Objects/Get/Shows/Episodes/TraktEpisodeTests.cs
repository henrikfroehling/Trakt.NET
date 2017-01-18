namespace TraktApiSharp.Tests.Objects.Shows.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using Utils;

    [TestClass]
    public class TraktEpisodeTests
    {
        [TestMethod]
        public void TestTraktEpisodeDefaultConstructor()
        {
            var episode = new TraktEpisode();

            episode.Title.Should().BeNullOrEmpty();
            episode.SeasonNumber.Should().NotHaveValue();
            episode.Number.Should().NotHaveValue();
            episode.NumberAbsolute.Should().NotHaveValue();
            episode.Overview.Should().BeNullOrEmpty();
            episode.FirstAired.Should().NotHaveValue();
            episode.UpdatedAt.Should().NotHaveValue();
            episode.Rating.Should().NotHaveValue();
            episode.Votes.Should().NotHaveValue();
            episode.Ids.Should().BeNull();
            episode.Images.Should().BeNull();
            episode.AvailableTranslationLanguageCodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktEpisodeReadFromJsonMinimal()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episode = JsonConvert.DeserializeObject<TraktEpisode>(jsonFile);

            episode.Should().NotBeNull();
            episode.Title.Should().Be("Winter Is Coming");
            episode.SeasonNumber.Should().Be(1);
            episode.Number.Should().Be(1);
            episode.NumberAbsolute.Should().NotHaveValue();
            episode.Overview.Should().BeNullOrEmpty();
            episode.FirstAired.Should().NotHaveValue();
            episode.UpdatedAt.Should().NotHaveValue();
            episode.Rating.Should().NotHaveValue();
            episode.Votes.Should().NotHaveValue();
            episode.Ids.Should().NotBeNull();
            episode.Ids.Trakt.Should().Be(73640U);
            episode.Ids.Tvdb.Should().Be(3254641U);
            episode.Ids.Imdb.Should().Be("tt1480055");
            episode.Ids.Tmdb.Should().Be(63056U);
            episode.Ids.TvRage.Should().Be(1065008299U);
            episode.Images.Should().BeNull();
            episode.AvailableTranslationLanguageCodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktEpisodeReadFromJsonImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episode = JsonConvert.DeserializeObject<TraktEpisode>(jsonFile);

            episode.Should().NotBeNull();
            episode.Title.Should().Be("Winter Is Coming");
            episode.SeasonNumber.Should().Be(1);
            episode.Number.Should().Be(1);
            episode.NumberAbsolute.Should().NotHaveValue();
            episode.Overview.Should().BeNullOrEmpty();
            episode.FirstAired.Should().NotHaveValue();
            episode.UpdatedAt.Should().NotHaveValue();
            episode.Rating.Should().NotHaveValue();
            episode.Votes.Should().NotHaveValue();
            episode.Ids.Should().NotBeNull();
            episode.Ids.Trakt.Should().Be(73640U);
            episode.Ids.Tvdb.Should().Be(3254641U);
            episode.Ids.Imdb.Should().Be("tt1480055");
            episode.Ids.Tmdb.Should().Be(63056U);
            episode.Ids.TvRage.Should().Be(1065008299U);
            episode.Images.Should().NotBeNull();
            episode.Images.Screenshot.Should().NotBeNull();
            episode.Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/original/dd3fc55725.jpg");
            episode.Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/medium/dd3fc55725.jpg");
            episode.Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/thumb/dd3fc55725.jpg");
            episode.AvailableTranslationLanguageCodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktEpisodeReadFromJsonFull()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episode = JsonConvert.DeserializeObject<TraktEpisode>(jsonFile);

            episode.Should().NotBeNull();
            episode.Title.Should().Be("Winter Is Coming");
            episode.SeasonNumber.Should().Be(1);
            episode.Number.Should().Be(1);
            episode.NumberAbsolute.Should().Be(50);
            episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            episode.Rating.Should().Be(9.0f);
            episode.Votes.Should().Be(111);
            episode.Ids.Should().NotBeNull();
            episode.Ids.Trakt.Should().Be(73640U);
            episode.Ids.Tvdb.Should().Be(3254641U);
            episode.Ids.Imdb.Should().Be("tt1480055");
            episode.Ids.Tmdb.Should().Be(63056U);
            episode.Ids.TvRage.Should().Be(1065008299U);
            episode.Images.Should().BeNull();
            episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktEpisodeReadFromJsonFullAndImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFullAndImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episode = JsonConvert.DeserializeObject<TraktEpisode>(jsonFile);

            episode.Should().NotBeNull();
            episode.Title.Should().Be("Winter Is Coming");
            episode.SeasonNumber.Should().Be(1);
            episode.Number.Should().Be(1);
            episode.NumberAbsolute.Should().Be(50);
            episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            episode.Rating.Should().Be(9.0f);
            episode.Votes.Should().Be(111);
            episode.Ids.Should().NotBeNull();
            episode.Ids.Trakt.Should().Be(73640U);
            episode.Ids.Tvdb.Should().Be(3254641U);
            episode.Ids.Imdb.Should().Be("tt1480055");
            episode.Ids.Tmdb.Should().Be(63056U);
            episode.Ids.TvRage.Should().Be(1065008299U);
            episode.Images.Should().NotBeNull();
            episode.Images.Screenshot.Should().NotBeNull();
            episode.Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/original/dd3fc55725.jpg");
            episode.Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/medium/dd3fc55725.jpg");
            episode.Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/thumb/dd3fc55725.jpg");
            episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }
    }
}
