namespace TraktNet.Requests.Tests.Recommendations.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Recommendations.OAuth;
    using Xunit;

    [Category("Requests.Recommendations.OAuth")]
    public class UserRecommendationHideShowRequest_Tests
    {
        [Fact]
        public void Test_UserRecommendationHideShowRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserRecommendationHideShowRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserRecommendationHideShowRequest_Returns_Valid_RequestObjectType()
        {
            var request = new UserRecommendationHideShowRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Shows);
        }

        [Fact]
        public void Test_UserRecommendationHideShowRequest_Has_Valid_UriTemplate()
        {
            var request = new UserRecommendationHideShowRequest();
            request.UriTemplate.Should().Be("recommendations/shows/{id}");
        }

        [Fact]
        public void Test_UserRecommendationHideShowRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new UserRecommendationHideShowRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserRecommendationHideShowRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new UserRecommendationHideShowRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new UserRecommendationHideShowRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new UserRecommendationHideShowRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
