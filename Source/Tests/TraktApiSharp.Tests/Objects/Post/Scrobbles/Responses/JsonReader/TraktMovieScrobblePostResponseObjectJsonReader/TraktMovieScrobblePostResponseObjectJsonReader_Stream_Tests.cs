namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Comments.Responses.JsonReader")]
    public partial class TraktMovieScrobblePostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
                movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
                movieScrobbleResponse.Sharing.Google.Should().BeTrue();
                movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
                movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
                movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
                movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
                movieScrobbleResponse.Sharing.Google.Should().BeTrue();
                movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
                movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
                movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(3373536623UL);
                movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
                movieScrobbleResponse.Progress.Should().Be(85.9f);
                movieScrobbleResponse.Sharing.Should().NotBeNull();
                movieScrobbleResponse.Sharing.Facebook.Should().BeTrue();
                movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
                movieScrobbleResponse.Sharing.Google.Should().BeTrue();
                movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
                movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
                movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);

                movieScrobbleResponse.Should().NotBeNull();
                movieScrobbleResponse.Id.Should().Be(0UL);
                movieScrobbleResponse.Action.Should().BeNull();
                movieScrobbleResponse.Progress.Should().BeNull();
                movieScrobbleResponse.Sharing.Should().BeNull();
                movieScrobbleResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(default(Stream));
            movieScrobbleResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieScrobblePostResponseObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktMovieScrobblePostResponseObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var movieScrobbleResponse = await jsonReader.ReadObjectAsync(stream);
                movieScrobbleResponse.Should().BeNull();
            }
        }
    }
}
