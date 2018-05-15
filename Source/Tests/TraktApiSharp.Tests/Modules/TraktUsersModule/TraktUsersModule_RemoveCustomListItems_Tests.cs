namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Users.CustomListItems;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Implementations;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string REMOVE_CUSTOM_LIST_ITEMS_URI = $"users/{USERNAME}/lists/{LIST_ID}/items/remove";

        [Fact]
        public async Task Test_TraktUsersModule_RemoveCustomListItems()
        {
            string postJson = await TestUtility.SerializeObject(RemoveCustomListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, postJson,
                                                                CUSTOM_LIST_ITEMS_REMOVE_POST_RESPONSE_JSON);

            TraktResponse<ITraktUserCustomListItemsRemovePostResponse> response =
                await client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserCustomListItemsRemovePostResponse responseValue = response.Value;

            responseValue.Deleted.Should().NotBeNull();
            responseValue.Deleted.Movies.Should().Be(1);
            responseValue.Deleted.Shows.Should().Be(1);
            responseValue.Deleted.Seasons.Should().Be(1);
            responseValue.Deleted.Episodes.Should().Be(2);
            responseValue.Deleted.People.Should().Be(1);

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
            responseValue.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
            responseValue.NotFound.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktListNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_RemoveCustomListItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktUsersModule_RemoveCustomListItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(RemoveCustomListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_CUSTOM_LIST_ITEMS_URI, postJson,
                                                                CUSTOM_LIST_ITEMS_REMOVE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>>> act = () => client.Users.RemoveCustomListItemsAsync(null, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.RemoveCustomListItemsAsync(string.Empty, LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.RemoveCustomListItemsAsync("user name", LIST_ID, RemoveCustomListItemsPost);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, null, RemoveCustomListItemsPost);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, string.Empty, RemoveCustomListItemsPost);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, "list id", RemoveCustomListItemsPost);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, new TraktUserCustomListItemsPost());
            act.Should().Throw<ArgumentException>();

            ITraktUserCustomListItemsPost customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<ITraktUserCustomListItemsPostMovie>(),
                Shows = new List<ITraktUserCustomListItemsPostShow>(),
                People = new List<ITraktPerson>()
            };

            act = () => client.Users.RemoveCustomListItemsAsync(USERNAME, LIST_ID, customListItems);
            act.Should().Throw<ArgumentException>();
        }
    }
}
