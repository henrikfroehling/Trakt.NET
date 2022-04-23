﻿namespace TraktNet.Modules.Tests.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Shows;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string RESET_SHOW_WATCHED_PROGRESS_URI = $"shows/{SHOW_ID}/progress/watched/reset";

        [Fact]
        public async Task Test_TraktShowsModule_ResetShowWatchedProgress_Without_ResetAt()
        {
            string postJson = await TestUtility.SerializeObject(ResetWatchedProgressPostEmpty);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(RESET_SHOW_WATCHED_PROGRESS_URI, postJson, RESET_WATCHED_PROGRESS_POST_RESPONSE_JSON);
            TraktResponse<ITraktShowResetWatchedProgressPost> response = await client.Shows.ResetShowWatchedProgressAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
            response.Value.ResetAt.Should().Be(DateTime.Parse("2022-01-23T21:12:25.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktShowsModule_ResetShowWatchedProgress_With_ResetAt()
        {
            string postJson = await TestUtility.SerializeObject(ResetWatchedProgressPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(RESET_SHOW_WATCHED_PROGRESS_URI, postJson, RESET_WATCHED_PROGRESS_POST_RESPONSE_JSON);
            TraktResponse<ITraktShowResetWatchedProgressPost> response = await client.Shows.ResetShowWatchedProgressAsync(SHOW_ID, RESET_WATCHED_PROGRESS_AT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
            response.Value.ResetAt.Should().Be(DateTime.Parse("2022-01-23T21:12:25.000Z").ToUniversalTime());
        }

        [Theory]
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
        public async Task Test_TraktShowsModule_ResetShowWatchedProgress_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(RESET_SHOW_WATCHED_PROGRESS_URI, statusCode);

            try
            {
                await client.Shows.ResetShowWatchedProgressAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
