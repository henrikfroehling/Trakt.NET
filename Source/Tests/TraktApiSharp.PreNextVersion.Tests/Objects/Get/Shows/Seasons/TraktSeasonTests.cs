namespace TraktApiSharp.Tests.Objects.Shows.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using Utils;

    [TestClass]
    public class TraktSeasonTests
    {
        [TestMethod]
        public void TestTraktSeasonDefaultConstructor()
        {
            var season = new TraktSeason();

            season.Number.Should().NotHaveValue();
            season.Ids.Should().BeNull();
            season.Images.Should().BeNull();
            season.Rating.Should().NotHaveValue();
            season.Votes.Should().NotHaveValue();
            season.TotalEpisodesCount.Should().NotHaveValue();
            season.AiredEpisodesCount.Should().NotHaveValue();
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().NotHaveValue();
            season.Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonReadFromJsonMinimal()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonSummaryMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var season = JsonConvert.DeserializeObject<TraktSeason>(jsonFile);

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Images.Should().BeNull();
            season.Rating.Should().NotHaveValue();
            season.Votes.Should().NotHaveValue();
            season.TotalEpisodesCount.Should().NotHaveValue();
            season.AiredEpisodesCount.Should().NotHaveValue();
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().NotHaveValue();
            season.Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonReadFromJsonMinimalWithEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonSummaryWithEpisodesMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var season = JsonConvert.DeserializeObject<TraktSeason>(jsonFile);

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Images.Should().BeNull();
            season.Rating.Should().NotHaveValue();
            season.Votes.Should().NotHaveValue();
            season.TotalEpisodesCount.Should().NotHaveValue();
            season.AiredEpisodesCount.Should().NotHaveValue();
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().NotHaveValue();

            season.Episodes.Should().NotBeNull();
            season.Episodes.Should().HaveCount(6);

            var episodes = season.Episodes.ToArray();

            episodes[0].Title.Should().Be("City of Heroes");
            episodes[1].Title.Should().Be("Fastest Man Alive");
            episodes[2].Title.Should().Be("Things You Can't Outrun");
            episodes[3].Title.Should().Be("Going Rogue");
            episodes[4].Title.Should().Be("Plastique");
            episodes[5].Title.Should().Be("The Flash is Born");
        }

        [TestMethod]
        public void TestTraktSeasonReadFromJsonImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonSummaryImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var season = JsonConvert.DeserializeObject<TraktSeason>(jsonFile);

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Images.Should().NotBeNull();
            season.Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/original/ea214a63c3.jpg");
            season.Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/medium/ea214a63c3.jpg");
            season.Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/thumb/ea214a63c3.jpg");
            season.Images.Thumb.Full.Should().BeNullOrEmpty();
            season.Rating.Should().NotHaveValue();
            season.Votes.Should().NotHaveValue();
            season.TotalEpisodesCount.Should().NotHaveValue();
            season.AiredEpisodesCount.Should().NotHaveValue();
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().NotHaveValue();
            season.Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonReadFromJsonImagesWithEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonSummaryWithEpisodesImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var season = JsonConvert.DeserializeObject<TraktSeason>(jsonFile);

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Images.Should().NotBeNull();
            season.Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/original/ea214a63c3.jpg");
            season.Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/medium/ea214a63c3.jpg");
            season.Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/thumb/ea214a63c3.jpg");
            season.Images.Thumb.Full.Should().BeNullOrEmpty();
            season.Rating.Should().NotHaveValue();
            season.Votes.Should().NotHaveValue();
            season.TotalEpisodesCount.Should().NotHaveValue();
            season.AiredEpisodesCount.Should().NotHaveValue();
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().NotHaveValue();

            season.Episodes.Should().NotBeNull();
            season.Episodes.Should().HaveCount(6);

            var episodes = season.Episodes.ToArray();

            episodes[0].Title.Should().Be("City of Heroes");
            episodes[1].Title.Should().Be("Fastest Man Alive");
            episodes[2].Title.Should().Be("Things You Can't Outrun");
            episodes[3].Title.Should().Be("Going Rogue");
            episodes[4].Title.Should().Be("Plastique");
            episodes[5].Title.Should().Be("The Flash is Born");
        }

        [TestMethod]
        public void TestTraktSeasonReadFromJsonFull()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonSummaryFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var season = JsonConvert.DeserializeObject<TraktSeason>(jsonFile);

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Images.Should().BeNull();
            season.Rating.Should().Be(8.57053f);
            season.Votes.Should().Be(794);
            season.TotalEpisodesCount.Should().Be(23);
            season.AiredEpisodesCount.Should().Be(23);
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());
            season.Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonReadFromJsonFullWithEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonSummaryWithEpisodesFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var season = JsonConvert.DeserializeObject<TraktSeason>(jsonFile);

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Images.Should().BeNull();
            season.Rating.Should().Be(8.57053f);
            season.Votes.Should().Be(794);
            season.TotalEpisodesCount.Should().Be(23);
            season.AiredEpisodesCount.Should().Be(23);
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());

            season.Episodes.Should().NotBeNull();
            season.Episodes.Should().HaveCount(6);

            var episodes = season.Episodes.ToArray();

            episodes[0].Title.Should().Be("City of Heroes");
            episodes[1].Title.Should().Be("Fastest Man Alive");
            episodes[2].Title.Should().Be("Things You Can't Outrun");
            episodes[3].Title.Should().Be("Going Rogue");
            episodes[4].Title.Should().Be("Plastique");
            episodes[5].Title.Should().Be("The Flash is Born");
        }

        [TestMethod]
        public void TestTraktSeasonReadFromJsonFullAndImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonSummaryFullAndImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var season = JsonConvert.DeserializeObject<TraktSeason>(jsonFile);

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Images.Should().NotBeNull();
            season.Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/original/ea214a63c3.jpg");
            season.Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/medium/ea214a63c3.jpg");
            season.Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/thumb/ea214a63c3.jpg");
            season.Images.Thumb.Full.Should().BeNullOrEmpty();
            season.Rating.Should().Be(8.57053f);
            season.Votes.Should().Be(794);
            season.TotalEpisodesCount.Should().Be(23);
            season.AiredEpisodesCount.Should().Be(23);
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());
            season.Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonReadFromJsonFullAndImagesWithEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonSummaryWithEpisodesFullAndImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var season = JsonConvert.DeserializeObject<TraktSeason>(jsonFile);

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Images.Should().NotBeNull();
            season.Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/original/ea214a63c3.jpg");
            season.Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/medium/ea214a63c3.jpg");
            season.Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/thumb/ea214a63c3.jpg");
            season.Images.Thumb.Full.Should().BeNullOrEmpty();
            season.Rating.Should().Be(8.57053f);
            season.Votes.Should().Be(794);
            season.TotalEpisodesCount.Should().Be(23);
            season.AiredEpisodesCount.Should().Be(23);
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());

            season.Episodes.Should().NotBeNull();
            season.Episodes.Should().HaveCount(6);

            var episodes = season.Episodes.ToArray();

            episodes[0].Title.Should().Be("City of Heroes");
            episodes[1].Title.Should().Be("Fastest Man Alive");
            episodes[2].Title.Should().Be("Things You Can't Outrun");
            episodes[3].Title.Should().Be("Going Rogue");
            episodes[4].Title.Should().Be("Plastique");
            episodes[5].Title.Should().Be("The Flash is Born");
        }
    }
}
