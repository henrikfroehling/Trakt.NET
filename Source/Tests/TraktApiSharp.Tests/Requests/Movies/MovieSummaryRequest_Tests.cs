namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies")]
    public class MovieSummaryRequest_Tests
    {
        [Fact]
        public void Test_MovieSummaryRequest_IsNotAbstract()
        {
            typeof(MovieSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_MovieSummaryRequest_IsSealed()
        {
            typeof(MovieSummaryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_MovieSummaryRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(MovieSummaryRequest).IsSubclassOf(typeof(AMovieRequest<ITraktMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_MovieSummaryRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(MovieSummaryRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_MovieSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieSummaryRequest();
            request.UriTemplate.Should().Be("movies/{id}{?extended}");
        }

        [Fact]
        public void Test_MovieSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new MovieSummaryRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new MovieSummaryRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_MovieSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieSummaryRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new MovieSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new MovieSummaryRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
