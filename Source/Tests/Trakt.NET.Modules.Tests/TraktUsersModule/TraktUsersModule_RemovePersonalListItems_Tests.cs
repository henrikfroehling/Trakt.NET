﻿namespace TraktNet.Modules.Tests.TraktUsersModule
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
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string REMOVE_PERSONAL_LIST_ITEMS_URI = $"users/{USERNAME}/lists/{LIST_ID}/items/remove";

        [Fact]
        public async Task Test_TraktUsersModule_RemovePersonalListItems()
        {
            string postJson = await TestUtility.SerializeObject(RemovePersonalListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_PERSONAL_LIST_ITEMS_URI, postJson,
                                                                CUSTOM_LIST_ITEMS_REMOVE_POST_RESPONSE_JSON);

            TraktResponse<ITraktUserPersonalListItemsRemovePostResponse> response =
                await client.Users.RemovePersonalListItemsAsync(USERNAME, LIST_ID, RemovePersonalListItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserPersonalListItemsRemovePostResponse responseValue = response.Value;

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
        public async Task Test_TraktUsersModule_RemovePersonalListItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_PERSONAL_LIST_ITEMS_URI, statusCode);

            try
            {
                await client.Users.RemovePersonalListItemsAsync(USERNAME, LIST_ID, RemovePersonalListItemsPost);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_RemovePersonalListItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(RemovePersonalListItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_PERSONAL_LIST_ITEMS_URI, postJson,
                                                                CUSTOM_LIST_ITEMS_REMOVE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktUserPersonalListItemsRemovePostResponse>>> act = () => client.Users.RemovePersonalListItemsAsync(null, LIST_ID, RemovePersonalListItemsPost);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.RemovePersonalListItemsAsync(string.Empty, LIST_ID, RemovePersonalListItemsPost);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.RemovePersonalListItemsAsync("user name", LIST_ID, RemovePersonalListItemsPost);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.RemovePersonalListItemsAsync(USERNAME, null, RemovePersonalListItemsPost);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.RemovePersonalListItemsAsync(USERNAME, string.Empty, RemovePersonalListItemsPost);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.RemovePersonalListItemsAsync(USERNAME, "list id", RemovePersonalListItemsPost);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.RemovePersonalListItemsAsync(USERNAME, LIST_ID, null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.RemovePersonalListItemsAsync(USERNAME, LIST_ID, new TraktUserPersonalListItemsPost());
            await act.Should().ThrowAsync<ArgumentException>();

            ITraktUserPersonalListItemsPost customListItems = new TraktUserPersonalListItemsPost
            {
                Movies = new List<ITraktUserPersonalListItemsPostMovie>(),
                Shows = new List<ITraktUserPersonalListItemsPostShow>(),
                People = new List<ITraktUserPersonalListItemsPostPerson>()
            };

            act = () => client.Users.RemovePersonalListItemsAsync(USERNAME, LIST_ID, customListItems);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
