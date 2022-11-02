namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_PERSONAL_LIST_ITEMS_URI = $"users/{USERNAME}/lists/{LIST_ID}/items";

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalListItems()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSONAL_LIST_ITEMS_URI, LIST_ITEMS_JSON);

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalListItems_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PERSONAL_LIST_ITEMS_URI, LIST_ITEMS_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalListItems_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_PERSONAL_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}",
                LIST_ITEMS_JSON);

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(USERNAME, LIST_ID, LIST_ITEM_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalListItems_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_PERSONAL_LIST_ITEMS_URI}?extended={EXTENDED_INFO}",
                LIST_ITEMS_JSON);

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(USERNAME, LIST_ID, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalListItems_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_PERSONAL_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}",
                LIST_ITEMS_JSON);

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(USERNAME, LIST_ID, LIST_ITEM_TYPE, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
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
        public async Task Test_TraktUsersModule_GetPersonalListItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSONAL_LIST_ITEMS_URI, statusCode);

            try
            {
                await client.Users.GetPersonalListItemsAsync(USERNAME, LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
