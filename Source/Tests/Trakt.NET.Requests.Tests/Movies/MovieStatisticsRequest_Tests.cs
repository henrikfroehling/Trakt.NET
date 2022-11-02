namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies")]
    public class MovieStatisticsRequest_Tests
    {
        [Fact]
        public void Test_MovieStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieStatisticsRequest();
            request.UriTemplate.Should().Be("movies/{id}/stats");
        }

        [Fact]
        public void Test_MovieStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new MovieStatisticsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_MovieStatisticsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieStatisticsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new MovieStatisticsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new MovieStatisticsRequest { Id = "invalid id" };
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
