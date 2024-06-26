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
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string REFRESH_SHOW_URI = $"shows/{TRAKT_SHOD_ID}/refresh";

        [Fact]
        public async Task Test_TraktShowsModule_RefreshShow()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REFRESH_SHOW_URI, HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Shows.RefreshShowAsync(TRAKT_SHOD_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktShowsModule_RefreshShow_With_TraktID()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"shows/{TRAKT_SHOD_ID}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Shows.RefreshShowAsync(TRAKT_SHOD_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktShowsModule_RefreshShow_With_ShowIds_TraktID()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"shows/{TRAKT_SHOD_ID}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Shows.RefreshShowAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktShowsModule_RefreshShow_With_ShowIds_Slug()
        {
            var showIds = new TraktShowIds
            {
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"shows/{SHOW_SLUG}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Shows.RefreshShowAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktShowsModule_RefreshShow_With_ShowIds()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID,
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"shows/{TRAKT_SHOD_ID}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Shows.RefreshShowAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktShowsModule_RefreshShow_With_Show()
        {
            var show = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = TRAKT_SHOD_ID,
                    Slug = SHOW_SLUG
                }
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"shows/{TRAKT_SHOD_ID}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Shows.RefreshShowAsync(show);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
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
        [InlineData((HttpStatusCode)426, typeof(TraktFailedVIPValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktShowsModule_RefreshShow_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REFRESH_SHOW_URI, statusCode);

            try
            {
                await client.Shows.RefreshShowAsync(TRAKT_SHOD_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktShowsModule_RefreshShow_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REFRESH_SHOW_URI, HttpStatusCode.Created);

            Func<Task<TraktNoContentResponse>> act = () => client.Shows.RefreshShowAsync(default(ITraktShowIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Shows.RefreshShowAsync(default(ITraktShow));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Shows.RefreshShowAsync(new TraktShowIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Shows.RefreshShowAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
