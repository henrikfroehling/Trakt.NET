namespace TraktNet.Modules.Tests.TraktListsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Lists")]
    public partial class TraktListsModule_Tests
    {
        private readonly string GET_LIST_LIKES_URI = $"lists/{LIST_ID}/likes";

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_LIKES_URI,
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page={PAGE}",
                LIST_LIKES_JSON, PAGE, 10, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?limit={LIMIT}",
                LIST_LIKES_JSON, 1, LIMIT, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page={PAGE}&limit={LIMIT}",
                LIST_LIKES_JSON, PAGE, LIMIT, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktListNotFoundException))]
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
        public async Task Test_TraktListsModule_GetListLikes_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_LIKES_URI, statusCode);

            try
            {
                await client.Lists.GetListLikesAsync(LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
