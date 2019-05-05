namespace TraktNet.Objects.Post.Tests.Checkins.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class EpisodeCheckinPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
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
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().BeNull();
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
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
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
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            checkinEpisodeResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinEpisodeResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
                checkinEpisodeResponse.Should().BeNull();
            }
        }
    }
}
