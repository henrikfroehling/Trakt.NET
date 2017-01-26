namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Movies")]
    public class TraktMoviePeopleRequest_Tests
    {
        [Fact]
        public void Test_TraktMoviePeopleRequest_IsNotAbstract()
        {
            typeof(TraktMoviePeopleRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMoviePeopleRequest_IsSealed()
        {
            typeof(TraktMoviePeopleRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviePeopleRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMoviePeopleRequest).IsSubclassOf(typeof(ATraktMovieRequest<TraktCastAndCrew>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviePeopleRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktMoviePeopleRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktMoviePeopleRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMoviePeopleRequest();
            request.UriTemplate.Should().Be("movies/{id}/people{?extended}");
        }

        [Fact]
        public void Test_TraktMoviePeopleRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktMoviePeopleRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktMoviePeopleRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktMoviePeopleRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMoviePeopleRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMoviePeopleRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMoviePeopleRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
