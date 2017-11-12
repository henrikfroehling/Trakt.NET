namespace TraktApiSharp.Tests.Modules.TraktCertificationsModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Certifications")]
    public partial class TraktCertificationsModule_Tests
    {
        private const string GET_SHOW_CERTIFICATIONS_URL = "certifications/shows";

        [Fact]
        public async Task Test_TraktCertificationsModule_GetShowCertificationsAsync()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, GET_SHOW_CERTIFICATIONS_JSON);

            TraktResponse<ITraktCertifications> response = await TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.Value.Should().NotBeNull();
            response.HasValue.Should().BeTrue();
            response.Exception.Should().BeNull();

            ITraktCertifications certifications = response.Value;
            certifications.US.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(7);

            ITraktCertification[] certificationsUS = certifications.US.ToArray();

            certificationsUS[0].Should().NotBeNull();
            certificationsUS[0].Name.Should().Be("TV-Y");
            certificationsUS[0].Slug.Should().Be("tv-y");
            certificationsUS[0].Description.Should().Be("All Children");

            certificationsUS[1].Should().NotBeNull();
            certificationsUS[1].Name.Should().Be("TV-Y7");
            certificationsUS[1].Slug.Should().Be("tv-y7");
            certificationsUS[1].Description.Should().Be("Older Children - Ages 7+ Recommended");

            certificationsUS[2].Should().NotBeNull();
            certificationsUS[2].Name.Should().Be("TV-G");
            certificationsUS[2].Slug.Should().Be("tv-g");
            certificationsUS[2].Description.Should().Be("All Ages");

            certificationsUS[3].Should().NotBeNull();
            certificationsUS[3].Name.Should().Be("TV-PG");
            certificationsUS[3].Slug.Should().Be("tv-pg");
            certificationsUS[3].Description.Should().Be("Parental Guidance Suggested");

            certificationsUS[4].Should().NotBeNull();
            certificationsUS[4].Name.Should().Be("TV-14");
            certificationsUS[4].Slug.Should().Be("tv-14");
            certificationsUS[4].Description.Should().Be("Parents Strongly Cautioned - Ages 14+ Recommended");

            certificationsUS[5].Should().NotBeNull();
            certificationsUS[5].Name.Should().Be("TV-MA");
            certificationsUS[5].Slug.Should().Be("tv-ma");
            certificationsUS[5].Description.Should().Be("tv-ma");

            certificationsUS[6].Should().NotBeNull();
            certificationsUS[6].Name.Should().Be("Not Rated");
            certificationsUS[6].Slug.Should().Be("nr");
            certificationsUS[6].Description.Should().Be("Not Rated");

            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_NotFound()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktNotFoundException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_Unauthorized()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktAuthorizationException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_BadRequest()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktBadRequestException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_Forbidden()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktForbiddenException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_MethodNotAllowed()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_Conflict()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktConflictException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_InternalServerError()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktServerException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_BadGateway()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktBadGatewayException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_HttpStatusCode_412()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_HttpStatusCode_422()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktValidationException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_HttpStatusCode_429()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktRateLimitException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_HttpStatusCode_503()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_HttpStatusCode_504()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_HttpStatusCode_520()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_HttpStatusCode_521()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions_HttpStatusCode_522()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(GET_SHOW_CERTIFICATIONS_URL, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
            TestUtility.ResetMockHttpClient();
        }
    }
}
