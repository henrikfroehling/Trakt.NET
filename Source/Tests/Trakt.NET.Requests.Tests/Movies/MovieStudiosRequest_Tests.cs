namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies")]
    public class MovieStudiosRequest_Tests
    {
        [Fact]
        public void Test_MovieStudiosRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieStudiosRequest();
            request.UriTemplate.Should().Be("movies/{id}/studios");
        }

        [Fact]
        public void Test_MovieStudiosRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new MovieStudiosRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_MovieStudiosRequest_Returns_Valid_RequestObjectType()
        {
            var request = new MovieStudiosRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Movies);
        }

        [Fact]
        public void Test_MovieStudiosRequest_Returns_Valid_UriPathParameters()
        {
            var request = new MovieStudiosRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_MovieStudiosRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieStudiosRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new MovieStudiosRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new MovieStudiosRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
