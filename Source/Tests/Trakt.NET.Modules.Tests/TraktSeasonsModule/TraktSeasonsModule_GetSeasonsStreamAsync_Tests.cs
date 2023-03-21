namespace TraktNet.Modules.Tests.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Responses;
    using TraktNet.Extensions;
    using Xunit;

    [TestCategory("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASONS_STREAM_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonsStreamAsync()
        {
            TraktMultipleSeasonsQueryParams parameters = new TraktMultipleSeasonsQueryParams
            {
                { SHOW_ID, SEASON_NR },
                { SHOW_ID, SEASON_NR }
            };
            int totalSeasons = parameters.Count;
            TraktClient client = TestUtility.GetMockClient(GET_SEASONS_STREAM_URI, SEASON_EPISODES_JSON);
            IAsyncEnumerable<TraktListResponse<ITraktEpisode>> responses = client.Seasons.GetSeasonsStreamAsync(parameters);

            int returnedSeasons = 0;

            await foreach (TraktListResponse<ITraktEpisode> response in responses) {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull().And.HaveCount(10);
                returnedSeasons++;
            }
            returnedSeasons.Should().Be(totalSeasons);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonsStreamAsync_With_ExtendedInfo()
        {
            TraktMultipleSeasonsQueryParams parameters = new TraktMultipleSeasonsQueryParams
            {
                { SHOW_ID, SEASON_NR, EXTENDED_INFO },
                { SHOW_ID, SEASON_NR, EXTENDED_INFO }
            };
            int totalSeasons = parameters.Count;
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASONS_STREAM_URI}?extended={EXTENDED_INFO}",
                                                           SEASON_EPISODES_JSON);
            IAsyncEnumerable<TraktListResponse<ITraktEpisode>> responses = client.Seasons.GetSeasonsStreamAsync(parameters);

            int returnedSeasons = 0;
            await foreach (var response in responses.ConfigureAwait(false))
            {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull().And.HaveCount(10);
                returnedSeasons++;
            }
            returnedSeasons.Should().Be(totalSeasons);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonsStreamAsync_With_Translations()
        {
            TraktMultipleSeasonsQueryParams parameters = new TraktMultipleSeasonsQueryParams
            {
                { SHOW_ID, SEASON_NR, EXTENDED_INFO, TRANSLATION_LANGUAGE_CODE },
                { SHOW_ID, SEASON_NR, EXTENDED_INFO, TRANSLATION_LANGUAGE_CODE }
            };
            int totalSeasons = parameters.Count;
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASONS_STREAM_URI}?translations={TRANSLATION_LANGUAGE_CODE}",
                                                           SEASON_EPISODES_JSON);

            IAsyncEnumerable<TraktListResponse<ITraktEpisode>> responses = client.Seasons.GetSeasonsStreamAsync(parameters);

            int returnedSeasons = 0;
            await foreach (var response in responses.ConfigureAwait(false))
            {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull().And.HaveCount(10);
                returnedSeasons++;
            }
            returnedSeasons.Should().Be(totalSeasons);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonsStreamAsync_With_ExtendedInfo_And_Translations()
        {
            TraktMultipleSeasonsQueryParams parameters = new TraktMultipleSeasonsQueryParams
            {
                { SHOW_ID, SEASON_NR, EXTENDED_INFO, TRANSLATION_LANGUAGE_CODE },
                { SHOW_ID, SEASON_NR, EXTENDED_INFO, TRANSLATION_LANGUAGE_CODE }
            };
            int totalSeasons = parameters.Count;
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASONS_STREAM_URI}?extended={EXTENDED_INFO}&translations={TRANSLATION_LANGUAGE_CODE}",
                                                           SEASON_EPISODES_JSON);
            IAsyncEnumerable<TraktListResponse<ITraktEpisode>> responses = client.Seasons.GetSeasonsStreamAsync(parameters);

            int returnedSeasons = 0;
            await foreach (var response in responses.ConfigureAwait(false))
            {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull().And.HaveCount(10);
            }
            returnedSeasons.Should().Be(totalSeasons);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonsStreamAsync_With_All_Translations()
        {
            TraktMultipleSeasonsQueryParams parameters = new TraktMultipleSeasonsQueryParams
            {
                { SHOW_ID, SEASON_NR, TRANSLATION_LANGUAGE_CODE_All },
                { SHOW_ID, SEASON_NR, TRANSLATION_LANGUAGE_CODE_All }
            };
            int totalSeasons = parameters.Count;
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASONS_STREAM_URI}?translations={TRANSLATION_LANGUAGE_CODE_All}",
                                                           SEASON_EPISODES_JSON);

            IAsyncEnumerable<TraktListResponse<ITraktEpisode>> responses = client.Seasons.GetSeasonsStreamAsync(parameters);

            int returnedSeasons = 0;
            await foreach (var response in responses.ConfigureAwait(false))
            {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull().And.HaveCount(10);
                returnedSeasons++;
            }
            returnedSeasons.Should().Be(totalSeasons);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonsStreamAsync_With_ExtendedInfo_And_All_Translations()
        {
            TraktMultipleSeasonsQueryParams parameters = new TraktMultipleSeasonsQueryParams
            {
                { SHOW_ID, SEASON_NR, EXTENDED_INFO, TRANSLATION_LANGUAGE_CODE_All },
                { SHOW_ID, SEASON_NR, EXTENDED_INFO, TRANSLATION_LANGUAGE_CODE_All }
            };
            int totalSeasons = parameters.Count;
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASONS_STREAM_URI}?extended={EXTENDED_INFO}&translations=all",
                                                           SEASON_EPISODES_JSON);

            IAsyncEnumerable<TraktListResponse<ITraktEpisode>> responses = client.Seasons.GetSeasonsStreamAsync(parameters);

            int returnedSeasons = 0;
            await foreach (var response in responses.ConfigureAwait(false))
            {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull().And.HaveCount(10);
                returnedSeasons++;
            }
            returnedSeasons.Should().Be(totalSeasons);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonsStreamAsync_WithNullParameters()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASONS_STREAM_URI}?extended={EXTENDED_INFO}&translations=all",
                                                           SEASON_EPISODES_JSON);

            IAsyncEnumerable<TraktListResponse<ITraktEpisode>> responses = client.Seasons.GetSeasonsStreamAsync(null);
            (await responses.ToListAsync()).Should().BeEmpty();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonsStreamAsync_WithEmptyParameters()
        {
            TraktMultipleSeasonsQueryParams parameters = new TraktMultipleSeasonsQueryParams();
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASONS_STREAM_URI}?extended={EXTENDED_INFO}&translations=all",
                                                           SEASON_EPISODES_JSON);

            IAsyncEnumerable<TraktListResponse<ITraktEpisode>> responses = client.Seasons.GetSeasonsStreamAsync(parameters);
            (await responses.ToListAsync()).Should().BeEmpty();
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
        public async Task Test_TraktSeasonsModule_GetSeasonsStreamAsync_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktMultipleSeasonsQueryParams parameters = new TraktMultipleSeasonsQueryParams
            {
                { SHOW_ID, SEASON_NR },
                { SHOW_ID, SEASON_NR }
            };
            TraktClient client = TestUtility.GetMockClient(GET_SEASONS_STREAM_URI, statusCode);

            try
            {
                var responses = client.Seasons.GetSeasonsStreamAsync(parameters);
                (await responses.ToListAsync()).Should().NotBeNull();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
