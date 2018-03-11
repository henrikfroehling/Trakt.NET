namespace TraktApiSharp.Tests.Modules.TraktCertificationsModule
{
    //using FluentAssertions;
    //using System;
    //using System.Linq;
    //using System.Net;
    //using System.Threading.Tasks;
    //using TestUtils;
    using Traits;
    //using TraktApiSharp.Exceptions;
    //using TraktApiSharp.Objects.Basic;
    //using TraktApiSharp.Responses;
    //using Xunit;

    [Category("Modules.Certifications")]
    public partial class TraktCertificationsModule_Tests
    {
        //private const string GET_MOVIE_CERTIFICATIONS_URL = "certifications/movies";

        //[Fact]
        //public async Task Test_TraktCertificationsModule_GetMovieCertificationsAsync()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, GET_MOVIE_CERTIFICATIONS_JSON);

        //    TraktResponse<ITraktCertifications> response = await TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();

        //    response.Should().NotBeNull();
        //    response.IsSuccess.Should().BeTrue();
        //    response.Value.Should().NotBeNull();
        //    response.HasValue.Should().BeTrue();
        //    response.Exception.Should().BeNull();

        //    ITraktCertifications certifications = response.Value;
        //    certifications.US.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(5);

        //    ITraktCertification[] certificationsUS = certifications.US.ToArray();

        //    certificationsUS[0].Should().NotBeNull();
        //    certificationsUS[0].Name.Should().Be("G");
        //    certificationsUS[0].Slug.Should().Be("g");
        //    certificationsUS[0].Description.Should().Be("All Ages");

        //    certificationsUS[1].Should().NotBeNull();
        //    certificationsUS[1].Name.Should().Be("PG");
        //    certificationsUS[1].Slug.Should().Be("pg");
        //    certificationsUS[1].Description.Should().Be("Parental Guidance Suggested");

        //    certificationsUS[2].Should().NotBeNull();
        //    certificationsUS[2].Name.Should().Be("PG-13");
        //    certificationsUS[2].Slug.Should().Be("pg-13");
        //    certificationsUS[2].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");

        //    certificationsUS[3].Should().NotBeNull();
        //    certificationsUS[3].Name.Should().Be("R");
        //    certificationsUS[3].Slug.Should().Be("r");
        //    certificationsUS[3].Description.Should().Be("Mature Audiences - Ages 17+ Recommended");

        //    certificationsUS[4].Should().NotBeNull();
        //    certificationsUS[4].Name.Should().Be("Not Rated");
        //    certificationsUS[4].Slug.Should().Be("nr");
        //    certificationsUS[4].Description.Should().Be("Not Rated");

        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_NotFound()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, HttpStatusCode.NotFound);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktNotFoundException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_Unauthorized()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, HttpStatusCode.Unauthorized);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktAuthorizationException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_BadRequest()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, HttpStatusCode.BadRequest);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktBadRequestException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_Forbidden()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, HttpStatusCode.Forbidden);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktForbiddenException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_MethodNotAllowed()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, HttpStatusCode.MethodNotAllowed);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktMethodNotFoundException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_Conflict()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, HttpStatusCode.Conflict);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktConflictException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_InternalServerError()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, HttpStatusCode.InternalServerError);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktServerException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_BadGateway()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, HttpStatusCode.BadGateway);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktBadGatewayException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_HttpStatusCode_412()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, (HttpStatusCode)412);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktPreconditionFailedException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_HttpStatusCode_422()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, (HttpStatusCode)422);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktValidationException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_HttpStatusCode_429()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, (HttpStatusCode)429);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktRateLimitException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_HttpStatusCode_503()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, (HttpStatusCode)503);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_HttpStatusCode_504()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, (HttpStatusCode)504);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_HttpStatusCode_520()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, (HttpStatusCode)520);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_HttpStatusCode_521()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, (HttpStatusCode)521);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktCertificationsModule_GetMovieCertificationsAsync_Exceptions_HttpStatusCode_522()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_MOVIE_CERTIFICATIONS_URL, (HttpStatusCode)522);
        //    Func<Task<TraktResponse<ITraktCertifications>>> act = () => TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}
    }
}
