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
    public class TraktUserRecommendationHideShowRequest_Tests
    {
        [Fact]
        public void Test_TraktUserRecommendationHideShowRequest_IsNotAbstract()
        {
            typeof(TraktUserRecommendationHideShowRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserRecommendationHideShowRequest_IsSealed()
        {
            typeof(TraktUserRecommendationHideShowRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserRecommendationHideShowRequest_Inherits_ATraktUserRecommendationHideRequest()
        {
            typeof(TraktUserRecommendationHideShowRequest).IsSubclassOf(typeof(ATraktUserRecommendationHideRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserRecommendationHideShowRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserRecommendationHideShowRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserRecommendationHideShowRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktUserRecommendationHideShowRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Shows);
        }

        [Fact]
        public void Test_TraktUserRecommendationHideShowRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserRecommendationHideShowRequest();
            request.UriTemplate.Should().Be("recommendations/shows/{id}");
        }

        [Fact]
        public void Test_TraktUserRecommendationHideShowRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new TraktUserRecommendationHideShowRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktUserRecommendationHideShowRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktUserRecommendationHideShowRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserRecommendationHideShowRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserRecommendationHideShowRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
