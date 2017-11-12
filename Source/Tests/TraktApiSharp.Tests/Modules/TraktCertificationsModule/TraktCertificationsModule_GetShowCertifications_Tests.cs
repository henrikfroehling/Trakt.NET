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
        [Fact]
        public async Task Test_TraktCertificationsModule_GetShowCertificationsAsync()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth("certifications/shows", GET_SHOW_CERTIFICATIONS_JSON);

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
        public void Test_TraktCertificationsModule_GetShowCertificationsAsync_Exceptions()
        {
            const string uri = "certifications/shows";

            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktCertifications>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ResetMockHttpClient();
        }
    }
}
