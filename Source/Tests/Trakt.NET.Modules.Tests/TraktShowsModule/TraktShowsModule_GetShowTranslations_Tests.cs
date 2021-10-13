namespace TraktNet.Modules.Tests.TraktShowsModule
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

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_TRANSLATIONS_URI = $"shows/{SHOW_ID}/translations";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowTranslations()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, SHOW_TRANSLATIONS_JSON);
            TraktListResponse<ITraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowTranslations_With_LanguageCode()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SHOW_TRANSLATIONS_URI}/{ LANGUAGE_CODE}", SHOW_TRANSLATIONS_JSON);
            TraktListResponse<ITraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(SHOW_ID, LANGUAGE_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
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
        public async Task Test_TraktShowsModule_GetShowTranslations_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, statusCode);

            try
            {
                await client.Shows.GetShowTranslationsAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowTranslations_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, SHOW_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync("show id");
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowTranslations_With_LanguageCode_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, SHOW_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync("show id");
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID, "eng");
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();

            act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID, "e");
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }
    }
}
