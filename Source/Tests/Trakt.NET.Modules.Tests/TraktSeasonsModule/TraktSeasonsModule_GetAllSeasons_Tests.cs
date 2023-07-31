namespace TraktNet.Modules.Tests.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_ALL_SEASONS_URI = $"shows/{SHOW_ID}/seasons";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, SEASONS_ALL_FULL_JSON);
            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons", SEASONS_ALL_FULL_JSON);
            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(TRAKT_SHOD_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_ShowIds_TraktID()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons", SEASONS_ALL_FULL_JSON);
            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_ShowIds_Slug()
        {
            var showIds = new TraktShowIds
            {
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{SHOW_SLUG}/seasons", SEASONS_ALL_FULL_JSON);
            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_ShowIds()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID,
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons", SEASONS_ALL_FULL_JSON);
            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_Show()
        {
            var show = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = TRAKT_SHOD_ID,
                    Slug = SHOW_SLUG
                }
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons", SEASONS_ALL_FULL_JSON);
            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(show);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASONS_URI}?extended={EXTENDED_INFO}",
                                                           SEASONS_ALL_FULL_JSON);

            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(SHOW_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_Translations()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASONS_URI}?translations={TRANSLATION_LANGUAGE_CODE}",
                                                           SEASONS_ALL_FULL_JSON);

            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(SHOW_ID, null, TRANSLATION_LANGUAGE_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_ExtendedInfo_And_Translations()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASONS_URI}?extended={EXTENDED_INFO}&translations={TRANSLATION_LANGUAGE_CODE}",
                                                           SEASONS_ALL_FULL_JSON);

            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(SHOW_ID, EXTENDED_INFO, TRANSLATION_LANGUAGE_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_All_Translations()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASONS_URI}?translations=all",
                                                           SEASONS_ALL_FULL_JSON);

            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(SHOW_ID, null, "all");

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_With_ExtendedInfo_And_All_Translations()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASONS_URI}?extended={EXTENDED_INFO}&translations=all",
                                                           SEASONS_ALL_FULL_JSON);

            TraktListResponse<ITraktSeason> response = await client.Seasons.GetAllSeasonsAsync(SHOW_ID, EXTENDED_INFO, "all");

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktShowNotFoundException))]
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
        public async Task Test_TraktSeasonsModule_GetAllSeasons_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, statusCode);

            try
            {
                await client.Seasons.GetAllSeasonsAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetAllSeasons_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, SEASONS_ALL_FULL_JSON);

            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(default(ITraktShowIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetAllSeasonsAsync(default(ITraktShow));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetAllSeasonsAsync(new TraktShowIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetAllSeasonsAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
