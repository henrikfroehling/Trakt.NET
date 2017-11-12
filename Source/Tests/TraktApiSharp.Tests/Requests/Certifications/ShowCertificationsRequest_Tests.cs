namespace TraktApiSharp.Tests.Requests.Certifications
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Certifications;
    using Xunit;

    [Category("Requests.Certifications")]
    public class ShowCertificationsRequest_Tests
    {
        [Fact]
        public void Test_ShowCertificationsRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowCertificationsRequest();
            request.UriTemplate.Should().Be("certifications/shows");
        }
    }
}
