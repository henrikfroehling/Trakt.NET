namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.JsonReader")]
    public partial class TraktEpisodeScrobblePostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                episodeScrobbleResponse.Episode.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                episodeScrobbleResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().BeNull();
                episodeScrobbleResponse.Progress.Should().BeNull();
                episodeScrobbleResponse.Sharing.Should().BeNull();
                episodeScrobbleResponse.Episode.Should().BeNull();
                episodeScrobbleResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().BeNull();
                episodeScrobbleResponse.Sharing.Should().BeNull();
                episodeScrobbleResponse.Episode.Should().BeNull();
                episodeScrobbleResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
                episodeScrobbleResponse.Action.Should().BeNull();
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().BeNull();
                episodeScrobbleResponse.Episode.Should().BeNull();
                episodeScrobbleResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
                episodeScrobbleResponse.Action.Should().BeNull();
                episodeScrobbleResponse.Progress.Should().BeNull();
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
                episodeScrobbleResponse.Sharing.Facebook.Should().BeTrue();
                episodeScrobbleResponse.Sharing.Twitter.Should().BeTrue();
                episodeScrobbleResponse.Sharing.Google.Should().BeTrue();
                episodeScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
                episodeScrobbleResponse.Sharing.Medium.Should().BeTrue();
                episodeScrobbleResponse.Sharing.Slack.Should().BeTrue();
                episodeScrobbleResponse.Episode.Should().BeNull();
                episodeScrobbleResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
                episodeScrobbleResponse.Action.Should().BeNull();
                episodeScrobbleResponse.Progress.Should().BeNull();
                episodeScrobbleResponse.Sharing.Should().BeNull();
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
                episodeScrobbleResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
                episodeScrobbleResponse.Action.Should().BeNull();
                episodeScrobbleResponse.Progress.Should().BeNull();
                episodeScrobbleResponse.Sharing.Should().BeNull();
                episodeScrobbleResponse.Episode.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                episodeScrobbleResponse.Episode.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                episodeScrobbleResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
                episodeScrobbleResponse.Action.Should().BeNull();
                episodeScrobbleResponse.Progress.Should().BeNull();
                episodeScrobbleResponse.Sharing.Should().BeNull();
                episodeScrobbleResponse.Episode.Should().BeNull();
                episodeScrobbleResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            episodeScrobbleResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktEpisodeScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodeScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
                episodeScrobbleResponse.Should().BeNull();
            }
        }
    }
}
