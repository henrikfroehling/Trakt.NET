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
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Checkins;
    using TraktNet.Objects.Post.Checkins.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Checkins")]
    public partial class TraktCheckinsModule_Tests
    {
        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppVersion()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppVersion = APP_VERSION
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, APP_VERSION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppVersion_And_AppDate()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppVersion_And_Message()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppVersion = APP_VERSION,
                Message = MESSAGE
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, APP_VERSION, null, MESSAGE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppVersion_And_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppVersion = APP_VERSION,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, APP_VERSION, null, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppVersion_And_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppVersion = APP_VERSION,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, APP_VERSION, null, null, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppVersion_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppVersion = APP_VERSION,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, APP_VERSION, null, null, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppDate()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppDate_And_Message()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                Message = MESSAGE
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, APP_BUILD_DATE, MESSAGE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppDate_And_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, APP_BUILD_DATE, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppDate_And_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, APP_BUILD_DATE, null, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_AppDate_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, APP_BUILD_DATE, null, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_Message()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Message = MESSAGE
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, MESSAGE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_Message_And_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Message = MESSAGE,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, MESSAGE, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_Message_And_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Message = MESSAGE,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, MESSAGE, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_Message_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Message = MESSAGE,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, MESSAGE, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_Sharing_And_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Sharing = SHARING,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, null, SHARING, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_Sharing_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Sharing = SHARING,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, null, SHARING, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, null, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_FoursquareVenueId_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                FoursquareVenueId = FOURSQUARE_VENUE_ID,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, null, null, FOURSQUARE_VENUE_ID, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_With_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, null, null, null, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_Complete()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToString("yyyy-MM-dd"),
                Message = MESSAGE,
                Sharing = SHARING,
                FoursquareVenueId = FOURSQUARE_VENUE_ID,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeAsync(Episode, APP_VERSION, APP_BUILD_DATE, MESSAGE, SHARING,
                                                            FOURSQUARE_VENUE_ID, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktCheckinException))]
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
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, statusCode);

            try
            {
                await client.Checkins.CheckIntoEpisodeAsync(Episode);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Checkins.CheckIntoEpisodeAsync(new TraktEpisode());
            await act.Should().ThrowAsync<ArgumentNullException>();

            episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds()
            };

            act = () => client.Checkins.CheckIntoEpisodeAsync(episode);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
