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
    public class MovieRatingsRequest_Tests
    {
        [Fact]
        public void Test_MovieRatingsRequest_IsNotAbstract()
        {
            typeof(MovieRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_MovieRatingsRequest_IsSealed()
        {
            typeof(MovieRatingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_MovieRatingsRequest_Inherits_AMovieRequest_1()
        {
            typeof(MovieRatingsRequest).IsSubclassOf(typeof(AMovieRequest<ITraktRating>)).Should().BeTrue();
        }

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
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new MovieRatingsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new MovieRatingsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
