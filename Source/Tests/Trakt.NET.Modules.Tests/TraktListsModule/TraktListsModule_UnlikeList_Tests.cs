﻿namespace TraktNet.Modules.Tests.TraktListsModule
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
            TraktClient client = TestUtility.GetOAuthMockClient($"lists/{TRAKT_LIST_ID}/like", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(TRAKT_LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList_With_ListIds_TraktID()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"lists/{TRAKT_LIST_ID}/like", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList_With_ListIds_Slug()
        {
            var listIds = new TraktListIds
            {
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"lists/{LIST_SLUG}/like", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList_With_ListIds()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID,
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"lists/{TRAKT_LIST_ID}/like", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_UnlikeList_With_List()
        {
            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = TRAKT_LIST_ID,
                    Slug = LIST_SLUG
                }
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"lists/{TRAKT_LIST_ID}/like", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Lists.UnlikeListAsync(list);

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

            act = () => client.Lists.UnlikeListAsync(default(ITraktList));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Lists.UnlikeListAsync(new TraktListIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Lists.UnlikeListAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
