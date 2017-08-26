namespace TraktApiSharp.Tests.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Recommendations.OAuth;
    using Xunit;

    [Category("Requests.Recommendations.OAuth")]
    public class AUserRecommendationHideRequest_Tests
    {
        internal class UserRecommendationHideRequestMock : AUserRecommendationHideRequest
        {
            public override RequestObjectType RequestObjectType { get { throw new NotImplementedException(); } }
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AUserRecommendationHideRequest_IsAbstract()
        {
            typeof(AUserRecommendationHideRequest).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_AUserRecommendationHideRequest_Inherits_ATraktDeleteRequest()
        {
            typeof(AUserRecommendationHideRequest).IsSubclassOf(typeof(ADeleteRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_AUserRecommendationHideRequest_Implements_ITraktHasId_Interface()
        {
            typeof(AUserRecommendationHideRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_AUserRecommendationHideRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new UserRecommendationHideRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_AUserRecommendationHideRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var requestMock = new UserRecommendationHideRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_AUserRecommendationHideRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new UserRecommendationHideRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new UserRecommendationHideRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new UserRecommendationHideRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
