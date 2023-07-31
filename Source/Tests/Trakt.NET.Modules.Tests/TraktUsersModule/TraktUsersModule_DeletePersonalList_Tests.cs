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
        private readonly string DELETE_PERSONAL_LIST_URI = $"users/{USERNAME}/lists/{LIST_ID}";

        [Fact]
        public async Task Test_TraktUsersModule_DeletePersonalList()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(DELETE_PERSONAL_LIST_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.DeletePersonalListAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_DeletePersonalList_With_TraktID()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.DeletePersonalListAsync(USERNAME, TRAKT_LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_DeletePersonalList_With_ListIds_TraktID()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.DeletePersonalListAsync(USERNAME, listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_DeletePersonalList_With_ListIds_Slug()
        {
            var listIds = new TraktListIds
            {
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{LIST_SLUG}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.DeletePersonalListAsync(USERNAME, listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_DeletePersonalList_With_ListIds()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID,
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.DeletePersonalListAsync(USERNAME, listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_DeletePersonalList_With_List()
        {
            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = TRAKT_LIST_ID,
                    Slug = LIST_SLUG
                }
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.DeletePersonalListAsync(USERNAME, list);

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
        public async Task Test_TraktUsersModule_DeletePersonalList_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(DELETE_PERSONAL_LIST_URI, statusCode);

            try
            {
                await client.Users.DeletePersonalListAsync(USERNAME, LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_DeletePersonalList_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(DELETE_PERSONAL_LIST_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Users.DeletePersonalListAsync(USERNAME, default(ITraktListIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.DeletePersonalListAsync(USERNAME, default(ITraktList));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.DeletePersonalListAsync(USERNAME, new TraktListIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.DeletePersonalListAsync(USERNAME, 0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
