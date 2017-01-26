namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Movie")]
    public class TraktMovieRatingsRequest_Tests
    {
        [Fact]
        public void Test_TraktMovieRatingsRequest_IsNotAbstract()
        {
            typeof(TraktMovieRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieRatingsRequest_IsSealed()
        {
            typeof(TraktMovieRatingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieRatingsRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMovieRatingsRequest).IsSubclassOf(typeof(ATraktMovieRequest<TraktRating>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMovieRatingsRequest();
            request.UriTemplate.Should().Be("movies/{id}/ratings");
        }

        [Fact]
        public void Test_TraktMovieRatingsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktMovieRatingsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktMovieRatingsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMovieRatingsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMovieRatingsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMovieRatingsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
