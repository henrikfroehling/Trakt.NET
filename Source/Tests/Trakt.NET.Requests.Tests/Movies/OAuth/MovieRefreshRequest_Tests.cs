namespace TraktNet.Requests.Tests.Movies.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Movies.OAuth;
    using Xunit;

    [TestCategory("Requests.Movies")]
    public class MovieRefreshRequest_Tests
    {
        [Fact]
        public void Test_MovieRefreshRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new MovieRefreshRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_MovieRefreshRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieRefreshRequest();
            request.UriTemplate.Should().Be("movies/{id}/refresh");
        }

        [Fact]
        public void Test_MovieRefreshRequest_Returns_Valid_UriPathParameters()
        {
            var request = new MovieRefreshRequest { Id = "123" };
            request.GetUriPathParameters().Should().NotBeSameAs(new Dictionary<string, object> { { "id", "123" } });
        }

        [Fact]
        public void Test_MovieRefreshRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieRefreshRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new MovieRefreshRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new MovieRefreshRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
