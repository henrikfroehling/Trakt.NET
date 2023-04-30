namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Shows;
    using Xunit;

    [TestCategory("Requests.Shows")]
    public class ShowStudiosRequest_Tests
    {
        [Fact]
        public void Test_ShowStudiosRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowStudiosRequest();
            request.UriTemplate.Should().Be("shows/{id}/studios");
        }

        [Fact]
        public void Test_ShowStudiosRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new ShowStudiosRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ShowStudiosRequest_Returns_Valid_RequestObjectType()
        {
            var request = new ShowStudiosRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Shows);
        }

        [Fact]
        public void Test_ShowStudiosRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ShowStudiosRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_ShowStudiosRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowStudiosRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ShowStudiosRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ShowStudiosRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
