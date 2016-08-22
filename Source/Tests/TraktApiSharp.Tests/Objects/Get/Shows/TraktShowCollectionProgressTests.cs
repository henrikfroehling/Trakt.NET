namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows;
    using Utils;

    [TestClass]
    public class TraktShowCollectionProgressTests
    {
        [TestMethod]
        public void TestTraktShowCollectionProgressDefaultConstructor()
        {
            var collectionProgress = new TraktShowCollectionProgress();

            collectionProgress.Aired.Should().NotHaveValue();
            collectionProgress.Completed.Should().NotHaveValue();
            collectionProgress.LastCollectedAt.Should().NotHaveValue();
            collectionProgress.Seasons.Should().BeNull();
            collectionProgress.HiddenSeasons.Should().BeNull();
            collectionProgress.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowCollectionProgressReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgress.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectionProgress = JsonConvert.DeserializeObject<TraktShowCollectionProgress>(jsonFile);

            collectionProgress.Should().NotBeNull();

            collectionProgress.Aired.Should().Be(8);
            collectionProgress.Completed.Should().Be(6);
            collectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            collectionProgress.Seasons.Should().NotBeNull();
            collectionProgress.Seasons.Should().HaveCount(1);

            var seasons = collectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(8);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[6].Number.Should().Be(7);
            episodes[6].Completed.Should().BeFalse();
            episodes[6].CollectedAt.Should().NotHaveValue();

            episodes[7].Number.Should().Be(8);
            episodes[7].Completed.Should().BeFalse();
            episodes[7].CollectedAt.Should().NotHaveValue();

            collectionProgress.HiddenSeasons.Should().NotBeNull();
            collectionProgress.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = collectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            collectionProgress.NextEpisode.Should().NotBeNull();
            collectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            collectionProgress.NextEpisode.Number.Should().Be(7);
            collectionProgress.NextEpisode.Title.Should().Be("Water");
            collectionProgress.NextEpisode.Ids.Should().NotBeNull();
            collectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            collectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            collectionProgress.NextEpisode.Ids.Imdb.Should().BeNull();
            collectionProgress.NextEpisode.Ids.Tmdb.Should().BeNull();
            collectionProgress.NextEpisode.Ids.TvRage.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowCollectionProgressCompleteReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectionProgress = JsonConvert.DeserializeObject<TraktShowCollectionProgress>(jsonFile);

            collectionProgress.Should().NotBeNull();

            collectionProgress.Aired.Should().Be(6);
            collectionProgress.Completed.Should().Be(6);
            collectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            collectionProgress.Seasons.Should().NotBeNull();
            collectionProgress.Seasons.Should().HaveCount(1);

            var seasons = collectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            collectionProgress.HiddenSeasons.Should().NotBeNull();
            collectionProgress.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = collectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            collectionProgress.NextEpisode.Should().BeNull();
        }
    }
}
