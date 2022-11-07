namespace TraktNet.Requests.Tests.Certifications
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Certifications;
    using Xunit;

    [TestCategory("Requests.Certifications")]
    public class ACertificationsRequest_Tests
    {
        internal class CertificationsRequestMock : ACertificationsRequest
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ACertificationsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new CertificationsRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ACertificationsRequest_Returns_Valid_UriPathParameters()
        {
            var requestMock = new CertificationsRequestMock();
            requestMock.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
