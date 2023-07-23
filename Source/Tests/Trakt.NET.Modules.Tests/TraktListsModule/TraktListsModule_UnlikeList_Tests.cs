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
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Lists")]
    public partial class TraktListsModule_Tests
    {
        private readonly string UNLIKE_LIST_URI = $"lists/{LIST_ID}/like";

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNLIKE_LIST_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList_With_TraktID()
        {
            const uint traktID = 55;

            TraktClient client = TestUtility.GetOAuthMockClient($"lists/{traktID}/like", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(traktID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList_With_ListIds_TraktID()
        {
            const uint traktID = 55;

            var listIds = new TraktListIds
            {
                Trakt = traktID
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"lists/{traktID}/like", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList_With_ListIds_Slug()
        {
            const string listSlug = "incredible-thoughts";

            var listIds = new TraktListIds
            {
                Slug = listSlug
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"lists/{listSlug}/like", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList_With_ListIds()
        {
            const uint traktID = 55;
            const string listSlug = "incredible-thoughts";

            var listIds = new TraktListIds
            {
                Trakt = traktID,
                Slug = listSlug
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"lists/{traktID}/like", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(listIds);

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
        public async Task Test_TraktListsModule_UnlikeList_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNLIKE_LIST_URI, statusCode);

            try
            {
                await client.Lists.UnlikeListAsync(LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNLIKE_LIST_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Lists.UnlikeListAsync(default(ITraktListIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Lists.UnlikeListAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
