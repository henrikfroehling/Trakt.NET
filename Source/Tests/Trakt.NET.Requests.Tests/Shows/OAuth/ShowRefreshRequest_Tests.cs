namespace TraktNet.Requests.Tests.Shows.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Shows.OAuth;
    using Xunit;

    [TestCategory("Requests.Shows.OAuth")]
    public class ShowRefreshRequest_Tests
    {
        [Fact]
        public void Test_ShowRefreshRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new ShowRefreshRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ShowRefreshRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowRefreshRequest();
            request.UriTemplate.Should().Be("shows/{id}/refresh");
        }

        [Fact]
        public void Test_ShowRefreshRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ShowRefreshRequest { Id = "123" };
            request.GetUriPathParameters().Should().NotBeSameAs(new Dictionary<string, object> { { "id", "123" } });
        }

        [Fact]
        public void Test_ShowRefreshRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowRefreshRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ShowRefreshRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ShowRefreshRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
