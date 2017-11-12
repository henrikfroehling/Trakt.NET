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
        public async Task Test_TraktCertificationsModule_GetMovieCertificationsAsync()
        {
            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth("certifications/movies", GET_MOVIE_CERTIFICATIONS_JSON);

            TraktResponse<ITraktCertifications> response = await TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.Value.Should().NotBeNull();
            response.HasValue.Should().BeTrue();
            response.Exception.Should().BeNull();

            ITraktCertifications certifications = response.Value;
            certifications.US.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(5);

            ITraktCertification[] certificationsUS = certifications.US.ToArray();

            certificationsUS[0].Should().NotBeNull();
            certificationsUS[0].Name.Should().Be("G");
            certificationsUS[0].Slug.Should().Be("g");
            certificationsUS[0].Description.Should().Be("All Ages");

            certificationsUS[1].Should().NotBeNull();
            certificationsUS[1].Name.Should().Be("PG");
            certificationsUS[1].Slug.Should().Be("pg");
            certificationsUS[1].Description.Should().Be("Parental Guidance Suggested");

            certificationsUS[2].Should().NotBeNull();
            certificationsUS[2].Name.Should().Be("PG-13");
            certificationsUS[2].Slug.Should().Be("pg-13");
            certificationsUS[2].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");

            certificationsUS[3].Should().NotBeNull();
            certificationsUS[3].Name.Should().Be("R");
            certificationsUS[3].Slug.Should().Be("r");
            certificationsUS[3].Description.Should().Be("Mature Audiences - Ages 17+ Recommended");

            certificationsUS[4].Should().NotBeNull();
            certificationsUS[4].Name.Should().Be("Not Rated");
            certificationsUS[4].Slug.Should().Be("nr");
            certificationsUS[4].Description.Should().Be("Not Rated");

            TestUtility.ResetMockHttpClient();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions()
        {
            const string uri = "certifications/movies";

            TestUtility.SetupMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktCertifications>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
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
