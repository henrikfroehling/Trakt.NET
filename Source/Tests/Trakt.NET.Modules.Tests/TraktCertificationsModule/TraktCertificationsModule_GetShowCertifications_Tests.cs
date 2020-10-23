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
        private const string GET_SHOW_CERTIFICATIONS_URI = "certifications/shows";

        [Fact]
        public async Task Test_TraktCertificationsModule_GetShowCertifications()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, GET_SHOW_CERTIFICATIONS_JSON);
            TraktResponse<ITraktCertifications> response = await client.Certifications.GetShowCertificationsAsync();

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
        public async Task Test_TraktCertificationsModule_GetShowCertifications_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, statusCode);

            try
            {
                await client.Certifications.GetShowCertificationsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
