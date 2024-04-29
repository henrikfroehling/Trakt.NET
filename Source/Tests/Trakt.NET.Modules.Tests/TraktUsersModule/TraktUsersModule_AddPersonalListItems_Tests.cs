﻿namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string ADD_PERSONAL_LIST_ITEMS_URI = $"users/{USERNAME}/lists/{LIST_ID}/items";

        [Fact]
        public async Task Test_TraktUsersModule_AddPersonalListItems()
        {
            string postJson = await TestUtility.SerializeObject(AddPersonalListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(
                ADD_PERSONAL_LIST_ITEMS_URI, postJson, CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON);

            TraktResponse<ITraktUserPersonalListItemsPostResponse> response =
                await client.Users.AddPersonalListItemsAsync(USERNAME, LIST_ID, AddPersonalListItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserPersonalListItemsPostResponse responseValue = response.Value;

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
        public async Task Test_TraktUsersModule_AddPersonalListItems_With_TraktID()
        {
            string postJson = await TestUtility.SerializeObject(AddPersonalListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/items",
                postJson, CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON);
            
            TraktResponse<ITraktUserPersonalListItemsPostResponse> response =
                await client.Users.AddPersonalListItemsAsync(USERNAME, TRAKT_LIST_ID, AddPersonalListItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_AddPersonalListItems_With_ListIds_TraktID()
        {
            string postJson = await TestUtility.SerializeObject(AddPersonalListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/items",
                postJson, CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON);

            TraktResponse<ITraktUserPersonalListItemsPostResponse> response =
                await client.Users.AddPersonalListItemsAsync(USERNAME, listIds, AddPersonalListItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_AddPersonalListItems_With_ListIds_Slug()
        {
            string postJson = await TestUtility.SerializeObject(AddPersonalListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            var listIds = new TraktListIds
            {
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{LIST_SLUG}/items",
                postJson, CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON);

            TraktResponse<ITraktUserPersonalListItemsPostResponse> response =
                await client.Users.AddPersonalListItemsAsync(USERNAME, listIds, AddPersonalListItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_AddPersonalListItems_With_ListIds()
        {
            string postJson = await TestUtility.SerializeObject(AddPersonalListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID,
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/items",
                postJson, CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON);

            TraktResponse<ITraktUserPersonalListItemsPostResponse> response =
                await client.Users.AddPersonalListItemsAsync(USERNAME, listIds, AddPersonalListItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_AddPersonalListItems_With_List()
        {
            string postJson = await TestUtility.SerializeObject(AddPersonalListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = TRAKT_LIST_ID,
                    Slug = LIST_SLUG
                }
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/items",
                postJson, CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON);

            TraktResponse<ITraktUserPersonalListItemsPostResponse> response =
                await client.Users.AddPersonalListItemsAsync(USERNAME, list, AddPersonalListItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
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
        public async Task Test_TraktUsersModule_AddPersonalListItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_PERSONAL_LIST_ITEMS_URI, statusCode);

            try
            {
                await client.Users.AddPersonalListItemsAsync(USERNAME, LIST_ID, AddPersonalListItemsPost);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_AddPersonalListItems_Throws_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(AddPersonalListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_PERSONAL_LIST_ITEMS_URI,
                postJson, CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktUserPersonalListItemsPostResponse>>> act =
                () => client.Users.AddPersonalListItemsAsync(USERNAME, default(ITraktListIds), AddPersonalListItemsPost);
            
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.AddPersonalListItemsAsync(USERNAME, default(ITraktList), AddPersonalListItemsPost);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.AddPersonalListItemsAsync(USERNAME, new TraktListIds(), AddPersonalListItemsPost);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.AddPersonalListItemsAsync(USERNAME, 0, AddPersonalListItemsPost);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
