namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Checkins.Responses.Implementations;
    using TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.Implementations")]
    public class TraktEpisodeCheckinPostResponse_Tests
    {
        [Fact]
        public void Test_TraktEpisodeCheckinPostResponse_Default_Constructor()
        {
            var episodeCheckinResponse = new TraktEpisodeCheckinPostResponse();

            episodeCheckinResponse.Id.Should().Be(0);
            episodeCheckinResponse.WatchedAt.Should().BeNull();
            episodeCheckinResponse.Sharing.Should().BeNull();
            episodeCheckinResponse.Episode.Should().BeNull();
            episodeCheckinResponse.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodeCheckinPostResponse_From_Json()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();
            var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(JSON) as TraktEpisodeCheckinPostResponse;

            checkinEpisodeResponse.Should().NotBeNull();
            checkinEpisodeResponse.Id.Should().Be(3373536620UL);
            checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            checkinEpisodeResponse.Sharing.Should().NotBeNull();
            checkinEpisodeResponse.Sharing.Facebook.Should().BeTrue();
            checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
            checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
            checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
            checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
            checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
            checkinEpisodeResponse.Episode.Should().NotBeNull();
            checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
            checkinEpisodeResponse.Episode.Number.Should().Be(1);
            checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
            checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
            checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
            checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
            checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
            checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
            checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
            checkinEpisodeResponse.Show.Should().NotBeNull();
            checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
            checkinEpisodeResponse.Show.Year.Should().Be(2011);
            checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
            checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
            checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
            checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
            checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
            checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
            checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
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
