namespace TraktNet.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Users.CustomListItems;
    using TraktNet.Objects.Post.Users.CustomListItems.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string ADD_CUSTOM_LIST_ITEMS_URI = $"users/{USERNAME}/lists/{LIST_ID}/items";

        [Fact]
        public async Task Test_TraktUsersModule_AddCustomListItems()
        {
            string postJson = await TestUtility.SerializeObject(AddCustomListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(
                ADD_CUSTOM_LIST_ITEMS_URI, postJson, CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON);

            TraktResponse<ITraktUserCustomListItemsPostResponse> response =
                await client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserCustomListItemsPostResponse responseValue = response.Value;

            responseValue.Added.Should().NotBeNull();
            responseValue.Added.Movies.Should().Be(1);
            responseValue.Added.Shows.Should().Be(1);
            responseValue.Added.Seasons.Should().Be(1);
            responseValue.Added.Episodes.Should().Be(2);
            responseValue.Added.People.Should().Be(1);

            responseValue.Existing.Should().NotBeNull();
            responseValue.Existing.Movies.Should().Be(0);
            responseValue.Existing.Shows.Should().Be(0);
            responseValue.Existing.Seasons.Should().Be(0);
            responseValue.Existing.Episodes.Should().Be(0);
            responseValue.Existing.People.Should().Be(0);

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
        public void Test_TraktUsersModule_AddCustomListItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktListNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_AddCustomListItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktUsersModule_AddCustomListItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(AddCustomListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, postJson, CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktUserCustomListItemsPostResponse>>> act =
                () => client.Users.AddCustomListItemsAsync(null, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.AddCustomListItemsAsync(string.Empty, LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.AddCustomListItemsAsync("user name", LIST_ID, AddCustomListItemsPost);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.AddCustomListItemsAsync(USERNAME, null, AddCustomListItemsPost);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.AddCustomListItemsAsync(USERNAME, string.Empty, AddCustomListItemsPost);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.AddCustomListItemsAsync(USERNAME, "list id", AddCustomListItemsPost);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, new TraktUserCustomListItemsPost());
            act.Should().Throw<ArgumentException>();

            ITraktUserCustomListItemsPost customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<ITraktUserCustomListItemsPostMovie>(),
                Shows = new List<ITraktUserCustomListItemsPostShow>(),
                People = new List<ITraktPerson>()
            };

            act = () => client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, customListItems);
            act.Should().Throw<ArgumentException>();
        }
    }
}
