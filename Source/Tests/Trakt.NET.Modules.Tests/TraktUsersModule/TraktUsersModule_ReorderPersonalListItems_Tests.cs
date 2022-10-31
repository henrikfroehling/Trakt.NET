namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string REORDER_PERSONAL_LIST_ITEMS_URI = $"users/{USERNAME}/lists/{LIST_ID}/items/reorder";

        [Fact]
        public async Task Test_TraktUsersModule_ReorderPersonalListItems()
        {
            ITraktListItemsReorderPost personalListItemsReorderPost = new TraktListItemsReorderPost
            {
                Rank = REORDERED_CUSTOM_LIST_ITEMS
            };

            string postJson = await TestUtility.SerializeObject(personalListItemsReorderPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_PERSONAL_LIST_ITEMS_URI, postJson, CUSTOM_LIST_ITEMS_REORDER_POST_RESPONSE_JSON);
            TraktResponse<ITraktListItemsReorderPostResponse> response = await client.Users.ReorderPersonalListItemsAsync(USERNAME, LIST_ID, REORDERED_CUSTOM_LIST_ITEMS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktListItemsReorderPostResponse responseValue = response.Value;

            responseValue.Updated.Should().Be(6);
            responseValue.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            responseValue.SkippedIds.Should().BeEquivalentTo(new List<uint> { 12 });
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
        public async Task Test_TraktUsersModule_ReorderPersonalListItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_PERSONAL_LIST_ITEMS_URI, statusCode);

            try
            {
                await client.Users.ReorderPersonalListItemsAsync(USERNAME, LIST_ID, REORDERED_CUSTOM_LIST_ITEMS);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_ReorderPersonalListItems_Exceptions()
        {
            ITraktListItemsReorderPost personalListItemsReorderPost = new TraktListItemsReorderPost
            {
                Rank = REORDERED_CUSTOM_LIST_ITEMS
            };

            string postJson = await TestUtility.SerializeObject(personalListItemsReorderPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_PERSONAL_LIST_ITEMS_URI, postJson, CUSTOM_LIST_ITEMS_REORDER_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktListItemsReorderPostResponse>>> act = () => client.Users.ReorderPersonalListItemsAsync(null, LIST_ID, REORDERED_CUSTOM_LIST_ITEMS);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(string.Empty, LIST_ID, REORDERED_CUSTOM_LIST_ITEMS);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("user name", LIST_ID, REORDERED_CUSTOM_LIST_ITEMS);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("username", null, REORDERED_CUSTOM_LIST_ITEMS);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("username", string.Empty, REORDERED_CUSTOM_LIST_ITEMS);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("username", "list id", REORDERED_CUSTOM_LIST_ITEMS);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(USERNAME, LIST_ID, null);
            await act.Should().ThrowAsync<TraktPostValidationException>();
        }
    }
}
