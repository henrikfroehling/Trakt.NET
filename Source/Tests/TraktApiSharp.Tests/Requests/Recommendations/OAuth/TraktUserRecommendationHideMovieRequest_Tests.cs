namespace TraktApiSharp.Tests.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Recommendations.OAuth;
    using Xunit;

    [Category("Requests.Recommendations.OAuth")]
    public class TraktUserRecommendationHideMovieRequest_Tests
    {
        [Fact]
        public void Test_TraktUserRecommendationHideMovieRequest_IsNotAbstract()
        {
            typeof(TraktUserRecommendationHideMovieRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserRecommendationHideMovieRequest_IsSealed()
        {
            typeof(TraktUserRecommendationHideMovieRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserRecommendationHideMovieRequest_Inherits_ATraktUserRecommendationHideRequest()
        {
            typeof(TraktUserRecommendationHideMovieRequest).IsSubclassOf(typeof(ATraktUserRecommendationHideRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserRecommendationHideMovieRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserRecommendationHideMovieRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserRecommendationHideMovieRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktUserRecommendationHideMovieRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Movies);
        }

        [Fact]
        public void Test_TraktUserRecommendationHideMovieRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserRecommendationHideMovieRequest();
            request.UriTemplate.Should().Be("recommendations/movies/{id}");
        }

        [Fact]
        public void Test_TraktUserRecommendationHideMovieRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new TraktUserRecommendationHideMovieRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktUserRecommendationHideMovieRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktUserRecommendationHideMovieRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserRecommendationHideMovieRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserRecommendationHideMovieRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
