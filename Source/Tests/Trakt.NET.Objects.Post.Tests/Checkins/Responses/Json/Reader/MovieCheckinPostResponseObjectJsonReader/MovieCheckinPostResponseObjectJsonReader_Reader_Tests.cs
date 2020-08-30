namespace TraktNet.Objects.Post.Tests.Checkins.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Checkins.Responses;
    using TraktNet.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class MovieCheckinPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(3373536620UL);
                checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinMovieResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(0UL);
                checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinMovieResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(3373536620UL);
                checkinMovieResponse.WatchedAt.Should().BeNull();
                checkinMovieResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(3373536620UL);
                checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinMovieResponse.Sharing.Should().BeNull();
                checkinMovieResponse.Movie.Should().NotBeNull();
                checkinMovieResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                checkinMovieResponse.Movie.Year.Should().Be(2015);
                checkinMovieResponse.Movie.Ids.Should().NotBeNull();
                checkinMovieResponse.Movie.Ids.Trakt.Should().Be(94024U);
                checkinMovieResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                checkinMovieResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
                checkinMovieResponse.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(3373536620UL);
                checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinMovieResponse.Sharing.Should().NotBeNull();
                checkinMovieResponse.Sharing.Twitter.Should().BeTrue();
                checkinMovieResponse.Sharing.Google.Should().BeTrue();
                checkinMovieResponse.Sharing.Tumblr.Should().BeTrue();
                checkinMovieResponse.Sharing.Medium.Should().BeTrue();
                checkinMovieResponse.Sharing.Slack.Should().BeTrue();
                checkinMovieResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(3373536620UL);
                checkinMovieResponse.WatchedAt.Should().BeNull();
                checkinMovieResponse.Sharing.Should().BeNull();
                checkinMovieResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(0UL);
                checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinMovieResponse.Sharing.Should().BeNull();
                checkinMovieResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(0UL);
                checkinMovieResponse.WatchedAt.Should().BeNull();
                checkinMovieResponse.Sharing.Should().NotBeNull();
                checkinMovieResponse.Sharing.Twitter.Should().BeTrue();
                checkinMovieResponse.Sharing.Google.Should().BeTrue();
                checkinMovieResponse.Sharing.Tumblr.Should().BeTrue();
                checkinMovieResponse.Sharing.Medium.Should().BeTrue();
                checkinMovieResponse.Sharing.Slack.Should().BeTrue();
                checkinMovieResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(0UL);
                checkinMovieResponse.WatchedAt.Should().BeNull();
                checkinMovieResponse.Sharing.Should().BeNull();
                checkinMovieResponse.Movie.Should().NotBeNull();
                checkinMovieResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                checkinMovieResponse.Movie.Year.Should().Be(2015);
                checkinMovieResponse.Movie.Ids.Should().NotBeNull();
                checkinMovieResponse.Movie.Ids.Trakt.Should().Be(94024U);
                checkinMovieResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                checkinMovieResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
                checkinMovieResponse.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(0UL);
                checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinMovieResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(3373536620UL);
                checkinMovieResponse.WatchedAt.Should().BeNull();
                checkinMovieResponse.Sharing.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(3373536620UL);
                checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinMovieResponse.Sharing.Should().BeNull();
                checkinMovieResponse.Movie.Should().NotBeNull();
                checkinMovieResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                checkinMovieResponse.Movie.Year.Should().Be(2015);
                checkinMovieResponse.Movie.Ids.Should().NotBeNull();
                checkinMovieResponse.Movie.Ids.Trakt.Should().Be(94024U);
                checkinMovieResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                checkinMovieResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
                checkinMovieResponse.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(3373536620UL);
                checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinMovieResponse.Sharing.Should().NotBeNull();
                checkinMovieResponse.Sharing.Twitter.Should().BeTrue();
                checkinMovieResponse.Sharing.Google.Should().BeTrue();
                checkinMovieResponse.Sharing.Tumblr.Should().BeTrue();
                checkinMovieResponse.Sharing.Medium.Should().BeTrue();
                checkinMovieResponse.Sharing.Slack.Should().BeTrue();
                checkinMovieResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(0UL);
                checkinMovieResponse.WatchedAt.Should().BeNull();
                checkinMovieResponse.Sharing.Should().BeNull();
                checkinMovieResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();
            Func<Task<ITraktMovieCheckinPostResponse>> checkinMovieResponse = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            checkinMovieResponse.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinMovieResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
                checkinMovieResponse.Should().BeNull();
            }
        }
    }
}
