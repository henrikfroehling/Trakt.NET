namespace TraktNet.Objects.Post.Tests.Scrobbles.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Post.Scrobbles.Responses;
    using TraktNet.Objects.Post.Scrobbles.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Scrobbles.Responses.Implementations")]
    public class TraktMovieScrobblePostResponse_Tests
    {
        [Fact]
        public void Test_TraktMovieScrobblePostResponse_Default_Constructor()
        {
            var movieScrobbleResponse = new TraktMovieScrobblePostResponse();

            movieScrobbleResponse.Id.Should().Be(0UL);
            movieScrobbleResponse.Action.Should().BeNull();
            movieScrobbleResponse.Progress.Should().BeNull();
            movieScrobbleResponse.Sharing.Should().BeNull();
            movieScrobbleResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieScrobblePostResponse_From_Json()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();
            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON) as TraktMovieScrobblePostResponse;

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        private const string JSON =
            @"{
                ""id"": 3373536623,
                ""action"": ""scrobble"",
                ""progress"": 85.9,
                ""sharing"": {
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
