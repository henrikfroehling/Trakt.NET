namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using Utils;

    [TestClass]
    public class TraktMovieCheckinPostResponseTests
    {
        [TestMethod]
        public void TestTraktMovieCheckinPostResponseDefaultConstructor()
        {
            var movieCheckinResponse = new TraktMovieCheckinPostResponse();

            movieCheckinResponse.WatchedAt.Should().NotHaveValue();
            movieCheckinResponse.Sharing.Should().BeNull();
            movieCheckinResponse.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMovieCheckinPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\MovieCheckinPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieCheckinResponse = JsonConvert.DeserializeObject<TraktMovieCheckinPostResponse>(jsonFile);

            movieCheckinResponse.Should().NotBeNull();
            movieCheckinResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            movieCheckinResponse.Sharing.Should().NotBeNull();
            movieCheckinResponse.Sharing.Facebook.Should().BeTrue();
            movieCheckinResponse.Sharing.Twitter.Should().BeTrue();
            movieCheckinResponse.Sharing.Tumblr.Should().BeFalse();
            movieCheckinResponse.Movie.Should().NotBeNull();
            movieCheckinResponse.Movie.Title.Should().Be("Guardians of the Galaxy");
            movieCheckinResponse.Movie.Year.Should().Be(2014);
            movieCheckinResponse.Movie.Ids.Should().NotBeNull();
            movieCheckinResponse.Movie.Ids.Trakt.Should().Be(28U);
            movieCheckinResponse.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            movieCheckinResponse.Movie.Ids.Imdb.Should().Be("tt2015381");
            movieCheckinResponse.Movie.Ids.Tmdb.Should().Be(118340U);
        }
    }
}
