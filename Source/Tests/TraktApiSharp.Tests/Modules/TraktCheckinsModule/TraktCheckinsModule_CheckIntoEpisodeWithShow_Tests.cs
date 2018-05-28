namespace TraktApiSharp.Tests.Modules.TraktCheckinsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Post.Checkins;
    using TraktApiSharp.Objects.Post.Checkins.Implementations;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Checkins")]
    public partial class TraktCheckinsModule_Tests
    {
        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppVersion()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppVersion = APP_VERSION
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, APP_VERSION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppVersion_And_AppDate()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppVersion_And_Message()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppVersion = APP_VERSION,
                Message = MESSAGE
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, APP_VERSION, null, MESSAGE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppVersion_And_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppVersion = APP_VERSION,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, APP_VERSION, null, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppVersion_And_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppVersion = APP_VERSION,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, APP_VERSION, null,
                                                                    null, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppVersion_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppVersion = APP_VERSION,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, APP_VERSION, null,
                                                                    null, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppDate()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppDate_And_Message()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                Message = MESSAGE
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, APP_BUILD_DATE, MESSAGE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppDate_And_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, APP_BUILD_DATE, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppDate_And_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, APP_BUILD_DATE,
                                                                    null, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_AppDate_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                AppDate = APP_BUILD_DATE.ToTraktDateString(),
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, APP_BUILD_DATE,
                                                                    null, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_Message()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                Message = MESSAGE
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null, MESSAGE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_Message_And_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                Message = MESSAGE,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null, MESSAGE, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_Message_And_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                Message = MESSAGE,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null,
                                                                    MESSAGE, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_Message_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                Message = MESSAGE,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null,
                                                                    MESSAGE, null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_Sharing_And_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                Sharing = SHARING,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null, null,
                                                                    SHARING, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_Sharing_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                Sharing = SHARING,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null, null,
                                                                    SHARING, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                FoursquareVenueId = FOURSQUARE_VENUE_ID
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null, null, null, FOURSQUARE_VENUE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_FoursquareVenueId_And_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                FoursquareVenueId = FOURSQUARE_VENUE_ID,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null, null,
                                                                    null, FOURSQUARE_VENUE_ID, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_With_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
                FoursquareVenueName = FOURSQUARE_VENUE_NAME
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeCheckinPostResponse> response =
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, null, null, null,
                                                                    null, null, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Complete()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = Episode,
                Show = Show,
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
                await client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show, APP_VERSION, APP_BUILD_DATE, MESSAGE,
                                                                    SHARING, FOURSQUARE_VENUE_ID, FOURSQUARE_VENUE_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeCheckinPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536620);
            responseValue.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
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
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktCheckinException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(Episode, Show);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktCheckinsModule_CheckIntoEpisodeWithShow_ArgumentExceptions()
        {
            ITraktEpisode episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1
            };

            ITraktShow show = new TraktShow
            {
                Title = "Breaking Bad"
            };

            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show
            };

            string postJson = await TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, postJson, EPISODE_CHECKIN_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktEpisodeCheckinPostResponse>>> act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(null, show);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(episode, null);
            act.Should().Throw<ArgumentNullException>();

            episode.Number = -1;

            act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(episode, show);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Number = 1;
            episode.SeasonNumber = -1;

            act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(episode, show);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.SeasonNumber = 1;
            show.Title = string.Empty;

            act = () => client.Checkins.CheckIntoEpisodeWithShowAsync(episode, show);
            act.Should().Throw<ArgumentException>();
        }
    }
}
