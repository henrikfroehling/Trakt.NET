namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Movies;
    using Xunit;

    [Category("Requests.Movies")]
    public class TraktMovieStatisticsRequest_Tests
    {
        [Fact]
        public void Test_TraktMovieStatisticsRequest_IsNotAbstract()
        {
            typeof(TraktMovieStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieStatisticsRequest_IsSealed()
        {
            typeof(TraktMovieStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieStatisticsRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMovieStatisticsRequest).IsSubclassOf(typeof(ATraktMovieRequest<TraktStatistics>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMovieStatisticsRequest();
            request.UriTemplate.Should().Be("movies/{id}/stats");
        }

        [Fact]
        public void Test_TraktMovieStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktMovieStatisticsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktMovieStatisticsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMovieStatisticsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMovieStatisticsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMovieStatisticsRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
