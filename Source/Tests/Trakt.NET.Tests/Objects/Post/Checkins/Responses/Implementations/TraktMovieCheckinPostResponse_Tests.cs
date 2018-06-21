namespace TraktNet.Tests.Objects.Post.Checkins.Responses.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Post.Checkins.Responses;
    using TraktNet.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.Implementations")]
    public class TraktMovieCheckinPostResponse_Tests
    {
        [Fact]
        public void Test_TraktMovieCheckinPostResponse_Default_Constructor()
        {
            var movieCheckinResponse = new TraktMovieCheckinPostResponse();

            movieCheckinResponse.Id.Should().Be(0);
            movieCheckinResponse.WatchedAt.Should().BeNull();
            movieCheckinResponse.Sharing.Should().BeNull();
            movieCheckinResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieCheckinPostResponse_From_Json()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();
            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON) as TraktMovieCheckinPostResponse;

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(3373536620UL);
            checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            checkinMovieResponse.Sharing.Should().NotBeNull();
            checkinMovieResponse.Sharing.Facebook.Should().BeTrue();
            checkinMovieResponse.Sharing.Twitter.Should().BeTrue();
            checkinMovieResponse.Sharing.Google.Should().BeTrue();
            checkinMovieResponse.Sharing.Tumblr.Should().BeTrue();
            checkinMovieResponse.Sharing.Medium.Should().BeTrue();
            checkinMovieResponse.Sharing.Slack.Should().BeTrue();
            checkinMovieResponse.Movie.Should().NotBeNull();
            checkinMovieResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            checkinMovieResponse.Movie.Year.Should().Be(2015);
            checkinMovieResponse.Movie.Ids.Should().NotBeNull();
            checkinMovieResponse.Movie.Ids.Trakt.Should().Be(94024U);
            checkinMovieResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            checkinMovieResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            checkinMovieResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        private const string JSON =
            @"{
                ""id"": 3373536620,
                ""watched_at"": ""2014-08-06T06:54:36.859Z"",
                ""sharing"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";
    }
}
