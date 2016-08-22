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
    public class TraktShowWatchedProgressTests
    {
        [TestMethod]
        public void TestTraktShowWatchedProgressDefaultConstructor()
        {
            var watchedProgress = new TraktShowWatchedProgress();

            watchedProgress.Aired.Should().NotHaveValue();
            watchedProgress.Completed.Should().NotHaveValue();
            watchedProgress.LastWatchedAt.Should().NotHaveValue();
            watchedProgress.Seasons.Should().BeNull();
            watchedProgress.HiddenSeasons.Should().BeNull();
            watchedProgress.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowWatchedProgressReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgress.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var watchedProgress = JsonConvert.DeserializeObject<TraktShowWatchedProgress>(jsonFile);

            watchedProgress.Should().NotBeNull();

            watchedProgress.Aired.Should().Be(8);
            watchedProgress.Completed.Should().Be(6);
            watchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            watchedProgress.Seasons.Should().NotBeNull();
            watchedProgress.Seasons.Should().HaveCount(1);

            var seasons = watchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(8);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[6].Number.Should().Be(7);
            episodes[6].Completed.Should().BeFalse();
            episodes[6].LastWatchedAt.Should().NotHaveValue();

            episodes[7].Number.Should().Be(8);
            episodes[7].Completed.Should().BeFalse();
            episodes[7].LastWatchedAt.Should().NotHaveValue();

            watchedProgress.HiddenSeasons.Should().NotBeNull();
            watchedProgress.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = watchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            watchedProgress.NextEpisode.Should().NotBeNull();
            watchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            watchedProgress.NextEpisode.Number.Should().Be(7);
            watchedProgress.NextEpisode.Title.Should().Be("Water");
            watchedProgress.NextEpisode.Ids.Should().NotBeNull();
            watchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            watchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            watchedProgress.NextEpisode.Ids.Imdb.Should().BeNull();
            watchedProgress.NextEpisode.Ids.Tmdb.Should().BeNull();
            watchedProgress.NextEpisode.Ids.TvRage.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowWatchedProgressCompleteReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var watchedProgress = JsonConvert.DeserializeObject<TraktShowWatchedProgress>(jsonFile);

            watchedProgress.Should().NotBeNull();

            watchedProgress.Aired.Should().Be(6);
            watchedProgress.Completed.Should().Be(6);
            watchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            watchedProgress.Seasons.Should().NotBeNull();
            watchedProgress.Seasons.Should().HaveCount(1);

            var seasons = watchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            watchedProgress.HiddenSeasons.Should().NotBeNull();
            watchedProgress.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = watchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            watchedProgress.NextEpisode.Should().BeNull();
        }
    }
}
