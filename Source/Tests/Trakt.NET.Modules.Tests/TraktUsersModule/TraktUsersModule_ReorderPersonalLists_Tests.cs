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
        private readonly string REORDER_PERSONAL_LISTS_URI = $"users/{USERNAME}/lists/reorder";

        [Fact]
        public async Task Test_TraktUsersModule_ReorderPersonalLists()
        {
            ITraktListItemsReorderPost personalListsReorderPost = new TraktListItemsReorderPost
            {
                Rank = REORDERED_CUSTOM_LISTS
            };

            string postJson = await TestUtility.SerializeObject(personalListsReorderPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_PERSONAL_LISTS_URI, postJson, CUSTOM_LISTS_REORDER_POST_RESPONSE_JSON);
            TraktResponse<ITraktListItemsReorderPostResponse> response = await client.Users.ReorderPersonalListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktListItemsReorderPostResponse responseValue = response.Value;

            responseValue.Updated.Should().Be(6);
            responseValue.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            responseValue.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
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
        public async Task Test_TraktUsersModule_ReorderPersonalLists_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_PERSONAL_LISTS_URI, statusCode);

            try
            {
                await client.Users.ReorderPersonalListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_ReorderPersonalLists_Exceptions()
        {
            ITraktListItemsReorderPost personalListsReorderPost = new TraktListItemsReorderPost
            {
                Rank = REORDERED_CUSTOM_LISTS
            };

            string postJson = await TestUtility.SerializeObject(personalListsReorderPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_PERSONAL_LISTS_URI, postJson, CUSTOM_LISTS_REORDER_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktListItemsReorderPostResponse>>> act = () => client.Users.ReorderPersonalListsAsync(null, REORDERED_CUSTOM_LISTS);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListsAsync(string.Empty, REORDERED_CUSTOM_LISTS);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListsAsync("user name", REORDERED_CUSTOM_LISTS);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListsAsync(USERNAME, null);
            await act.Should().ThrowAsync<TraktPostValidationException>();
        }
    }
}
