namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class MovieCheckinPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(3373536620UL);
            checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            checkinMovieResponse.Sharing.Should().NotBeNull();
            checkinMovieResponse.Sharing.Facebook.Should().BeTrue();
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

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(0UL);
            checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            checkinMovieResponse.Sharing.Should().NotBeNull();
            checkinMovieResponse.Sharing.Facebook.Should().BeTrue();
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

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(3373536620UL);
            checkinMovieResponse.WatchedAt.Should().BeNull();
            checkinMovieResponse.Sharing.Should().NotBeNull();
            checkinMovieResponse.Sharing.Facebook.Should().BeTrue();
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

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

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

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(3373536620UL);
            checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            checkinMovieResponse.Sharing.Should().NotBeNull();
            checkinMovieResponse.Sharing.Facebook.Should().BeTrue();
            checkinMovieResponse.Sharing.Twitter.Should().BeTrue();
            checkinMovieResponse.Sharing.Google.Should().BeTrue();
            checkinMovieResponse.Sharing.Tumblr.Should().BeTrue();
            checkinMovieResponse.Sharing.Medium.Should().BeTrue();
            checkinMovieResponse.Sharing.Slack.Should().BeTrue();
            checkinMovieResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(3373536620UL);
            checkinMovieResponse.WatchedAt.Should().BeNull();
            checkinMovieResponse.Sharing.Should().BeNull();
            checkinMovieResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(0UL);
            checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            checkinMovieResponse.Sharing.Should().BeNull();
            checkinMovieResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(0UL);
            checkinMovieResponse.WatchedAt.Should().BeNull();
            checkinMovieResponse.Sharing.Should().NotBeNull();
            checkinMovieResponse.Sharing.Facebook.Should().BeTrue();
            checkinMovieResponse.Sharing.Twitter.Should().BeTrue();
            checkinMovieResponse.Sharing.Google.Should().BeTrue();
            checkinMovieResponse.Sharing.Tumblr.Should().BeTrue();
            checkinMovieResponse.Sharing.Medium.Should().BeTrue();
            checkinMovieResponse.Sharing.Slack.Should().BeTrue();
            checkinMovieResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

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

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(0UL);
            checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            checkinMovieResponse.Sharing.Should().NotBeNull();
            checkinMovieResponse.Sharing.Facebook.Should().BeTrue();
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

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(3373536620UL);
            checkinMovieResponse.WatchedAt.Should().BeNull();
            checkinMovieResponse.Sharing.Should().NotBeNull();
            checkinMovieResponse.Sharing.Facebook.Should().BeTrue();
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

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

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

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(3373536620UL);
            checkinMovieResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            checkinMovieResponse.Sharing.Should().NotBeNull();
            checkinMovieResponse.Sharing.Facebook.Should().BeTrue();
            checkinMovieResponse.Sharing.Twitter.Should().BeTrue();
            checkinMovieResponse.Sharing.Google.Should().BeTrue();
            checkinMovieResponse.Sharing.Tumblr.Should().BeTrue();
            checkinMovieResponse.Sharing.Medium.Should().BeTrue();
            checkinMovieResponse.Sharing.Slack.Should().BeTrue();
            checkinMovieResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            checkinMovieResponse.Should().NotBeNull();
            checkinMovieResponse.Id.Should().Be(0UL);
            checkinMovieResponse.WatchedAt.Should().BeNull();
            checkinMovieResponse.Sharing.Should().BeNull();
            checkinMovieResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(default(string));
            checkinMovieResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieCheckinPostResponseObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MovieCheckinPostResponseObjectJsonReader();

            var checkinMovieResponse = await jsonReader.ReadObjectAsync(string.Empty);
            checkinMovieResponse.Should().BeNull();
        }
    }
}
