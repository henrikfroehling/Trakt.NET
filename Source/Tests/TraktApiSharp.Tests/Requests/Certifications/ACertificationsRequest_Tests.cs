namespace TraktApiSharp.Tests.Requests.Certifications
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Certifications;
    using Xunit;

    [Category("Requests.Certifications")]
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
