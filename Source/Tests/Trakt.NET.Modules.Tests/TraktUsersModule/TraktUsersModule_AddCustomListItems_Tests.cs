namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
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
        public async Task Test_TraktUsersModule_AddCustomListItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_CUSTOM_LIST_ITEMS_URI, statusCode);

            try
            {
                await client.Users.AddCustomListItemsAsync(USERNAME, LIST_ID, AddCustomListItemsPost);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
