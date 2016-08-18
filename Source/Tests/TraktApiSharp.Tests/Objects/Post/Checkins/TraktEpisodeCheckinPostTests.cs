namespace TraktApiSharp.Tests.Objects.Post.Checkins
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Objects.Post.Checkins;

    [TestClass]
    public class TraktEpisodeCheckinPostTests
    {
        [TestMethod]
        public void TestTraktEpisodeCheckinPostDefaultConstructor()
        {
            var episodeCheckin = new TraktEpisodeCheckinPost();

            episodeCheckin.Sharing.Should().BeNull();
            episodeCheckin.Message.Should().BeNullOrEmpty();
            episodeCheckin.AppVersion.Should().BeNullOrEmpty();
            episodeCheckin.AppDate.Should().BeNull();
            episodeCheckin.FoursquareVenueId.Should().BeNullOrEmpty();
            episodeCheckin.FoursquareVenueName.Should().BeNullOrEmpty();
            episodeCheckin.Episode.Should().BeNull();
            episodeCheckin.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktEpisodeCheckinPostWriteJson()
        {
            var sharing = new TraktSharing { Facebook = true, Twitter = false, Tumblr = true };
            var message = "checkin in now";
            var appVersion = "App Version 1.0.0";
            var appDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var venueId = "venue id";
            var venueName = "venue name";

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

            var episodeCheckin = new TraktEpisodeCheckinPost
            {
                Sharing = sharing,
                Message = message,
                AppVersion = appVersion,
                AppDate = appDate,
                FoursquareVenueId = venueId,
                FoursquareVenueName = venueName,
                Episode = episode,
                Show = show
            };

            var strJson = JsonConvert.SerializeObject(episodeCheckin);

            strJson.Should().NotBeNullOrEmpty();

            var episodeCheckinFromJson = JsonConvert.DeserializeObject<TraktEpisodeCheckinPost>(strJson);

            episodeCheckinFromJson.Should().NotBeNull();
            episodeCheckinFromJson.Sharing.Should().NotBeNull();
            episodeCheckinFromJson.Sharing.Facebook.Should().BeTrue();
            episodeCheckinFromJson.Sharing.Twitter.Should().BeFalse();
            episodeCheckinFromJson.Sharing.Tumblr.Should().BeTrue();
            episodeCheckinFromJson.Message.Should().Be(message);
            episodeCheckinFromJson.AppVersion.Should().Be(appVersion);
            episodeCheckinFromJson.AppDate.Should().NotBeNull().And.NotBeEmpty().And.Be(appDate);
            episodeCheckinFromJson.FoursquareVenueId.Should().Be(venueId);
            episodeCheckinFromJson.FoursquareVenueName.Should().Be(venueName);

            episodeCheckinFromJson.Episode.Should().NotBeNull();
            episodeCheckinFromJson.Episode.SeasonNumber.Should().Be(seasonNr);
            episodeCheckinFromJson.Episode.Number.Should().Be(episodeNr);
            episodeCheckinFromJson.Episode.Title.Should().Be(episodeTitle);
            episodeCheckinFromJson.Episode.Ids.Should().NotBeNull();
            episodeCheckinFromJson.Episode.Ids.Trakt.Should().Be(episodeTraktId);
            episodeCheckinFromJson.Episode.Ids.Tvdb.Should().Be(episodeTvdb);
            episodeCheckinFromJson.Episode.Ids.Imdb.Should().Be(episodeImdb);
            episodeCheckinFromJson.Episode.Ids.Tmdb.Should().Be(episodeTmdb);
            episodeCheckinFromJson.Episode.Ids.TvRage.Should().Be(episodeTvRage);

            episodeCheckinFromJson.Show.Should().NotBeNull();
            episodeCheckinFromJson.Show.Title.Should().Be(showTitle);
            episodeCheckinFromJson.Show.Year.Should().Be(showYear);
            episodeCheckinFromJson.Show.Ids.Should().NotBeNull();
            episodeCheckinFromJson.Show.Ids.Trakt.Should().Be(showTraktId);
            episodeCheckinFromJson.Show.Ids.Slug.Should().Be(showSlug);
            episodeCheckinFromJson.Show.Ids.Tvdb.Should().Be(showTvdb);
            episodeCheckinFromJson.Show.Ids.Imdb.Should().Be(showImdb);
            episodeCheckinFromJson.Show.Ids.Tmdb.Should().Be(showTmdb);
            episodeCheckinFromJson.Show.Ids.TvRage.Should().Be(showTvRage);
        }
    }
}
