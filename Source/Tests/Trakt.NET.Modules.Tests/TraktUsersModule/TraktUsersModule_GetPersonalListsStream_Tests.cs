﻿namespace TraktNet.Modules.Tests.TraktUsersModule
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
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Responses;
    using TraktNet.Extensions;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_PERSONAL_LIST_STREAM_URI = $"users/{USERNAME}/lists/{LIST_ID}";

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalListStream()
        {
            TraktMultipleUserListsQueryParams parameters = new TraktMultipleUserListsQueryParams
            {
                { USERNAME, LIST_ID },
                { USERNAME, LIST_ID },
            };
            int totalLists = parameters.Count;
            TraktClient client = TestUtility.GetMockClientForMultipleCalls(GET_PERSONAL_LIST_STREAM_URI, LIST_JSON, totalLists);
            IAsyncEnumerable<TraktResponse<ITraktList>> responses = client.Users.GetPersonalListsStreamAsync(parameters);

            int returnedLists = 0;
            await foreach (TraktResponse<ITraktList> response in responses)
            {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull();

                ITraktList responseValue = response.Value;

                responseValue.Name.Should().Be("Star Wars in machete order");
                responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                responseValue.Privacy.Should().Be(TraktListPrivacy.Public);
                responseValue.DisplayNumbers.Should().BeTrue();
                responseValue.AllowComments.Should().BeFalse();
                responseValue.SortBy.Should().Be(TraktSortBy.Rank);
                responseValue.SortHow.Should().Be(TraktSortHow.Ascending);
                responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                responseValue.ItemCount.Should().Be(5);
                responseValue.CommentCount.Should().Be(1);
                responseValue.Likes.Should().Be(2);
                responseValue.Ids.Should().NotBeNull();
                responseValue.Ids.Trakt.Should().Be(55);
                responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
                responseValue.User.Should().NotBeNull();
                returnedLists++;
            }
            returnedLists.Should().Be(totalLists);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalListStream_With_OAuth_Enforced()
        {
            TraktMultipleUserListsQueryParams parameters = new TraktMultipleUserListsQueryParams
            {
                { USERNAME, LIST_ID },
                { USERNAME, LIST_ID },
            };
            int totalLists = parameters.Count;
            TraktClient client = TestUtility.GetOAuthMockClientForMultipleCalls(GET_PERSONAL_LIST_STREAM_URI, LIST_JSON, totalLists);
            client.Configuration.ForceAuthorization = true;

            IAsyncEnumerable<TraktResponse<ITraktList>> responses = client.Users.GetPersonalListsStreamAsync(parameters);

            int returnedLists = 0;
            await foreach (TraktResponse<ITraktList> response in responses)
            {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull();

                ITraktList responseValue = response.Value;

                responseValue.Name.Should().Be("Star Wars in machete order");
                responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                responseValue.Privacy.Should().Be(TraktListPrivacy.Public);
                responseValue.DisplayNumbers.Should().BeTrue();
                responseValue.AllowComments.Should().BeFalse();
                responseValue.SortBy.Should().Be(TraktSortBy.Rank);
                responseValue.SortHow.Should().Be(TraktSortHow.Ascending);
                responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                responseValue.ItemCount.Should().Be(5);
                responseValue.CommentCount.Should().Be(1);
                responseValue.Likes.Should().Be(2);
                responseValue.Ids.Should().NotBeNull();
                responseValue.Ids.Trakt.Should().Be(55);
                responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
                responseValue.User.Should().NotBeNull();
                returnedLists++;
            }
            returnedLists.Should().Be(totalLists);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalListStream_WithEmptyParameters()
        {
            TraktMultipleUserListsQueryParams parameters = new TraktMultipleUserListsQueryParams();
            TraktClient client = TestUtility.GetMockClient(GET_PERSONAL_LIST_STREAM_URI, LIST_JSON);
            IAsyncEnumerable<TraktResponse<ITraktList>> responses = client.Users.GetPersonalListsStreamAsync(parameters);

            (await responses.ToListAsync()).Should().BeEmpty();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalListStream_WithNullParameters()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSONAL_LIST_STREAM_URI, LIST_JSON);
            IAsyncEnumerable<TraktResponse<ITraktList>> responses = client.Users.GetPersonalListsStreamAsync(null);

            (await responses.ToListAsync()).Should().BeEmpty();
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
        public async Task Test_TraktUsersModule_GetPersonalListStream_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktMultipleUserListsQueryParams parameters = new TraktMultipleUserListsQueryParams
            {
                { USERNAME, LIST_ID },
                { USERNAME, LIST_ID },
            };
            TraktClient client = TestUtility.GetMockClient(GET_PERSONAL_LIST_STREAM_URI, statusCode);

            try
            {
                IAsyncEnumerable<TraktResponse<ITraktList>> responses = client.Users.GetPersonalListsStreamAsync(parameters);
                (await responses.ToListAsync()).Should().NotBeNullOrEmpty();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
