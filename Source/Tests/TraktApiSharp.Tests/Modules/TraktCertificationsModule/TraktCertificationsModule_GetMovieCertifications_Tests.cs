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
        private const string GET_MOVIE_CERTIFICATIONS_URI = "certifications/movies";

        [Fact]
        public async Task Test_TraktCertificationsModule_GetMovieCertifications()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, GET_MOVIE_CERTIFICATIONS_JSON);
            TraktResponse<ITraktCertifications> response = await client.Certifications.GetMovieCertificationsAsync();

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
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetMovieCertifications_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetMovieCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
