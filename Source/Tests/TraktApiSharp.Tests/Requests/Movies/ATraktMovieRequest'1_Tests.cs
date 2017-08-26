namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Movies;
    using Xunit;

    [Category("Requests.Movies")]
    public class ATraktMovieRequest_1_Tests
    {
        internal class TraktMovieRequestMock : ATraktMovieRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktMovieRequest_1_IsAbstract()
        {
            typeof(ATraktMovieRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktMovieRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktMovieRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktMovieRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktMovieRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktMovieRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktMovieRequest_1_Implements_ITraktHasId_Interface()
        {
            typeof(ATraktMovieRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_ATraktMovieRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktMovieRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ATraktMovieRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktMovieRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Movies);
        }

        [Fact]
        public void Test_ATraktMovieRequest_1_Returns_Valid_UriPathParameters()
        {
            var requestMock = new TraktMovieRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_ATraktMovieRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktMovieRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktMovieRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktMovieRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
