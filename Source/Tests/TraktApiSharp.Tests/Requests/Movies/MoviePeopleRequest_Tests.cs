namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies")]
    public class MoviePeopleRequest_Tests
    {
        [Fact]
        public void Test_MoviePeopleRequest_IsNotAbstract()
        {
            typeof(MoviePeopleRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_MoviePeopleRequest_IsSealed()
        {
            typeof(MoviePeopleRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_MoviePeopleRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(MoviePeopleRequest).IsSubclassOf(typeof(AMovieRequest<ITraktCastAndCrew>)).Should().BeTrue();
        }

        [Fact]
        public void Test_MoviePeopleRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(MoviePeopleRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_MoviePeopleRequest_Has_Valid_UriTemplate()
        {
            var request = new MoviePeopleRequest();
            request.UriTemplate.Should().Be("movies/{id}/people{?extended}");
        }

        [Fact]
        public void Test_MoviePeopleRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new MoviePeopleRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new MoviePeopleRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_MoviePeopleRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MoviePeopleRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new MoviePeopleRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new MoviePeopleRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
