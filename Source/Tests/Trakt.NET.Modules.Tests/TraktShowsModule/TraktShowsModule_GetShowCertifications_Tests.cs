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

    [TestCategory("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_CERTIFICATIONS_URI = $"shows/{SHOW_ID}/certifications";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCertifications()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, SHOW_CERTIFICATIONS_JSON);
            TraktListResponse<ITraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(7);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCertifications_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/certifications", SHOW_CERTIFICATIONS_JSON);
            TraktListResponse<ITraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(TRAKT_SHOD_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(7);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCertifications_With_ShowIds_TraktID()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/certifications", SHOW_CERTIFICATIONS_JSON);
            TraktListResponse<ITraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(7);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCertifications_With_ShowIds_Slug()
        {
            var showIds = new TraktShowIds
            {
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{SHOW_SLUG}/certifications", SHOW_CERTIFICATIONS_JSON);
            TraktListResponse<ITraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(7);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCertifications_With_ShowIds()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID,
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/certifications", SHOW_CERTIFICATIONS_JSON);
            TraktListResponse<ITraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(showIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(7);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCertifications_With_Show()
        {
            var show = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = TRAKT_SHOD_ID,
                    Slug = SHOW_SLUG
                }
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/certifications", SHOW_CERTIFICATIONS_JSON);
            TraktListResponse<ITraktShowCertification> response = await client.Shows.GetShowCertificationsAsync(show);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(7);
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
        public async Task Test_TraktShowsModule_GetShowCertifications_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, statusCode);

            try
            {
                await client.Shows.GetShowCertificationsAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCertifications_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, SHOW_CERTIFICATIONS_JSON);

            Func<Task<TraktListResponse<ITraktShowCertification>>> act = () => client.Shows.GetShowCertificationsAsync(default(ITraktShowIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Shows.GetShowCertificationsAsync(default(ITraktShow));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Shows.GetShowCertificationsAsync(new TraktShowIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowCertificationsAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
