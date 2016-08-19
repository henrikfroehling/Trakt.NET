namespace TraktApiSharp.Tests.Objects.Get.Syncs.Playback
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using Utils;

    [TestClass]
    public class TraktSyncPlaybackProgressItemTests
    {
        [TestMethod]
        public void TestTraktSyncPlaybackProgressItemDefaultConstructor()
        {
            var playbackProgress = new TraktSyncPlaybackProgressItem();

            playbackProgress.Progress.Should().NotHaveValue();
            playbackProgress.PausedAt.Should().NotHaveValue();
            playbackProgress.Id.Should().Be(0);
            playbackProgress.Type.Should().BeNull();
            playbackProgress.Movie.Should().BeNull();
            playbackProgress.Episode.Should().BeNull();
            playbackProgress.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncPlaybackProgressItemMovieReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgressItemMovie.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var playbackProgress = JsonConvert.DeserializeObject<TraktSyncPlaybackProgressItem>(jsonFile);

            playbackProgress.Should().NotBeNull();

            playbackProgress.Progress.Should().Be(10.0f);
            playbackProgress.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            playbackProgress.Id.Should().Be(13);
            playbackProgress.Type.Should().Be(TraktSyncType.Movie);
            playbackProgress.Movie.Should().NotBeNull();
            playbackProgress.Movie.Title.Should().Be("Batman Begins");
            playbackProgress.Movie.Year.Should().Be(2005);
            playbackProgress.Movie.Ids.Should().NotBeNull();
            playbackProgress.Movie.Ids.Trakt.Should().Be(1U);
            playbackProgress.Movie.Ids.Slug.Should().Be("batman-begins-2005");
            playbackProgress.Movie.Ids.Imdb.Should().Be("tt0372784");
            playbackProgress.Movie.Ids.Tmdb.Should().Be(272U);
            playbackProgress.Episode.Should().BeNull();
            playbackProgress.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncPlaybackProgressItemEpisodeReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgressItemEpisode.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var playbackProgress = JsonConvert.DeserializeObject<TraktSyncPlaybackProgressItem>(jsonFile);

            playbackProgress.Should().NotBeNull();

            playbackProgress.Progress.Should().Be(65.5f);
            playbackProgress.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            playbackProgress.Id.Should().Be(37);
            playbackProgress.Type.Should().Be(TraktSyncType.Episode);
            playbackProgress.Movie.Should().BeNull();
            playbackProgress.Episode.Should().NotBeNull();
            playbackProgress.Episode.SeasonNumber.Should().Be(0);
            playbackProgress.Episode.Number.Should().Be(1);
            playbackProgress.Episode.Title.Should().Be("Good Cop Bad Cop");
            playbackProgress.Episode.Ids.Should().NotBeNull();
            playbackProgress.Episode.Ids.Trakt.Should().Be(1U);
            playbackProgress.Episode.Ids.Tvdb.Should().Be(3859781U);
            playbackProgress.Episode.Ids.Imdb.Should().BeNullOrEmpty();
            playbackProgress.Episode.Ids.Tmdb.Should().Be(62131U);
            playbackProgress.Episode.Ids.TvRage.Should().BeNull();
            playbackProgress.Show.Should().NotBeNull();
            playbackProgress.Show.Title.Should().Be("Breaking Bad");
            playbackProgress.Show.Year.Should().Be(2008);
            playbackProgress.Show.Ids.Should().NotBeNull();
            playbackProgress.Show.Ids.Trakt.Should().Be(1U);
            playbackProgress.Show.Ids.Slug.Should().Be("breaking-bad");
            playbackProgress.Show.Ids.Tvdb.Should().Be(81189U);
            playbackProgress.Show.Ids.Imdb.Should().Be("tt0903747");
            playbackProgress.Show.Ids.Tmdb.Should().Be(1396U);
            playbackProgress.Show.Ids.TvRage.Should().Be(18164U);
        }
    }
}
