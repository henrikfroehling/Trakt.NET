namespace TraktApiSharp.Tests.Requests.Certifications
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Certifications;
    using Xunit;

    [Category("Requests.Certifications")]
    public class MovieCertificationsRequest_Tests
    {
        [Fact]
        public void Test_MovieCertificationsRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieCertificationsRequest();
            request.UriTemplate.Should().Be("certifications/movies");
        }
    }
}
