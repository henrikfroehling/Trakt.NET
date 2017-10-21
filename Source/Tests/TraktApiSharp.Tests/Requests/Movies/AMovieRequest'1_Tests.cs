namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Movies;
    using Xunit;

    [Category("Requests.Movies")]
    public class AMovieRequest_1_Tests
    {
        internal class MovieRequestMock : AMovieRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AMovieRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new MovieRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_AMovieRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new MovieRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Movies);
        }

        [Fact]
        public void Test_AMovieRequest_1_Returns_Valid_UriPathParameters()
        {
            var requestMock = new MovieRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_AMovieRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new MovieRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new MovieRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new MovieRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
