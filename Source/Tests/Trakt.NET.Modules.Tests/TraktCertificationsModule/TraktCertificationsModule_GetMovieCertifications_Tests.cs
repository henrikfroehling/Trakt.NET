namespace TraktNet.Modules.Tests.TraktCertificationsModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
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
        public async Task Test_TraktCertificationsModule_GetMovieCertifications_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_CERTIFICATIONS_URI, statusCode);

            try
            {
                await client.Certifications.GetMovieCertificationsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
