namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using Utils;

    [TestClass]
    public class TraktMovieScrobblePostResponseTests
    {
        [TestMethod]
        public void TestTraktMovieScrobblePostResponseDefaultConstructor()
        {
            var movieScrobbleResponse = new TraktMovieScrobblePostResponse();

            movieScrobbleResponse.Action.Should().BeNull();
            movieScrobbleResponse.Progress.Should().NotHaveValue();
            movieScrobbleResponse.Sharing.Should().BeNull();
            movieScrobbleResponse.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMovieScrobblePostResponseStartReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieScrobbleResponse = JsonConvert.DeserializeObject<TraktMovieScrobblePostResponse>(jsonFile);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Start);
            movieScrobbleResponse.Progress.Should().Be(1.25f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeFalse();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Guardians of the Galaxy");
            movieScrobbleResponse.Movie.Year.Should().Be(2014);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(28U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2015381");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktMovieScrobblePostResponsePauseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieScrobbleResponse = JsonConvert.DeserializeObject<TraktMovieScrobblePostResponse>(jsonFile);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Pause);
            movieScrobbleResponse.Progress.Should().Be(75.0f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Facebook.Should().BeFalse();
            movieScrobbleResponse.Sharing.Twitter.Should().BeFalse();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeFalse();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Guardians of the Galaxy");
            movieScrobbleResponse.Movie.Year.Should().Be(2014);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(28U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2015381");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktMovieScrobblePostResponseStopReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieScrobbleResponse = JsonConvert.DeserializeObject<TraktMovieScrobblePostResponse>(jsonFile);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().Be(85.0f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Facebook.Should().BeFalse();
            movieScrobbleResponse.Sharing.Twitter.Should().BeFalse();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeFalse();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Guardians of the Galaxy");
            movieScrobbleResponse.Movie.Year.Should().Be(2014);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(28U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2015381");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(118340U);
        }
    }
}
