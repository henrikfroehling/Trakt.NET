namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies")]
    public class MovieRatingsRequest_Tests
    {
        [Fact]
        public void Test_MovieRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieRatingsRequest();
            request.UriTemplate.Should().Be("movies/{id}/ratings");
        }

        [Fact]
        public void Test_MovieRatingsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new MovieRatingsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_MovieRatingsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieRatingsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new MovieRatingsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new MovieRatingsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
