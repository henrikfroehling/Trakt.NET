namespace TraktNet.Objects.Post.Tests.Checkins.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Checkins.Responses;
    using TraktNet.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class MovieCheckinPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(3373536620UL);
                checkinMovieResponse.WatchedAt.Should().BeNull();
                checkinMovieResponse.Sharing.Should().BeNull();
                checkinMovieResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(0UL);
                checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinMovieResponse.Sharing.Should().BeNull();
                checkinMovieResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);

                checkinMovieResponse.Should().NotBeNull();
                checkinMovieResponse.Id.Should().Be(0UL);
                checkinMovieResponse.WatchedAt.Should().BeNull();
                checkinMovieResponse.Sharing.Should().BeNull();
                checkinMovieResponse.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();
            Func<Task<ITraktMovieCheckinPostResponse>> checkinMovieResponse = () => jsonReader.ReadObjectAsync(default(Stream));
            await checkinMovieResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var checkinMovieResponse = await jsonReader.ReadObjectAsync(stream);
                checkinMovieResponse.Should().BeNull();
            }
        }
    }
}
