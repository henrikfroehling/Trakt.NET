namespace TraktNet.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Users.HiddenItems.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        [Fact]
        public async Task Test_TraktUsersModule_RemoveHiddenItems()
        {
            string postJson = await TestUtility.SerializeObject(HiddenItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(
                RemoveHiddenItemsUri, postJson, HIDDEN_ITEMS_REMOVE_POST_RESPONSE_JSON);

            TraktResponse<ITraktUserHiddenItemsRemovePostResponse> response =
                await client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserHiddenItemsRemovePostResponse responseValue = response.Value;

            responseValue.Deleted.Should().NotBeNull();
            responseValue.Deleted.Movies.Should().Be(1);
            responseValue.Deleted.Shows.Should().Be(2);
            responseValue.Deleted.Seasons.Should().Be(2);

            responseValue.NotFound.Should().NotBeNull();
            responseValue.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktPostResponseNotFoundMovie[] movies = responseValue.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            responseValue.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            responseValue.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveHiddenItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktUsersModule_RemoveHiddenItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(HiddenItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(RemoveHiddenItemsUri, postJson, HIDDEN_ITEMS_REMOVE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsPost, TraktHiddenItemsSection.Unspecified);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.RemoveHiddenItemsAsync(null, HIDDEN_ITEMS_SECTION);
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
