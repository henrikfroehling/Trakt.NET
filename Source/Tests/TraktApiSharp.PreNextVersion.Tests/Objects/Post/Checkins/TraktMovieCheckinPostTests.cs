namespace TraktApiSharp.Tests.Objects.Post.Checkins
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Post.Checkins;

    [TestClass]
    public class TraktMovieCheckinPostTests
    {
        [TestMethod]
        public void TestTraktMovieCheckinPostDefaultConstructor()
        {
            var movieCheckin = new TraktMovieCheckinPost();

            movieCheckin.Sharing.Should().BeNull();
            movieCheckin.Message.Should().BeNullOrEmpty();
            movieCheckin.AppVersion.Should().BeNullOrEmpty();
            movieCheckin.AppDate.Should().BeNull();
            movieCheckin.FoursquareVenueId.Should().BeNullOrEmpty();
            movieCheckin.FoursquareVenueName.Should().BeNullOrEmpty();
            movieCheckin.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMovieCheckinPostWriteJson()
        {
            var sharing = new TraktSharing { Facebook = true, Twitter = false, Tumblr = false };
            var message = "checkin in now";
            var appVersion = "App Version 1.0.0";
            var appDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var venueId = "venue id";
            var venueName = "venue name";

            var movieTitle = "Guardians of the Galaxy";
            var movieYear = 2014;
            var movieTraktId = 28U;
            var movieSlug = "guardiangs-of-the-galaxy-2014";
            var movieImdb = "tt2015381";
            var movieTmdb = 118340U;

            var movie = new TraktMovie
            {
                Title = movieTitle,
                Year = movieYear,
                Ids = new TraktMovieIds
                {
                    Trakt = movieTraktId,
                    Slug = movieSlug,
                    Imdb = movieImdb,
                    Tmdb = movieTmdb
                }
            };

            var movieCheckin = new TraktMovieCheckinPost
            {
                Sharing = sharing,
                Message = message,
                AppVersion = appVersion,
                AppDate = appDate,
                FoursquareVenueId = venueId,
                FoursquareVenueName = venueName,
                Movie = movie
            };

            var strJson = JsonConvert.SerializeObject(movieCheckin);

            strJson.Should().NotBeNullOrEmpty();

            var movieCheckinFromJson = JsonConvert.DeserializeObject<TraktMovieCheckinPost>(strJson);

            movieCheckinFromJson.Should().NotBeNull();
            movieCheckinFromJson.Sharing.Should().NotBeNull();
            movieCheckinFromJson.Sharing.Facebook.Should().BeTrue();
            movieCheckinFromJson.Sharing.Twitter.Should().BeFalse();
            movieCheckinFromJson.Sharing.Tumblr.Should().BeFalse();
            movieCheckinFromJson.Message.Should().Be(message);
            movieCheckinFromJson.AppVersion.Should().Be(appVersion);
            movieCheckinFromJson.AppDate.Should().NotBeNull().And.NotBeEmpty().And.Be(appDate);
            movieCheckinFromJson.FoursquareVenueId.Should().Be(venueId);
            movieCheckinFromJson.FoursquareVenueName.Should().Be(venueName);

            movieCheckinFromJson.Movie.Should().NotBeNull();
            movieCheckinFromJson.Movie.Title.Should().Be(movieTitle);
            movieCheckinFromJson.Movie.Year.Should().Be(movieYear);
            movieCheckinFromJson.Movie.Ids.Should().NotBeNull();
            movieCheckinFromJson.Movie.Ids.Trakt.Should().Be(movieTraktId);
            movieCheckinFromJson.Movie.Ids.Slug.Should().Be(movieSlug);
            movieCheckinFromJson.Movie.Ids.Imdb.Should().Be(movieImdb);
            movieCheckinFromJson.Movie.Ids.Tmdb.Should().Be(movieTmdb);
        }
    }
}
