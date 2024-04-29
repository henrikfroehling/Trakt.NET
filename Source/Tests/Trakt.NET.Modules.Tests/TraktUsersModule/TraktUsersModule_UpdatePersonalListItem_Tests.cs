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
        private readonly string UPDATE_PERSONAL_LIST_ITEM_URI = $"users/{USERNAME}/lists/{LIST_ID}/items/{LIST_ITEM_ID}";
        private const string NOTES = "This is a great movie!";

        [Fact]
        public async Task Test_TraktUsersModule_UpdatePersonalListItem()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_PERSONAL_LIST_ITEM_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.UpdatePersonalListItemAsync(USERNAME, LIST_ID, LIST_ITEM_ID, NOTES);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdatePersonalListItem_With_TraktID()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/items/{LIST_ITEM_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.UpdatePersonalListItemAsync(USERNAME, TRAKT_LIST_ID, LIST_ITEM_ID, NOTES);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdatePersonalListItem_With_ListIds_TraktID()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/items/{LIST_ITEM_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.UpdatePersonalListItemAsync(USERNAME, listIds, LIST_ITEM_ID, NOTES);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdatePersonalListItem_With_ListIds_Slug()
        {
            var listIds = new TraktListIds
            {
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{LIST_SLUG}/items/{LIST_ITEM_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.UpdatePersonalListItemAsync(USERNAME, listIds, LIST_ITEM_ID, NOTES);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdatePersonalListItem_With_ListIds()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID,
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/items/{LIST_ITEM_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.UpdatePersonalListItemAsync(USERNAME, listIds, LIST_ITEM_ID, NOTES);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdatePersonalListItem_With_List()
        {
            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = TRAKT_LIST_ID,
                    Slug = LIST_SLUG
                }
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/items/{LIST_ITEM_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.UpdatePersonalListItemAsync(USERNAME, list, LIST_ITEM_ID, NOTES);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
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
        public async Task Test_TraktUsersModule_UpdatePersonalListItem_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_PERSONAL_LIST_ITEM_URI, statusCode);

            try
            {
                await client.Users.UpdatePersonalListItemAsync(USERNAME, LIST_ID, LIST_ITEM_ID, NOTES);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdatePersonalListItem_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_PERSONAL_LIST_ITEM_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Users.UpdatePersonalListItemAsync(USERNAME, default(ITraktListIds), LIST_ITEM_ID, NOTES);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListItemAsync(USERNAME, default(ITraktList), LIST_ITEM_ID, NOTES);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListItemAsync(USERNAME, new TraktListIds(), LIST_ITEM_ID, NOTES);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.UpdatePersonalListItemAsync(USERNAME, 0, LIST_ITEM_ID, NOTES);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
