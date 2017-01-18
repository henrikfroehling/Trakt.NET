namespace TraktApiSharp.Tests.Objects.Post.Scrobbles
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Post.Scrobbles;

    [TestClass]
    public class TraktMovieScrobblePostTests
    {
        [TestMethod]
        public void TestTraktMovieScrobblePostDefaultConstructor()
        {
            var movieScrobble = new TraktMovieScrobblePost();

            movieScrobble.Progress.Should().Be(0.0f);
            movieScrobble.AppVersion.Should().BeNullOrEmpty();
            movieScrobble.AppDate.Should().BeNull();
            movieScrobble.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMovieScrobblePostWriteJson()
        {
            var progress = 55.0f;
            var appVersion = "App Version 1.0.0";
            var appDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

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

            var movieScrobble = new TraktMovieScrobblePost
            {
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appDate,
                Movie = movie
            };

            var strJson = JsonConvert.SerializeObject(movieScrobble);

            strJson.Should().NotBeNullOrEmpty();

            var movieScrobbleFromJson = JsonConvert.DeserializeObject<TraktMovieScrobblePost>(strJson);

            movieScrobbleFromJson.Should().NotBeNull();
            movieScrobbleFromJson.Progress.Should().Be(progress);
            movieScrobbleFromJson.AppVersion.Should().Be(appVersion);
            movieScrobbleFromJson.AppDate.Should().NotBeNull().And.NotBeEmpty().And.Be(appDate);

            movieScrobbleFromJson.Movie.Should().NotBeNull();
            movieScrobbleFromJson.Movie.Title.Should().Be(movieTitle);
            movieScrobbleFromJson.Movie.Year.Should().Be(movieYear);
            movieScrobbleFromJson.Movie.Ids.Should().NotBeNull();
            movieScrobbleFromJson.Movie.Ids.Trakt.Should().Be(movieTraktId);
            movieScrobbleFromJson.Movie.Ids.Slug.Should().Be(movieSlug);
            movieScrobbleFromJson.Movie.Ids.Imdb.Should().Be(movieImdb);
            movieScrobbleFromJson.Movie.Ids.Tmdb.Should().Be(movieTmdb);
        }
    }
}
