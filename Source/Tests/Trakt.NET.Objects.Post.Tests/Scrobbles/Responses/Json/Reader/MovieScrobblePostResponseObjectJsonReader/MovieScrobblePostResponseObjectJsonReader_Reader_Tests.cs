namespace TraktNet.Objects.Post.Tests.Scrobbles.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Post.Scrobbles.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.JsonReader")]
    public partial class MovieScrobblePostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
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
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().NotBeNull();
                movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                movieScrobbleResponse.Movie.Year.Should().Be(2015);
                movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
                movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
                movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
                movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
                movieScrobbleResponse.Sharing.Google.Should().BeTrue();
                movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
                movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
                movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().NotBeNull();
                movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                movieScrobbleResponse.Movie.Year.Should().Be(2015);
                movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
                movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
                movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
                movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
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
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().NotBeNull();
                movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                movieScrobbleResponse.Movie.Year.Should().Be(2015);
                movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
                movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
                movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
                movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            movieScrobbleResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MovieScrobblePostResponseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieScrobbleResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
                movieScrobbleResponse.Should().BeNull();
            }
        }
    }
}
