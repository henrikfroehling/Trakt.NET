﻿namespace TraktNet.Modules.Tests.TraktEpisodesModule
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
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        private readonly string GET_EPISODE_STREAM_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}";

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodesStream()
        {
            TraktMultipleEpisodesQueryParams parameters = new TraktMultipleEpisodesQueryParams
            {
                { SHOW_ID, SEASON_NR, EPISODE_NR },
                { SHOW_ID, SEASON_NR, EPISODE_NR }
            };
            int totalNumberOfEpisodes = parameters.Count;
            TraktClient client = TestUtility.GetMockClientForMultipleCalls(GET_EPISODE_STREAM_URI, EPISODE_SUMMARY_FULL_JSON, totalNumberOfEpisodes);
            IAsyncEnumerable<TraktResponse<ITraktEpisode>> responses = client.Episodes.GetEpisodesStreamAsync(parameters);

            int episodesReturned = 0;

            await foreach (TraktResponse<ITraktEpisode> response in responses)
            {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull();

                ITraktEpisode responseValue = response.Value;

                responseValue.Title.Should().Be("Winter Is Coming");
                responseValue.SeasonNumber.Should().Be(1);
                responseValue.Number.Should().Be(1);
                responseValue.NumberAbsolute.Should().Be(50);
                responseValue.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                responseValue.Rating.Should().Be(9.0f);
                responseValue.Votes.Should().Be(111);
                responseValue.Ids.Should().NotBeNull();
                responseValue.Ids.Trakt.Should().Be(73640U);
                responseValue.Ids.Tvdb.Should().Be(3254641U);
                responseValue.Ids.Imdb.Should().Be("tt1480055");
                responseValue.Ids.Tmdb.Should().Be(63056U);
                responseValue.Ids.TvRage.Should().Be(1065008299U);
                responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);

                episodesReturned++;
            }

            episodesReturned.Should().Be(totalNumberOfEpisodes);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodesStream_WithExtendedInfo()
        {
            TraktMultipleEpisodesQueryParams parameters = new TraktMultipleEpisodesQueryParams
            {
                { SHOW_ID, SEASON_NR, EPISODE_NR, EXTENDED_INFO },
                { SHOW_ID, SEASON_NR, EPISODE_NR, EXTENDED_INFO }
            };
            int totalNumberOfEpisodes = parameters.Count;
            TraktClient client = TestUtility.GetMockClientForMultipleCalls($"{GET_EPISODE_STREAM_URI}?extended={EXTENDED_INFO}", EPISODE_SUMMARY_FULL_JSON, totalNumberOfEpisodes);
            IAsyncEnumerable<TraktResponse<ITraktEpisode>> responses = client.Episodes.GetEpisodesStreamAsync(parameters);

            int episodesReturned = 0;

            await foreach (TraktResponse<ITraktEpisode> response in responses)
            {
                response.Should().NotBeNull();
                response.IsSuccess.Should().BeTrue();
                response.HasValue.Should().BeTrue();
                response.Value.Should().NotBeNull();

                ITraktEpisode responseValue = response.Value;

                responseValue.Title.Should().Be("Winter Is Coming");
                responseValue.SeasonNumber.Should().Be(1);
                responseValue.Number.Should().Be(1);
                responseValue.NumberAbsolute.Should().Be(50);
                responseValue.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                responseValue.Rating.Should().Be(9.0f);
                responseValue.Votes.Should().Be(111);
                responseValue.Ids.Should().NotBeNull();
                responseValue.Ids.Trakt.Should().Be(73640U);
                responseValue.Ids.Tvdb.Should().Be(3254641U);
                responseValue.Ids.Imdb.Should().Be("tt1480055");
                responseValue.Ids.Tmdb.Should().Be(63056U);
                responseValue.Ids.TvRage.Should().Be(1065008299U);
                responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
                episodesReturned++;
            }

            episodesReturned.Should().Be(totalNumberOfEpisodes);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodesStream_EmptyParameters()
        {
            TraktMultipleEpisodesQueryParams parameters = new TraktMultipleEpisodesQueryParams
            {
            };
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_STREAM_URI}?extended={EXTENDED_INFO}", EPISODE_SUMMARY_FULL_JSON);
            IAsyncEnumerable<TraktResponse<ITraktEpisode>> responses = client.Episodes.GetEpisodesStreamAsync(parameters);
            (await responses.ToListAsync()).Should().BeEmpty();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodesStream_NullParameters()
        {
            TraktMultipleEpisodesQueryParams parameters = null;
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_STREAM_URI}?extended={EXTENDED_INFO}", EPISODE_SUMMARY_FULL_JSON);
            IAsyncEnumerable<TraktResponse<ITraktEpisode>> responses = client.Episodes.GetEpisodesStreamAsync(parameters);
            (await responses.ToListAsync()).Should().BeEmpty();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktEpisodeNotFoundException))]
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
        public async Task Test_TraktEpisodesModule_GetEpisodesStream_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STREAM_URI, statusCode);

            try
            {
                TraktMultipleEpisodesQueryParams parameters = new TraktMultipleEpisodesQueryParams
                {
                    { SHOW_ID, SEASON_NR, EPISODE_NR, EXTENDED_INFO },
                    { SHOW_ID, SEASON_NR, EPISODE_NR, EXTENDED_INFO }
                };
                IAsyncEnumerable<TraktResponse<ITraktEpisode>> responses = client.Episodes.GetEpisodesStreamAsync(parameters);
                (await responses.ToListAsync()).Should().BeEmpty();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}