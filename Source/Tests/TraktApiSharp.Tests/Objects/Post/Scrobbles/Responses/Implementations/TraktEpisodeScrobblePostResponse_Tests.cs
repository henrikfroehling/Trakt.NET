namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses.Implementations;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.Implementations")]
    public class TraktEpisodeScrobblePostResponse_Tests
    {
        [Fact]
        public void Test_TraktEpisodeScrobblePostResponse_Implements_ITraktEpisodeScrobblePostResponse_Interface()
        {
            typeof(TraktEpisodeScrobblePostResponse).GetInterfaces().Should().Contain(typeof(ITraktEpisodeScrobblePostResponse));
        }

        [Fact]
        public void Test_TraktEpisodeScrobblePostResponse_Default_Constructor()
        {
            var episodeScrobbleResponse = new TraktEpisodeScrobblePostResponse();

            episodeScrobbleResponse.Id.Should().Be(0UL);
            episodeScrobbleResponse.Action.Should().BeNull();
            episodeScrobbleResponse.Progress.Should().BeNull();
            episodeScrobbleResponse.Sharing.Should().BeNull();
            episodeScrobbleResponse.Episode.Should().BeNull();
            episodeScrobbleResponse.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponse_From_Json()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();
            var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(JSON) as TraktEpisodeScrobblePostResponse;

            episodeScrobbleResponse.Should().NotBeNull();
            episodeScrobbleResponse.Id.Should().Be(3373536623UL);
            episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            episodeScrobbleResponse.Progress.Should().Be(85.9f);
            episodeScrobbleResponse.Sharing.Should().NotBeNull();
            episodeScrobbleResponse.Sharing.Facebook.Should().BeTrue();
            episodeScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            episodeScrobbleResponse.Sharing.Google.Should().BeTrue();
            episodeScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            episodeScrobbleResponse.Sharing.Medium.Should().BeTrue();
            episodeScrobbleResponse.Sharing.Slack.Should().BeTrue();
            episodeScrobbleResponse.Episode.Should().NotBeNull();
            episodeScrobbleResponse.Episode.SeasonNumber.Should().Be(1);
            episodeScrobbleResponse.Episode.Number.Should().Be(1);
            episodeScrobbleResponse.Episode.Title.Should().Be("Winter Is Coming");
            episodeScrobbleResponse.Episode.Ids.Should().NotBeNull();
            episodeScrobbleResponse.Episode.Ids.Trakt.Should().Be(73640U);
            episodeScrobbleResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
            episodeScrobbleResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
            episodeScrobbleResponse.Episode.Ids.Tmdb.Should().Be(63056U);
            episodeScrobbleResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
            episodeScrobbleResponse.Show.Should().NotBeNull();
            episodeScrobbleResponse.Show.Title.Should().Be("Game of Thrones");
            episodeScrobbleResponse.Show.Year.Should().Be(2011);
            episodeScrobbleResponse.Show.Ids.Should().NotBeNull();
            episodeScrobbleResponse.Show.Ids.Trakt.Should().Be(1390U);
            episodeScrobbleResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
            episodeScrobbleResponse.Show.Ids.Tvdb.Should().Be(121361U);
            episodeScrobbleResponse.Show.Ids.Imdb.Should().Be("tt0944947");
            episodeScrobbleResponse.Show.Ids.Tmdb.Should().Be(1399U);
            episodeScrobbleResponse.Show.Ids.TvRage.Should().Be(24493U);
        }

        private const string JSON =
            @"{
                ""id"": 3373536623,
                ""action"": ""scrobble"",
                ""progress"": 85.9,
                ""sharing"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""episode"": {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Winter Is Coming"",
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  }
                },
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";
    }
}
