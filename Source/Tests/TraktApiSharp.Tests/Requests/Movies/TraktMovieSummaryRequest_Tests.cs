namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Movies")]
    public class TraktMovieSummaryRequest_Tests
    {
        [Fact]
        public void Test_TraktMovieSummaryRequest_IsNotAbstract()
        {
            typeof(TraktMovieSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieSummaryRequest_IsSealed()
        {
            typeof(TraktMovieSummaryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieSummaryRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMovieSummaryRequest).IsSubclassOf(typeof(ATraktMovieRequest<TraktMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieSummaryRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktMovieSummaryRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktMovieSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMovieSummaryRequest();
            request.UriTemplate.Should().Be("movies/{id}{?extended}");
        }

        [Fact]
        public void Test_TraktMovieSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktMovieSummaryRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktMovieSummaryRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktMovieSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMovieSummaryRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMovieSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMovieSummaryRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
