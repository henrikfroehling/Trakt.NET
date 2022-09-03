namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Modules;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_PERSONAL_LIST_URI = $"users/{USERNAME}/lists/{LIST_ID}";

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalList()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSONAL_LIST_URI, LIST_JSON);
            TraktResponse<ITraktList> response = await client.Users.GetPersonalListAsync(USERNAME, LIST_ID);

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
        public async Task Test_TraktUsersModule_GetPersonalList_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PERSONAL_LIST_URI, LIST_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktResponse<ITraktList> response = await client.Users.GetPersonalListAsync(USERNAME, LIST_ID);

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
        public async Task Test_TraktUsersModule_GetPersonalList_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSONAL_LIST_URI, statusCode);

            try
            {
                await client.Users.GetPersonalListAsync(USERNAME, LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalList_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSONAL_LIST_URI, LIST_JSON);

            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.GetPersonalListAsync(null, LIST_ID);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetPersonalListAsync(string.Empty, LIST_ID);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetPersonalListAsync("user name", LIST_ID);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetPersonalListAsync(USERNAME, null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetPersonalListAsync(USERNAME, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetPersonalListAsync(USERNAME, "list id");
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetMultipleCustomLists_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSONAL_LIST_URI, LIST_JSON);

            Func<Task<IEnumerable<TraktResponse<ITraktList>>>> act = () => client.Users.GetMultiplePersonalListsAsync(null);
            await act.Should().NotThrowAsync();

            act = () => client.Users.GetMultiplePersonalListsAsync(new TraktMultipleUserListsQueryParams());
            await act.Should().NotThrowAsync();

            act = () => client.Users.GetMultiplePersonalListsAsync(new TraktMultipleUserListsQueryParams { { null, LIST_ID } });
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetMultiplePersonalListsAsync(new TraktMultipleUserListsQueryParams { { string.Empty, LIST_ID } });
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetMultiplePersonalListsAsync(new TraktMultipleUserListsQueryParams { { "user name", LIST_ID } });
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetMultiplePersonalListsAsync(new TraktMultipleUserListsQueryParams { { USERNAME, null } });
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetMultiplePersonalListsAsync(new TraktMultipleUserListsQueryParams { { USERNAME, string.Empty } });
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetMultiplePersonalListsAsync(new TraktMultipleUserListsQueryParams { { USERNAME, "list id" } });
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
