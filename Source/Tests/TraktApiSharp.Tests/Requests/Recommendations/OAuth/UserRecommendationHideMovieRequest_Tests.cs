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
    public class UserRecommendationHideMovieRequest_Tests
    {
        [Fact]
        public void Test_UserRecommendationHideMovieRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserRecommendationHideMovieRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserRecommendationHideMovieRequest_Returns_Valid_RequestObjectType()
        {
            var request = new UserRecommendationHideMovieRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Movies);
        }

        [Fact]
        public void Test_UserRecommendationHideMovieRequest_Has_Valid_UriTemplate()
        {
            var request = new UserRecommendationHideMovieRequest();
            request.UriTemplate.Should().Be("recommendations/movies/{id}");
        }

        [Fact]
        public void Test_UserRecommendationHideMovieRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new UserRecommendationHideMovieRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserRecommendationHideMovieRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new UserRecommendationHideMovieRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new UserRecommendationHideMovieRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new UserRecommendationHideMovieRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
