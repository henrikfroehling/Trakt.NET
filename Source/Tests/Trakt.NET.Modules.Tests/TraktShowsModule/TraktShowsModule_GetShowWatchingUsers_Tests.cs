﻿namespace TraktNet.Modules.Tests.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_WATCHING_USERS_URI = $"shows/{SHOW_ID}/watching";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_SHOW_WATCHING_USERS_URI,
                SHOW_WATCHING_USERS_JSON);

            TraktListResponse<ITraktUser> response =
                await client.Shows.GetShowWatchingUsersAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/watching", SHOW_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TRAKT_SHOD_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers_With_ShowIds_TraktID()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/watching", SHOW_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Shows.GetShowWatchingUsersAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers_With_ShowIds_Slug()
        {
            var showIds = new TraktShowIds
            {
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{SHOW_SLUG}/watching", SHOW_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Shows.GetShowWatchingUsersAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers_With_ShowIds()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID,
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/watching", SHOW_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Shows.GetShowWatchingUsersAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers_With_Show()
        {
            var show = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = TRAKT_SHOD_ID,
                    Slug = SHOW_SLUG
                }
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/watching", SHOW_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Shows.GetShowWatchingUsersAsync(show);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_WATCHING_USERS_URI}?extended={EXTENDED_INFO}",
                SHOW_WATCHING_USERS_JSON);

            TraktListResponse<ITraktUser> response =
                await client.Shows.GetShowWatchingUsersAsync(SHOW_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktShowNotFoundException))]
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
        public async Task Test_TraktShowsModule_GetShowWatchingUsers_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, statusCode);

            try
            {
                await client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, SHOW_WATCHING_USERS_JSON);

            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(default(ITraktShowIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Shows.GetShowWatchingUsersAsync(default(ITraktShow));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Shows.GetShowWatchingUsersAsync(new TraktShowIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowWatchingUsersAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
