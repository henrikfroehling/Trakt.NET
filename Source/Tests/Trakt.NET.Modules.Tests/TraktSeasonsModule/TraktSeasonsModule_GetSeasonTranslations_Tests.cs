﻿namespace TraktNet.Modules.Tests.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASON_TRANSLATIONS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/translations";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonTranslations()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_TRANSLATIONS_URI, SEASON_TRANSLATIONS_JSON);
            TraktListResponse<ITraktSeasonTranslation> response = await client.Seasons.GetSeasonTranslationsAsync(SHOW_ID, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonTranslations_With_LanguageCode()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_TRANSLATIONS_URI}/{LANGUAGE_CODE}", SEASON_TRANSLATIONS_JSON);
            TraktListResponse<ITraktSeasonTranslation> response = await client.Seasons.GetSeasonTranslationsAsync(SHOW_ID, SEASON_NR, LANGUAGE_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktSeasonNotFoundException))]
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
        public async Task Test_TraktSeasonsModule_GetSeasonTranslations_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_TRANSLATIONS_URI, statusCode);

            try
            {
                await client.Seasons.GetSeasonTranslationsAsync(SHOW_ID, SEASON_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonTranslations_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_TRANSLATIONS_URI, SEASON_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktSeasonTranslation>>> act = () => client.Seasons.GetSeasonTranslationsAsync(null, SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonTranslationsAsync(string.Empty, SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonTranslationsAsync("show id", SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonTranslations_With_LanguageCode_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_TRANSLATIONS_URI, SEASON_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktSeasonTranslation>>> act = () => client.Seasons.GetSeasonTranslationsAsync(null, SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonTranslationsAsync(string.Empty, SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonTranslationsAsync("show id", SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonTranslationsAsync(SHOW_ID, SEASON_NR, "eng");
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();

            act = () => client.Seasons.GetSeasonTranslationsAsync(SHOW_ID, SEASON_NR, "e");
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }
    }
}
