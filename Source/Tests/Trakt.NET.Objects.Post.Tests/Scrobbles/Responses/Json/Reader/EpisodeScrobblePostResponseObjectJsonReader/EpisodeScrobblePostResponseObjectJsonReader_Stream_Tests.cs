namespace TraktNet.Objects.Post.Tests.Scrobbles.Responses.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Post.Scrobbles.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.JsonReader")]
    public partial class EpisodeScrobblePostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().BeNull();
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().BeNull();
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
                episodeScrobbleResponse.Action.Should().BeNull();
                episodeScrobbleResponse.Progress.Should().BeNull();
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(0UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().BeNull();
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().BeNull();
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                episodeScrobbleResponse.Should().NotBeNull();
                episodeScrobbleResponse.Id.Should().Be(3373536623UL);
                episodeScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                episodeScrobbleResponse.Progress.Should().Be(85.9f);
                episodeScrobbleResponse.Sharing.Should().NotBeNull();
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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(default(Stream));
            episodeScrobbleResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new EpisodeScrobblePostResponseObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var episodeScrobbleResponse = await jsonReader.ReadObjectAsync(stream);
                episodeScrobbleResponse.Should().BeNull();
            }
        }
    }
}
