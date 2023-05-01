namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Shows;
    using Xunit;

    [TestCategory("Requests.Shows")]
    public class ShowCertificationsRequest_Tests
    {
        [Fact]
        public void Test_ShowCertificationsRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowCertificationsRequest();
            request.UriTemplate.Should().Be("shows/{id}/certifications");
        }

        [Fact]
        public void Test_ShowCertificationsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ShowCertificationsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_ShowCertificationsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowCertificationsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ShowCertificationsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ShowCertificationsRequest { Id = "invalid id" };
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
