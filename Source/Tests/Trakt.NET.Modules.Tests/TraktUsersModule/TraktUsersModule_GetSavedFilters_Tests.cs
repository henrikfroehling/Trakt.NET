namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private const string GET_SAVED_FILTERS_URI = "users/saved_filters";

        [Fact]
        public async Task Test_TraktUsersModule_GetSavedFilters()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SAVED_FILTERS_URI,
                SAVED_FILTERS_JSON, 1, 10, 1, SAVED_FILTERS_COUNT);

            TraktPagedResponse<ITraktUserSavedFilter> response = await client.Users.GetSavedFiltersAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(SAVED_FILTERS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(SAVED_FILTERS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetSavedFilters_With_Section()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SAVED_FILTERS_URI}?section={FILTER_SECTION.UriName}",
                SAVED_FILTERS_JSON, 1, 10, 1, SAVED_FILTERS_COUNT);

            TraktPagedResponse<ITraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FILTER_SECTION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(SAVED_FILTERS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(SAVED_FILTERS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetSavedFilters_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SAVED_FILTERS_URI}?page={PAGE}",
                SAVED_FILTERS_JSON, PAGE, 10, 1, SAVED_FILTERS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(SAVED_FILTERS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(SAVED_FILTERS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetSavedFilters_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SAVED_FILTERS_URI}?limit={SAVED_FILTERS_LIMIT}",
                SAVED_FILTERS_JSON, 1, SAVED_FILTERS_LIMIT, 1, SAVED_FILTERS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, SAVED_FILTERS_LIMIT);

            TraktPagedResponse<ITraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(SAVED_FILTERS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(SAVED_FILTERS_COUNT);
            response.Limit.Should().Be(SAVED_FILTERS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetSavedFilters_With_Section_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SAVED_FILTERS_URI}?section={FILTER_SECTION.UriName}&page={PAGE}",
                SAVED_FILTERS_JSON, PAGE, 10, 1, SAVED_FILTERS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FILTER_SECTION, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(SAVED_FILTERS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(SAVED_FILTERS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetSavedFilters_With_Section_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SAVED_FILTERS_URI}?section={FILTER_SECTION.UriName}&limit={SAVED_FILTERS_LIMIT}",
                SAVED_FILTERS_JSON, 1, SAVED_FILTERS_LIMIT, 1, SAVED_FILTERS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, SAVED_FILTERS_LIMIT);

            TraktPagedResponse<ITraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FILTER_SECTION, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(SAVED_FILTERS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(SAVED_FILTERS_COUNT);
            response.Limit.Should().Be(SAVED_FILTERS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetSavedFilters_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SAVED_FILTERS_URI}?section={FILTER_SECTION.UriName}" +
                $"&page={PAGE}&limit={SAVED_FILTERS_LIMIT}",
                SAVED_FILTERS_JSON, PAGE, SAVED_FILTERS_LIMIT, 1, SAVED_FILTERS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, SAVED_FILTERS_LIMIT);

            TraktPagedResponse<ITraktUserSavedFilter> response =
                await client.Users.GetSavedFiltersAsync(FILTER_SECTION, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(SAVED_FILTERS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(SAVED_FILTERS_COUNT);
            response.Limit.Should().Be(SAVED_FILTERS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
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
        [InlineData((HttpStatusCode)426, typeof(TraktFailedVIPValidationException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktUsersModule_GetSavedFilters_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SAVED_FILTERS_URI, statusCode);

            try
            {
                await client.Users.GetSavedFiltersAsync(FILTER_SECTION);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
