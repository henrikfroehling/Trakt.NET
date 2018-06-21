namespace TraktNet.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Modules;
    using TraktNet.Objects.Get.Users.Lists;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_CUSTOM_LIST_URI = $"users/{USERNAME}/lists/{LIST_ID}";

        [Fact]
        public async Task Test_TraktUsersModule_GetCustomList()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, LIST_JSON);
            TraktResponse<ITraktList> response = await client.Users.GetCustomListAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCustomList_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_CUSTOM_LIST_URI, LIST_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktResponse<ITraktList> response = await client.Users.GetCustomListAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktListNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomList_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, LIST_JSON);

            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetCustomListAsync(null, LIST_ID);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetCustomListAsync(string.Empty, LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCustomListAsync("user name", LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCustomListAsync(USERNAME, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetCustomListAsync(USERNAME, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCustomListAsync(USERNAME, "list id");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetMultipleCustomLists_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_URI, LIST_JSON);

            Func<Task<IEnumerable<TraktResponse<ITraktList>>>> act = () => client.Users.GetMultipleCustomListsAsync(null);
            act.Should().NotThrow();

            act = () => client.Users.GetMultipleCustomListsAsync(new TraktMultipleUserListsQueryParams());
            act.Should().NotThrow();

            act = () => client.Users.GetMultipleCustomListsAsync(new TraktMultipleUserListsQueryParams { { null, LIST_ID } });
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetMultipleCustomListsAsync(new TraktMultipleUserListsQueryParams { { string.Empty, LIST_ID } });
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetMultipleCustomListsAsync(new TraktMultipleUserListsQueryParams { { "user name", LIST_ID } });
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetMultipleCustomListsAsync(new TraktMultipleUserListsQueryParams { { USERNAME, null } });
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetMultipleCustomListsAsync(new TraktMultipleUserListsQueryParams { { USERNAME, string.Empty } });
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetMultipleCustomListsAsync(new TraktMultipleUserListsQueryParams { { USERNAME, "list id" } });
            act.Should().Throw<ArgumentException>();
        }
    }
}
