namespace TraktNet.Requests.Tests.Certifications
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Certifications;
    using Xunit;

    [TestCategory("Requests.Certifications")]
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
