namespace TraktNet.Modules.Tests.TraktCheckinsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Checkins;
    using TraktNet.Objects.Post.Checkins.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Checkins")]
    public partial class TraktCheckinsModule_Tests
    {
        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie()
        {
            ITraktMovieCheckinPost movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = Movie
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);
            TraktResponse<ITraktMovieCheckinPostResponse> response = await client.Checkins.CheckIntoMovieAsync(Movie);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppVersion()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppVersion = APP_VERSION
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);
            TraktResponse<ITraktMovieCheckinPostResponse> response = await client.Checkins.CheckIntoMovieAsync(Movie, APP_VERSION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppVersion_And_AppDate()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppVersion_And_Message()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppVersion = APP_VERSION,
                Message = MESSAGE
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, APP_VERSION, null, MESSAGE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppVersion_And_Sharing()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppVersion = APP_VERSION,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, APP_VERSION, null, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppVersion_And_FoursquareVenueId()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppVersion = APP_VERSION,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, APP_VERSION, null, null, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppVersion_And_FoursquareVenueName()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppVersion = APP_VERSION,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, APP_VERSION, null, null, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppDate()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppDate_And_Message()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                Message = MESSAGE
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, APP_BUILD_DATE, MESSAGE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppDate_And_Sharing()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, APP_BUILD_DATE, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppDate_And_FoursquareVenueId()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, APP_BUILD_DATE, null, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_AppDate_And_FoursquareVenueName()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, APP_BUILD_DATE, null, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_Message()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                Message = MESSAGE
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, MESSAGE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_Message_And_Sharing()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                Message = MESSAGE,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, MESSAGE, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_Message_And_FoursquareVenueId()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                Message = MESSAGE,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, MESSAGE, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_Message_And_FoursquareVenueName()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                Message = MESSAGE,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, MESSAGE, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_Sharing()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_Sharing_And_FoursquareVenueId()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                Sharing = SHARING,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, null, SHARING, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_Sharing_And_FoursquareVenueName()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                Sharing = SHARING,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, null, SHARING, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_FoursquareVenueId()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, null, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_FoursquareVenueId_And_FoursquareVenueName()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                FoursquareVenueId = FOURSQUARE_VENUE_ID,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, null, null,
                                                          FOURSQUARE_VENUE_ID, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_With_FoursquareVenueName()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, null, null, null, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_Complete()
        {
            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = Movie,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToString("yyyy-MM-dd"),
                Message = MESSAGE,
                Sharing = SHARING,
                FoursquareVenueId = FOURSQUARE_VENUE_ID,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieCheckinPostResponse> response =
                await client.Checkins.CheckIntoMovieAsync(Movie, APP_VERSION, APP_BUILD_DATE, MESSAGE, SHARING,
                                                          FOURSQUARE_VENUE_ID, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536619);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, statusCode);

            try
            {
                await client.Checkins.CheckIntoMovieAsync(Movie);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoMovie_ArgumentExceptions()
        {
            ITraktMovie movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            ITraktMovieCheckinPost movieCheckinPost  = new TraktMovieCheckinPost
            {
                Movie = movie
            };

            string postJson = await TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, MOVIE_CHECKIN_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktMovieCheckinPostResponse>>> act = () => client.Checkins.CheckIntoMovieAsync(null);
            act.Should().Throw<ArgumentNullException>();

            movie.Year = 0;

            act = () => client.Checkins.CheckIntoMovieAsync(movie);
            act.Should().Throw<ArgumentOutOfRangeException>();

            movie.Year = 123;

            act = () => client.Checkins.CheckIntoMovieAsync(movie);
            act.Should().Throw<ArgumentOutOfRangeException>();

            movie.Year = 12345;

            act = () => client.Checkins.CheckIntoMovieAsync(movie);
            act.Should().Throw<ArgumentOutOfRangeException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = () => client.Checkins.CheckIntoMovieAsync(movie);
            act.Should().Throw<ArgumentNullException>();

            movie.Ids = new TraktMovieIds();

            act = () => client.Checkins.CheckIntoMovieAsync(movie);
            act.Should().Throw<ArgumentException>();
        }
    }
}
