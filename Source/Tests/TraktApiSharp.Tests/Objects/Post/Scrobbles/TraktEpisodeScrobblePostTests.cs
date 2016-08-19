namespace TraktApiSharp.Tests.Objects.Post.Scrobbles
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Objects.Post.Scrobbles;

    [TestClass]
    public class TraktEpisodeScrobblePostTests
    {
        [TestMethod]
        public void TestTraktEpisodeScrobblePostDefaultConstructor()
        {
            var episodeScrobble = new TraktEpisodeScrobblePost();

            episodeScrobble.Progress.Should().Be(0.0f);
            episodeScrobble.AppVersion.Should().BeNullOrEmpty();
            episodeScrobble.AppDate.Should().BeNull();
            episodeScrobble.Episode.Should().BeNull();
            episodeScrobble.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktEpisodeScrobblePostWriteJson()
        {
            var progress = 65.0f;
            var appVersion = "App Version 1.0.0";
            var appDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

            var episodeNr = 1;
            var seasonNr = 1;
            var episodeTitle = "Pilot";
            var episodeTraktId = 16U;
            var episodeTvdb = 349232U;
            var episodeImdb = "tt0959621";
            var episodeTmdb = 62085U;
            var episodeTvRage = 637041U;

            var showTitle = "Breaking Bad";
            var showYear = 2008;
            var showTraktId = 1U;
            var showSlug = "breaking-bad";
            var showTvdb = 81189U;
            var showImdb = "tt0903747";
            var showTmdb = 1396U;
            var showTvRage = 18164U;

            var episode = new TraktEpisode
            {
                SeasonNumber = seasonNr,
                Number = episodeNr,
                Title = episodeTitle,
                Ids = new TraktEpisodeIds
                {
                    Trakt = episodeTraktId,
                    Tvdb = episodeTvdb,
                    Imdb = episodeImdb,
                    Tmdb = episodeTmdb,
                    TvRage = episodeTvRage
                }
            };

            var show = new TraktShow
            {
                Title = showTitle,
                Year = showYear,
                Ids = new TraktShowIds
                {
                    Trakt = showTraktId,
                    Slug = showSlug,
                    Tvdb = showTvdb,
                    Imdb = showImdb,
                    Tmdb = showTmdb,
                    TvRage = showTvRage
                }
            };

            var movieScrobble = new TraktEpisodeScrobblePost
            {
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appDate,
                Episode = episode,
                Show = show
            };

            var strJson = JsonConvert.SerializeObject(movieScrobble);

            strJson.Should().NotBeNullOrEmpty();

            var episodeScrobbleFromJson = JsonConvert.DeserializeObject<TraktEpisodeScrobblePost>(strJson);

            episodeScrobbleFromJson.Should().NotBeNull();
            episodeScrobbleFromJson.Progress.Should().Be(progress);
            episodeScrobbleFromJson.AppVersion.Should().Be(appVersion);
            episodeScrobbleFromJson.AppDate.Should().NotBeNull().And.NotBeEmpty().And.Be(appDate);

            episodeScrobbleFromJson.Episode.Should().NotBeNull();
            episodeScrobbleFromJson.Episode.SeasonNumber.Should().Be(seasonNr);
            episodeScrobbleFromJson.Episode.Number.Should().Be(episodeNr);
            episodeScrobbleFromJson.Episode.Title.Should().Be(episodeTitle);
            episodeScrobbleFromJson.Episode.Ids.Should().NotBeNull();
            episodeScrobbleFromJson.Episode.Ids.Trakt.Should().Be(episodeTraktId);
            episodeScrobbleFromJson.Episode.Ids.Tvdb.Should().Be(episodeTvdb);
            episodeScrobbleFromJson.Episode.Ids.Imdb.Should().Be(episodeImdb);
            episodeScrobbleFromJson.Episode.Ids.Tmdb.Should().Be(episodeTmdb);
            episodeScrobbleFromJson.Episode.Ids.TvRage.Should().Be(episodeTvRage);

            episodeScrobbleFromJson.Show.Should().NotBeNull();
            episodeScrobbleFromJson.Show.Title.Should().Be(showTitle);
            episodeScrobbleFromJson.Show.Year.Should().Be(showYear);
            episodeScrobbleFromJson.Show.Ids.Should().NotBeNull();
            episodeScrobbleFromJson.Show.Ids.Trakt.Should().Be(showTraktId);
            episodeScrobbleFromJson.Show.Ids.Slug.Should().Be(showSlug);
            episodeScrobbleFromJson.Show.Ids.Tvdb.Should().Be(showTvdb);
            episodeScrobbleFromJson.Show.Ids.Imdb.Should().Be(showImdb);
            episodeScrobbleFromJson.Show.Ids.Tmdb.Should().Be(showTmdb);
            episodeScrobbleFromJson.Show.Ids.TvRage.Should().Be(showTvRage);
        }
    }
}
