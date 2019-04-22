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
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
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

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASONS_URI, SEASONS_ALL_FULL_JSON);

            Func<Task<TraktListResponse<ITraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetAllSeasonsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetAllSeasonsAsync("show id");
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID, null, "eng");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID, null, "e");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Seasons.GetAllSeasonsAsync(SHOW_ID, null, "all");
            act.Should().NotThrow();
        }
    }
}
